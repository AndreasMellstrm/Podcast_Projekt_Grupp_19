using Podcast_Player_Grupp_19.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Podcast_Player_Grupp_19 {
    public partial class PodcastGUI : Form {

        public ItemList<Category> CategoryList = new ItemList<Category>();

        public PodcastGUI() {
            InitializeComponent();
        }



        private void RemoveListItems<T>(ListView listView, ItemList<T> list) {
            try {
                foreach (ListViewItem selectedIndex in listView.SelectedItems) {
                    list.RemoveFromList(listView.SelectedItems[selectedIndex.Index].Text);
                }
                list.UpdateList(listView);
            }
            catch (ArgumentOutOfRangeException) {
                MessageBox.Show("You must select the  object that you want to remove");
            }
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void lvCategory_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void btnPlay_Click(object sender, EventArgs e) {

            string path = @"C:\Users\User\Desktop\sample.mp3";
            BLL.Player.Play(path);

        }

        private void lvPodcasts_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void lvEpisodes_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void tbUrl_TextChanged(object sender, EventArgs e) {

        }

        private void lblAddCategory_Click(object sender, EventArgs e) {

        }
        //Press this button to send the chosen category name from the user to create a new object in the Category() class.
        private void btnAddCategory_Click(object sender, EventArgs e) {
            //Runs the following method which is created down below.
            string userInput = tbCategory.Text;
            var Category = new Category(userInput);
            CategoryList.AddToList(Category, userInput);
            CategoryList.UpdateList(lvCategory);
            tbCategory.Clear();

        }

        private void btnAddPodcast_Click(object sender, EventArgs e) {
        }


        private void btnRemoveCategory_Click(object sender, EventArgs e) {
            RemoveListItems(lvCategory, CategoryList);

        }
    }
}

