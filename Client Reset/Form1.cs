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
using Client_Reset.Properties;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Client_Reset
{
    public partial class Form1 : MaterialForm
    {
        MaterialSkinManager ThemeManager = MaterialSkinManager.Instance;
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        public enum DeviceCap
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117,
            LOGPIXELSY = 90,
        }


        private float getScalingFactor()
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            int LogicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.VERTRES);
            int PhysicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);

            float ScreenScalingFactor = (float)PhysicalScreenHeight / (float)LogicalScreenHeight;

            return ScreenScalingFactor; // 1.25 = 125%
            
        }
        public Form1()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Settings.Default.themeMode == "Light")
            {
                ThemeManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            else {
                ThemeManager.Theme = MaterialSkinManager.Themes.DARK;
            }


            if (Settings.Default.themeColor == "Default")
            {
                ThemeManager.ColorScheme = new ColorScheme(Primary.DeepOrange600, Primary.Grey900, Primary.DeepOrange600, Accent.DeepOrange400, TextShade.WHITE);
            }
            if (Settings.Default.themeColor == "Yellow")
            {
                ThemeManager.ColorScheme = new ColorScheme(Primary.Yellow600, Primary.Grey900, Primary.Yellow600, Accent.Yellow400, TextShade.BLACK);
            }
            if (Settings.Default.themeColor == "Red")
            {
                ThemeManager.ColorScheme = new ColorScheme(Primary.Red600, Primary.Grey900, Primary.Red600, Accent.Red400, TextShade.WHITE);
            }
            if (Settings.Default.themeColor == "Green")
            {
                ThemeManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Grey900, Primary.Green600, Accent.Green400, TextShade.WHITE);
            }
            if (Settings.Default.themeColor == "Blue")
            {
                ThemeManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Grey900, Primary.Blue600, Accent.Blue400, TextShade.WHITE);
            }
            if (Settings.Default.themeColor == "Purple")
            {
                ThemeManager.ColorScheme = new ColorScheme(Primary.DeepPurple600, Primary.Grey900, Primary.DeepPurple600, Accent.DeepPurple400, TextShade.WHITE);
            }


            this.Text = "Client Reset Tool - By: INSTINCT";

            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            int LogicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.VERTRES);
            int PhysicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);
            int logpixelsy = GetDeviceCaps(desktop, (int)DeviceCap.LOGPIXELSY);
            float screenScalingFactor = (float)PhysicalScreenHeight / (float)LogicalScreenHeight;
            float dpiScalingFactor = (float)logpixelsy / (float)96;

            if (screenScalingFactor > 1 ||
                dpiScalingFactor > 1)
            {
                // do something nice for people who can't see very well...
                MessageBox.Show("Error: DPI0x00\n\nSystem Scaling has been detected and is above 100%.\nClient Reset does not support System Scaling. Please change your scaling back to 100% or resize Client Reset manually!","System Scaling Detected",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Visible = false;
          
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            SettingsForm SettingsFRM = new SettingsForm();

            SettingsFRM.ShowDialog(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Settings.Default.enableResetAll == "Enabled")
            {
                materialButton10.Visible = true;
            }
            else {
                materialButton10.Visible = false;
            }
        }
        private void wait(int seconds)
        {
            for (int i = 0; i <= seconds * 100; i++)
            {
                System.Threading.Thread.Sleep(10);
                Application.DoEvents();
            }
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Visible = true;
            if (Settings.Default.firstTimeRunning == "1")
            {
                onboarding ob = new onboarding();
               // ob.ShowDialog(this);

            }
            Application.DoEvents();
            wait(2);
            
        }

        private void materialButton9_Click(object sender, EventArgs e)
        {
            
        }
    }
}
