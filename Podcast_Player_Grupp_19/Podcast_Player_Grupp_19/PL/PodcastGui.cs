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
        private DAL.FeedReader FeedReader { get; set; }


        public PodcastGUI() {
            InitializeComponent();
            CategoryList = new CategoryList<Category>();
            PodcastList = new PodcastList<Podcast>();
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
        // Adds a new podcast asynchronously.
        private async void AddPodcast() {
            string userInputUrl = tbUrl.Text;
            string userInputName = tbPodName.Text;
            int userInputInterval = GetMilliseconds(cbInterval.SelectedItem.ToString());
            string errorMessage = "";

            if (Validation.ValidURL(userInputUrl, out errorMessage) && Validation.ValidUserInput(userInputName, out errorMessage)) {
                if (Validation.CountSelections(lvCategory.SelectedItems.Count, out errorMessage)) {
                    string userInputCategory = lvCategory.SelectedItems[0].Text;
                    var countSelections = lvCategory.SelectedItems.Count;
                    Podcast Podcast = new Podcast(userInputName, userInputUrl, userInputCategory, userInputInterval);
                    try {
                        await Podcast.AsyncPodcast(Podcast.Url);
                        PodcastList.AddToList(Podcast);
                        UpdateLvPodcasts(PodcastList.List);
                    }
                    catch (Exception) {
                        MessageBox.Show("Sidan hittades inte. Kontrollera URL:n och försök igen");
                        Podcast.UpdateTimer.Dispose();
                    }
                }
                else {
                    MessageBox.Show(errorMessage);
                }
            }
            else {
                MessageBox.Show(errorMessage);
            }
            tbUrl.Clear();
            tbPodName.Clear();
        }
        //Removes the selected category/categories.
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

        //Removes the selected podcast(s).
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
        // Updates the Category listview when called
        public void UpdateLvCategory<T>(ItemList<T> ItemList) {
            lvCategory.Items.Clear();
            foreach (Category Category in CategoryList.List) {
                lvCategory.Items.Add(Category.GetType().GetProperty("Name").GetValue(Category).ToString());
            }
            CategoryList.SaveList("categories.json");
        }

        // Updates the Podcast listview when called
        public void UpdateLvPodcasts(List<Podcast> List) {
            lvEpisodes.Items.Clear();
            lvPodcasts.Items.Clear();
            foreach (Podcast item in List) {

                var listViewItem = new ListViewItem(new[]
                {
                    item.Name, item.Title, item.PodcastEpisodes.Count.ToString(), (item.Interval/60000).ToString(), item.Category
                });

                lvPodcasts.Items.Add(listViewItem);
            }
            PodcastList.SaveList("podcasts.json");


        }
        // Updates the podcast episodes depending on the selected podcast.
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

        // method for selecting the podcast to use.
        public void SelectPodcast() {
            var PodcastSelections =
                from Podcast in PodcastList.List
                where Podcast.Name == lvPodcasts.SelectedItems[0].SubItems[0].Text
                select Podcast;
            var PodcastSelectionsList = PodcastSelections.ToList();
            SelectedPodcast = PodcastSelectionsList[0];
        }

        //Display the selected episode's description in the textbox.
        private void ShowEpisodeInfo() {
            tbEpisodeInfo.Clear();
            var podcastInfo =
                from PodcastEpisode in SelectedPodcast.PodcastEpisodes
                where PodcastEpisode.Title == lvEpisodes.SelectedItems[0].SubItems[0].Text
                select PodcastEpisode;
            var SelectedEpisode = podcastInfo.ToList();
            if (SelectedEpisode[0].Description == "") {
                tbEpisodeInfo.Text = "There is no available description for this episode.";
            }
            else {
                tbEpisodeInfo.Text = StripHtml(SelectedEpisode[0].Description);
            }

        }

        //Change the URL of the selected podcast
        private async void ChangeUrl() {
            string url = tbUrl.Text;
            string errorMessage = "";
            if (Validation.ValidURL(url, out errorMessage)) {
                try {
                    await SelectedPodcast.ChangeUrl(tbUrl.Text);
                    UpdateLvPodcasts(PodcastList.List);
                    tbUrl.Clear();
                }
                catch (NullReferenceException) {
                    MessageBox.Show("Please select a podcast");
                }
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private void ChangeInterval(int Interval) {
            try
            {
                SelectedPodcast.SetInterval(Interval);
                UpdateLvPodcasts(PodcastList.List);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please select a podcast");
            }
        }

        //Change name of the currently selected category in the listview.
        private void RenameCategory()
        {
            string errorMessage = "";
            if(Validation.CountSelections(lvCategory.SelectedItems.Count, out errorMessage))
            {
                if (Validation.ValidUserInput(tbCategory.Text, out errorMessage))
                {
                        var CategorySelections = from Category in CategoryList.List
                                                 where Category.Name == lvCategory.SelectedItems[0].Text
                                                 select Category;
                        var SelectedCategory = CategorySelections.ToList()[0];
                        SelectedCategory.Name = tbCategory.Text;
                    UpdateLvCategory(CategoryList);
                        
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
        }

        //Changes the category of the selected podcast in the listview.
        private void SetPodcastCategory()
        {
            string errorMessage = "";
            try
            {
                if (Validation.CountSelections(lvCategory.SelectedItems.Count, out errorMessage))
                {
                    SelectedPodcast.Category = lvCategory.SelectedItems[0].Text;
                    UpdateLvPodcasts(PodcastList.List);
                }

                else
                {
                    MessageBox.Show(errorMessage);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please select a podcast");
            }
        }

        //Get the milliseconds that corresponds to the input string.
        private int GetMilliseconds(string Interval) {
            switch (Interval) {
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

        //Adds a new category object and displays it in the listview.
        private void AddCategory() {
            string userInput = tbCategory.Text;
            if (Validation.ValidUserInput(userInput, out string errorMessage)) {
                var Category = new Category(userInput);
                CategoryList.AddToList(Category);
                UpdateLvCategory(CategoryList);
                tbCategory.Clear();
            }
            else {
                MessageBox.Show(errorMessage);
            }
        }

        //Removes all HTML code from the Episode description text.
        private static string StripHtml(string input) {
            return Regex.Replace(input, "<.*?>", string.Empty);
        }


        private void Form1_Load(object sender, EventArgs e) {
            DeserializeLists();
            cbInterval.SelectedIndex = 0; //Set the default value to the one at index 0.

        }

        //Deserializes the two .json files and updates the corresponding lists.
        private async void DeserializeLists() {
            CategoryList.LoadList(CategoryList, "categories.json");
            await PodcastList.LoadList("podcasts.json");
            UpdateLvCategory(CategoryList);
            UpdateLvPodcasts(PodcastList.List);
        }

        private void btnAddCategory_Click(object sender, EventArgs e) {
            AddCategory();
        }

        private void btnAddPodcast_Click(object sender, EventArgs e) {
            AddPodcast();

        }


        private void btnRemoveCategory_Click(object sender, EventArgs e) {
            RemoveCategory(CategoryList);

        }

        private void lvPodcasts_ItemActivate(object sender, EventArgs e) {
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

        private void btnChangeInterval_Click(object sender, EventArgs e) {
            ChangeInterval(GetMilliseconds(cbInterval.SelectedItem.ToString()));
        }

        private void btnChangeCategory_Click(object sender, EventArgs e)
        {
            SetPodcastCategory();
        }

        private void btnRenameCategory_Click(object sender, EventArgs e)
        {
            RenameCategory();
        }
    }
}

