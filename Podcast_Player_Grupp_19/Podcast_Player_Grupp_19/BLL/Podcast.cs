﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Podcast_Player_Grupp_19.BLL {
    public class Podcast {

        public string Name { get; set; }
        public string Category { get; set; }
        private string Url { get; set; }
        private int Interval { get; set; }
        private Timer updateTimer;
        public List<PodcastEpisode> PodcastEpisodes { get; set; }
        public int UpdateFrequency { get; set; }
        public DAL.FeedReader FeedReader{ get; set; }
        

        public Podcast(string url, string Category) {

            this.Url = url;
            this.Category = Category;
            PodcastEpisodes = new List<PodcastEpisode>();
            Interval = 20000;
            InitTimer(Interval);
            List<PodcastEpisode> List = new List<PodcastEpisode>();
        }

        private void InitTimer(int interval = 300000)
        {
            updateTimer = new Timer(interval);
            updateTimer.Elapsed += OnTimeOutEvt;
            updateTimer.AutoReset = true;
            updateTimer.Enabled = true;
        }
        private async void OnTimeOutEvt(Object sender, ElapsedEventArgs e)
        {
            await AsyncPodcast(Url);
            System.Diagnostics.Debug.WriteLine("Hej");
        }

        public void SetInterval(int userInput)
        {
            updateTimer.Dispose();
            Interval = userInput;
            InitTimer(Interval);
        }

        public async Task AsyncPodcast(string url)
        {
            FeedReader = new DAL.FeedReader();
            await FeedReader.GetRssData(url);
            Name = FeedReader.Feed.Title.Text;
            GetPodcastEpisodes();
        }

        public void GetPodcastEpisodes() {
            foreach(SyndicationItem item in FeedReader.Feed.Items) {
                if (!PodcastEpisodes.Any((episode) => episode.Title == item.Title.Text)){
                    var PodcastEpisode = new PodcastEpisode(item);
                    PodcastEpisodes.Add(PodcastEpisode);
                }
            }
            
        }
    }
}
