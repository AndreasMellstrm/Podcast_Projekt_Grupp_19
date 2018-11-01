using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace Podcast_Player_Grupp_19.BLL {
    class Podcast {

        public string Name { get; set; }
        public string Category { get; set; }
        private string Url { get; set; }
        private Timer Timer { get; set; }
        public List<PodcastEpisode> PodcastEpisodes { get; set; }
        public int UpdateFrequency { get; set; }
        public DAL.FeedReader FeedReader{ get; set; }
        

        public Podcast(string url, string Category = "N/A") {

            this.Url = url;
            this.Category = Category;
            PodcastEpisodes = new List<PodcastEpisode>();
        }

        public async Task AsyncPodcast(string url)
        {
            FeedReader = new DAL.FeedReader();
            await FeedReader.GetRssData(url);
            Name = FeedReader.Feed.Title.Text;
            GetPodcastEpisodes();
        }

        public void GetPodcastEpisodes() {
            List<PodcastEpisode> List = new List<PodcastEpisode>();
            foreach(SyndicationItem item in FeedReader.Feed.Items) {
                var PodcastEpisode = new PodcastEpisode(item);
                PodcastEpisodes.Add(PodcastEpisode);
            }
            
        }
    }
}
