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
        public List<T> List { get; private set; }

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
        public void RemoveFromList(T item)
        {
            if (List.Contains(item))
            {
                List.Remove(item);
            }
            else
            {
                MessageBox.Show("Det gick inte att ta bort " + item + " för att listan inte innehåller " + item + ".", "Error Message");
            }
        }
    }
}
