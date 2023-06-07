using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using static DHCI.Text;
using Octokit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.Net;
using static System.Net.WebRequestMethods;
using System.Xml;
using File = System.IO.File;
using DHCI.Properties;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Win32;
using System.Reflection;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DHCI
{
    partial class Main : Form
    {
        //This token is for the BRNR account only. Using this token is useless exept for editing the GHrepository!
        public string GithubToken = "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";

        private Timer tmr;
        private DownloadProgressChangedEventHandler wc_DownloadProgressChanged;
        private NotifyIcon trayIcon;
        private Timer timer1;


        public string Link { get; private set; }
        public string Dup { get; private set; }

        public Main()
        {
            InitializeComponent();
            if (Properties.Settings.Default.Darkmode == true)
            {
                this.BackColor = Color.FromArgb(36, 36, 36);
                PT.BackColor = Color.FromArgb(50, 50, 50);
                CE.BackColor = Color.FromArgb(36, 36, 36);
                wp_Label.BackColor = Color.FromArgb(36, 36, 36);
            }
            else
            {
                this.BackColor = SystemColors.Control;
                PT.BackColor = SystemColors.Control;
                CE.BackColor = SystemColors.Control;
                wp_Label.BackColor = SystemColors.Control;
            }

            BTNLab();
            TrayMenuContext();

            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(10);

            var timer = new System.Threading.Timer((f) =>
            {
                //doUpdate();
            }, null, startTimeSpan, periodTimeSpan);

            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"MRO");
            key.SetValue("Version", version);
            key.Close();

            doUpdate();
            WebPushTimer();
            InitTimer();
        }

        public void WebPushTimer()
        {
            //var timerWP = new System.Threading.Timer(
            //e => doUpdate(),
            //null,
            //TimeSpan.Zero,
            //TimeSpan.FromMinutes(10));

            var timerDU = new System.Threading.Timer(
            e => WebPushReceive(),
            null,
            TimeSpan.Zero,
            TimeSpan.FromMinutes(10));
        }

        public void WebPushReceive()
        {
            try
            {
                //string Dup = "";

                //Gets raw data from the project
                System.Net.WebClient wc = new System.Net.WebClient();

                //Using this in a try/catch so the program won't crash if there is no internet.
                System.Net.WebClient ginf = new System.Net.WebClient();

                byte[] raw = ginf.DownloadData("http://davinkiheren.nl/application/mobilepush/datapusher/zcf-jncrfujxn2r5u8x-adgkbpdsgvkyp3s6v9ybehmcqfthwmzq4t7wzcf-jandrgukxn2r5u8x-adgkbpeshvmyq3s6v9ybehmcqftjwnzr4u7wzcf-jandrgukxp2s5v8y-adgkbpeshvmyq3t6w9zcehmcqf");

                string webData = System.Text.Encoding.UTF8.GetString(raw);

                string GetLine(string text, int lineNo)
                {
                    string[] lines = text.Replace("\r", "").Split('\n');
                    return lines.Length >= lineNo ? lines[lineNo - 1] : null;
                }

                webData = webData.Replace("<div class=\"wp-block-comment-content\"><p>", "");
                webData = webData.Replace("</p>", ""); // to replace the specific text with blank
               //MessageBox.Show(GetLine(webData, 188));

                if (Dup == GetLine(webData, 188))
                {
                    //Do nothing
                    //MessageBox.Show("Duplicaat!");
                }
                else
                {
                    if (GetLine(webData, 188).StartsWith("https://"))
                    {
                        //MessageBox.Show("Dit is een link!");
                        Video.ControlID.VideoData = GetLine(webData, 188);
                        using (Video PVV = new Video())
                        {
                            if (PVV.ShowDialog() == DialogResult.OK)
                            {
                                //Data already called!
                            }
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Dit is text!");
                        ControlID.TextData = GetLine(webData, 188);
                        using (Text IVI = new Text())
                        {
                            if (IVI.ShowDialog() == DialogResult.OK)
                            {
                                //Data already called!
                            }
                        }
                    }

                    Dup = GetLine(webData, 188);
                }

                WebPushTimer();
            }
            catch
            {
                var NI = new NI();
                NI.ShowDialog();
            }
        }

        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 5000; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            getDSContent();
        }

        private void TrayMenuContext()
        {
            this.notifyIcon1.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.notifyIcon1.ContextMenuStrip.Items.Add("About SystemIntergratedCycliManager...", null, (s, e) => MessageBox.Show("Null"));
        }

        private void DSdata()
        {
            WebClient client = new WebClient();
            String webDataDS = client.DownloadString("https://github.com/MexiMoo/DavinkiMannen/blob/master/DavinkiServerPush.txt");
            CE_EDITOR.Text = webDataDS;

            //if (Properties.Settings.Default.DebugServer != webDataDS)
            //{
                //char[] array = webData.Take(8).ToArray();
                //if (array.ToString() == "https://")
                //{
                //MessageBox.Show("ddd");
                //}
                //MessageBox.Show(array.ToString());

                
                //MessageBox.Show(Properties.Settings.Default.DebugServer);
                //MessageBox.Show(webDataDS);
                //Task.Delay(1000).ContinueWith(t => Properties.Settings.Default["DebugServer"] = "Test");
                //Task.Delay(1000).ContinueWith(t => Properties.Settings.Default.Save());
            //}
            //else
            //{
                //Do nothing
                //MessageBox.Show(Properties.Settings.Default.DebugServer);
                //MessageBox.Show(webDataDS);
            //}
        }

        private void getDSContent()
        {
            //Gets raw data from the project
            System.Net.WebClient wc = new System.Net.WebClient();

            //Using this in a try/catch so the program won't crash if there is no internet.
            try
            {
                System.Net.WebClient ginf = new System.Net.WebClient();

                byte[] raw = ginf.DownloadData("https://github.com/MexiMoo/DavinkiMannen/blob/master/DavinkiServerPush.txt");

                string webData = System.Text.Encoding.UTF8.GetString(raw);

                string GetLine(string text, int lineNo)
                {
                    string[] lines = text.Replace("\r", "").Split('\n');
                    return lines.Length >= lineNo ? lines[lineNo - 1] : null;
                }

                string onlineAppVersion = GetLine(webData, 20);
                CE_EDITOR.Text = GetLine(webData, 20);
                //MessageBox.Show(GetLine(webData, 20));
            }
            catch
            {
                var NI = new NI();
                NI.ShowDialog();
            }
        }

        private void doUpdate()
        {
            //Gets raw data from the project
            System.Net.WebClient wc = new System.Net.WebClient();

            //Using this in a try/catch so the program won't crash if there is no internet.
            try
            {
                System.Net.WebClient ginf = new System.Net.WebClient();

                byte[] raw = ginf.DownloadData("https://raw.githubusercontent.com/MexiMoo/DavinkiMannen/master/DavinkiData");

                string webData = System.Text.Encoding.UTF8.GetString(raw);

                string GetLine(string text, int lineNo)
                {
                    string[] lines = text.Replace("\r", "").Split('\n');
                    return lines.Length >= lineNo ? lines[lineNo - 1] : null;
                }

                string onlineAppVersion = GetLine(webData, 35);

                //Will ry to receive data from the app that is stored
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"MRO");
                if (key != null)
                {
                    var AppVersion = key.GetValue("Version");
                    key.Close();

                    //Removes unused revision number from version
                    string appVersionLocalRaw = (string)AppVersion.ToString();
                    string appVersionLocal = appVersionLocalRaw.Remove(appVersionLocalRaw.Length - 2);

                    //Compares the versions
                    if (appVersionLocal != onlineAppVersion)
                    {
                        //update
                        MessageBox.Show("There is an update!");
                        Process.Start("https://github.com/MexiMoo/DavinkiMannen/releases/latest");
                    }
                    else
                    {
                        //Do nothing
                    }
                }
            }
            catch
            {
                var NI = new NI();
                NI.ShowDialog();
            }
        }

        private void BTNLab()
        {
            System.Net.WebClient ginf = new System.Net.WebClient();

            byte[] raw = ginf.DownloadData("https://raw.githubusercontent.com/MexiMoo/DavinkiMannen/master/DavinkiData");

            string webData = System.Text.Encoding.UTF8.GetString(raw);

            string GetLine(string text, int lineNo)
            {
                string[] lines = text.Replace("\r", "").Split('\n');
                return lines.Length >= lineNo ? lines[lineNo - 1] : null;
            }

            BTN1.Text = GetLine(webData, 16);
            BTN2.Text = GetLine(webData, 17);
            BTN3.Text = GetLine(webData, 18);
            BTN4.Text = GetLine(webData, 19);
            BTN5.Text = GetLine(webData, 20);
            this.Text = GetLine(webData, 23);
            Logo.ImageLocation = GetLine(webData, 29);
            Foto.ImageLocation = GetLine(webData, 26);
            CE_T.Text = GetLine(webData, 32);
            Link = GetLine(webData, 38);
            
            try
            {
                WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
                wplayer.URL = "BG.mp3";
                wplayer.controls.play();

                using (var client = new WebClient())
                {
                    client.DownloadFile(GetLine(webData, 35), "Icon.ico");
                }

                using (var stream = File.OpenRead("Icon.ico"))
                {
                    this.Icon = new Icon(stream);

                    trayIcon = new NotifyIcon()
                    {
                        Icon = new Icon(stream),
                        ContextMenu = new ContextMenu(new MenuItem[] {
                            new MenuItem("Driven Compiler")
                        }),
                        Visible = true
                    };
                }
            }
            catch
            {
                //Nothing
            }
        }


        private void BTN1_Click(object sender, EventArgs e)
        {
            TC.Visible = true;
            TC.SelectedIndex = 0;
        }

        private void BTN2_Click(object sender, EventArgs e)
        {
            TC.Visible = true;
            TC.SelectedIndex = 1;
        }

        public void BTN3_Click(object sender, EventArgs e)
        {
            Process.Start(Link);
        }

        private void BTN4_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/MexiMoo/DavinkiMannen/blob/master/DavinkiData");
        }

        private void PT_SEND_L_MouseClick(object sender, MouseEventArgs e)
        {
            PT_SEND_L.Checked = true;
            PT_SEND_P.Checked = false;
        }

        private void PT_SEND_P_MouseClick(object sender, MouseEventArgs e)
        {
            PT_SEND_L.Checked = false;
            PT_SEND_P.Checked = true;
        }

        private async void PT_Send_Click(object sender, EventArgs e)
        {
            if (PT_SEND_L.Checked == true)
            {
                string DST_V = "alleen deze PC";
                DATA_SENT_TITLE.Text = ("De data is verzonden naar " + DST_V + " met sucess!");
                PT_Send_Done.Visible = true;
            }
            else 
            {
                try
                {
                    var owner = "MexiMoo";
                    var repo = "DavinkiMannen";
                    var branch = "master";
                    var github = new GitHubClient(new ProductHeaderValue("AppData"));
                    github.Credentials = new Credentials(GithubToken);

                    var currentFileText = "";

                    var contents = await github.Repository.Content.GetAllContentsByRef(owner, repo, "DavinkiServerPush.txt", branch);
                    var targetFile = contents[0];
                    if (targetFile.EncodedContent != null)
                    {
                        currentFileText = Encoding.UTF8.GetString(Convert.FromBase64String(targetFile.EncodedContent));
                    }
                    else
                    {
                        currentFileText = targetFile.Content;
                    }

                    int result = 0;
                    var newFileText = string.Format(PT_TEXT_TB.Text.ToString());
                    var updateRequest = new UpdateFileRequest("DVM App Debug Push", newFileText, targetFile.Sha, branch);

                    var updatefile = await github.Repository.Content.UpdateFile(owner, repo, "DavinkiServerPush.txt", updateRequest);

                    string DST_V = "alle verbonden PC's";
                    DATA_SENT_TITLE.Text = ("De data is verzonden naar " + DST_V + " met sucess!");
                    PT_Send_Done.Visible = true;
                }
                catch
                {
                    var NI = new NI();
                    NI.ShowDialog();
                }
            }
        }

        private void DATA_SENT_B_Click(object sender, EventArgs e)
        {
            PT_Send_Done.Visible = false;
        }

        private void Tab_MouseClick(object sender, MouseEventArgs e)
        {
            if (Tab.SelectedTab == TB2)
            {
                TC.Visible = true;
                TC.SelectedIndex = 2;
                MessageBox.Show("This is an old debug page you found! This page is no longer in use by the program but still presists.");
                TC.SelectedIndex = 0;
                Tab.Visible = false;
                Tab.SelectedTab = TB1;
            }
            else
            {
                TC.Visible = false;
            }
        }

        private async void CE_SEND_Click(object sender, EventArgs e)
        {
            CE_RTV.Enabled = false;
            CE_SEND_LB.Visible = true;
            tmr = new System.Windows.Forms.Timer();
            tmr.Tick += delegate {
                CE_SEND_LB.ForeColor = Color.Lime;
                CE_SEND_LB.Text = "Code Opgeslagen!";
                CE_SEND_LB.Visible = false;
                CE_RTV.Enabled = true;
            };
            tmr.Interval = (int)TimeSpan.FromSeconds(5).TotalMilliseconds;
            tmr.Start();

            try
            {
                var owner = "MexiMoo";
                var repo = "DavinkiMannen";
                var branch = "master";
                var github = new GitHubClient(new ProductHeaderValue("AppData"));
                github.Credentials = new Credentials(GithubToken);

                var currentFileText = "";

                var contents = await github.Repository.Content.GetAllContentsByRef(owner, repo, "EditorData.txt", branch);
                var targetFile = contents[0];
                if (targetFile.EncodedContent != null)
                {
                    currentFileText = Encoding.UTF8.GetString(Convert.FromBase64String(targetFile.EncodedContent));
                }
                else
                {
                    currentFileText = targetFile.Content;
                }

                int result = 0;
                var newFileText = string.Format(CE_EDITOR.Text.ToString());
                var updateRequest = new UpdateFileRequest("DVM App Editor Push", newFileText, targetFile.Sha, branch);

                var updatefile = await github.Repository.Content.UpdateFile(owner, repo, "EditorData.txt", updateRequest);
            }
            catch
            {
                var NI = new NI();
                NI.ShowDialog();
            }
        }

        private void CE_RTV_Click(object sender, EventArgs e)
        {
            CE_SEND.Enabled = false;
            CE_SEND_LB.Visible = true;
            tmr = new System.Windows.Forms.Timer();
            tmr.Tick += delegate {
                CE_SEND_LB.ForeColor = Color.Lime;
                CE_SEND_LB.Text = "Code Ververst!";
                CE_SEND_LB.Visible = false;
                CE_SEND.Enabled = true;
            };
            tmr.Interval = (int)TimeSpan.FromSeconds(5).TotalMilliseconds;
            tmr.Start();

            try
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                string webData = wc.DownloadString("https://raw.githubusercontent.com/MexiMoo/DavinkiMannen/master/EditorData.txt");
                CE_EDITOR.Text = webData;
            }
            catch
            {
                var NI = new NI();
                NI.ShowDialog();
            }
        }

        private void PT_IMAGE_B_Click(object sender, EventArgs e)
        {
            //ControlID.ImageData = PT_TEXT_TB.Text;
            using (Text PVI = new Text())
            {
                if (PVI.ShowDialog() == DialogResult.OK)
                {
                    //Data already called!
                }
            }
        }

        private void PT_VIDEO_B_Click(object sender, EventArgs e)
        {
            Video.ControlID.VideoData = PT_TEXT_TB.Text;
            using (Video PVV = new Video())
            {
                if (PVV.ShowDialog() == DialogResult.OK)
                {
                    //Data already called!
                }
            }
        }

        private void PT_TEXT_B_Click(object sender, EventArgs e)
        {
            var PVT = new Text();
            PVT.ShowDialog();
        }

        public void Logo_Click(object sender, EventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sInfo_Click(object sender, EventArgs e)
        {
            var INF = new About();
            INF.ShowDialog();
        }

        private void BTN5_Click(object sender, EventArgs e)
        {
            TC.Visible = true;
            TC.SelectedIndex = 3;
        }

        private void Logo_DoubleClick(object sender, EventArgs e)
        {
            var INF = new About();
            INF.ShowDialog();
        }

        private void panel3_DoubleClick(object sender, EventArgs e)
        {
            Tab.Visible = true;
        }

        private void HPNL_Settings_Click(object sender, EventArgs e)
        {
            var STG = new Settings();
            STG.ShowDialog();
        }
    }
}
