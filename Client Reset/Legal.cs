using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using System.Management;
using MaterialSkin.Controls;
using Client_Reset.Properties;

namespace Client_Reset
{
    public partial class Legal : MaterialForm
    {
        public Legal()
        {
            InitializeComponent();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            Settings.Default.acceptedEULA = "Yes";
            materialTabControl1.SelectedTab = tabPage2;
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            Settings.Default.acceptedMIT = "Yes";
            materialTabControl1.SelectedTab = tabPage3;
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            Settings.Default.acceptedDisclaimer = "Yes";
            Settings.Default.acceptedLicnese = "Yes";
            Settings.Default.Save();
            System.Diagnostics.Process.Start(Application.StartupPath + @"\Client Reset.exe");
            Application.Exit();
        }
    }
}
