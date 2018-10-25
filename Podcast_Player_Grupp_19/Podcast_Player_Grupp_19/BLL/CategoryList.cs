using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Podcast_Player_Grupp_19.BLL
{
    class CategoryList : IList<Category>
    {
        public List<Category> List { get; set; }

        public CategoryList()
        {
            List = new List<Category>();
        }
        public void AddToList(Category item)
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
        public void RemoveFromList(Category item)
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