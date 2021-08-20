using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Client_Reset
{
    public partial class onboarding : MaterialForm
    {
        public onboarding()
        {
            InitializeComponent();
        }

        private void onboarding_Load(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialButton1_Click_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.firstTimeRunning = "0";
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
