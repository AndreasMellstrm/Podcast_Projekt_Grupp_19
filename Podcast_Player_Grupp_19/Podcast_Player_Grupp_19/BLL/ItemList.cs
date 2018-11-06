using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Podcast_Player_Grupp_19.BLL {

    public class ItemList<T> : IList<T> {
        public List<T> List { get; set; }

        public ItemList() {
            List = new List<T>();
        }

        /* Adds an object to an ItemList if the object does not already have an object with the propery Name 
        and the same value on that property*/
        public virtual void AddToList(T item) {
            if (!List.Any((i) => i.GetType().GetProperty("Name").GetValue(i).ToString() == item.GetType().GetProperty("Name").GetValue(item).ToString())) {
                List.Add(item);
            }
            else {
                MessageBox.Show("Listan innehåller redan det objektet", "Error Message");
            }

        }

        // Serializes a generic List into a json file with the specified path in the inparameter Path.
        public virtual void SaveList(string Path) {
            Serializer<List<T>> serializer = new Serializer<List<T>>(Path);
            serializer.Serialize(this.List);
        }

        /* Removes an object from an ItemList if the object has the property Name 
        and the property's value corresponds to the inparamter userInput. */
        public void RemoveFromList(string userInput) {
            if (List.Any((i) => i.GetType().GetProperty("Name").GetValue(i).ToString() == userInput)) {
                List.RemoveAll(item => item.GetType().GetProperty("Name").GetValue(item).ToString() == userInput);
            }
        }

        /* Deserializes a json file specified with the inparameter Path into a generic List
        and then adds each item in that list to the specified ItemList in the inparameter.*/
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

