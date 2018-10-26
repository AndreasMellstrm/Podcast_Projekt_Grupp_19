using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podcast_Player_Grupp_19.BLL {
    class Podcast {

        public string Title { get; set; }
        public Category Category { get; set; }
        public int NumberOfEpisodes { get; set; }
        public int UpdateFrequency { get; set; }
        public DAL.FeedReader FeedReader{ get; set; }
        

        public Podcast(string Url) {
            FeedReader= new DAL.FeedReader(Url);
            this.Title = FeedReader.Feed.Title.ToString();
            this.Category = Category;
            this.NumberOfEpisodes = FeedReader.Feed.Items.Count();
            this.UpdateFrequency = UpdateFrequency;
            
        }
    }
}
