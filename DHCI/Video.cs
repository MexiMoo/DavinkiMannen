using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DHCI
{
    public partial class Video : Form
    {
        public static class ControlID
        {
            public static string VideoData { get; set; }
        }

        public Video()
        {
            InitializeComponent();

            //PlayFile(ControlID.VideoData);
            PlayFile(@"c:\myaudio.wma");

            System.Net.WebClient ginf = new System.Net.WebClient();

            byte[] raw = ginf.DownloadData("https://raw.githubusercontent.com/MexiMoo/DavinkiMannen/master/DavinkiData");

            string webData = System.Text.Encoding.UTF8.GetString(raw);

            string GetLine(string text, int lineNo)
            {
                string[] lines = text.Replace("\r", "").Split('\n');
                return lines.Length >= lineNo ? lines[lineNo - 1] : null;
            }

            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(GetLine(webData, 35), "Icon.ico");
                }

                using (var stream = File.OpenRead("Icon.ico"))
                {
                    this.Icon = new Icon(stream);
                }
            }
            catch
            {
                //Nothing
            }
        }

        WMPLib.WindowsMediaPlayer Player;

        private void PlayFile(String url)
        {
            Player = new WMPLib.WindowsMediaPlayer();
            Player.PlayStateChange +=
                new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
            Player.MediaError +=
                new WMPLib._WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);
            Player.URL = url;
            Player.controls.play();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            // TODO  Insert a valid path in the line below.
            PlayFile(@"c:\myaudio.wma");
        }

        private void Player_PlayStateChange(int NewState)
        {
            if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsStopped)
            {
                this.Close();
            }
        }

        private void Player_MediaError(object pMediaObject)
        {
            var NI = new NI();
            NI.ShowDialog();
        }
    }
}
