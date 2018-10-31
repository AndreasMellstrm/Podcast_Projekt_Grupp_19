using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace Podcast_Player_Grupp_19.BLL {
    class Podcast {

        public string Name { get; set; }
        public Category Category { get; set; }
        public ItemList<PodcastEpisode> PodcastEpisodes { get; set; }
        public int UpdateFrequency { get; set; }
        public DAL.FeedReader FeedReader{ get; set; }
        

        public Podcast(string Url) {
            
            this.Category = Category;
        }

        public async Task asyncPodcast(string Url)
        {
            FeedReader = new DAL.FeedReader();
            await FeedReader.GetRssData(Url);
            Name = FeedReader.Feed.Title.ToString();
        }

        public void GetPodcastEpisodes() {
            foreach(SyndicationItem item in FeedReader.Feed.Items) {
                var PodcastEpisode = new PodcastEpisode(item);
                PodcastEpisodes.AddToList(PodcastEpisode);
            }
        }
    }
}
