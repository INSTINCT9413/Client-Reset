using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client_Reset.Properties;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Client_Reset
{
    public partial class SettingsForm : MaterialForm
    {
        MaterialSkinManager ThemeManager = MaterialSkinManager.Instance;
        public SettingsForm()
        {
            InitializeComponent();

            

        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            materialLabel4.Text =  Application.ProductVersion;

            if (Settings.Default.enableResetAll == "Enabled")
            {
                materialCheckbox1 .Checked = true;
            }
            else
            {
                materialCheckbox1.Checked = false;
            }
            if (Settings.Default.themeMode == "Light")
            {
                materialSwitch1.Checked = true;
                materialSwitch1.Text = "Light Mode";
            }
            else
            {
                materialSwitch1.Checked = false;
                materialSwitch1.Text = "Dark Mode";
            }
            if (Settings.Default.fullClean == "Yes")
            {
                materialCheckbox2.Checked = true;
            }
            else
            {
                materialCheckbox2.Checked = false;
            }
            if (Settings.Default.themeColor == "Default")
            {
                materialComboBox1.SelectedIndex = 0;
            }
            if (Settings.Default.themeColor == "Yellow")
            {
                materialComboBox1.SelectedIndex = 1;
            }
            if (Settings.Default.themeColor == "Red")
            {
                materialComboBox1.SelectedIndex = 2;
            }
            if (Settings.Default.themeColor == "Green")
            {
                materialComboBox1.SelectedIndex = 3;
            }
            if (Settings.Default.themeColor == "Blue")
            {
                materialComboBox1.SelectedIndex = 4;
            }
            if (Settings.Default.themeColor == "Purple")
            {
                materialComboBox1.SelectedIndex = 5;
            }
            if (Settings.Default.startingTab == "Battle.net")
            {
                materialComboBox2.SelectedIndex = 0;
            }
            if (Settings.Default.startingTab == "Bethesda Launcher")
            {
                materialComboBox2.SelectedIndex = 1;
            }
            if (Settings.Default.startingTab == "Epic Games")
            {
                materialComboBox2.SelectedIndex = 2;
            }
            if (Settings.Default.startingTab == "GOG Galaxy")
            {
                materialComboBox2.SelectedIndex = 3;
            }
            if (Settings.Default.startingTab == "Origin")
            {
                materialComboBox2.SelectedIndex = 4;
            }
            if (Settings.Default.startingTab == "Steam")
            {
                materialComboBox2.SelectedIndex = 5;
            }
            if (Settings.Default.startingTab == "Ubisoft Connect")
            {
                materialComboBox2.SelectedIndex = 6;
            }
            if (Settings.Default.startingTab == "Windows Store")
            {
                materialComboBox2.SelectedIndex = 7;
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            Legal LF = new Legal();
            LF.ShowDialog(this);
        }

        private void materialCheckbox1_CheckedChanged(object sender, EventArgs e)
        {
            if (materialCheckbox1.Checked)
            {
                Properties.Settings.Default.enableResetAll = "Enabled";
                Properties.Settings.Default.Save();
            }
            else if (!materialCheckbox1 .Checked)
                Properties.Settings.Default.enableResetAll = "Disabled";
                Properties.Settings.Default.Save();
            }

        private void materialSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (materialSwitch1.Checked)
            {
                ThemeManager.Theme = MaterialSkinManager.Themes.LIGHT;
                Properties.Settings.Default.themeMode = "Light";
                materialSwitch1.Text = "Light Mode";
                Properties.Settings.Default.Save();
                
            }
            else if (!materialSwitch1.Checked)
                ThemeManager.Theme = MaterialSkinManager.Themes.DARK;
                Properties.Settings.Default.themeMode = "Dark";
                materialSwitch1.Text = "Dark Mode";
                Properties.Settings.Default.Save();
                
        }

        private void materialCheckbox2_CheckedChanged(object sender, EventArgs e)
        {
            if (materialCheckbox2.Checked)
            {
                Properties.Settings.Default.fullClean = "Yes";
                Properties.Settings.Default.Save();
            }
            else if (!materialCheckbox2.Checked)
                Properties.Settings.Default.fullClean = "No";
                Properties.Settings.Default.Save();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Settings.Default.themeMode == "Light")
            {
                materialSwitch1.Text = "Light Mode";
            }
            else
            {
                materialSwitch1.Text = "Dark Mode";
            }
        }

        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialComboBox1.SelectedIndex == 0)
            {
                ThemeManager.Theme = MaterialSkinManager.Themes.LIGHT;
                ThemeManager.ColorScheme = new ColorScheme(Primary.DeepOrange600, Primary.Grey900, Primary.DeepOrange600, Accent.DeepOrange400, TextShade.WHITE);
                Properties.Settings.Default.themeColor = "Default";
                Properties.Settings.Default.Save();
            }
            if (materialComboBox1.SelectedIndex == 1)
            {
                ThemeManager.Theme = MaterialSkinManager.Themes.LIGHT;
                ThemeManager.ColorScheme = new ColorScheme(Primary.Yellow600, Primary.Grey900, Primary.Yellow600, Accent.Yellow400, TextShade.BLACK);
                Properties.Settings.Default.themeColor = "Yellow";
                Properties.Settings.Default.Save();
            }
            if (materialComboBox1.SelectedIndex == 2)
            {
                ThemeManager.Theme = MaterialSkinManager.Themes.LIGHT;
                ThemeManager.ColorScheme = new ColorScheme(Primary.Red600, Primary.Grey900, Primary.Red600, Accent.Red400, TextShade.WHITE);
                Properties.Settings.Default.themeColor = "Red";
                Properties.Settings.Default.Save();
            }
            if (materialComboBox1.SelectedIndex == 3)
            {
                ThemeManager.Theme = MaterialSkinManager.Themes.LIGHT;
                ThemeManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Grey900, Primary.Green600, Accent.Green400, TextShade.WHITE);
                Properties.Settings.Default.themeColor = "Green";
                Properties.Settings.Default.Save();
            }
            if (materialComboBox1.SelectedIndex == 4)
            {
                ThemeManager.Theme = MaterialSkinManager.Themes.LIGHT;
                ThemeManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Grey900, Primary.Blue600, Accent.Blue400, TextShade.WHITE);
                Properties.Settings.Default.themeColor = "Blue";
                Properties.Settings.Default.Save();
            }
            if (materialComboBox1.SelectedIndex == 5)
            {
                ThemeManager.Theme = MaterialSkinManager.Themes.LIGHT;
                ThemeManager.ColorScheme = new ColorScheme(Primary.DeepPurple600, Primary.Grey900, Primary.DeepPurple600, Accent.DeepPurple400, TextShade.WHITE);
                Properties.Settings.Default.themeColor = "Purple";
                Properties.Settings.Default.Save();
            }
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            changelog CL = new changelog();
            CL.ShowDialog(this);
        }

        private void materialComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialComboBox2.SelectedIndex == 0)
            {
                
                Properties.Settings.Default.startingTab = "Battle.net";
                Properties.Settings.Default.Save();
            }
            if (materialComboBox2.SelectedIndex == 1)
            {
                
                Properties.Settings.Default.startingTab = "Bethesda Launcher";
                Properties.Settings.Default.Save();
            }
            if (materialComboBox2.SelectedIndex == 2)
            {
                
                Properties.Settings.Default.startingTab = "Epic Games";
                Properties.Settings.Default.Save();
            }
            if (materialComboBox2.SelectedIndex == 3)
            {
                
                Properties.Settings.Default.startingTab = "GOG Galaxy";
                Properties.Settings.Default.Save();
            }
            if (materialComboBox2.SelectedIndex == 4)
            {
                
                Properties.Settings.Default.startingTab = "Origin";
                Properties.Settings.Default.Save();
            }
            if (materialComboBox2.SelectedIndex == 5)
            {
                
                Properties.Settings.Default.startingTab = "Steam";
                Properties.Settings.Default.Save();
            }
            if (materialComboBox2.SelectedIndex == 6)
            {
                
                Properties.Settings.Default.startingTab = "Ubisoft Connect";
                Properties.Settings.Default.Save();
            }
            if (materialComboBox2.SelectedIndex == 7)
            {

                Properties.Settings.Default.startingTab = "Windows Store";
                Properties.Settings.Default.Save();
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + @"\Updater.exe");
        }
    }
}

