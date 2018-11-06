using Podcast_Player_Grupp_19.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Podcast_Player_Grupp_19 {
    public partial class PodcastGUI : Form {

        private ItemList<Category> CategoryList { get; set; }
        private ItemList<Podcast> PodcastList { get; set; }
        private Podcast SelectedPodcast { get; set; }
        private Serializer<List<Category>> CategorySerializer {get; set;}
        private Serializer<List<Podcast>> PodcastSerializer { get; set; }
        private string PodcastFile = "podcasts.json";
        private string CategoryFile = "categories.json";

        private DAL.FeedReader FeedReader { get; set; }


        public PodcastGUI() {
            InitializeComponent();
            CategoryList = new ItemList<Category>();
            PodcastList = new ItemList<Podcast>();
            CategorySerializer = new Serializer<List<Category>>(CategoryFile);
            PodcastSerializer = new Serializer<List<Podcast>>(PodcastFile);
        }

        private List<Podcast> SortPodcastListByName() {
            return PodcastList.List.OrderBy((i) => i.Name).ToList();
        }
        
        private void SortByCategory() {
            var SelectedCategory = from Podcast in PodcastList.List
                                     where Podcast.Category == lvCategory.SelectedItems[0].SubItems[0].Text
                                     select Podcast;
            UpdateLvPodcasts(SelectedCategory.ToList());
            
        }


        private void RemoveCategory<T>(Serializer<List<T>> serializer, ItemList<T> ItemList) {
            try {
                foreach (ListViewItem selectedIndex in lvCategory.SelectedItems) {
                    CategoryList.RemoveFromList(selectedIndex.Text);
                }
                UpdateLvCategory(ItemList,serializer);
            }
            catch (ArgumentOutOfRangeException) {
                MessageBox.Show("You must select the category that you want to remove");
            }
        }

        private void RemovePodcast(List<Podcast> List) {
            try {
                foreach (ListViewItem selectedIndex in lvPodcasts.SelectedItems) {
                    PodcastList.RemoveFromList(selectedIndex.Text);
                }
                UpdateLvPodcasts(List);
            }
            catch (ArgumentOutOfRangeException) {
                MessageBox.Show("You must select the podcast that you want to remove");
            }
        }
        // här
        public void UpdateLvCategory<T>(ItemList<T> ItemList, Serializer<List<T>> serializer) {
            lvCategory.Items.Clear();
            foreach (Category Category in CategoryList.List) {
                lvCategory.Items.Add(Category.GetType().GetProperty("Name").GetValue(Category).ToString());
            }
            serializer.Serialize(ItemList.List);
        }
        
        public void UpdateLvPodcasts(List<Podcast> List)
        {
            lvPodcasts.Items.Clear();
            foreach(Podcast item in List)
            {
                var listViewItem = new ListViewItem(new[]
                {
                    item.Name, item.Title, item.PodcastEpisodes.Count.ToString(), "1", item.Category
                });

                lvPodcasts.Items.Add(listViewItem);
                PodcastList.SavePodcastList(PodcastList);
            }
        }

        private void UpdatePodcastEpisodes() {
            lvEpisodes.Items.Clear();
                foreach (PodcastEpisode item in SelectedPodcast.PodcastEpisodes) {
                    var listViewItem = new ListViewItem(new[]
                    {
                    item.Title
                });
                    lvEpisodes.Items.Add(listViewItem);

                }
        }

        private void SelectPodcast() {
            var PodcastSelections =
                from Podcast in PodcastList.List
                where Podcast.Name == lvPodcasts.SelectedItems[0].SubItems[0].Text
                select Podcast;
            var PodcastSelectionsList = PodcastSelections.ToList();
            SelectedPodcast = PodcastSelectionsList[0];
        }

        private void ShowEpisodeInfo() {
            tbEpisodeInfo.Clear();
            var podcastInfo =
                from PodcastEpisode in SelectedPodcast.PodcastEpisodes
                where PodcastEpisode.Title == lvEpisodes.SelectedItems[0].SubItems[0].Text
                select PodcastEpisode;
            var SelectedEpisode = podcastInfo.ToList();
            if(SelectedEpisode[0].Description == "") {
                tbEpisodeInfo.Text = "There is no available description for this episode.";
            }
            else { 
            tbEpisodeInfo.Text = StripHtml(SelectedEpisode[0].Description);
            }

        }
        private static string StripHtml(string input) {
            return Regex.Replace(input, "<.*?>", string.Empty);
        }


            private void Form1_Load(object sender, EventArgs e) {
            DeserializeLists();
            
        }

        private void DeserializeList<T>(ItemList<T> itemList,Serializer<List<T>> Serializer, string JsonFile) {
            if (File.Exists(JsonFile)) {
                itemList.List = Serializer.DeSerialize();
            } 
        }

        private async void DeserializeLists() {
            DeserializeList(CategoryList, CategorySerializer, CategoryFile);
            await PodcastList.LoadPodcastList(PodcastList);
            UpdateLvCategory(CategoryList, CategorySerializer);
            UpdateLvPodcasts(PodcastList.List);
        }

        private void btnPlay_Click(object sender, EventArgs e) {

            string path = @"C:\Users\User\Desktop\sample.mp3";
            BLL.Player.Play(path);

        }

        private void tbUrl_TextChanged(object sender, EventArgs e) {

        }

        private void lblAddCategory_Click(object sender, EventArgs e) {

        }
        
        private void btnAddCategory_Click(object sender, EventArgs e) {
            //Runs the following method which is created down below.
            string userInput = tbCategory.Text;
            var Category = new Category(userInput);
            CategoryList.AddToList(Category, userInput);
            UpdateLvCategory(CategoryList,CategorySerializer);
            tbCategory.Clear();
            
            

        }

        private async void btnAddPodcast_Click(object sender, EventArgs e) {
            string userInputUrl = tbUrl.Text;
            string userInputName = tbPodName.Text;
            string userInputCategory = lvCategory.SelectedItems[0].Text;
            var countSelections = lvCategory.SelectedItems.Count;
            string errorMessage = "";

            if (Validation.ValidURL(userInputUrl, out errorMessage) && Validation.ValidUserInput(userInputName, out errorMessage))
            {

                if (countSelections == 1)
                {
                    Podcast Podcast = new Podcast(userInputName, userInputUrl, userInputCategory);
                    try { 
                        await Podcast.AsyncPodcast();
                        PodcastList.AddToList(Podcast);
                        UpdateLvPodcasts(PodcastList.List);
                        tbUrl.Clear();
                    }
                    catch(WebException ex)
                    {
                        MessageBox.Show("Sidan hittades inte. Kontrollera URL:n och försök igen");
                        Podcast.UpdateTimer.Dispose();
                        Console.Write(ex);
                    }
                }
                else if (countSelections > 1)
                {
                    MessageBox.Show("Please select one category only");
                    lvCategory.SelectedItems.Clear();

                }
                else if (countSelections == 0)
                {
                    MessageBox.Show("Please select a category");
                }
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }


        private void btnRemoveCategory_Click(object sender, EventArgs e) {
            RemoveCategory(CategorySerializer, CategoryList);

        }

        private void lvPodcasts_ItemActivate(object sender, EventArgs e)
        {
            SelectPodcast();
            UpdatePodcastEpisodes();
        }

        private void lvEpisodes_ItemActivate(object sender, EventArgs e) {
            ShowEpisodeInfo();
        }

        private void btnRemovePodcast_Click(object sender, EventArgs e) {
            RemovePodcast(PodcastList.List);
        }

        private void lvPodcasts_ColumnClick(object sender, ColumnClickEventArgs e) {
            PodcastList.List = SortPodcastListByName();
            UpdateLvPodcasts(PodcastList.List);
        }

        private void lvCategory_ItemActivate(object sender, EventArgs e) {
            SortByCategory();
        }
    }
}

