using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DHCI
{
    public partial class NI : Form
    {
        public NI()
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
        }

        private void NI_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1000);
        }
    }
}
