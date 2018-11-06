namespace Podcast_Player_Grupp_19.PL {
    partial class PopupForm {
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbNewUrl = new System.Windows.Forms.TextBox();
            this.btnUpdateUrl = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL goes here:";
            // 
            // tbNewUrl
            // 
            this.tbNewUrl.Location = new System.Drawing.Point(119, 48);
            this.tbNewUrl.Name = "tbNewUrl";
            this.tbNewUrl.Size = new System.Drawing.Size(275, 22);
            this.tbNewUrl.TabIndex = 1;
            // 
            // btnUpdateUrl
            // 
            this.btnUpdateUrl.Location = new System.Drawing.Point(319, 76);
            this.btnUpdateUrl.Name = "btnUpdateUrl";
            this.btnUpdateUrl.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateUrl.TabIndex = 2;
            this.btnUpdateUrl.Text = "Change";
            this.btnUpdateUrl.UseVisualStyleBackColor = true;
            this.btnUpdateUrl.Click += new System.EventHandler(this.btnUpdateUrl_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(278, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Change URL for the selected Podcast feed";
            // 
            // PopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 174);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnUpdateUrl);
            this.Controls.Add(this.tbNewUrl);
            this.Controls.Add(this.label1);
            this.Name = "PopupForm";
            this.Text = "Customize";
            this.Load += new System.EventHandler(this.PopupForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNewUrl;
        private System.Windows.Forms.Button btnUpdateUrl;
        private System.Windows.Forms.Label label2;
    }
}