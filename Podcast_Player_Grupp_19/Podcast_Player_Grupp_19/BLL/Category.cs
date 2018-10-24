using System;
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
        public static ItemList<Category> CategoryList { get; set; }

        public Category(string name)
        {
            CategoryName = name;
            CategoryList = new ItemList<Category>(this);
            CategoryList.AddToList(this);
        }
    }
}
