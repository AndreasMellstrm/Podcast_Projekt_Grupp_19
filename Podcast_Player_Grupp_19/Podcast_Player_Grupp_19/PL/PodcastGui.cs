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
        public PodcastGUI() {
            InitializeComponent();
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
            AddCategory();
            
        }
        //Get the category name from the user input,
        private void AddCategory() {
            string cat = tbCategory.Text;
            BLL.Category category = new BLL.Category(cat);
        }

        private void tbCategory_TextChanged(object sender, EventArgs e) {

        }

        private void btnAddPodcast_Click(object sender, EventArgs e) {

        }
    }
}
