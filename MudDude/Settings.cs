using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MudDude
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void btnSettingsCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSettingsOK_Click(object sender, EventArgs e)
        {
            if (ConnectionSanityCheck())
            {
                SaveCurrentSettings();
                this.Hide();
            }
            else
            {
                // TODO sanity check fail, display message, highlight first bad field
            }
        }

        private void SaveCurrentSettings()
        {
            MudDude.Default.ServerAddress = txtSettingsAddress.Text;
            MudDude.Default.ServerPort = int.Parse(txtSettingsPort.Text);

            MudDude.Default.Save();
        }

        private bool ConnectionSanityCheck()
        {
            // TODO Make sure settings are valid
            return true;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            txtSettingsAddress.Text = MudDude.Default.ServerAddress;
            txtSettingsPort.Text = MudDude.Default.ServerPort.ToString();
        }
    }
}
