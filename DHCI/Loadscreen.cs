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

            //Gets raw data from the project
            System.Net.WebClient ginf = new System.Net.WebClient();

            //Using this in a <try/catch> so the program won't crash if there is no internet.
            byte[] raw = ginf.DownloadData("https://pastebin.com/raw/TpE9d9h4");

            string webData = System.Text.Encoding.UTF8.GetString(raw);

            //Extracts one line
            string GetLine(string text, int lineNo)
            {
                string[] lines = text.Replace("\r", "").Split('\n');
                return lines.Length >= lineNo ? lines[lineNo - 1] : null;
            }

            Title.Text = GetLine(webData, 2);
            Description.Text = GetLine(webData, 8);
            VSN.Text = GetLine(webData, 5);
            Logo.ImageLocation = "https://" + GetLine(webData, 11);

            LB.Value = LoadTimer.Interval;
            LB.Value = LoadTimer.Interval;
            LB.Value = LoadTimer.Interval;

            this.Hide();
            var form2 = new Home();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}
