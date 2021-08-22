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
    public partial class changelog : MaterialForm
    {
        public changelog()
        {
            InitializeComponent();
            
        }

        private async void changelog_Load(object sender, EventArgs e)
        {
            webView21.InitializeLifetimeService();
            await webView21.EnsureCoreWebView2Async(null);
            webView21.CoreWebView2.Navigate("https://jacobbrookhouse.me/downloads/server2/product/clientreset/data/changelog.html");
        }
    }
}
