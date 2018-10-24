using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podcast_Player_Grupp_19.BLL
{
    static class Player
    {
        //Play mp3 file in standrad media player.
        public static void Play(string filePath)//use a local file path @param filePath
        {
            System.Diagnostics.Process.Start(filePath);
        }
    }
}
