using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Podcast_Player_Grupp_19.BLL {
    public class Podcast {

        public string Name { get; set; }
        public string FeedName { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

        public int Interval { get; set; }
        public System.Timers.Timer UpdateTimer { get; set; }
        public List<PodcastEpisode> PodcastEpisodes { get; set; }
        public int UpdateFrequency { get; set; }
        public DAL.FeedReader FeedReader { get; set; }


        public Podcast(string Name, string Url, string Category, int Interval = 20000) {
            PodcastEpisodes = new List<PodcastEpisode>();
            InitTimer(Interval);
            List<PodcastEpisode> List = new List<PodcastEpisode>();
            this.Url = Url;
            this.Name = Name;
            this.Category = Category;
            this.Interval = Interval;

        }

        // Initializes a timer for this podcast object.
        private void InitTimer(int interval = 300000) {
            UpdateTimer = new System.Timers.Timer(interval);
            UpdateTimer.Elapsed += OnTimeOutEvt;
            UpdateTimer.AutoReset = true;
            UpdateTimer.Enabled = true;
        }
        // When updated timer times out, this method is called asynchronously
        private async void OnTimeOutEvt(Object sender, ElapsedEventArgs e) {
            await AsyncPodcast(Url);
        }

        // Dispose current UpdateTimer and init new one with userInput interval
        public void SetInterval(int userInput) {
            UpdateTimer.Dispose();
            Interval = userInput;
            InitTimer(Interval);
        }

        // Asynchronous fetch of the Rss data through a FeedReader object which holds the SyndicationFeed 
        public async Task AsyncPodcast(string Url) {
            FeedReader = new DAL.FeedReader();
            await FeedReader.GetRssData(Url);
            Title = FeedReader.Feed.Title.Text;
            GetPodcastEpisodes();
        }

        // Asynchronously changes the Url property of a Podcast Object
        public async Task ChangeUrl(string Url) {
            try {
                await AsyncPodcast(Url);
                this.Url = Url;
            }
            catch (Exception) {
                MessageBox.Show("Please enter a valid URL");
            }
        }

        // Creates a PodcastEpisode object for each SyndicationItem in the SyndicationFeed
        public void GetPodcastEpisodes() {
            PodcastEpisodes.Clear();
            foreach (SyndicationItem item in FeedReader.Feed.Items) {
                var PodcastEpisode = new PodcastEpisode();
                PodcastEpisode.GetPodcastEpisodeInfo(item);
                PodcastEpisodes.Add(PodcastEpisode);
            }

        }
    }

    public class PodcastList<T> : ItemList<Podcast> {

        // Method to add a Podcast object to a PodcastList
        public override void AddToList(Podcast item) {
            if (!List.Any((i) => i.GetType().GetProperty("Title").GetValue(i).ToString() == item.GetType().GetProperty("Title").GetValue(item).ToString())) {
                List.Add(item);
            }
            else {
                MessageBox.Show("Listan innehåller redan den podcasten.", "Error Message");
            }
        }

        /* Deserializes the json file specified in the inparameter Path into a List of string[] 
        and then creates a Podcast object for each string[] in the List.*/
        public async Task LoadList(string Path) {
            if (File.Exists(Path)) {
                var serializer = new Serializer<List<string[]>>(Path);
                var PodcastStringArray = serializer.DeSerialize();
                foreach (string[] stringArray in PodcastStringArray) {
                    Podcast Podcast = new Podcast(stringArray[0], stringArray[1], stringArray[2], int.Parse(stringArray[3]));
                    await Podcast.AsyncPodcast(Podcast.Url);
                    this.AddToList(Podcast);
                }


            }
        }
        /* Creates a List of string[], adds a string[] to it for each Podcast in a PodcastList and
        then serializes the List of string[] into a json file.*/
        public override void SaveList(string Path) {
            var PodcastListArray = new List<string[]>();
            foreach (var Podcast in this.List) {
                string[] stringArray = new string[] {
                    Podcast.Name, Podcast.Url, Podcast.Category, Podcast.Interval.ToString()
                };
                PodcastListArray.Add(stringArray);

            }
            var serializer = new Serializer<List<string[]>>(Path);
            serializer.Serialize(PodcastListArray);
        }
    }
}
