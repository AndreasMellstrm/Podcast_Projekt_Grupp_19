using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Podcast_Player_Grupp_19.BLL {
    public class Podcast {

        public string Name { get; set; }
        public string FeedName { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

        public int Interval { get; set; }
        public Timer UpdateTimer { get; set; }
        public List<PodcastEpisode> PodcastEpisodes { get; set; }
        public int UpdateFrequency { get; set; }
        public DAL.FeedReader FeedReader{ get; set; }
        

        public Podcast() {
            PodcastEpisodes = new List<PodcastEpisode>();
            Interval = 20000;
            InitTimer(Interval);
            List<PodcastEpisode> List = new List<PodcastEpisode>();
        }

        private void InitTimer(int interval = 300000)
        {
            UpdateTimer = new Timer(interval);
            UpdateTimer.Elapsed += OnTimeOutEvt;
            UpdateTimer.AutoReset = true;
            UpdateTimer.Enabled = true;
        }
        private async void OnTimeOutEvt(Object sender, ElapsedEventArgs e)
        {
            await AsyncPodcast(Title, Url, FeedName, Category);
            System.Diagnostics.Debug.WriteLine("Hej");
        }

        public void SetInterval(int userInput)
        {
            UpdateTimer.Dispose();
            Interval = userInput;
            InitTimer(Interval);
        }

        public async Task AsyncPodcast(string title, string url,string FeedName, string Category)
        {
            FeedReader = new DAL.FeedReader();
            await FeedReader.GetRssData(url);
            Name = FeedName;
            Title = FeedReader.Feed.Title.Text; 
            Url = url;
            this.Category = Category;
            GetPodcastEpisodes();
        }

        public void GetPodcastEpisodes() {
            foreach(SyndicationItem item in FeedReader.Feed.Items) {
                if (!PodcastEpisodes.Any((episode) => episode.Title == item.Title.Text)){
                    var PodcastEpisode = new PodcastEpisode();
                    PodcastEpisode.GetPodcastEpisodeInfo(item);
                    PodcastEpisodes.Add(PodcastEpisode);
                }
            }
            
        }
    }
}
