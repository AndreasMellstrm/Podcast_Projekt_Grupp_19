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
        public string Name { get; set; }

        public Category(string userInput)
        {
            Name = userInput;
        }

        //
       
    }
}

public class CategoryList : ItemList<Category> {

}
