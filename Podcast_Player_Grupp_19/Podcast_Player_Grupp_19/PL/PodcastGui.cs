using Podcast_Player_Grupp_19.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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

        private void RemoveListItems<T>(ListView listView, ItemList<T> list, Serializer<List<T>> serializer) {
            try {
                foreach (ListViewItem selectedIndex in listView.SelectedItems) {
                    list.RemoveFromList(selectedIndex.Text);
                }
                UpdateListView(listView,list,serializer);
            }
            catch (ArgumentOutOfRangeException) {
                MessageBox.Show("You must select the  object that you want to remove");
            }
        }
        // här
        public void UpdateListView<T>(ListView listView, ItemList<T> ItemList, Serializer<List<T>> serializer) {
            listView.Items.Clear();
            foreach (T item in ItemList.List) {
                listView.Items.Add(item.GetType().GetProperty("Name").GetValue(item).ToString());
            }
            serializer.Serialize(ItemList.List);
        }
        
        public void UpdateListView2<T>(ListView listView, ItemList<T> ItemList, Serializer<List<T>> serializer)
        {
            listView.Items.Clear();
            foreach(Podcast item in PodcastList.List)
            {
                var listViewItem = new ListViewItem(new[]
                {
                    item.PodcastEpisodes.Count.ToString(), item.Name, "1", item.Category
                });

                listView.Items.Add(listViewItem);
            }
            serializer.Serialize(ItemList.List);
        }

        private void UpdatePodcastEpisodes() {
            lvEpisodes.Items.Clear();
                foreach (PodcastEpisode item in SelectedPodcast.PodcastEpisodes) {
                    var listViewItem = new ListViewItem(new[]
                    {
                    item.Title, "1"
                });
                    lvEpisodes.Items.Add(listViewItem);
                }
        }

        private void SelectPodcast() {
            var PodcastSelections =
                from Podcast in PodcastList.List
                where Podcast.Name == lvPodcasts.SelectedItems[0].SubItems[1].Text
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
            tbEpisodeInfo.Text = StripHtml(SelectedEpisode[0].Description);
            

        }
        private static string StripHtml(string input) {
            return Regex.Replace(input, "<.*?>", string.Empty);
        }


            private void Form1_Load(object sender, EventArgs e) {
            DeserializeList(CategoryList,CategorySerializer,CategoryFile);
            
            UpdateListView(lvCategory, CategoryList, CategorySerializer);
            
        }

        private void DeserializeList<T>(ItemList<T> itemList,Serializer<List<T>> Serializer, string JsonFile) {
            if (File.Exists(JsonFile)) {
                itemList.List = Serializer.DeSerialize();
                
                
            } 
        }
            
        private void lvCategory_SelectedIndexChanged(object sender, EventArgs e) {

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
            UpdateListView(lvCategory,CategoryList,CategorySerializer);
            tbCategory.Clear();
            
            

        }

        private async void btnAddPodcast_Click(object sender, EventArgs e) {
            string userInput = tbUrl.Text;
            var countSelections = lvCategory.SelectedItems.Count;

            if(countSelections == 1) {
                Podcast Podcast = new Podcast(tbUrl.Text, lvCategory.SelectedItems[0].Text);
                await Podcast.AsyncPodcast(userInput);
                PodcastList.AddToList(Podcast);
                UpdateListView2(lvPodcasts, PodcastList, PodcastSerializer);
                tbUrl.Clear();
            } else if(countSelections > 1) {
                MessageBox.Show("Please select one category only");
                lvCategory.SelectedItems.Clear();

            }
            else if(countSelections == 0){
                MessageBox.Show("Please select a category");
            }
        }


        private void btnRemoveCategory_Click(object sender, EventArgs e) {
            RemoveListItems(lvCategory, CategoryList,CategorySerializer);

        }

        private void lvPodcasts_ItemActivate(object sender, EventArgs e)
        {
            SelectPodcast();
            UpdatePodcastEpisodes();
        }

        private void lvEpisodes_ItemActivate(object sender, EventArgs e)
        {
            ShowEpisodeInfo();
        }
    }
}

