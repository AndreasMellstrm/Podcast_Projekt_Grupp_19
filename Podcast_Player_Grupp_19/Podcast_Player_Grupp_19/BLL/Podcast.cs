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
        

        public Podcast() {
            
            this.Category = Category;
        }

        public async Task AsyncPodcast(string url)
        {
            FeedReader = new DAL.FeedReader();
            await FeedReader.GetRssData(url);
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
