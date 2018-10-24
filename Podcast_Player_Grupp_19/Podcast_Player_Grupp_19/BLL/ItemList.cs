using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Podcast_Player_Grupp_19.BLL
{

    public class ItemList<T> : IList<T>
    {
        public List<T> List { get; set; }

        public ItemList(T item)
        {
            List = new List<T>();
        }
        public void AddToList(T item)
        {
            if (!List.Contains(item))
            {
                List.Add(item);
            }
            else
            {
                MessageBox.Show("Listan " + List + " innehåller redan " + item + " .", "Error Message");
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
