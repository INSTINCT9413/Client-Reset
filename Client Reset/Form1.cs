using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client_Reset.Properties;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.VisualBasic;

namespace Client_Reset
{

    public partial class Form1 : MaterialForm
    {
        private Process[] p;
        //Get System Drive
        static string sysDisk = System.IO.Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
        //Get System User
        static string user = Environment.UserName;
        string FileDownloaded = "";

        //BATTLE.NET Directories
        string BNInstaller = "https://us.battle.net/download/getInstaller?os=win&installer=Battle.net-Setup.exe";
        string BNMain = sysDisk + @"Program Files (x86)\Battle.net\Battle.net.exe";
        string BNUninstall = sysDisk + @"Program Files (x86)\Battle.net\";
        string AppDataBNLC = sysDisk + @"Users\" + user + @"\AppData\Local\Battle.net\Logs";
        string BE = sysDisk + @"ProgramData\Blizzard Entertainment";
        string AppDataBN = sysDisk + @"Users\" + user + @"\AppData\Local\Battle.net\Cache";
        string AppDataBNL = sysDisk + @"Users\" + user + @"\AppData\Local\Battle.net\Logs";

        //BETHESDA LAUNCHER Directories
        string BLInstaller = "https://download.cdp.bethesda.net/BethesdaNetLauncher_Setup.exe";
        string BMain = sysDisk + @"Program Files (x86)\Bethesda.net Launcher\BethesdaNetLauncher.exe";
        string BUninstall = sysDisk + @"Program Files (x86)\Bethesda.net Launcher\unins000.exe";
        string BL = sysDisk + @"Users\" + user + @"\AppData\Local\Bethesda.net Launcher\cache";
        string BLL = sysDisk + @"Program Files (x86)\Bethesda.net Launcher\logs";

        //EPIC GAMES LAUNCER Directories
        string EGInstaller = "https://epicgames-download1.akamaized.net/Builds/UnrealEngineLauncher/Installers/Win32/EpicInstaller-12.1.7.msi";
        string EGMain = sysDisk + @"Program Files (x86)\Epic Games\Launcher\Engine\Binaries\Win64\EpicGamesLauncher.exe";
        string EG = sysDisk + @"ProgramData\Epic\EpicGamesLauncher\Data\EMS\EpicGamesLauncher";
        string EGCC = sysDisk + @"ProgramData\Epic\EpicGamesLauncher\Data\ContentCache";
        string EGL = sysDisk + @"Users\" + user + @"\AppData\Local\EpicGamesLauncher\Saved\Logs";
        string EGWEB = sysDisk + @"Users\" + user + @"\AppData\Local\EpicGamesLauncher\Saved\webcache_4147";

        //GOG GALAXY Directories
        string GOGInstaller = "https://webinstallers.gog-statics.com/download/GOG_Galaxy_2.0.exe";
        string GOGMain = sysDisk + @"Program Files (x86)\GOG Galaxy\GalaxyClient.exe";
        string GOGUninstall = sysDisk + @"Program Files (x86)\GOG Galaxy\unins000.exe";
        string GOGL = sysDisk + @"ProgramData\GOG.com\Galaxy\logs";
        string GOGWEB = sysDisk + @"ProgramData\GOG.com\Galaxy\webcache";

        //Origin Directories
        string OInstaller = "https://origin-a.akamaihd.net/Origin-Client-Download/origin/live/OriginThinSetup.exe";
        string OMain = sysDisk + @"Program Files (x86)\Origin\Origin.exe";
        string OUninstall = sysDisk + @"Program Files (x86)\Origin\OriginUninstall.exe";
        string AC = sysDisk + @"ProgramData\Origin\AchievementCache";
        string CC = sysDisk + @"ProgramData\Origin\CatalogCache";
        string CBC = sysDisk + @"ProgramData\Origin\CustomBoxartCache";
        string DC = sysDisk + @"ProgramData\Origin\DownloadCache";
        string EC = sysDisk + @"ProgramData\Origin\EntitlementCache";
        string IGOC = sysDisk + @"ProgramData\Origin\IGOCache";
        string Logs1 = sysDisk + @"ProgramData\Origin\Logs";
        string NOCC = sysDisk + @"ProgramData\Origin\NonOriginContentCache";
        string temp1 = sysDisk + @"temp\";
        string temp2 = sysDisk + @"Windows\Temp\";
        string temp3 = sysDisk + @"Users\" + user + @"\AppData\Local\Temp";
        string CC2 = sysDisk + @"Users\" + user + @"\AppData\Roaming\Origin\CatalogCache";
        string CS = sysDisk + @"Users\" + user + @"\AppData\Roaming\Origin\Cloud Saves";
        string CT = sysDisk + @"Users\" + user + @"\AppData\Roaming\Origin\CommonTitles";
        string CC3 = sysDisk + @"Users\" + user + @"\AppData\Roaming\Origin\ConsolidatedCache";
        string NC = sysDisk + @"Users\" + user + @"\AppData\Roaming\Origin\NucleusCache";
        string WU = sysDisk + @"Users\" + user + @"\AppData\Roaming\Origin\Widget Updates";
        string origin = sysDisk + @"Users\" + user + @"\AppData\Local\Origin";

        //STEAM Directories
        string SInstaller = "https://cdn.cloudflare.steamstatic.com/client/installer/SteamSetup.exe";
        string SMain = sysDisk + @"Program Files (x86)\Steam\steam.exe";
        string SUnintall = sysDisk + @"Program Files (x86)\Steam\uninstall.exe";
        string SL = sysDisk + @"Program Files (x86)\Steam\logs";
        string SDC = sysDisk + @"Program Files (x86)\Steam\depotcache";
        string SAC = sysDisk + @"Program Files (x86)\Steam\config\avatarcache";
        string SWEB = sysDisk + @"Users\" + user + @"AppData\Local\Steam\htmlcache";

        //UBISOFT CONNECT Directories
        string UInstaller = "https://ubistatic3-a.akamaihd.net/orbit/launcher_installer/UbisoftConnectInstaller.exe";
        string UMain = sysDisk + @"Program Files (x86)\Ubisoft\Ubisoft Game Launcher\UbisoftGameLauncher.exe";
        string UUninstall = sysDisk + @"Program Files (x86)\Ubisoft\Ubisoft Game Launcher\Uninstall.exe";
        string UCL = sysDisk + @"Program Files (x86)\Ubisoft\Ubisoft Game Launcher\logs";
        string UCA = sysDisk + @"Program Files (x86)\Ubisoft\Ubisoft Game Launcher\cache\assets";
        string UCAV = sysDisk + @"Program Files (x86)\Ubisoft\Ubisoft Game Launcher\cache\avatars";
        string UCWEB = sysDisk + @"Program Files (x86)\Ubisoft\Ubisoft Game Launcher\cache\http2";

        //WINDOWS STORE
        //None call WRESET.exe

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
        public void wc_DownloadProgressChanged(Object sender, DownloadProgressChangedEventArgs e)
        {
            bunifuCircleProgressbar1.Value = e.ProgressPercentage;
            materialLabel17.Text = e.ProgressPercentage.ToString() + "%";
            bunifuCircleProgressbar2.Value = e.ProgressPercentage;
            materialLabel18.Text = e.ProgressPercentage.ToString() + "%";
            bunifuCircleProgressbar3.Value = e.ProgressPercentage;
            materialLabel19.Text = e.ProgressPercentage.ToString() + "%";
            bunifuCircleProgressbar4.Value = e.ProgressPercentage;
            materialLabel20.Text = e.ProgressPercentage.ToString() + "%";
            bunifuCircleProgressbar5.Value = e.ProgressPercentage;
            materialLabel21.Text = e.ProgressPercentage.ToString() + "%";
            bunifuCircleProgressbar6.Value = e.ProgressPercentage;
            materialLabel22.Text = e.ProgressPercentage.ToString() + "%";
            bunifuCircleProgressbar7.Value = e.ProgressPercentage;
            materialLabel23.Text = e.ProgressPercentage.ToString() + "%";
        }
        public void AsyncDownloadDone(Object sender, AsyncCompletedEventArgs e)
        {
            bunifuCircleProgressbar1.Visible = false;
            materialLabel17.Visible = false;
            bunifuCircleProgressbar2.Visible = false;
            materialLabel18.Visible = false;
            bunifuCircleProgressbar3.Visible = false;
            materialLabel19.Visible = false;
            bunifuCircleProgressbar4.Visible = false;
            materialLabel20.Visible = false;
            bunifuCircleProgressbar5.Visible = false;
            materialLabel21.Visible = false;
            bunifuCircleProgressbar6.Visible = false;
            materialLabel22.Visible = false;
            bunifuCircleProgressbar7.Visible = false;
            materialLabel23.Visible = false;
            System.Diagnostics.Process.Start(Application.StartupPath + @"\data\downloads\installers\" + FileDownloaded);
        }
        public Form1()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);


        }
        private void WSClean()
        {
            materialLabel8.Visible = true;
            pictureBox16.Visible = true;
            materialLabel8.Text = "Stage 1 - 4";
            System.Diagnostics.Process.Start(Application.StartupPath + @"\data\scripts\INET.bat");
            wait(5);
            materialLabel8.Text = "Stage 2 - 4";
            System.Diagnostics.Process.Start(Application.StartupPath + @"\data\scripts\TASKKILLER.bat");
            wait(10);
            materialLabel8.Text = "Stage 3 - 4";
            System.Diagnostics.Process.Start(Application.StartupPath + @"\data\scripts\USLESSTASK.bat");
            wait(5);
            materialLabel8.Text = "Stage 4 - 4";
            System.Diagnostics.Process.Start(Application.StartupPath + @"\data\scripts\WSReset.exe");
            wait(10);
            materialLabel8.Text = "Reset Complete";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread worker = new Thread(new ThreadStart(() =>
            {
                LoadSettings();
                findLaunchers();
            }));
            worker.Start();
           

        }
        public void LoadSettings()
        {
            if (Settings.Default.acceptedLicnese == null || Settings.Default.acceptedLicnese == "No")
            {
                CheckForIllegalCrossThreadCalls = false;
                //this.Hide();
                //this.Visible = false;
                Legal LD = new Legal();
                LD.StartPosition = FormStartPosition.CenterScreen;
                LD.Show();

            }

            if (Settings.Default.themeMode == "Light")
            {
                ThemeManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            else
            {
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
            if (Settings.Default.startingTab == "Battle.net")
            {
                materialTabControl1.SelectedTab = tabPage1;
            }
            if (Settings.Default.startingTab == "Bethesda Launcher")
            {
                materialTabControl1.SelectedTab = tabPage2;
            }
            if (Settings.Default.startingTab == "Epic Games")
            {
                materialTabControl1.SelectedTab = tabPage3;
            }
            if (Settings.Default.startingTab == "GOG Galaxy")
            {
                materialTabControl1.SelectedTab = tabPage4;
            }
            if (Settings.Default.startingTab == "Origin")
            {
                materialTabControl1.SelectedTab = tabPage5;
            }
            if (Settings.Default.startingTab == "Steam")
            {
                materialTabControl1.SelectedTab = tabPage6;
            }
            if (Settings.Default.startingTab == "Ubisoft Connect")
            {
                materialTabControl1.SelectedTab = tabPage7;
            }
            if (Settings.Default.startingTab == "Windows Store")
            {
                materialTabControl1.SelectedTab = tabPage8;

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
                MessageBox.Show("Error: DPI0x00\n\nSystem Scaling has been detected and is above 100%.\nClient Reset does not support System Scaling. Please change your scaling back to 100% or resize Client Reset manually!", "System Scaling Detected", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Visible = true;
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
            else
            {
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
            Thread worker = new Thread(new ThreadStart(() =>
            {
                this.Visible = true;
                if (Settings.Default.firstTimeRunning == "1")
                {
                    onboarding ob = new onboarding();
                    ob.ShowDialog(this);

                }

                findLaunchers();

                Application.DoEvents();
                wait(2);
            }));
            worker.Start();
            

        }
        private void findLaunchers()
        {
            if (!System.IO.File.Exists(UMain))
            {
                materialButton11.Icon = Properties.Resources._3688454_find_lens_search_magnifier_magnifying_icon;
                materialButton12.Icon = Properties.Resources._3688524_arrow_bottom_arrows_direction_down_icon;
                materialButton11.Tag = "0";
                materialButton12.Tag = "0";
                materialButton8.Enabled = false;
            }
            else
            {
                materialButton11.Icon = Properties.Resources._3688505_check_done_right_accept_ok_icon;
                materialButton12.Icon = Properties.Resources._3688440_delete_remove_trash_bin_dustbin_icon;
                materialButton11.Tag = "1";
                materialButton12.Tag = "1";
                materialButton8.Enabled = true;
            }
            if (!System.IO.File.Exists(BNMain))
            {
                materialButton14.Icon = Properties.Resources._3688454_find_lens_search_magnifier_magnifying_icon;
                materialButton13.Icon = Properties.Resources._3688524_arrow_bottom_arrows_direction_down_icon;
                materialButton14.Tag = "0";
                materialButton13.Tag = "0";
                materialButton2.Enabled = false;
            }
            else
            {
                materialButton14.Icon = Properties.Resources._3688505_check_done_right_accept_ok_icon;
                materialButton13.Icon = Properties.Resources._3688440_delete_remove_trash_bin_dustbin_icon;
                materialButton14.Tag = "1";
                materialButton13.Tag = "1";
                materialButton2.Enabled = true;
            }
            if (!System.IO.File.Exists(BMain))
            {
                materialButton16.Icon = Properties.Resources._3688454_find_lens_search_magnifier_magnifying_icon;
                materialButton15.Icon = Properties.Resources._3688524_arrow_bottom_arrows_direction_down_icon;
                materialButton16.Tag = "0";
                materialButton15.Tag = "0";
                materialButton3.Enabled = false;
            }
            else
            {
                materialButton16.Icon = Properties.Resources._3688505_check_done_right_accept_ok_icon;
                materialButton15.Icon = Properties.Resources._3688440_delete_remove_trash_bin_dustbin_icon;
                materialButton16.Tag = "1";
                materialButton15.Tag = "1";
                materialButton3.Enabled = true;
            }
            if (!System.IO.File.Exists(EGMain))
            {
                materialButton18.Icon = Properties.Resources._3688454_find_lens_search_magnifier_magnifying_icon;
                materialButton17.Icon = Properties.Resources._3688524_arrow_bottom_arrows_direction_down_icon;
                materialButton18.Tag = "0";
                materialButton17.Tag = "0";
                materialButton4.Enabled = false;
            }
            else
            {
                materialButton18.Icon = Properties.Resources._3688505_check_done_right_accept_ok_icon;
                materialButton17.Icon = Properties.Resources._3688440_delete_remove_trash_bin_dustbin_icon;
                materialButton18.Tag = "1";
                materialButton17.Tag = "1";
                materialButton4.Enabled = true;
            }
            if (!System.IO.File.Exists(GOGMain))
            {
                materialButton20.Icon = Properties.Resources._3688454_find_lens_search_magnifier_magnifying_icon;
                materialButton19.Icon = Properties.Resources._3688524_arrow_bottom_arrows_direction_down_icon;
                materialButton20.Tag = "0";
                materialButton19.Tag = "0";
                materialButton5.Enabled = false;
            }
            else
            {
                materialButton20.Icon = Properties.Resources._3688505_check_done_right_accept_ok_icon;
                materialButton19.Icon = Properties.Resources._3688440_delete_remove_trash_bin_dustbin_icon;
                materialButton20.Tag = "1";
                materialButton19.Tag = "1";
                materialButton5.Enabled = true;
            }
            if (!System.IO.File.Exists(OMain))
            {
                materialButton22.Icon = Properties.Resources._3688454_find_lens_search_magnifier_magnifying_icon;
                materialButton21.Icon = Properties.Resources._3688524_arrow_bottom_arrows_direction_down_icon;
                materialButton22.Tag = "0";
                materialButton21.Tag = "0";
                materialButton6.Enabled = false;
            }
            else
            {
                materialButton22.Icon = Properties.Resources._3688505_check_done_right_accept_ok_icon;
                materialButton21.Icon = Properties.Resources._3688440_delete_remove_trash_bin_dustbin_icon;
                materialButton22.Tag = "1";
                materialButton21.Tag = "1";
                materialButton6.Enabled = true;
            }
            if (!System.IO.File.Exists(SMain))
            {
                materialButton24.Icon = Properties.Resources._3688454_find_lens_search_magnifier_magnifying_icon;
                materialButton23.Icon = Properties.Resources._3688524_arrow_bottom_arrows_direction_down_icon;
                materialButton24.Tag = "0";
                materialButton23.Tag = "0";
                materialButton7.Enabled = false;
            }
            else
            {
                materialButton24.Icon = Properties.Resources._3688505_check_done_right_accept_ok_icon;
                materialButton23.Icon = Properties.Resources._3688440_delete_remove_trash_bin_dustbin_icon;
                materialButton24.Tag = "1";
                materialButton23.Tag = "1";
                materialButton7.Enabled = true;
            }
        }

        private void materialButton9_Click(object sender, EventArgs e)
        {
            WSClean();
        }

        private void materialButton11_Click(object sender, EventArgs e)
        {
            if (materialButton11.Tag.ToString() == "0")
            {
                MessageBox.Show("Not found");
            }
            else
            {
                MessageBox.Show("Found");
            }
        }

        private void materialButton12_Click(object sender, EventArgs e)
        {
            if (materialButton12.Tag.ToString() == "0")
            {
                var messUCINSTALL = MessageBox.Show("Ubisoft Connect could not be found! Would you like to download and install it now?", "Ubisoft Connect not found!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (messUCINSTALL == DialogResult.Yes)
                {
                    materialLabel17.Visible = true;
                    bunifuCircleProgressbar1.Value = 0;
                    bunifuCircleProgressbar1.Visible = true;
                    FileDownloaded = "Ubisoft Setup.exe";

                    using (WebClient wc = new WebClient())
                    {
                        wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                        wc.DownloadFileCompleted += new AsyncCompletedEventHandler(AsyncDownloadDone);
                        wc.DownloadFileAsync(new System.Uri(UInstaller), Application.StartupPath + @"\data\downloads\installers\Ubisoft Setup.exe");

                     
                    }
                }
            }
            else
            {
                var messU = MessageBox.Show("You are about to uninstall are you sure", "Uninstall", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (messU == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(UUninstall);
                }
            }
        }

        private void materialButton14_Click(object sender, EventArgs e)
        {
            if (materialButton14.Tag.ToString() == "0")
            {
                MessageBox.Show("Not found");
            }
            else
            {
                MessageBox.Show("Found");
            }
        }

        private void materialButton13_Click(object sender, EventArgs e)
        {
            if (materialButton13.Tag.ToString() == "0")
            {
                var messBNINSTALL = MessageBox.Show("Battle.Net could not be found! Would you like to download and install it now?", "Battle.Net not found!", MessageBoxButtons .YesNo, MessageBoxIcon.Warning);
                if (messBNINSTALL == DialogResult.Yes)
                {
                    materialLabel23.Visible = true;
                    bunifuCircleProgressbar7.Value = 0;
                        bunifuCircleProgressbar7.Visible = true;
                        FileDownloaded = "Battle.net Setup.exe";
                        using (WebClient wc = new WebClient())
                        {
                            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(AsyncDownloadDone);
                            wc.DownloadFileAsync(new System.Uri(BNInstaller), Application.StartupPath + @"\data\downloads\installers\Battle.net Setup.exe");
                    }
                }
            }
            else
            {

                var messBN = MessageBox.Show("You are about to uninstall are you sure", "Uninstall", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (messBN == DialogResult.Yes)
                {
                    new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;
                        UninstallProgram("Battle.net");
                    }).Start();
                }

            }
        }
        private bool UninstallProgram(string ProgramName)
        {
            try
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher(
                  "SELECT * FROM Win32_Product WHERE Name = '" + ProgramName + "'");
                foreach (ManagementObject mo in mos.Get())
                {
                    try
                    {
                        if (mo["Name"].ToString() == ProgramName)
                        {
                            object hr = mo.InvokeMethod("Uninstall", null);
                            return (bool)hr;
                        }
                    }
                    catch (Exception ex)
                    {
                        //this program may not have a name property, so an exception will be thrown
                    }
                }

                //was not found...
                return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void materialButton16_Click(object sender, EventArgs e)
        {
            if (materialButton16.Tag.ToString() == "0")
            {
                MessageBox.Show("Not found");
            }
            else
            {
                MessageBox.Show("Found");
            }
        }

        private void materialButton15_Click(object sender, EventArgs e)
        {
            if (materialButton15.Tag.ToString() == "0")
            {
                var messBLINSTALL = MessageBox.Show("Bethesda Launcher could not be found! Would you like to download and install it now?", "Bethesda Launcher not found!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (messBLINSTALL == DialogResult.Yes)
                {
                    materialLabel22.Visible = true;
                    bunifuCircleProgressbar6.Value = 0;
                        bunifuCircleProgressbar6.Visible = true;
                        FileDownloaded = "Bethesda Setup.exe";
                        using (WebClient wc = new WebClient())
                        {
                            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(AsyncDownloadDone);
                            wc.DownloadFileAsync(new System.Uri(BLInstaller), Application.StartupPath + @"\data\downloads\installers\Bethesda Setup.exe");
                    }
                }
            }
            else
            {
                var messB = MessageBox.Show("You are about to uninstall are you sure", "Uninstall", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (messB == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(BUninstall);
                }
            }
        }

        private void materialButton18_Click(object sender, EventArgs e)
        {
            if (materialButton18.Tag.ToString() == "0")
            {
                MessageBox.Show("Not found");
            }
            else
            {
                MessageBox.Show("Found");
            }
        }

        private void materialButton17_Click(object sender, EventArgs e)
        {
            if (materialButton17.Tag.ToString() == "0")
            {
                var messEGINSTALL = MessageBox.Show("Epic Games could not be found! Would you like to download and install it now?", "Epic Games not found!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (messEGINSTALL == DialogResult.Yes)
                {
                    materialLabel21.Visible = true;
                    bunifuCircleProgressbar5.Value = 0;
                        bunifuCircleProgressbar5.Visible = true;
                        FileDownloaded = "Epic Setup.msi";
                        using (WebClient wc = new WebClient())
                        {
                            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(AsyncDownloadDone);
                            wc.DownloadFileAsync(new System.Uri(EGInstaller), Application.StartupPath + @"\data\downloads\installers\Epic Setup.msi");
                    }
                }
            }
            else
            {
                var messE = MessageBox.Show("You are about to uninstall are you sure", "Uninstall", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (messE == DialogResult.Yes)
                {
                    new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;
                        UninstallProgram("Epic Games Launcher");
                    }).Start();
                }
            }
        }

        private void materialButton20_Click(object sender, EventArgs e)
        {
            if (materialButton20.Tag.ToString() == "0")
            {
                MessageBox.Show("Not found");
            }
            else
            {
                MessageBox.Show("Found");
            }
        }

        private void materialButton19_Click(object sender, EventArgs e)
        {
            if (materialButton19.Tag.ToString() == "0")
            {
                var messGOGINSTALL = MessageBox.Show("GOG Galaxy could not be found! Would you like to download and install it now?", "GOG Galaxy not found!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (messGOGINSTALL == DialogResult.Yes)
                {
                    materialLabel20.Visible = true;
                    bunifuCircleProgressbar4.Value = 0;
                        bunifuCircleProgressbar4.Visible = true;
                        FileDownloaded = "GOG Setup.exe";
                        using (WebClient wc = new WebClient())
                        {
                            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(AsyncDownloadDone);
                            wc.DownloadFileAsync(new System.Uri(GOGInstaller), Application.StartupPath + @"\data\downloads\installers\GOG Setup.exe");
                    }
                }
            }
            else
            {
                var messGOG = MessageBox.Show("You are about to uninstall are you sure", "Uninstall", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (messGOG == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(GOGUninstall);
                }
            }
        }

        private void materialButton22_Click(object sender, EventArgs e)
        {
            if (materialButton22.Tag.ToString() == "0")
            {
                MessageBox.Show("Not found");
            }
            else
            {
                MessageBox.Show("Found");
            }
        }

        private void materialButton21_Click(object sender, EventArgs e)
        {
            if (materialButton21.Tag.ToString() == "0")
            {
                var messOINSTALL = MessageBox.Show("Origin could not be found! Would you like to download and install it now?", "Origin not found!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (messOINSTALL == DialogResult.Yes)
                {
                    materialLabel19.Visible = true;
                    bunifuCircleProgressbar3.Value = 0;
                        bunifuCircleProgressbar3.Visible = true;
                        FileDownloaded = "Origin Setup.exe";
                        using (WebClient wc = new WebClient())
                        {
                            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(AsyncDownloadDone);
                            wc.DownloadFileAsync(new System.Uri(OInstaller), Application.StartupPath + @"\data\downloads\installers\Origin Setup.exe");
                    }
                }
            }
            else
            {
                var messO = MessageBox.Show("You are about to uninstall are you sure", "Uninstall", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (messO == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(OUninstall);
                }
            }
        }

        private void materialButton24_Click(object sender, EventArgs e)
        {
            if (materialButton24.Tag.ToString() == "0")
            {
                MessageBox.Show("Not found");
            }
            else
            {
                MessageBox.Show("Found");
            }
        }

        private void materialButton23_Click(object sender, EventArgs e)
        {
            if (materialButton23.Tag.ToString() == "0")
            {
                var messSINSTALL = MessageBox.Show("Steam could not be found! Would you like to download and install it now?", "Steam not found!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (messSINSTALL == DialogResult.Yes)
                {
                        materialLabel18.Visible = true;
                        bunifuCircleProgressbar2.Value = 0;
                        bunifuCircleProgressbar2.Visible = true;
                        FileDownloaded = "Steam Setup.exe";
                        using (WebClient wc = new WebClient())
                        {
                            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(AsyncDownloadDone);
                            wc.DownloadFileAsync(new System.Uri(SInstaller), Application.StartupPath + @"\data\downloads\installers\Steam Setup.exe");
                        
                    }
                }
            }
            else
            {
                var messS = MessageBox.Show("You are about to uninstall are you sure", "Uninstall", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (messS == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(SUnintall);
                }
            }
        }

        private void materialButton25_Click(object sender, EventArgs e)
        {
            //Find code to reset Windows Store

            var messWS = MessageBox.Show("You are about to uninstall are you sure", "Uninstall", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (messWS == DialogResult.Yes)
            {
                var ps1File = @"data\scripts\WSREINSTALL.ps1";
                var startInfo = new ProcessStartInfo()
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy unrestricted -file \"{ps1File}\"",
                    UseShellExecute = false
                };
                Process.Start(startInfo);
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            findLaunchers();
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            materialLabel5.Visible = true;
            pictureBox13.Visible = true;
            p = Process.GetProcessesByName("Origin");
            if (p.Count() > 0)
            {
                MessageBox.Show("We detected that Origin is still open and we can't continue with the reset!" + Constants.vbNewLine + "We will try and close Origin for you!", "Can't Continue", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                try
                {

                }
                catch (Exception ex)
                {
                }
                try
                {
                    var proc1 = Process.GetProcessesByName("Origin");

                    for (int i = 0; i <= proc1.Count() - 1; i++)
                        proc1[i].CloseMainWindow();
                    foreach (Process w in p)
                    {
                        w.Kill();
                        w.WaitForExit();
                        w.Dispose();
                    }
                }
                catch (Exception ex)
                {
                }

                CheckForIllegalCrossThreadCalls = false;
                Thread worker = new Thread(new ThreadStart(() =>
                {
                    DeleteFilesOrigin();
                }));
                worker.Start();
            }
            else
            {
                try
                {
                    //Process.GetProcessesByName("OriginWebHelperService")(0).Kill();
                }
                catch (Exception ex)
                {
                }

                CheckForIllegalCrossThreadCalls = false;



                Thread worker = new Thread(new ThreadStart(() =>
                {
                    DeleteFilesOrigin();
                }));
                worker.Start();

            }
        }
        public void DeleteFilesOrigin()
{
    try
    {
        
        materialLabel5.Text = "Scanning for files...";
        wait(2);
        if (Directory.Exists(AC))
            Directory.Delete(AC, true);
        materialLabel5.Text = "Stage: 1 of 17";
        Thread.Sleep(1500);
        if (Directory.Exists(CC))
            Directory.Delete(CC, true);
         materialLabel5.Text = "Stage: 2 of 17";
        Thread.Sleep(1300);
        if (Directory.Exists(CBC))
            Directory.Delete(CBC, true);
        materialLabel5.Text = "Stage: 3 of 17";
        Thread.Sleep(1900);
        if (Directory.Exists(DC))
            Directory.Delete(DC, true);
        materialLabel5.Text = "Stage: 4 of 17";
        Thread.Sleep(1100);
        if (Directory.Exists(EC))
            Directory.Delete(EC, true);
        materialLabel5.Text = "Stage: 5 of 17";
        Thread.Sleep(1654);
        if (Directory.Exists(IGOC))
            Directory.Delete(IGOC, true);
        materialLabel5.Text = "Stage: 6 of 17";
        Thread.Sleep(1000);
        if (Directory.Exists(Logs1))
            Directory.Delete(Logs1, true);
        materialLabel5.Text = "Stage: 7 of 17";
        Thread.Sleep(1000);
        if (Directory.Exists(NOCC))
            Directory.Delete(NOCC, true);
        try
        {
            materialLabel5.Text = "Stage: 8 of 17";
            Thread.Sleep(1000);
            // If Directory.Exists(temp1) Then
            // Directory.Delete(temp1, True)
            // End If
            foreach (System.IO.FileInfo file in new System.IO.DirectoryInfo(temp1).GetFiles("*.*"))
            {
                // If (Now - file.CreationTime).Days > Now Then
                try
                {
                    file.Delete();
                }
                catch
                {
                }
            }
        }
        catch (Exception ex)
        {
        }
        materialLabel5.Text = "Stage: 9 of 17";
        Thread.Sleep(2500);
        // If Directory.Exists(temp2) Then
        // Directory.Delete(temp2, True)
        // End If
        foreach (System.IO.FileInfo file in new System.IO.DirectoryInfo(temp2).GetFiles("*.*"))
        {
            // If (Now - file.CreationTime).Days > Now Then
            try
            {
                file.Delete();
            }
            catch
            {
            }
        }
        foreach (System.IO.FileInfo file in new System.IO.DirectoryInfo(temp3).GetFiles("*.*"))
        {
            // If (Now - file.CreationTime).Days > Now Then
            try
            {
                file.Delete();
            }
            catch
            {
            }
        }
        materialLabel5.Text = "Stage: 10 of 17";
        Thread.Sleep(2500);
        if (Directory.Exists(CC2))
            Directory.Delete(CC2, true);
        materialLabel5.Text = "Stage: 11 of 17";
        Thread.Sleep(1000);
        if (Directory.Exists(CS))
            Directory.Delete(CS, true);
        materialLabel5.Text = "Stage: 12 of 17";
        Thread.Sleep(1000);
        if (Directory.Exists(CT))
            Directory.Delete(CT, true);
        materialLabel5.Text = "Stage: 13 of 17";
        Thread.Sleep(200);
        if (Directory.Exists(CC3))
            Directory.Delete(CC3, true);
        materialLabel5.Text = "Stage: 14 of 17";
        Thread.Sleep(500);
        if (Directory.Exists(NC))
            Directory.Delete(NC, true);
        materialLabel5.Text = "Stage: 15 of 17";
        Thread.Sleep(2000);
        if (Directory.Exists(WU))
            Directory.Delete(WU, true);
        materialLabel5.Text = "Stage: 16 of 17";
        Thread.Sleep(2000);
        if (Directory.Exists(origin))
            Directory.Delete(origin, true);
        materialLabel5.Text = "Stage: 17 of 17";
        try
        {
            
        }
        catch (Exception ex)
        {
        }
        Thread.Sleep(5000);
        p = Process.GetProcessesByName("Origin");
        if (p.Count() > 0)
        {
        }
        else
        {
        }
        materialLabel5.Text = "Reset Complete";
        pictureBox13.Visible = false;
        materialLabel5.Visible = false;
                var mess = MessageBox.Show("The reset process is complete! Would you like Reset Client to launch Origin for you?", "Launch Origin?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (mess == DialogResult.Yes)
                    System.Diagnostics.Process.Start(OMain);
                //Interaction.Shell("Shutdown -r -t 5");
                else if (File.Exists(OMain))
                {
                    
                    Thread.Sleep(5000);
                   // Application.Exit();
                }
                else
                    MessageBox.Show("We could not find Origin!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message, "Can't Continue", MessageBoxButtons.OK, MessageBoxIcon.Stop);
    }
        }
        public void DeleteFilesBattleNet()
        {
            try
            {
                materialLabel1.Text = "Scanning for files...";
                wait(3);
                if (Directory.Exists(AppDataBNLC))
                    Directory.Delete(AppDataBNLC, true);
                materialLabel1.Text = "Stage: 1 of 6";
                Thread.Sleep(1500);
                if (Directory.Exists(BE))
                    Directory.Delete(BE, true);
                materialLabel1.Text = "Stage: 2 of 6";
                Thread.Sleep(1300);
                if (Directory.Exists(AppDataBN))
                    Directory.Delete(AppDataBN, true);
                materialLabel1.Text = "Stage: 3 of 6";
                Thread.Sleep(1900);
                if (Directory.Exists(AppDataBNL))
                    Directory.Delete(AppDataBNL, true);
                materialLabel1.Text = "Stage: 4 of 6";
                Thread.Sleep(1100);
          
                materialLabel1.Text = "Stage: 5 of 6";
                Thread.Sleep(2500);
                // If Directory.Exists(temp2) Then
                // Directory.Delete(temp2, True)
                // End If
                foreach (System.IO.FileInfo file in new System.IO.DirectoryInfo(temp2).GetFiles("*.*"))
                {
                    // If (Now - file.CreationTime).Days > Now Then
                    try
                    {
                        file.Delete();
                    }
                    catch
                    {
                    }
                }
                foreach (System.IO.FileInfo file in new System.IO.DirectoryInfo(temp3).GetFiles("*.*"))
                {
                    // If (Now - file.CreationTime).Days > Now Then
                    try
                    {
                        file.Delete();
                    }
                    catch
                    {
                    }
                }
                materialLabel1.Text = "Stage: 6 of 6";
                try
                {

                }
                catch (Exception ex)
                {
                }
                Thread.Sleep(5000);
                p = Process.GetProcessesByName("Battle.net");
                if (p.Count() > 0)
                {
                }
                else
                {
                }
                materialLabel1.Text = "Reset Complete";
                pictureBox9.Visible = false;
                materialLabel1.Visible = false;
                var mess = MessageBox.Show("The reset process is complete! Would you like Reset Client to launch Battle.net for you?", "Launch Battle.net?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (mess == DialogResult.Yes)
                    System.Diagnostics.Process.Start(BNMain);
                //Interaction.Shell("Shutdown -r -t 5");
                else if (File.Exists(BNMain))
                {
                    //System.Diagnostics.Process.Start(BNMain);
                    Thread.Sleep(5000);
                   // Application.Exit();
                }
                else
                    MessageBox.Show("We could not find Battle.Net!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Can't Continue", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        public void DeleteFilesUbisoft()
        {
            try
            {

                materialLabel7.Text = "Scanning for files...";
                wait(2);
                if (Directory.Exists(UCA))
                    Directory.Delete(UCA, true);
                materialLabel7.Text = "Stage: 1 of 7";
                Thread.Sleep(1500);
                if (Directory.Exists(UCL))
                    Directory.Delete(UCL, true);
                materialLabel7.Text = "Stage: 2 of 7";
                Thread.Sleep(1300);
                if (Directory.Exists(UCAV))
                    Directory.Delete(UCAV, true);
                materialLabel7.Text = "Stage: 3 of 7";
                Thread.Sleep(1900);
                if (Directory.Exists(UCWEB))
                    Directory.Delete(UCWEB, true);
                materialLabel7.Text = "Stage: 4 of 7";
                
                try
                {
                    materialLabel7.Text = "Stage: 5 of 7";
                    Thread.Sleep(1000);
                    // If Directory.Exists(temp1) Then
                    // Directory.Delete(temp1, True)
                    // End If
                    foreach (System.IO.FileInfo file in new System.IO.DirectoryInfo(temp1).GetFiles("*.*"))
                    {
                        // If (Now - file.CreationTime).Days > Now Then
                        try
                        {
                            file.Delete();
                        }
                        catch
                        {
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                materialLabel7.Text = "Stage: 6 of 7";
                Thread.Sleep(2500);
                // If Directory.Exists(temp2) Then
                // Directory.Delete(temp2, True)
                // End If
                foreach (System.IO.FileInfo file in new System.IO.DirectoryInfo(temp2).GetFiles("*.*"))
                {
                    // If (Now - file.CreationTime).Days > Now Then
                    try
                    {
                        file.Delete();
                    }
                    catch
                    {
                    }
                }
                foreach (System.IO.FileInfo file in new System.IO.DirectoryInfo(temp3).GetFiles("*.*"))
                {
                    // If (Now - file.CreationTime).Days > Now Then
                    try
                    {
                        file.Delete();
                    }
                    catch
                    {
                    }
                }
                materialLabel7.Text = "Stage: 7 of 7";
                
                try
                {

                }
                catch (Exception ex)
                {
                }
                Thread.Sleep(5000);
                p = Process.GetProcessesByName("Ubisoft Connect");
                if (p.Count() > 0)
                {
                }
                else
                {
                }
                materialLabel7.Text = "Reset Complete";
                pictureBox15.Visible = false;
                materialLabel7.Visible = false;
                var mess = MessageBox.Show("The reset process is complete! Would you like Reset Client to launch Ubisoft Connect for you?", "Launch Ubisoft Connect?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (mess == DialogResult.Yes)
                    System.Diagnostics.Process.Start(UMain);
                //Interaction.Shell("Shutdown -r -t 5");
                else if (File.Exists(UMain))
                {

                    Thread.Sleep(5000);
                    // Application.Exit();
                }
                else
                    MessageBox.Show("We could not find Ubisoft Connect!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Can't Continue", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void materialButton2_Click(object sender, EventArgs e)
        {
            materialLabel1.Visible = true;
            pictureBox9.Visible = true;
            p = Process.GetProcessesByName("Battle.net");
            if (p.Count() > 0)
            {
                MessageBox.Show("We detected that Battle.Net is still open and we can't continue with the reset!" + Constants.vbNewLine + "We will try and close Battle.Net for you!", "Can't Continue", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                try
                {

                }
                catch (Exception ex)
                {
                }
                try
                {
                    var proc1 = Process.GetProcessesByName("Battle.net");

                    for (int i = 0; i <= proc1.Count() - 1; i++)
                        proc1[i].CloseMainWindow();
                    foreach (Process w in p)
                    {
                        w.Kill();
                        w.WaitForExit();
                        w.Dispose();
                    }
                }
                catch (Exception ex)
                {
                }

                CheckForIllegalCrossThreadCalls = false;
                Thread worker = new Thread(new ThreadStart(() =>
                {
                    DeleteFilesBattleNet();
                }));
                worker.Start();
            }
            else
            {
                try
                {
                    //Process.GetProcessesByName("OriginWebHelperService")(0).Kill();
                }
                catch (Exception ex)
                {
                }

                CheckForIllegalCrossThreadCalls = false;



                Thread worker = new Thread(new ThreadStart(() =>
                {
                    DeleteFilesBattleNet();
                }));
                worker.Start();

                
            }
        }

        private void materialButton8_Click(object sender, EventArgs e)
        {
            materialLabel7.Visible = true;
            pictureBox15.Visible = true;
            p = Process.GetProcessesByName("Ubisoft Connect");
            if (p.Count() > 0)
            {
                MessageBox.Show("We detected that Ubisoft Connect is still open and we can't continue with the reset!" + Constants.vbNewLine + "We will try and close Ubisoft Connect for you!", "Can't Continue", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                try
                {

                }
                catch (Exception ex)
                {
                }
                try
                {
                    var proc1 = Process.GetProcessesByName("Ubisoft Connect");

                    for (int i = 0; i <= proc1.Count() - 1; i++)
                        proc1[i].CloseMainWindow();
                    foreach (Process w in p)
                    {
                        w.Kill();
                        w.WaitForExit();
                        w.Dispose();
                    }
                }
                catch (Exception ex)
                {
                }

                CheckForIllegalCrossThreadCalls = false;
                Thread worker = new Thread(new ThreadStart(() =>
                {
                    DeleteFilesUbisoft();
                }));
                worker.Start();
            }
            else
            {
                try
                {
                    //Process.GetProcessesByName("OriginWebHelperService")(0).Kill();
                }
                catch (Exception ex)
                {
                }

                CheckForIllegalCrossThreadCalls = false;



                Thread worker = new Thread(new ThreadStart(() =>
                {
                    DeleteFilesUbisoft();
                }));
                worker.Start();

            }
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            materialLabel2.Visible = true;
            pictureBox10.Visible = true;
            p = Process.GetProcessesByName("BethesdaNetLauncher");
            if (p.Count() > 0)
            {
                MessageBox.Show("We detected that Bethesda Launcher is still open and we can't continue with the reset!" + Constants.vbNewLine + "We will try and close Bethesda Launcher for you!", "Can't Continue", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                try
                {

                }
                catch (Exception ex)
                {
                }
                try
                {
                    var proc1 = Process.GetProcessesByName("BethesdaNetLauncher");

                    for (int i = 0; i <= proc1.Count() - 1; i++)
                        proc1[i].CloseMainWindow();
                    foreach (Process w in p)
                    {
                        w.Kill();
                        w.WaitForExit();
                        w.Dispose();
                    }
                }
                catch (Exception ex)
                {
                }

                CheckForIllegalCrossThreadCalls = false;
                Thread worker = new Thread(new ThreadStart(() =>
                {
                    DeleteFilesBethesda();
                }));
                worker.Start();
            }
            else
            {
                try
                {
                    //Process.GetProcessesByName("OriginWebHelperService")(0).Kill();
                }
                catch (Exception ex)
                {
                }

                CheckForIllegalCrossThreadCalls = false;



                Thread worker = new Thread(new ThreadStart(() =>
                {
                    DeleteFilesBethesda();
                }));
                worker.Start();


            }
        }
        public void DeleteFilesEpic()
        {
            try
            {

                materialLabel3.Text = "Scanning for files...";
                wait(2);
                if (Directory.Exists(EGL))
                    Directory.Delete(EGL, true);
                materialLabel3.Text = "Stage: 1 of 6";
                Thread.Sleep(1500);
                if (Directory.Exists(EGCC))
                    Directory.Delete(EGCC, true);
                materialLabel3.Text = "Stage: 2 of 6";
                if (Directory.Exists(EGWEB))
                    Directory.Delete(EGWEB, true);
                materialLabel3.Text = "Stage: 3 of 6";

                try
                {
                    materialLabel3.Text = "Stage: 4 of 6";
                    Thread.Sleep(1000);
                    // If Directory.Exists(temp1) Then
                    // Directory.Delete(temp1, True)
                    // End If
                    foreach (System.IO.FileInfo file in new System.IO.DirectoryInfo(temp1).GetFiles("*.*"))
                    {
                        // If (Now - file.CreationTime).Days > Now Then
                        try
                        {
                            file.Delete();
                        }
                        catch
                        {
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                materialLabel3.Text = "Stage: 5 of 6";
                Thread.Sleep(2500);
                // If Directory.Exists(temp2) Then
                // Directory.Delete(temp2, True)
                // End If
                foreach (System.IO.FileInfo file in new System.IO.DirectoryInfo(temp2).GetFiles("*.*"))
                {
                    // If (Now - file.CreationTime).Days > Now Then
                    try
                    {
                        file.Delete();
                    }
                    catch
                    {
                    }
                }
                foreach (System.IO.FileInfo file in new System.IO.DirectoryInfo(temp3).GetFiles("*.*"))
                {
                    // If (Now - file.CreationTime).Days > Now Then
                    try
                    {
                        file.Delete();
                    }
                    catch
                    {
                    }
                }
                materialLabel2.Text = "Stage: 6 of 6";

                try
                {

                }
                catch (Exception ex)
                {
                }
                Thread.Sleep(5000);
                p = Process.GetProcessesByName("EpicGamesLauncher");
                if (p.Count() > 0)
                {
                }
                else
                {
                }
                materialLabel3.Text = "Reset Complete";
                pictureBox11.Visible = false;
                materialLabel3.Visible = false;
                var mess = MessageBox.Show("The reset process is complete! Would you like Reset Client to launch Epic Games for you?", "Launch Epic Games?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (mess == DialogResult.Yes)
                    System.Diagnostics.Process.Start(EGMain);
                //Interaction.Shell("Shutdown -r -t 5");
                else if (File.Exists(EGMain))
                {

                    Thread.Sleep(5000);
                    // Application.Exit();
                }
                else
                    MessageBox.Show("We could not find Epic Games!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Can't Continue", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        public void DeleteFilesGOG()
        {
            try
            {
                var proc1 = Process.GetProcessesByName("GalaxyClient");
                var proc2 = Process.GetProcessesByName("GalaxyClientService");
                var proc3 = Process.GetProcessesByName("GalaxyUpdater");
                var proc4 = Process.GetProcessesByName("GalaxyCommunication");

                for (int i = 0; i <= proc1.Count() - 1; i++)
                    proc1[i].CloseMainWindow();
                foreach (Process w in p)
                {
                    w.Kill();
                    w.WaitForExit();
                    w.Dispose();
                }
                wait(2);
                for (int i = 0; i <= proc2.Count() - 1; i++)
                    proc1[i].CloseMainWindow();
                foreach (Process w2 in p)
                {
                    w2.Kill();
                    w2.WaitForExit();
                    w2.Dispose();
                }
                wait(2);
                for (int i = 0; i <= proc3.Count() - 1; i++)
                    proc1[i].CloseMainWindow();
                foreach (Process w3 in p)
                {
                    w3.Kill();
                    w3.WaitForExit();
                    w3.Dispose();
                }
                wait(2);
                for (int i = 0; i <= proc4.Count() - 1; i++)
                    proc1[i].CloseMainWindow();
                foreach (Process w4 in p)
                {
                    w4.Kill();
                    w4.WaitForExit();
                    w4.Dispose();
                }
                wait(2);
            }
            catch
            { 
            }
            try
            {
                
                materialLabel4.Text = "Scanning for files...";
                wait(2);
                //if (Directory.Exists(GOGL))
                //    Directory.Delete(GOGL, true);
                materialLabel4.Text = "Stage: 1 of 5";
                Thread.Sleep(1500);
                if (Directory.Exists(GOGWEB))
                    Directory.Delete(GOGWEB, true);
                materialLabel4.Text = "Stage: 2 of 5";

                try
                {
                    materialLabel4.Text = "Stage: 3 of 5";
                    Thread.Sleep(1000);
                    // If Directory.Exists(temp1) Then
                    // Directory.Delete(temp1, True)
                    // End If
                    foreach (System.IO.FileInfo file in new System.IO.DirectoryInfo(temp1).GetFiles("*.*"))
                    {
                        // If (Now - file.CreationTime).Days > Now Then
                        try
                        {
                            file.Delete();
                        }
                        catch
                        {
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                materialLabel4.Text = "Stage: 4 of 5";
                Thread.Sleep(2500);
                // If Directory.Exists(temp2) Then
                // Directory.Delete(temp2, True)
                // End If
                foreach (System.IO.FileInfo file in new System.IO.DirectoryInfo(temp2).GetFiles("*.*"))
                {
                    // If (Now - file.CreationTime).Days > Now Then
                    try
                    {
                        file.Delete();
                    }
                    catch
                    {
                    }
                }
                foreach (System.IO.FileInfo file in new System.IO.DirectoryInfo(temp3).GetFiles("*.*"))
                {
                    // If (Now - file.CreationTime).Days > Now Then
                    try
                    {
                        file.Delete();
                    }
                    catch
                    {
                    }
                }
                materialLabel4.Text = "Stage: 5 of 5";

                try
                {

                }
                catch (Exception ex)
                {
                }
                Thread.Sleep(5000);
                p = Process.GetProcessesByName("GalaxyClient");
                if (p.Count() > 0)
                {
                }
                else
                {
                }
                materialLabel4.Text = "Reset Complete";
                pictureBox12.Visible = false;
                materialLabel4.Visible = false;
                var mess = MessageBox.Show("The reset process is complete! Would you like Reset Client to launch GOG Galaxy for you?", "Launch GOG Galaxy?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (mess == DialogResult.Yes)
                    System.Diagnostics.Process.Start(GOGMain);
                //Interaction.Shell("Shutdown -r -t 5");
                else if (File.Exists(GOGMain))
                {

                    Thread.Sleep(5000);
                    // Application.Exit();
                }
                else
                    MessageBox.Show("We could not find GOG Galaxy!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Can't Continue", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        public void DeleteFilesBethesda()
        {
            try
            {

                materialLabel2.Text = "Scanning for files...";
                wait(2);
                if (Directory.Exists(BL))
                    Directory.Delete(BL, true);
                materialLabel2.Text = "Stage: 1 of 5";
                Thread.Sleep(1500);
                if (Directory.Exists(BLL))
                    Directory.Delete(BLL, true);
                materialLabel2.Text = "Stage: 2 of 5";
                
                try
                {
                    materialLabel2.Text = "Stage: 3 of 5";
                    Thread.Sleep(1000);
                    // If Directory.Exists(temp1) Then
                    // Directory.Delete(temp1, True)
                    // End If
                    foreach (System.IO.FileInfo file in new System.IO.DirectoryInfo(temp1).GetFiles("*.*"))
                    {
                        // If (Now - file.CreationTime).Days > Now Then
                        try
                        {
                            file.Delete();
                        }
                        catch
                        {
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                materialLabel2.Text = "Stage: 4 of 5";
                Thread.Sleep(2500);
                // If Directory.Exists(temp2) Then
                // Directory.Delete(temp2, True)
                // End If
                foreach (System.IO.FileInfo file in new System.IO.DirectoryInfo(temp2).GetFiles("*.*"))
                {
                    // If (Now - file.CreationTime).Days > Now Then
                    try
                    {
                        file.Delete();
                    }
                    catch
                    {
                    }
                }
                foreach (System.IO.FileInfo file in new System.IO.DirectoryInfo(temp3).GetFiles("*.*"))
                {
                    // If (Now - file.CreationTime).Days > Now Then
                    try
                    {
                        file.Delete();
                    }
                    catch
                    {
                    }
                }
                materialLabel2.Text = "Stage: 5 of 5";

                try
                {

                }
                catch (Exception ex)
                {
                }
                Thread.Sleep(5000);
                p = Process.GetProcessesByName("BethesdaNetLauncher");
                if (p.Count() > 0)
                {
                }
                else
                {
                }
                materialLabel2.Text = "Reset Complete";
                pictureBox10.Visible = false;
                materialLabel2.Visible = false;
                var mess = MessageBox.Show("The reset process is complete! Would you like Reset Client to launch Bethesda Launcher for you?", "Launch Bethesda Launcher?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (mess == DialogResult.Yes)
                    System.Diagnostics.Process.Start(BMain);
                //Interaction.Shell("Shutdown -r -t 5");
                else if (File.Exists(BMain))
                {

                    Thread.Sleep(5000);
                    // Application.Exit();
                }
                else
                    MessageBox.Show("We could not find Bethesda Launcher!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Can't Continue", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        public void DeleteFilesSteam()
        {
            try
            {

                materialLabel2.Text = "Scanning for files...";
                wait(2);
                if (Directory.Exists(SAC))
                    Directory.Delete(SAC, true);
                materialLabel6.Text = "Stage: 1 of 7";
                Thread.Sleep(1500);
                if (Directory.Exists(SL))
                    Directory.Delete(SL, true);
                materialLabel6.Text = "Stage: 2 of 7";
                Thread.Sleep(1500);
                if (Directory.Exists(SDC))
                    Directory.Delete(SDC, true);
                materialLabel6.Text = "Stage: 3 of 7";
                Thread.Sleep(1500);
                if (Directory.Exists(SWEB))
                    Directory.Delete(SWEB, true);
                materialLabel6.Text = "Stage: 4 of 7";

                try
                {
                    materialLabel6.Text = "Stage: 5 of 7";
                    Thread.Sleep(1000);
                    // If Directory.Exists(temp1) Then
                    // Directory.Delete(temp1, True)
                    // End If
                    foreach (System.IO.FileInfo file in new System.IO.DirectoryInfo(temp1).GetFiles("*.*"))
                    {
                        // If (Now - file.CreationTime).Days > Now Then
                        try
                        {
                            file.Delete();
                        }
                        catch
                        {
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                materialLabel6.Text = "Stage: 6 of 7";
                Thread.Sleep(2500);
                // If Directory.Exists(temp2) Then
                // Directory.Delete(temp2, True)
                // End If
                foreach (System.IO.FileInfo file in new System.IO.DirectoryInfo(temp2).GetFiles("*.*"))
                {
                    // If (Now - file.CreationTime).Days > Now Then
                    try
                    {
                        file.Delete();
                    }
                    catch
                    {
                    }
                }
                foreach (System.IO.FileInfo file in new System.IO.DirectoryInfo(temp3).GetFiles("*.*"))
                {
                    // If (Now - file.CreationTime).Days > Now Then
                    try
                    {
                        file.Delete();
                    }
                    catch
                    {
                    }
                }
                materialLabel6.Text = "Stage: 7 of 7";

                try
                {

                }
                catch (Exception ex)
                {
                }
                Thread.Sleep(5000);
                p = Process.GetProcessesByName("Steam");
                if (p.Count() > 0)
                {
                }
                else
                {
                }
                materialLabel6.Text = "Reset Complete";
                pictureBox14.Visible = false;
                materialLabel6.Visible = false;
                var mess = MessageBox.Show("The reset process is complete! Would you like Reset Client to launch Steam for you?", "Launch Steam?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (mess == DialogResult.Yes)
                    System.Diagnostics.Process.Start(SMain);
                //Interaction.Shell("Shutdown -r -t 5");
                else if (File.Exists(SMain))
                {

                    Thread.Sleep(5000);
                    // Application.Exit();
                }
                else
                    MessageBox.Show("We could not find Steam!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Can't Continue", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void materialButton4_Click(object sender, EventArgs e)
        {
            materialLabel3.Visible = true;
            pictureBox11.Visible = true;
            p = Process.GetProcessesByName("EpicGamesLauncher");
            if (p.Count() > 0)
            {
                MessageBox.Show("We detected that Epic Games is still open and we can't continue with the reset!" + Constants.vbNewLine + "We will try and close Epic Games for you!", "Can't Continue", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                try
                {

                }
                catch (Exception ex)
                {
                }
                try
                {
                    var proc1 = Process.GetProcessesByName("EpicGamesLauncher");

                    for (int i = 0; i <= proc1.Count() - 1; i++)
                        proc1[i].CloseMainWindow();
                    foreach (Process w in p)
                    {
                        w.Kill();
                        w.WaitForExit();
                        w.Dispose();
                    }
                    wait(2);
                }
                catch (Exception ex)
                {
                }

                CheckForIllegalCrossThreadCalls = false;
                Thread worker = new Thread(new ThreadStart(() =>
                {
                    DeleteFilesEpic();
                }));
                worker.Start();
            }
            else
            {
                try
                {
                    //Process.GetProcessesByName("OriginWebHelperService")(0).Kill();
                }
                catch (Exception ex)
                {
                }

                CheckForIllegalCrossThreadCalls = false;



                Thread worker = new Thread(new ThreadStart(() =>
                {
                    DeleteFilesEpic();
                }));
                worker.Start();


            }
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            materialLabel4.Visible = true;
            pictureBox12.Visible = true;
            p = Process.GetProcessesByName("GalaxyClient");
            if (p.Count() > 0)
            {
                MessageBox.Show("We detected that GOG Galaxy is still open and we can't continue with the reset!" + Constants.vbNewLine + "We will try and close GOG Galaxy for you!", "Can't Continue", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                try
                {

                }
                catch (Exception ex)
                {
                }
                try
                {
                    var proc1 = Process.GetProcessesByName("GalaxyClient");
                    var proc2 = Process.GetProcessesByName("GalaxyClientService");
                    var proc3 = Process.GetProcessesByName("GalaxyUpdater");
                    var proc4 = Process.GetProcessesByName("GalaxyCommunication");

                    for (int i = 0; i <= proc1.Count() - 1; i++)
                        proc1[i].CloseMainWindow();
                    foreach (Process w in p)
                    {
                        w.Kill();
                        w.WaitForExit();
                        w.Dispose();
                    }
                    wait(2);
                    for (int i = 0; i <= proc2.Count() - 1; i++)
                        proc1[i].CloseMainWindow();
                    foreach (Process w2 in p)
                    {
                        w2.Kill();
                        w2.WaitForExit();
                        w2.Dispose();
                    }
                    wait(2);
                    for (int i = 0; i <= proc3.Count() - 1; i++)
                        proc1[i].CloseMainWindow();
                    foreach (Process w3 in p)
                    {
                        w3.Kill();
                        w3.WaitForExit();
                        w3.Dispose();
                    }
                    wait(2);
                    for (int i = 0; i <= proc4.Count() - 1; i++)
                        proc1[i].CloseMainWindow();
                    foreach (Process w4 in p)
                    {
                        w4.Kill();
                        w4.WaitForExit();
                        w4.Dispose();
                    }
                    wait(2);
                }
                catch (Exception ex)
                {
                }

                CheckForIllegalCrossThreadCalls = false;
                Thread worker = new Thread(new ThreadStart(() =>
                {
                    DeleteFilesGOG();
                }));
                worker.Start();
            }
            else
            {
                try
                {
                    var proc1 = Process.GetProcessesByName("GalaxyClient");
                    var proc2 = Process.GetProcessesByName("GalaxyClientService");
                    var proc3 = Process.GetProcessesByName("GalaxyUpdater");
                    var proc4 = Process.GetProcessesByName("GalaxyCommunication");

                    for (int i = 0; i <= proc1.Count() - 1; i++)
                        proc1[i].CloseMainWindow();
                    foreach (Process w in p)
                    {
                        w.Kill();
                        w.WaitForExit();
                        w.Dispose();
                    }
                    wait(2);
                    for (int i = 0; i <= proc2.Count() - 1; i++)
                        proc1[i].CloseMainWindow();
                    foreach (Process w2 in p)
                    {
                        w2.Kill();
                        w2.WaitForExit();
                        w2.Dispose();
                    }
                    wait(2);
                    for (int i = 0; i <= proc3.Count() - 1; i++)
                        proc1[i].CloseMainWindow();
                    foreach (Process w3 in p)
                    {
                        w3.Kill();
                        w3.WaitForExit();
                        w3.Dispose();
                    }
                    wait(2);
                    for (int i = 0; i <= proc4.Count() - 1; i++)
                        proc1[i].CloseMainWindow();
                    foreach (Process w4 in p)
                    {
                        w4.Kill();
                        w4.WaitForExit();
                        w4.Dispose();
                    }
                    wait(2);
                }
                catch (Exception ex)
                {
                }

                CheckForIllegalCrossThreadCalls = false;



                Thread worker = new Thread(new ThreadStart(() =>
                {
                    DeleteFilesGOG();
                }));
                worker.Start();


            }
        }

        private void materialButton7_Click(object sender, EventArgs e)
        {
            materialLabel6.Visible = true;
            pictureBox14.Visible = true;
            p = Process.GetProcessesByName("Steam");
            if (p.Count() > 0)
            {
                MessageBox.Show("We detected that Steam is still open and we can't continue with the reset!" + Constants.vbNewLine + "We will try and close Steam for you!", "Can't Continue", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                try
                {

                }
                catch (Exception ex)
                {
                }
                try
                {
                    var proc1 = Process.GetProcessesByName("Steam");

                    for (int i = 0; i <= proc1.Count() - 1; i++)
                        proc1[i].CloseMainWindow();
                    foreach (Process w in p)
                    {
                        w.Kill();
                        w.WaitForExit();
                        w.Dispose();
                    }
                }
                catch (Exception ex)
                {
                }

                CheckForIllegalCrossThreadCalls = false;
                Thread worker = new Thread(new ThreadStart(() =>
                {
                    DeleteFilesSteam();
                }));
                worker.Start();
            }
            else
            {
                try
                {
                    //Process.GetProcessesByName("OriginWebHelperService")(0).Kill();
                }
                catch (Exception ex)
                {
                }

                CheckForIllegalCrossThreadCalls = false;



                Thread worker = new Thread(new ThreadStart(() =>
                {
                    DeleteFilesSteam();
                }));
                worker.Start();


            }
        }
    }
    }


