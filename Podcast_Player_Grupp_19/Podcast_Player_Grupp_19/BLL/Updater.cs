using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podcast_Player_Grupp_19.BLL
{
    class Updater
    {
        private static System.Windows.Forms.Timer UpdateTimer = new System.Windows.Forms.Timer();
        private int Counter;
        private void InitTimer()
        {
            Counter = 0;
            //Set the interval to 5 minutes aka 300 000 milliseconds.
            UpdateTimer.Interval = 300000;
            UpdateTimer.Enabled = true;
            this.UpdateTimer_Tick += new System.EventHandler(this.UpdateTimer_Tick);

        }

        private void UpdateTimer_Tick(object sender, System.EventArgs e)
        {
            if(Counter > 1)
            {
                UpdateTimer.Enabled = false;
                Counter = 0;
            }
            else
            {

            }
        }
    }
}
