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

namespace CBShowImage
{
    public partial class AboutForm : Form
    {
        public string VerString = "";  // 由 MainForm 傳進來
        public string DateString = "";  // 由 MainForm 傳進來
        public AboutForm()
        {
            InitializeComponent();
        }


        private void btOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://findicons.com/pack/129/soft_scraps");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.cbeta.org");
        }

        private void AboutForm_Shown(object sender, EventArgs e)
        {
            lbVer.Text = VerString;
            lbDate.Text = DateString;
        }
    }
}
