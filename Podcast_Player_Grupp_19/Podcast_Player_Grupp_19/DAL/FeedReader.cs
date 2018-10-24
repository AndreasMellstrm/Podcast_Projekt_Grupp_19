using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;

namespace Podcast_Player_Grupp_19.DAL {
    class FeedReader {

        private XmlTextReader reader { get; set; }
        private SyndicationFeed feed { get; set; }

        public FeedReader(string feedPath) {
            reader = new XmlTextReader(feedPath);
            feed = new SyndicationFeed();
        }

        public void test() {
            
        }

    }
}
