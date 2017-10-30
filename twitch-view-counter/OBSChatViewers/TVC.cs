using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Web;
using System.IO;
using Newtonsoft.Json;


using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using System.Diagnostics;
namespace OBSChatViewers
{
    public partial class MainWindow : Form
    {
        bool balloon = false;
        int recon = 0;
        StreamWriter sw;
        string songSeparator = " | ";

        Process[] musicPlayerProcess;

        const int OFFLINE = -1;
        const int ERROR = -2;

        public MainWindow()
        {
            InitializeComponent();
            sw = new StreamWriter("viewers.txt");
            sw.Close();
            
            string[] args = Environment.GetCommandLineArgs();
            if(args.Length == 2)
            {
                txtChannelName.Text = args[1];
            }
        }

        #region user32.dll functions
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int FindWindow(string sClass, string sWindow);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        #endregion


        #region Main Window events

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            startUpdateTimer();
            startSongTimer();
            //this.WindowState = FormWindowState.Minimized;
        }

        private void txtChannelName_TextChanged(object sender, EventArgs e)
        {
            // Stop the timer if the channel name changes
            stopUpdateTimer();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized) //If main window is minimized
            {
                notIcon.Visible = true; //Show notification icon

                if (balloon == false) //If balloon has not yet been shown
                {
                    notIcon.ShowBalloonTip(2000, "Twitch Viewer Counter", "Here I am! To close, change settings etc. right click here!", ToolTipIcon.Info);
                    balloon = true;
                }

                this.Visible = false; //Set main window invisible
            }
        }

        #endregion


        #region Private methods

        private int RequestCount()
        {
            try
            {
                WebClient webC = new WebClient();
                int viewCount = OFFLINE;
                string url = "https://api.twitch.tv/kraken/streams/" + txtChannelName.Text;
                string json = webC.DownloadString(url);

                JObject root = JObject.Parse(json);             // Get JSON root
                JToken stream = root.SelectToken("stream");     // Get JSON token

                // Check if user is online 
                if (stream.HasValues)
                {
                    //Online 
                    viewCount = int.Parse(stream["viewers"].ToString());
                    string game = stream["game"].ToString();    // Not used
                }

                WriteToFile(viewCount.ToString());
                return viewCount;
            }
            catch (Exception exep)
            {
                if (recon > 2) //If exeception and 3 or more reconnections has been made
                {
                    WriteToFile("ERROR");
                    timerUpdate.Stop();
                    this.Visible = true;
                    this.WindowState = FormWindowState.Normal;

                    notIcon.Visible = false;
                    recon = 0;
                    MessageBox.Show("Connection failed 3 times due to: \n" + exep.Message); //Return error and resize window to normal and stop update timer.
                    return ERROR;
                }
                recon++;
            }

            WriteToFile("OFFL"); //If channel is not yet online
            return OFFLINE;
        }

        private void WriteToFile(string str)
        {
            sw = new StreamWriter("viewers.txt"); //Write the given string to viewers.txt in app root.
            sw.Write(str);

            sw.Close();
        }

        private void WriteToFile(string str, string filename)
        {
            sw = new StreamWriter(filename); //Write the given string to viewers.txt in app root.
            sw.Write(str);

            sw.Close();
        }

        private void GetSong(MusicPlayer player)
        {
            if(player == MusicPlayer.Spotify)
            {
                musicPlayerProcess = Process.GetProcessesByName("Spotify");
            }
            else //In case of more players, add elseif instead. 
            {
                musicPlayerProcess = Process.GetProcessesByName("foobar2000");
            }

            if (musicPlayerProcess.Length > 0)
            {
                string musicInfo =  UpdateNowPlayingString(musicPlayerProcess[0].MainWindowHandle, player);
                lblSong.Text = musicInfo;
                WriteToFile(musicInfo + songSeparator, "nowPlaying.txt");
            }
            else
            {
                lblSong.Text = "";
                WriteToFile("", "nowPlaying.txt");
            }
        }

        /// <summary>
        /// Helper method to GetSong.
        /// </summary>
        private string UpdateNowPlayingString(IntPtr musicPlayerHandle, MusicPlayer player)
        {
            int capacity = GetWindowTextLength(musicPlayerHandle) * 2;
            StringBuilder windowTitle = new StringBuilder(capacity);
            GetWindowText(musicPlayerHandle, windowTitle, windowTitle.Capacity);

            if (player == MusicPlayer.Spotify)
            {
                if (windowTitle.Length > 9)
                {
                    return windowTitle.ToString().Substring(9);
                }
                else
                    return "";
            }
            else
            {
                if (!windowTitle.ToString().StartsWith("foobar2000"))
                    return System.Text.RegularExpressions.Regex.Replace(windowTitle.ToString(), @"\s+\[foobar2000 v\d+\.\d+\.\d+\]", string.Empty);
                return "";
            }
        }

#endregion


        #region Notification & Context Menu events

        private void itmBtnManUpdate_Click(object sender, EventArgs e)
        {
            //Same as update button on main window.
            timerUpdate_Tick(sender, e);
        }
        
        /// <summary>
        /// Sets timer update interval to 5000 ms = 5 sec
        /// </summary>
        private void itmBtn5sec_Click(object sender, EventArgs e)
        {
            setTimerInterval(5000);
            itmBtnCurrentInterval.Text = "Current interval: 5 sec";
        }

        /// <summary>
        /// Sets timer update interval to 10000 ms = 10 sec
        /// </summary>
        private void itmBtn10sec_Click(object sender, EventArgs e)
        {
            setTimerInterval(10000);
            itmBtnCurrentInterval.Text = "Current interval: 10 sec";
        }

        /// <summary>
        /// Sets timer update interval to 30000 ms = 30 sec
        /// </summary>
        private void itmBtn30sec_Click(object sender, EventArgs e)
        {
            setTimerInterval(30000);
            itmBtnCurrentInterval.Text = "Current interval: 30 sec";
        }

        /// <summary>
        /// Sets timer update interval to 60000 ms = 1 min
        /// </summary>
        private void itmBtn1min_Click_1(object sender, EventArgs e)
        {
            setTimerInterval(60000);
            itmBtnCurrentInterval.Text = "Current interval: 1 min";
        }

        /// <summary>
        /// Closes the application
        /// </summary>
        private void itmBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Copies the generated file path to clipboard
        /// </summary>
        private void itmBtnObsFilePath_Click(object sender, EventArgs e)
        {
            string path;
            path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase); //Gets current dir from where the exe is executing
            Clipboard.SetText(path.Substring(6) + "\\viewers.txt"); //Adds the file to the string and copies the result to clipboard.
        }

        /// <summary>
        /// Sets music player to Spotify
        /// </summary>
        private void itmBtnSpotify_Click(object sender, EventArgs e)
        {
            currentMusicPlayerToolStripMenuItem.Text = "Current music player: Spotify";
            rdoBtnFoobar.Checked = false;
            rdoBtnSpot.Checked = true;
        }

        /// <summary>
        /// Sets music player to Foobar2000
        /// </summary>
        private void itmBtnFoobar_Click(object sender, EventArgs e)
        {
            currentMusicPlayerToolStripMenuItem.Text = "Current music player: Foobar2000";
            rdoBtnFoobar.Checked = true;
            rdoBtnSpot.Checked = false;
        }

        /// <summary>
        /// Resizes main window and hides the notification icon
        /// </summary>
        private void notIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
            notIcon.Visible = false;
        }
        #endregion


        #region Timer related methods and events

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            //Each update request new view count and update label
            int viewCount = RequestCount();

            if (viewCount >= 0)
                lblViewers.Text = viewCount.ToString();
            else if (viewCount == OFFLINE)
                lblViewers.Text = "OFFLINE";
            else if (viewCount == ERROR)
                lblViewers.Text = "ERROR";

        }

        private void timerSong_Tick(object sender, EventArgs e)
        {
            if (rdoBtnSpot.Checked)
                GetSong(MusicPlayer.Spotify);
            else
                GetSong(MusicPlayer.Foobar2000);
        }

        /// <summary>
        /// Set the update timer interval
        /// </summary>
        /// <param name="interval">Interval in ms</param>
        private void setTimerInterval(int interval)
        {
            if (interval > 0)
            {
                stopUpdateTimer();
                timerUpdate.Interval = interval;
                startUpdateTimer();                
            }
        }

        /// <summary>
        /// Start the update timer
        /// </summary>
        private void startUpdateTimer()
        {
            if (!timerUpdate.Enabled)
                timerUpdate.Enabled = true;
        }

        /// <summary>
        /// Stop the update timer
        /// </summary>
        private void stopUpdateTimer()
        {
            if (timerUpdate.Enabled)
                timerUpdate.Enabled = false;
        }
        
        /// <summary>
        /// Start song update timer
        /// </summary>
        private void startSongTimer()
        {
            if (!timerSong.Enabled)
                timerSong.Enabled = true;
        }

        /// <summary>
        /// Stop song update timer
        /// </summary>
        private void stopSongTimer()
        {
            if (timerSong.Enabled)
                timerSong.Enabled = false;
        }

        #endregion
    }

    enum MusicPlayer { Spotify, Foobar2000};
}
