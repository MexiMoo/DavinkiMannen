using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DHCI
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            if (Properties.Settings.Default.AutoStart == true)
            {
                st_AS.Checked = true;
            }
            else if (Properties.Settings.Default.AutoStart == false)
            {
                st_AS.Checked = false;
            }

            SetStartup();
        }

        private void SetStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (Properties.Settings.Default.AutoStart == true)
                rk.SetValue("DHCI", Application.ExecutablePath);
            else
                rk.DeleteValue("DHCI", false);

        }

        private void st_TP_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void st_AS_CheckedChanged(object sender, EventArgs e)
        {
            if (st_AS.Checked == true)
            {
                Properties.Settings.Default.AutoStart = true;
                Properties.Settings.Default.Save();
            }
            else if (st_AS.Checked == false)
            {
                Properties.Settings.Default.AutoStart = false;
                Properties.Settings.Default.Save();
            }
        }
    }
}
