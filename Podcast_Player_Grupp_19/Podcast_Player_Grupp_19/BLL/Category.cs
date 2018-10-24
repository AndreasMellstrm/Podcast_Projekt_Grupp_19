using System;
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

        public Category(string name)
        {
            CategoryName = name;
        }

    }
    public class CategoryList<T> where T : IList
    {
        void AddToList(Object obj, List<T> listName)
        {
            if(!listName.Contains(obj))
            {
                listName.Add(obj);
            }
            else
            {
                MessageBox.Show("List "+listName+" already contains " +obj+" .", "System Error");
            }
        }

        void IList.RemoveFromList()
        {
            throw new NotImplementedException();
        }
    }
}
