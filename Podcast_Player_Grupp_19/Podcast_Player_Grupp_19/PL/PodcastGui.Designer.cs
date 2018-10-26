namespace Podcast_Player_Grupp_19 {
    partial class PodcastGUI {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lvCategory = new System.Windows.Forms.ListView();
            this.chCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPlay = new System.Windows.Forms.Button();
            this.lvPodcasts = new System.Windows.Forms.ListView();
            this.chPodEpiCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPodAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPodFreq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPodCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvEpisodes = new System.Windows.Forms.ListView();
            this.chEpiEpisode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEpiName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEpiLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblUrl = new System.Windows.Forms.Label();
            this.tbCategory = new System.Windows.Forms.TextBox();
            this.lblAddCategory = new System.Windows.Forms.Label();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnAddPodcast = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnRemoveCategory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 219);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Podcasts";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 405);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Episodes";
            // 
            // lvCategory
            // 
            this.lvCategory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCategory});
            this.lvCategory.Location = new System.Drawing.Point(9, 75);
            this.lvCategory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lvCategory.Name = "lvCategory";
            this.lvCategory.Size = new System.Drawing.Size(284, 120);
            this.lvCategory.TabIndex = 4;
            this.lvCategory.UseCompatibleStateImageBehavior = false;
            this.lvCategory.View = System.Windows.Forms.View.Details;
            this.lvCategory.SelectedIndexChanged += new System.EventHandler(this.lvCategory_SelectedIndexChanged);
            // 
            // chCategory
            // 
            this.chCategory.Text = "Category";
            this.chCategory.Width = 378;
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(534, 236);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(327, 151);
            this.btnPlay.TabIndex = 5;
            this.btnPlay.Text = "Play Episode";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // lvPodcasts
            // 
            this.lvPodcasts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPodEpiCount,
            this.chPodAuthor,
            this.chPodFreq,
            this.chPodCategory});
            this.lvPodcasts.Location = new System.Drawing.Point(9, 236);
            this.lvPodcasts.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lvPodcasts.Name = "lvPodcasts";
            this.lvPodcasts.Size = new System.Drawing.Size(505, 151);
            this.lvPodcasts.TabIndex = 6;
            this.lvPodcasts.UseCompatibleStateImageBehavior = false;
            this.lvPodcasts.View = System.Windows.Forms.View.Details;
            this.lvPodcasts.SelectedIndexChanged += new System.EventHandler(this.lvPodcasts_SelectedIndexChanged);
            // 
            // chPodEpiCount
            // 
            this.chPodEpiCount.Text = "Episodes";
            this.chPodEpiCount.Width = 63;
            // 
            // chPodAuthor
            // 
            this.chPodAuthor.Text = "Author";
            this.chPodAuthor.Width = 147;
            // 
            // chPodFreq
            // 
            this.chPodFreq.Text = "Update every:";
            // 
            // chPodCategory
            // 
            this.chPodCategory.Text = "Category";
            // 
            // lvEpisodes
            // 
            this.lvEpisodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chEpiEpisode,
            this.chEpiName,
            this.chEpiLength});
            this.lvEpisodes.Location = new System.Drawing.Point(9, 422);
            this.lvEpisodes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lvEpisodes.Name = "lvEpisodes";
            this.lvEpisodes.Size = new System.Drawing.Size(505, 125);
            this.lvEpisodes.TabIndex = 7;
            this.lvEpisodes.UseCompatibleStateImageBehavior = false;
            this.lvEpisodes.View = System.Windows.Forms.View.Details;
            this.lvEpisodes.SelectedIndexChanged += new System.EventHandler(this.lvEpisodes_SelectedIndexChanged);
            // 
            // chEpiEpisode
            // 
            this.chEpiEpisode.Text = "Episode";
            this.chEpiEpisode.Width = 77;
            // 
            // chEpiName
            // 
            this.chEpiName.Text = "Name";
            this.chEpiName.Width = 237;
            // 
            // chEpiLength
            // 
            this.chEpiLength.Text = "Length";
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(39, 36);
            this.tbUrl.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(475, 20);
            this.tbUrl.TabIndex = 8;
            this.tbUrl.TextChanged += new System.EventHandler(this.tbUrl_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(9, 38);
            this.lblUrl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(26, 13);
            this.lblUrl.TabIndex = 10;
            this.lblUrl.Text = "Url: ";
            // 
            // tbCategory
            // 
            this.tbCategory.Location = new System.Drawing.Point(628, 34);
            this.tbCategory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbCategory.Name = "tbCategory";
            this.tbCategory.Size = new System.Drawing.Size(195, 20);
            this.tbCategory.TabIndex = 11;
            // 
            // lblAddCategory
            // 
            this.lblAddCategory.AutoSize = true;
            this.lblAddCategory.Location = new System.Drawing.Point(626, 18);
            this.lblAddCategory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddCategory.Name = "lblAddCategory";
            this.lblAddCategory.Size = new System.Drawing.Size(71, 13);
            this.lblAddCategory.TabIndex = 12;
            this.lblAddCategory.Text = "Add Category";
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(628, 57);
            this.btnAddCategory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(56, 19);
            this.btnAddCategory.TabIndex = 13;
            this.btnAddCategory.Text = "Add Category";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnAddPodcast
            // 
            this.btnAddPodcast.Location = new System.Drawing.Point(9, 197);
            this.btnAddPodcast.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAddPodcast.Name = "btnAddPodcast";
            this.btnAddPodcast.Size = new System.Drawing.Size(56, 19);
            this.btnAddPodcast.TabIndex = 14;
            this.btnAddPodcast.Text = "Add Podcast";
            this.btnAddPodcast.UseVisualStyleBackColor = true;
            this.btnAddPodcast.Click += new System.EventHandler(this.btnAddPodcast_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(531, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Info";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(534, 422);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(327, 125);
            this.listView1.TabIndex = 17;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // btnRemoveCategory
            // 
            this.btnRemoveCategory.Location = new System.Drawing.Point(298, 172);
            this.btnRemoveCategory.Name = "btnRemoveCategory";
            this.btnRemoveCategory.Size = new System.Drawing.Size(122, 23);
            this.btnRemoveCategory.TabIndex = 18;
            this.btnRemoveCategory.Text = "Remove Category";
            this.btnRemoveCategory.UseVisualStyleBackColor = true;
            this.btnRemoveCategory.Click += new System.EventHandler(this.btnRemoveCategory_Click);
            // 
            // PodcastGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 634);
            this.Controls.Add(this.btnRemoveCategory);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddPodcast);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.lblAddCategory);
            this.Controls.Add(this.tbCategory);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.lvEpisodes);
            this.Controls.Add(this.lvPodcasts);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lvCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "PodcastGUI";
            this.Text = "       ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvCategory;
        private System.Windows.Forms.ColumnHeader chCategory;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.ListView lvPodcasts;
        private System.Windows.Forms.ListView lvEpisodes;
        private System.Windows.Forms.ColumnHeader chPodEpiCount;
        private System.Windows.Forms.ColumnHeader chPodAuthor;
        private System.Windows.Forms.ColumnHeader chPodFreq;
        private System.Windows.Forms.ColumnHeader chEpiEpisode;
        private System.Windows.Forms.ColumnHeader chEpiName;
        private System.Windows.Forms.ColumnHeader chEpiLength;
        private System.Windows.Forms.ColumnHeader chPodCategory;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox tbCategory;
        private System.Windows.Forms.Label lblAddCategory;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnAddPodcast;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnRemoveCategory;
    }
}

