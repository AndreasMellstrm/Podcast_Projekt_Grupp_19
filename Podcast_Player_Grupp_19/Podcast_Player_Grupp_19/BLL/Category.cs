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

        public Category(string userInput)
        {
            CategoryName = userInput;
        }

        //
       
    }
}
/* public List<Category> List { get; set; }

        public CategoryList()
        {
            List = new List<Category>();
        }
    }*/
