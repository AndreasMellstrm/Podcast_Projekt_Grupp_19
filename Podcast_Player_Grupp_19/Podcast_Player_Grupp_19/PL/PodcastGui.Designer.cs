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
            this.lvPodcasts = new System.Windows.Forms.ListView();
            this.chPodName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPodTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPodEpiCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPodFreq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPodCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvEpisodes = new System.Windows.Forms.ListView();
            this.chEpiName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblUrl = new System.Windows.Forms.Label();
            this.tbCategory = new System.Windows.Forms.TextBox();
            this.lblAddCategory = new System.Windows.Forms.Label();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnAddPodcast = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRemoveCategory = new System.Windows.Forms.Button();
            this.tbEpisodeInfo = new System.Windows.Forms.RichTextBox();
            this.btnRemovePodcast = new System.Windows.Forms.Button();
            this.tbPodName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnChangeUrl = new System.Windows.Forms.Button();
            this.cbInterval = new System.Windows.Forms.ComboBox();
            this.lblInterval = new System.Windows.Forms.Label();
            this.btnChangeInterval = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Podcasts";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 585);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Episodes";
            // 
            // lvCategory
            // 
            this.lvCategory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCategory});
            this.lvCategory.Location = new System.Drawing.Point(13, 165);
            this.lvCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvCategory.Name = "lvCategory";
            this.lvCategory.Size = new System.Drawing.Size(669, 146);
            this.lvCategory.TabIndex = 4;
            this.lvCategory.UseCompatibleStateImageBehavior = false;
            this.lvCategory.View = System.Windows.Forms.View.Details;
            this.lvCategory.ItemActivate += new System.EventHandler(this.lvCategory_ItemActivate);
            // 
            // chCategory
            // 
            this.chCategory.Text = "Category";
            this.chCategory.Width = 378;
            // 
            // lvPodcasts
            // 
            this.lvPodcasts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPodName,
            this.chPodTitle,
            this.chPodEpiCount,
            this.chPodFreq,
            this.chPodCategory});
            this.lvPodcasts.Location = new System.Drawing.Point(12, 378);
            this.lvPodcasts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvPodcasts.Name = "lvPodcasts";
            this.lvPodcasts.Size = new System.Drawing.Size(873, 185);
            this.lvPodcasts.TabIndex = 6;
            this.lvPodcasts.UseCompatibleStateImageBehavior = false;
            this.lvPodcasts.View = System.Windows.Forms.View.Details;
            this.lvPodcasts.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvPodcasts_ColumnClick);
            this.lvPodcasts.ItemActivate += new System.EventHandler(this.lvPodcasts_ItemActivate);
            // 
            // chPodName
            // 
            this.chPodName.Text = "Name";
            this.chPodName.Width = 206;
            // 
            // chPodTitle
            // 
            this.chPodTitle.Text = "Title";
            this.chPodTitle.Width = 320;
            // 
            // chPodEpiCount
            // 
            this.chPodEpiCount.Text = "Episodes";
            this.chPodEpiCount.Width = 98;
            // 
            // chPodFreq
            // 
            this.chPodFreq.Text = "Update every:";
            this.chPodFreq.Width = 107;
            // 
            // chPodCategory
            // 
            this.chPodCategory.Text = "Category";
            this.chPodCategory.Width = 141;
            // 
            // lvEpisodes
            // 
            this.lvEpisodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chEpiName});
            this.lvEpisodes.Location = new System.Drawing.Point(10, 606);
            this.lvEpisodes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvEpisodes.Name = "lvEpisodes";
            this.lvEpisodes.Size = new System.Drawing.Size(672, 153);
            this.lvEpisodes.TabIndex = 7;
            this.lvEpisodes.UseCompatibleStateImageBehavior = false;
            this.lvEpisodes.View = System.Windows.Forms.View.Details;
            this.lvEpisodes.ItemActivate += new System.EventHandler(this.lvEpisodes_ItemActivate);
            // 
            // chEpiName
            // 
            this.chEpiName.Text = "Name";
            this.chEpiName.Width = 237;
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(137, 34);
            this.tbUrl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(545, 22);
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
            this.lblUrl.Location = new System.Drawing.Point(88, 38);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(34, 17);
            this.lblUrl.TabIndex = 10;
            this.lblUrl.Text = "Url: ";
            // 
            // tbCategory
            // 
            this.tbCategory.Location = new System.Drawing.Point(724, 164);
            this.tbCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbCategory.Name = "tbCategory";
            this.tbCategory.Size = new System.Drawing.Size(258, 22);
            this.tbCategory.TabIndex = 11;
            // 
            // lblAddCategory
            // 
            this.lblAddCategory.AutoSize = true;
            this.lblAddCategory.Location = new System.Drawing.Point(802, 143);
            this.lblAddCategory.Name = "lblAddCategory";
            this.lblAddCategory.Size = new System.Drawing.Size(94, 17);
            this.lblAddCategory.TabIndex = 12;
            this.lblAddCategory.Text = "Add Category";
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(724, 194);
            this.btnAddCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(258, 117);
            this.btnAddCategory.TabIndex = 13;
            this.btnAddCategory.Text = "Add Category";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnAddPodcast
            // 
            this.btnAddPodcast.Location = new System.Drawing.Point(13, 321);
            this.btnAddPodcast.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddPodcast.Name = "btnAddPodcast";
            this.btnAddPodcast.Size = new System.Drawing.Size(75, 23);
            this.btnAddPodcast.TabIndex = 14;
            this.btnAddPodcast.Text = "Add Podcast";
            this.btnAddPodcast.UseVisualStyleBackColor = true;
            this.btnAddPodcast.Click += new System.EventHandler(this.btnAddPodcast_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(706, 585);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Info";
            // 
            // btnRemoveCategory
            // 
            this.btnRemoveCategory.Location = new System.Drawing.Point(227, 318);
            this.btnRemoveCategory.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveCategory.Name = "btnRemoveCategory";
            this.btnRemoveCategory.Size = new System.Drawing.Size(163, 28);
            this.btnRemoveCategory.TabIndex = 18;
            this.btnRemoveCategory.Text = "Remove Category";
            this.btnRemoveCategory.UseVisualStyleBackColor = true;
            this.btnRemoveCategory.Click += new System.EventHandler(this.btnRemoveCategory_Click);
            // 
            // tbEpisodeInfo
            // 
            this.tbEpisodeInfo.Location = new System.Drawing.Point(710, 606);
            this.tbEpisodeInfo.Name = "tbEpisodeInfo";
            this.tbEpisodeInfo.Size = new System.Drawing.Size(617, 153);
            this.tbEpisodeInfo.TabIndex = 19;
            this.tbEpisodeInfo.Text = "";
            // 
            // btnRemovePodcast
            // 
            this.btnRemovePodcast.Location = new System.Drawing.Point(549, 346);
            this.btnRemovePodcast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemovePodcast.Name = "btnRemovePodcast";
            this.btnRemovePodcast.Size = new System.Drawing.Size(133, 25);
            this.btnRemovePodcast.TabIndex = 20;
            this.btnRemovePodcast.Text = "Remove Podcast";
            this.btnRemovePodcast.UseVisualStyleBackColor = true;
            this.btnRemovePodcast.Click += new System.EventHandler(this.btnRemovePodcast_Click);
            // 
            // tbPodName
            // 
            this.tbPodName.Location = new System.Drawing.Point(137, 68);
            this.tbPodName.Name = "tbPodName";
            this.tbPodName.Size = new System.Drawing.Size(544, 22);
            this.tbPodName.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Choose name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "Choose Category:";
            // 
            // btnChangeUrl
            // 
            this.btnChangeUrl.Location = new System.Drawing.Point(748, 36);
            this.btnChangeUrl.Name = "btnChangeUrl";
            this.btnChangeUrl.Size = new System.Drawing.Size(97, 45);
            this.btnChangeUrl.TabIndex = 24;
            this.btnChangeUrl.Text = "Change URL";
            this.btnChangeUrl.UseVisualStyleBackColor = true;
            this.btnChangeUrl.Click += new System.EventHandler(this.btnChangeUrl_Click);
            // 
            // cbInterval
            // 
            this.cbInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInterval.FormattingEnabled = true;
            this.cbInterval.Items.AddRange(new object[] {
            "1 minute",
            "10 minutes",
            "30 minutes"});
            this.cbInterval.Location = new System.Drawing.Point(137, 102);
            this.cbInterval.Margin = new System.Windows.Forms.Padding(2);
            this.cbInterval.Name = "cbInterval";
            this.cbInterval.Size = new System.Drawing.Size(253, 24);
            this.cbInterval.TabIndex = 25;
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(10, 108);
            this.lblInterval.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(110, 17);
            this.lblInterval.TabIndex = 26;
            this.lblInterval.Text = "Choose interval:";
            // 
            // btnChangeInterval
            // 
            this.btnChangeInterval.Location = new System.Drawing.Point(748, 86);
            this.btnChangeInterval.Margin = new System.Windows.Forms.Padding(2);
            this.btnChangeInterval.Name = "btnChangeInterval";
            this.btnChangeInterval.Size = new System.Drawing.Size(97, 38);
            this.btnChangeInterval.TabIndex = 27;
            this.btnChangeInterval.Text = "Change Interval";
            this.btnChangeInterval.UseVisualStyleBackColor = true;
            this.btnChangeInterval.Click += new System.EventHandler(this.btnChangeInterval_Click);
            // 
            // PodcastGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 675);
            this.Controls.Add(this.btnChangeInterval);
            this.Controls.Add(this.lblInterval);
            this.Controls.Add(this.cbInterval);
            this.Controls.Add(this.btnChangeUrl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPodName);
            this.Controls.Add(this.btnRemovePodcast);
            this.Controls.Add(this.tbEpisodeInfo);
            this.Controls.Add(this.btnRemoveCategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddPodcast);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.lblAddCategory);
            this.Controls.Add(this.tbCategory);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.lvEpisodes);
            this.Controls.Add(this.lvPodcasts);
            this.Controls.Add(this.lvCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
        private System.Windows.Forms.ListView lvPodcasts;
        private System.Windows.Forms.ListView lvEpisodes;
        private System.Windows.Forms.ColumnHeader chPodEpiCount;
        private System.Windows.Forms.ColumnHeader chPodName;
        private System.Windows.Forms.ColumnHeader chPodFreq;
        private System.Windows.Forms.ColumnHeader chEpiName;
        private System.Windows.Forms.ColumnHeader chPodCategory;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox tbCategory;
        private System.Windows.Forms.Label lblAddCategory;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnAddPodcast;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRemoveCategory;
        private System.Windows.Forms.RichTextBox tbEpisodeInfo;
        private System.Windows.Forms.Button btnRemovePodcast;
        private System.Windows.Forms.TextBox tbPodName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader chPodTitle;
        private System.Windows.Forms.Button btnChangeUrl;
        private System.Windows.Forms.ComboBox cbInterval;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.Button btnChangeInterval;
    }
}

