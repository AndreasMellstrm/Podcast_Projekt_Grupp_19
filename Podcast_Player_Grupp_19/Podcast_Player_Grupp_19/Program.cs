using System;
using System.Collections.Generic;
using System.Threaeding.Tasks;
using System.Windows.Forms;

namespace Podcast_Player_Grupp_19 {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PodcastGUI());
        }
    }
}
//asfjhjashfkjaf