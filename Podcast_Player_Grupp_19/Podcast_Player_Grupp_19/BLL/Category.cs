using System;
using Podcast_Player_Grupp_19.BLL;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Podcast_Player_Grupp_19.BLL
{
    public class Category
    {
        public string CategoryName { get; set; }

        public Category(string userInput, ItemList<Category> CategoryList)
        {
            CategoryName = userInput;
            AddCategory(userInput, CategoryList);
        }

        //
        public void AddCategory(string userInput, ItemList<Category> CategoryList)
        {
            if(!CategoryList.List.Any((cat) => cat.CategoryName == userInput))
            {
                CategoryList.List.Add(this);
            }
            else
            {
                MessageBox.Show("Listan innehåller redan " + userInput + " .", "Error Message");
            }
        }
    }
}
/* public List<Category> List { get; set; }

        public CategoryList()
        {
            List = new List<Category>();
        }
    }*/
