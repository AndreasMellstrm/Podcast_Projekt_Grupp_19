using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podcast_Player_Grupp_19.BLL
{
    interface IList<T>
    {
        void AddToList(T obj);

        void RemoveFromList(T obj);
    }
}
