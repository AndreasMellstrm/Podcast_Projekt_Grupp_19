using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace Podcast_Player_Grupp_19.BLL {
    class PodcastEpisode {

        public string Title { get; set; }
        public decimal EpisodeLength { get; set; }
        public string Description { get; set; }

        public PodcastEpisode(SyndicationItem item) {
            Title = "Hej"; //item.Title.Text;
            Description = "Katterna"; //item.Summary.Text;
        }
    }
}
