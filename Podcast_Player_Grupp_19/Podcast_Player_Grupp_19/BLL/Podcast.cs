using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podcast_Player_Grupp_19.BLL {
    class Podcast {

        public string Name { get; set; }
        public Category Category { get; set; }
        public int NumberOfEpisodes { get; set; }
        public int UpdateFrequency { get; set; }

        public Podcast(string Url) {
            var feed = new DAL.FeedReader(Url);
            this.Name = feed.feed.Title.ToString();
            this.Category = Category;
            this.NumberOfEpisodes = feed.feed.Items.Count();
            this.UpdateFrequency = UpdateFrequency;

        }
    }
}
