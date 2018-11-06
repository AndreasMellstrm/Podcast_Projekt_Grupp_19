using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Net;

namespace Podcast_Player_Grupp_19.DAL {
    public class FeedReader {

        public SyndicationFeed Feed { get; set; }

        public FeedReader() {
            Feed = new SyndicationFeed();
        }

        // Sets the property Feed to the result of the method GetFeed() as soon as it finishes.
        public async Task GetRssData(string url) {
            var feed = await GetFeed(url);
            Feed = feed;
        }

        //Asynchronously fetches the SyndicationFeed with the inparamter url
        public async Task<SyndicationFeed> GetFeed(string url) {
            XmlReader reader = XmlReader.Create(url);
            var task = Task.Factory.StartNew(() => {
                try {
                    return SyndicationFeed.Load(reader);
                }
                catch (Exception) {
                    return null;
                }
            });
            return await task;
        }
    }
}

