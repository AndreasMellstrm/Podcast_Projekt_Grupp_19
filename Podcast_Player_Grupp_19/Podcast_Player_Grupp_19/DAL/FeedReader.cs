using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;

namespace Podcast_Player_Grupp_19.DAL {
    class FeedReader {

        public void ReadFeed(string url) {
            var reader = new XmlTextReader("url");
            var feed = new SyndicationFeed();



        }
          
    }
}

