using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;

namespace Podcast_Player_Grupp_19.DAL {
    class FeedReader {

        public SyndicationFeed feed { get; set; }
        private XmlTextReader reader { get; set; }

        public FeedReader(string url) {
            reader = new XmlTextReader(url);
            feed = SyndicationFeed.Load(reader);
        }
    }
}

