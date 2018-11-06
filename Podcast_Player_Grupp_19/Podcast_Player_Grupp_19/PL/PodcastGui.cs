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

        private CategoryList<Category> CategoryList { get; set; }
        private PodcastList<Podcast> PodcastList { get; set; }
        private Podcast SelectedPodcast { get; set; }
        private Serializer<List<Category>> CategorySerializer {get; set;}
        //private Serializer<List<Podcast>> PodcastSerializer { get; set; }
        private string PodcastFile = "podcasts.json";
        private string CategoryFile = "categories.json";

        private DAL.FeedReader FeedReader { get; set; }


        public PodcastGUI() {
            InitializeComponent();
            CategoryList = new CategoryList<Category>();
            PodcastList = new PodcastList<Podcast>();
            CategorySerializer = new Serializer<List<Category>>(CategoryFile);
            //PodcastSerializer = new Serializer<List<Podcast>>(PodcastFile);
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

        private async void AddPodcast()
        {
            string userInputUrl = tbUrl.Text;
            string userInputName = tbPodName.Text;
            int userInputInterval = GetMilliseconds(cbInterval.SelectedItem.ToString());
            string errorMessage = "";
            if (Validation.ValidURL(userInputUrl, out errorMessage) && Validation.ValidUserInput(userInputName, out errorMessage))
            {
                if (Validation.CountSelections(lvCategory.SelectedItems.Count, out errorMessage))
                {
                    string userInputCategory = lvCategory.SelectedItems[0].Text;
                    var countSelections = lvCategory.SelectedItems.Count;
                    Podcast Podcast = new Podcast(userInputName, userInputUrl, userInputCategory, userInputInterval);
                    try
                    {
                        await Podcast.AsyncPodcast(Podcast.Url);
                        PodcastList.AddToList(Podcast);
                        UpdateLvPodcasts(PodcastList.List);
                    }
                    catch (WebException)
                    {
                        MessageBox.Show("Sidan hittades inte. Kontrollera URL:n och försök igen");
                        Podcast.UpdateTimer.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show(errorMessage);
                }
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
            tbUrl.Clear();
            tbPodName.Clear();
        }

        private void RemoveCategory<T>(ItemList<T> ItemList) {
            try {
                foreach (ListViewItem selectedIndex in lvCategory.SelectedItems) {
                    CategoryList.RemoveFromList(selectedIndex.Text);
                }
                UpdateLvCategory(ItemList);
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
            }
            catch (ArgumentOutOfRangeException) {
                MessageBox.Show("You must select the podcast that you want to remove");
            }
            UpdateLvPodcasts(List);
        }
        
        public void UpdateLvCategory<T>(ItemList<T> ItemList) {
            lvCategory.Items.Clear();
            foreach (Category Category in CategoryList.List) {
                lvCategory.Items.Add(Category.GetType().GetProperty("Name").GetValue(Category).ToString());
            }
            CategoryList.SaveList(CategoryFile);
        }
        
        public void UpdateLvPodcasts(List<Podcast> List)
        {
            lvEpisodes.Items.Clear();
            lvPodcasts.Items.Clear();
            foreach(Podcast item in List)
            {
                
                var listViewItem = new ListViewItem(new[]
                {
                    item.Name, item.Title, item.PodcastEpisodes.Count.ToString(), (item.Interval/60000).ToString(), item.Category
                });

                lvPodcasts.Items.Add(listViewItem);
            }
            PodcastList.SaveList(PodcastFile);


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

        public void SelectPodcast() {
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

        private async void ChangeUrl() {
            string url = tbUrl.Text;
            string errorMessage = "";
            if (Validation.ValidURL(url, out errorMessage)) {
                try {
                    await SelectedPodcast.ChangeUrl(tbUrl.Text);
                    UpdateLvPodcasts(PodcastList.List);
                    tbUrl.Clear();
                } catch (NullReferenceException) {
                    MessageBox.Show("To change a feeds URL, Please write the new URL into the URL textbox and select the feed of which you want to change.");
                }

            }
        }

        private void ChangeInterval(int Interval)
        {
            SelectedPodcast.SetInterval(Interval);
            UpdateLvPodcasts(PodcastList.List);
        }

        private int GetMilliseconds(string Interval)
        {
            switch (Interval)
            {
                case "1 minute":
                    return 60000;
                case "10 minutes":
                    return 600000;
                case "30 minutes":
                    return 1800000;
                default:
                    return 60000;
            }
        }

        private static string StripHtml(string input) {
            return Regex.Replace(input, "<.*?>", string.Empty);
        }


        private void Form1_Load(object sender, EventArgs e) {
            DeserializeLists();
            
        }

        private async void DeserializeLists() {
                CategoryList.LoadList(CategoryList, CategoryFile);
                await PodcastList.LoadList(PodcastFile);
                UpdateLvCategory(CategoryList);
                UpdateLvPodcasts(PodcastList.List);
        }

        private void tbUrl_TextChanged(object sender, EventArgs e) {

        }

        private void lblAddCategory_Click(object sender, EventArgs e) {

        }
        
        private void btnAddCategory_Click(object sender, EventArgs e) {
            string userInput = tbCategory.Text;
            var Category = new Category(userInput);
            CategoryList.AddToList(Category);
            UpdateLvCategory(CategoryList);
            tbCategory.Clear();
        }

        private void btnAddPodcast_Click(object sender, EventArgs e)
        {
            AddPodcast();

        }


        private void btnRemoveCategory_Click(object sender, EventArgs e) {
            RemoveCategory(CategoryList);

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


        private void btnChangeUrl_Click(object sender, EventArgs e) {
            ChangeUrl();
            
        }

        private void btnChangeInterval_Click(object sender, EventArgs e)
        {
            ChangeInterval(GetMilliseconds(cbInterval.SelectedItem.ToString()));
        }
    }
}

