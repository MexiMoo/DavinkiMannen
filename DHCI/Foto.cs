using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DHCI
{
    public partial class Foto : Form
    {
        public static class ControlID
        {
            public static string ImageData { get; set; }
        }

        public Foto()
        {
            InitializeComponent();

            Image.ImageLocation = ControlID.ImageData;

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
                    client.DownloadFile(GetLine(webData, 34), "Icon.ico");
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
    }
}
