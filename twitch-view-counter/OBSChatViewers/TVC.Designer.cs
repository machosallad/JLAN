namespace OBSChatViewers
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.notIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmBtnObsFilePath = new System.Windows.Forms.ToolStripMenuItem();
            this.setUpdateIntervalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itmBtnCurrentInterval = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itmBtn5sec = new System.Windows.Forms.ToolStripMenuItem();
            this.itmBtn10sec = new System.Windows.Forms.ToolStripMenuItem();
            this.itmBtn30sec = new System.Windows.Forms.ToolStripMenuItem();
            this.itmBtn1min = new System.Windows.Forms.ToolStripMenuItem();
            this.itmBtnManUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.itmBtnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.rdoBtnSpot = new System.Windows.Forms.RadioButton();
            this.rdoBtnFoobar = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSong = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblViewers = new System.Windows.Forms.Label();
            this.lblChannel = new System.Windows.Forms.Label();
            this.txtChannelName = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.timerSong = new System.Windows.Forms.Timer(this.components);
            this.setMusicPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentMusicPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itmBtnSpotify = new System.Windows.Forms.ToolStripMenuItem();
            this.itmBtnFoobar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.notMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notIcon
            // 
            this.notIcon.ContextMenuStrip = this.notMenu;
            this.notIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notIcon.Icon")));
            this.notIcon.Text = "Twitch Viewer Counter";
            this.notIcon.DoubleClick += new System.EventHandler(this.notIcon_DoubleClick);
            // 
            // notMenu
            // 
            this.notMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmBtnObsFilePath,
            this.setUpdateIntervalToolStripMenuItem,
            this.setMusicPlayerToolStripMenuItem,
            this.itmBtnManUpdate,
            this.itmBtnExit});
            this.notMenu.Name = "notMenu";
            this.notMenu.Size = new System.Drawing.Size(260, 136);
            // 
            // itmBtnObsFilePath
            // 
            this.itmBtnObsFilePath.Name = "itmBtnObsFilePath";
            this.itmBtnObsFilePath.Size = new System.Drawing.Size(259, 22);
            this.itmBtnObsFilePath.Text = "Copy OBS textfile path to clipboard";
            this.itmBtnObsFilePath.Click += new System.EventHandler(this.itmBtnObsFilePath_Click);
            // 
            // setUpdateIntervalToolStripMenuItem
            // 
            this.setUpdateIntervalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmBtnCurrentInterval,
            this.toolStripSeparator1,
            this.itmBtn5sec,
            this.itmBtn10sec,
            this.itmBtn30sec,
            this.itmBtn1min});
            this.setUpdateIntervalToolStripMenuItem.Name = "setUpdateIntervalToolStripMenuItem";
            this.setUpdateIntervalToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.setUpdateIntervalToolStripMenuItem.Text = "Set update interval";
            // 
            // itmBtnCurrentInterval
            // 
            this.itmBtnCurrentInterval.Name = "itmBtnCurrentInterval";
            this.itmBtnCurrentInterval.Size = new System.Drawing.Size(188, 22);
            this.itmBtnCurrentInterval.Text = "Current interval: 5 sec";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(185, 6);
            // 
            // itmBtn5sec
            // 
            this.itmBtn5sec.Name = "itmBtn5sec";
            this.itmBtn5sec.Size = new System.Drawing.Size(188, 22);
            this.itmBtn5sec.Text = "5 sec";
            this.itmBtn5sec.Click += new System.EventHandler(this.itmBtn5sec_Click);
            // 
            // itmBtn10sec
            // 
            this.itmBtn10sec.Name = "itmBtn10sec";
            this.itmBtn10sec.Size = new System.Drawing.Size(188, 22);
            this.itmBtn10sec.Text = "10 sec";
            this.itmBtn10sec.Click += new System.EventHandler(this.itmBtn10sec_Click);
            // 
            // itmBtn30sec
            // 
            this.itmBtn30sec.Name = "itmBtn30sec";
            this.itmBtn30sec.Size = new System.Drawing.Size(188, 22);
            this.itmBtn30sec.Text = "30 sec";
            this.itmBtn30sec.Click += new System.EventHandler(this.itmBtn30sec_Click);
            // 
            // itmBtn1min
            // 
            this.itmBtn1min.Name = "itmBtn1min";
            this.itmBtn1min.Size = new System.Drawing.Size(188, 22);
            this.itmBtn1min.Text = "1 min";
            this.itmBtn1min.Click += new System.EventHandler(this.itmBtn1min_Click_1);
            // 
            // itmBtnManUpdate
            // 
            this.itmBtnManUpdate.Name = "itmBtnManUpdate";
            this.itmBtnManUpdate.Size = new System.Drawing.Size(259, 22);
            this.itmBtnManUpdate.Text = "Manual update";
            this.itmBtnManUpdate.Click += new System.EventHandler(this.itmBtnManUpdate_Click);
            // 
            // itmBtnExit
            // 
            this.itmBtnExit.Name = "itmBtnExit";
            this.itmBtnExit.Size = new System.Drawing.Size(259, 22);
            this.itmBtnExit.Text = "Exit";
            this.itmBtnExit.Click += new System.EventHandler(this.itmBtnExit_Click);
            // 
            // timerUpdate
            // 
            this.timerUpdate.Interval = 5000;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // rdoBtnSpot
            // 
            this.rdoBtnSpot.AutoSize = true;
            this.rdoBtnSpot.Checked = true;
            this.rdoBtnSpot.Location = new System.Drawing.Point(6, 19);
            this.rdoBtnSpot.Name = "rdoBtnSpot";
            this.rdoBtnSpot.Size = new System.Drawing.Size(57, 17);
            this.rdoBtnSpot.TabIndex = 4;
            this.rdoBtnSpot.TabStop = true;
            this.rdoBtnSpot.Text = "Spotify";
            this.rdoBtnSpot.UseVisualStyleBackColor = true;
            // 
            // rdoBtnFoobar
            // 
            this.rdoBtnFoobar.AutoSize = true;
            this.rdoBtnFoobar.Location = new System.Drawing.Point(69, 19);
            this.rdoBtnFoobar.Name = "rdoBtnFoobar";
            this.rdoBtnFoobar.Size = new System.Drawing.Size(82, 17);
            this.rdoBtnFoobar.TabIndex = 5;
            this.rdoBtnFoobar.Text = "Foobar2000";
            this.rdoBtnFoobar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSong);
            this.groupBox1.Controls.Add(this.rdoBtnSpot);
            this.groupBox1.Controls.Add(this.rdoBtnFoobar);
            this.groupBox1.Location = new System.Drawing.Point(12, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 159);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Music";
            // 
            // lblSong
            // 
            this.lblSong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSong.Location = new System.Drawing.Point(6, 39);
            this.lblSong.Name = "lblSong";
            this.lblSong.Size = new System.Drawing.Size(242, 117);
            this.lblSong.TabIndex = 8;
            this.lblSong.Text = "N/A";
            this.lblSong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblViewers);
            this.groupBox2.Controls.Add(this.lblChannel);
            this.groupBox2.Controls.Add(this.txtChannelName);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 182);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Viewer counter";
            // 
            // lblViewers
            // 
            this.lblViewers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblViewers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViewers.Location = new System.Drawing.Point(6, 75);
            this.lblViewers.Name = "lblViewers";
            this.lblViewers.Size = new System.Drawing.Size(242, 44);
            this.lblViewers.TabIndex = 7;
            this.lblViewers.Text = "N/A";
            this.lblViewers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblChannel
            // 
            this.lblChannel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChannel.Location = new System.Drawing.Point(6, 16);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(242, 23);
            this.lblChannel.TabIndex = 6;
            this.lblChannel.Text = "Channel name";
            this.lblChannel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtChannelName
            // 
            this.txtChannelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChannelName.Location = new System.Drawing.Point(6, 42);
            this.txtChannelName.Name = "txtChannelName";
            this.txtChannelName.Size = new System.Drawing.Size(242, 20);
            this.txtChannelName.TabIndex = 5;
            this.txtChannelName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(6, 131);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(242, 40);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Start";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // timerSong
            // 
            this.timerSong.Interval = 500;
            this.timerSong.Tick += new System.EventHandler(this.timerSong_Tick);
            // 
            // setMusicPlayerToolStripMenuItem
            // 
            this.setMusicPlayerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentMusicPlayerToolStripMenuItem,
            this.toolStripSeparator2,
            this.itmBtnSpotify,
            this.itmBtnFoobar});
            this.setMusicPlayerToolStripMenuItem.Name = "setMusicPlayerToolStripMenuItem";
            this.setMusicPlayerToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.setMusicPlayerToolStripMenuItem.Text = "Set music player";
            // 
            // currentMusicPlayerToolStripMenuItem
            // 
            this.currentMusicPlayerToolStripMenuItem.Name = "currentMusicPlayerToolStripMenuItem";
            this.currentMusicPlayerToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.currentMusicPlayerToolStripMenuItem.Text = "Current music player: Spotify ";
            // 
            // itmBtnSpotify
            // 
            this.itmBtnSpotify.Name = "itmBtnSpotify";
            this.itmBtnSpotify.Size = new System.Drawing.Size(230, 22);
            this.itmBtnSpotify.Text = "Spotify";
            this.itmBtnSpotify.Click += new System.EventHandler(this.itmBtnSpotify_Click);
            // 
            // itmBtnFoobar
            // 
            this.itmBtnFoobar.Name = "itmBtnFoobar";
            this.itmBtnFoobar.Size = new System.Drawing.Size(230, 22);
            this.itmBtnFoobar.Text = "Foobar2000";
            this.itmBtnFoobar.Click += new System.EventHandler(this.itmBtnFoobar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(227, 6);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 371);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Twitch Viewer Counter";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.notMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notIcon;
        private System.Windows.Forms.ContextMenuStrip notMenu;
        private System.Windows.Forms.ToolStripMenuItem itmBtnManUpdate;
        private System.Windows.Forms.ToolStripMenuItem itmBtnExit;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.ToolStripMenuItem setUpdateIntervalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itmBtn10sec;
        private System.Windows.Forms.ToolStripMenuItem itmBtn30sec;
        private System.Windows.Forms.ToolStripMenuItem itmBtn1min;
        private System.Windows.Forms.ToolStripMenuItem itmBtn5sec;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem itmBtnCurrentInterval;
        private System.Windows.Forms.ToolStripMenuItem itmBtnObsFilePath;
        private System.Windows.Forms.RadioButton rdoBtnSpot;
        private System.Windows.Forms.RadioButton rdoBtnFoobar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSong;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblViewers;
        private System.Windows.Forms.Label lblChannel;
        private System.Windows.Forms.TextBox txtChannelName;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Timer timerSong;
        private System.Windows.Forms.ToolStripMenuItem setMusicPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentMusicPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem itmBtnSpotify;
        private System.Windows.Forms.ToolStripMenuItem itmBtnFoobar;
    }
}

