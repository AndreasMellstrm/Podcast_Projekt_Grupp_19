using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Podcast_Player_Grupp_19.BLL
{
    class Timer
    {
        private System.Timers.Timer updateTimer;
        public event System.Timers.ElapsedEventHandler Elapsed;
        private int Interval { get; set; }

        public Timer(int interval)
        {
            this.Interval = interval;

        }
        /*
        private async void OnTimeOutEvt(Object sender, ElapsedEventArgs e)
        {
            await Podcast.AsyncPodcast(podcast.Url);
        }
        
        private void InitTimer()
        {
            updateTimer = new System.Timers.Timer(300000);
            updateTimer.Elapsed += OnTimeOutEvt;
            updateTimer.AutoReset = true;
            updateTimer.Enabled = true;
        }*/
    }
}
