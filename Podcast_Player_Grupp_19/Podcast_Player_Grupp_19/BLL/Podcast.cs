using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private void InitTimer(int interval = 300000) {
            UpdateTimer = new System.Timers.Timer(interval);
            UpdateTimer.Elapsed += OnTimeOutEvt;
            UpdateTimer.AutoReset = true;
            UpdateTimer.Enabled = true;
        }
        private async void OnTimeOutEvt(Object sender, ElapsedEventArgs e) {
            await AsyncPodcast();
            System.Diagnostics.Debug.WriteLine("Hej");
        }
        public void SetInterval(int userInput) {
            UpdateTimer.Dispose();
            Interval = userInput;
            InitTimer(Interval);
        }

        public async Task AsyncPodcast() {
            FeedReader = new DAL.FeedReader();
            await FeedReader.GetRssData(Url);
            Title = FeedReader.Feed.Title.Text;
            GetPodcastEpisodes();
        }

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

        public override void AddToList(Podcast item) {
            if (!List.Any((i) => i.GetType().GetProperty("Title").GetValue(i).ToString() == item.GetType().GetProperty("Title").GetValue(item).ToString())) {
                List.Add(item);
            }
            else {
                MessageBox.Show("Listan innehåller redan den podcasten.", "Error Message");
            }
        }

        public async Task LoadList(string Path) {
            if (File.Exists(Path)) {
                var serializer = new Serializer<List<string[]>>(Path);
                var PodcastStringArray = serializer.DeSerialize();
                foreach (string[] stringArray in PodcastStringArray) {
                    Podcast Podcast = new Podcast(stringArray[0], stringArray[1], stringArray[2], int.Parse(stringArray[3]));
                    await Podcast.AsyncPodcast();
                    this.AddToList(Podcast);
                }

            }
        }
        public void SaveList(string Path) {
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
