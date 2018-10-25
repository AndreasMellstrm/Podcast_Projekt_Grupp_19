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

        public CategoryList CategoryList { get; set; } = new CategoryList();

        public Category(string name)
        {
            CategoryName = name;

        }

        //Create a new Category object with CategoryName from user input.
        public void AddCategory(string userInput)
        {
            foreach(var item in CategoryList)
            {

            }
            new Category(userInput);
        }
    }
}
