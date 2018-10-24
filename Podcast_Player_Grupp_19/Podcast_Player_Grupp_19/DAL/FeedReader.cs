using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;

namespace Podcast_Player_Grupp_19.DAL {
    class FeedReader {

        public SyndicationFeed Feed { get; set; }
        private XmlTextReader Reader { get; set; }

        public FeedReader(string url) {
            Reader = new XmlTextReader(url);
            Feed = SyndicationFeed.Load(Reader);
        }
    }
}

