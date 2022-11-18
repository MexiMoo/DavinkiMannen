using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DHCI
{
    public partial class Home : Form
    {
        public Home()
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

            BTNLab();
        }

        private void BTNLab()
        {

        }

        private void BTN1_Click(object sender, EventArgs e)
        {

        }

        private void BTN2_Click(object sender, EventArgs e)
        {

        }

        private void BTN3_Click(object sender, EventArgs e)
        {

        }

        private void BTN4_Click(object sender, EventArgs e)
        {

        }
    }
}
