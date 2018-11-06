using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Podcast_Player_Grupp_19.BLL
{

    public class ItemList<T> : IList<T>
    {
        public List<T> List { get; set; }

        public ItemList()
        {
            List = new List<T>();
        }
        public void AddToList(T item, string userInput)
        {
            if (!List.Any((i) => i.GetType().GetProperty("Name").GetValue(i).ToString() == userInput)) {
                List.Add(item);
            }
            else {
                MessageBox.Show("Listan innehåller redan " + userInput + ".", "Error Message");
            }
            
        }

        public void AddToList(T item) {
            if (!List.Any((i) => i.GetType().GetProperty("Name").GetValue(i).ToString() == item.GetType().GetProperty("Name").GetValue(item).ToString())) {
                List.Add(item);
            }
            else {
                MessageBox.Show("Listan innehåller redan den podcasten.", "Error Message");
            }
        }

        public void RemoveFromList( string userInput)
        {
            if (List.Any((i) => i.GetType().GetProperty("Name").GetValue(i).ToString() == userInput)) {
                List.RemoveAll(item => item.GetType().GetProperty("Name").GetValue(item).ToString() == userInput);
            }
        }

        public List<string[]> PodcastListToArray(ItemList<Podcast> itemList) {
            var PodcastListArray = new List<string[]>();
            foreach(var Podcast in itemList.List) {
                string[] stringArray = new string[] {
                    Podcast.Name, Podcast.FeedName, Podcast.Url, Podcast.Category, Podcast.Interval.ToString()
                };
                PodcastListArray.Add(stringArray);
            }
            return PodcastListArray;
        }
    }
}
