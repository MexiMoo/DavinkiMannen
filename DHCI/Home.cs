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
using static DHCI.Foto;
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

namespace DHCI
{
    partial class Home : Form
    {
        private Timer tmr;
        private DownloadProgressChangedEventHandler wc_DownloadProgressChanged;
        private NotifyIcon trayIcon;

        public string Link { get; private set; }

        public Home()
        {
            InitializeComponent();
            if (Properties.Settings.Default.Darkmode == true)
            {
                this.BackColor = Color.FromArgb(36, 36, 36);
                ADM.BackColor = Color.FromArgb(36, 36, 36);
                PT.BackColor = Color.FromArgb(50, 50, 50);
                CE.BackColor = Color.FromArgb(36, 36, 36);
            }
            else
            {
                this.BackColor = SystemColors.Control;
                ADM.BackColor = SystemColors.Control;
                PT.BackColor = SystemColors.Control;
                CE.BackColor = SystemColors.Control;
            }

            BTNLab();
            TrayMenuContext();

            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(10);

            var timer = new System.Threading.Timer((e) =>
            {
                doUpdate();
            }, null, startTimeSpan, periodTimeSpan);

            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"MRO");
            key.SetValue("Version", version);
            key.Close();
        }

        private void TrayMenuContext()
        {
            this.notifyIcon1.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.notifyIcon1.ContextMenuStrip.Items.Add("About SystemIntergratedCycliManager...", null, (s, e) => MessageBox.Show("Null"));
        }

        private void doUpdate()
        {
            //Gets raw data from the project
            System.Net.WebClient wc = new System.Net.WebClient();

            //Using this in a try/catch so the program won't crash if there is no internet.
            try
            {
                byte[] raw = wc.DownloadData("https://raw.githubusercontent.com/MexiMoo/DavinkiMannen/master/DHCI/DHCI.csproj");
                string webData = System.Text.Encoding.UTF8.GetString(raw);

                //Extracts one line
                string GetLine(string text, int lineNo)
                {
                    string[] lines = text.Replace("\r", "").Split('\n');
                    return lines.Length >= lineNo ? lines[lineNo - 1] : null;
                }

                //Filters out the junk
                int startPos = webData.LastIndexOf("    <Version>") + "    <Version>".Length;
                int length = webData.IndexOf("</Version>") - startPos;
                string onlineAppVersion = webData.Substring(startPos, length);

                //Will ry to receive data from the app that is stored
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"MRO");
                if (key != null)
                {
                    var AppIsInstalled = key.GetValue("SMPbetaInstalled");
                    var AppVersion = key.GetValue("Version");
                    key.Close();

                    //Removes unused revision number from version
                    string appVersionLocalRaw = (string)AppVersion.ToString();
                    string appVersionLocal = appVersionLocalRaw.Remove(appVersionLocalRaw.Length - 2);

                    //Compares the versions
                    if (appVersionLocal != onlineAppVersion)
                    {

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
            this.Text = GetLine(webData, 22);
            Logo.ImageLocation = GetLine(webData, 28);
            Foto.ImageLocation = GetLine(webData, 25);
            CE_T.Text = GetLine(webData, 31);
            Link = GetLine(webData, 37);
            
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(GetLine(webData, 34), "Icon.ico");
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

        private void ADM_Click(object sender, EventArgs e)
        {
            Tab.Visible = true;
        }

        private void PT_IMAGE_RB_MouseClick(object sender, MouseEventArgs e)
        {
            PT_VIDEO_RB.Checked = false;
            PT_TEXT_RB.Checked = false;
            PT_IMAGE_RB.Checked = true;
        }

        private void PT_VIDEO_RB_MouseClick(object sender, MouseEventArgs e)
        {
            PT_IMAGE_RB.Checked = false;
            PT_TEXT_RB.Checked = false;
            PT_VIDEO_RB.Checked = true;
        }

        private void PT_TEXT_RB_MouseClick(object sender, MouseEventArgs e)
        {
            PT_IMAGE_RB.Checked = false;
            PT_VIDEO_RB.Checked = false;
            PT_TEXT_RB.Checked = true;
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

        private void PT_Send_Click(object sender, EventArgs e)
        {
            if (PT_SEND_L.Checked == true)
            {
                string DST_V = "alleen deze PC";
                DATA_SENT_TITLE.Text = ("De data is verzonden naar " + DST_V + " met sucess!");
                PT_Send_Done.Visible = true;
            }
            else 
            {
                string DST_V = "alle verbonden PC's";
                DATA_SENT_TITLE.Text = ("De data is verzonden naar " + DST_V + " met sucess!");
                PT_Send_Done.Visible = true;
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
                github.Credentials = new Credentials("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");

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
            ControlID.ImageData = PT_IMAGE_TB.Text;
            using (Foto PVI = new Foto())
            {
                if (PVI.ShowDialog() == DialogResult.OK)
                {
                    //Data already called!
                }
            }
        }

        private void PT_VIDEO_B_Click(object sender, EventArgs e)
        {
            Video.ControlID.VideoData = PT_VIDEO_TB.Text;
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
            var PVT = new Foto();
            PVT.ShowDialog();
        }
    }
}
