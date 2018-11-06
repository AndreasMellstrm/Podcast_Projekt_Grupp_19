using System;
using System.Collections.Generic;
using System.IO;
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
        public virtual void AddToList(T item)
        {
            if (!List.Any((i) => i.GetType().GetProperty("Name").GetValue(i).ToString() == item.GetType().GetProperty("Name").GetValue(item).ToString())) {
                List.Add(item);
            }
            else {
                MessageBox.Show("Listan innehåller redan det objektet", "Error Message");
            }
            
        }

        public virtual void SaveList(string Path) {
            Serializer<List<T>> serializer = new Serializer<List<T>>(Path);
            serializer.Serialize(this.List);
        }

        public void RemoveFromList(string userInput)
        {
            if (List.Any((i) => i.GetType().GetProperty("Name").GetValue(i).ToString() == userInput)) {
                List.RemoveAll(item => item.GetType().GetProperty("Name").GetValue(item).ToString() == userInput);
            }
        }

        public void LoadList(ItemList<T> itemList, string Path) {
            if (File.Exists(Path)) {
                var serializer = new Serializer<List<T>>(Path);
                var DeserializedList = serializer.DeSerialize();
                foreach (T item in DeserializedList) {
                    itemList.AddToList(item);
                }

            }


        }
           

        }
    }

