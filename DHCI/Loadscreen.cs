using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DHCI
{
    partial class Loadscreen : Form
    {
        private System.Windows.Forms.Timer tmr;

        public Loadscreen()
        {
            InitializeComponent();
            if (Properties.Settings.Default.Darkmode == true)
            {
                this.BackColor = Color.FromArgb(36, 36, 36);
            }
            else
            {
                this.BackColor = SystemColors.Control;
            }

            System.Net.WebClient ginf = new System.Net.WebClient();
            

            try
            {
                byte[] raw = ginf.DownloadData("https://raw.githubusercontent.com/MexiMoo/DavinkiMannen/master/DavinkiData");
                CI();
            }
            catch
            {
                var NI = new NI();
                NI.ShowDialog();
            }

        void CI()
            {
                byte[] raw = ginf.DownloadData("https://raw.githubusercontent.com/MexiMoo/DavinkiMannen/master/DavinkiData");
                string webData = System.Text.Encoding.UTF8.GetString(raw);

                string GetLine(string text, int lineNo)
                {
                    string[] lines = text.Replace("\r", "").Split('\n');
                    return lines.Length >= lineNo ? lines[lineNo - 1] : null;
                }

                Title.Text = GetLine(webData, 4);
                Description.Text = GetLine(webData, 10);
                VSN.Text = GetLine(webData, 7);
                Logo.ImageLocation = GetLine(webData, 13);

                LB.Value = LoadTimer.Interval;
                LB.Value = LoadTimer.Interval;
                LB.Value = LoadTimer.Interval;

                tmr = new System.Windows.Forms.Timer();
                tmr.Tick += delegate {
                    tmr.Stop();
                    this.Hide();
                    var form2 = new Home();
                    form2.ShowDialog();
                };
                tmr.Interval = (int)TimeSpan.FromSeconds(6).TotalMilliseconds;
                tmr.Start();
            }
        }
    }
}
