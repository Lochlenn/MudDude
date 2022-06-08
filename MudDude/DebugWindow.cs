using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MudDude
{
    public partial class DebugWindow : Form
    {
        Core MainCore;
        public DebugWindow(Core mainCore)
        {
            InitializeComponent();
            MainCore = mainCore;
        }

        private void btnDebugClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void AddTextToScreen(char charToAdd)
        {
            if (charToAdd == '\r')
            {
                charToAdd = ' ';
            }
            rtbDebugText.AppendText(charToAdd.ToString());
        }

        private void rtbDebugText_KeyPress(object sender, KeyPressEventArgs e)
        {
            // TODO fix echo
            // TODO fix massive delay
            MainCore.SendCharToServer(e.KeyChar);
        }

    }
}
