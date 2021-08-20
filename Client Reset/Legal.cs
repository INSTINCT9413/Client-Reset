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
using MaterialSkin.Controls;

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
            materialTabControl1.SelectedTab = tabPage2;
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedTab = tabPage3;
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
