using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowZipImage
{
    public partial class MainForm : Form
    {
        CZipImageFile ZipImageFile = new CZipImageFile();
        Image image;
        public int ImageHeight;
        public int ImageWidth;
        bool CtrlDown = false;
        

        public MainForm()
        {
            InitializeComponent();
            pbImage.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseWheel);
        }

        private void btShow_Click(object sender, EventArgs e)
        {
            ZipImageFile.FileName = tbZipFileName.Text;
            ZipImageFile.GetFileNameList();
            lbZipImageFileName.Items.Clear();
            foreach (string filename in ZipImageFile.FileNameList) {
                lbZipImageFileName.Items.Add(filename);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void lbZipImageFileName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = lbZipImageFileName.SelectedIndex;
            string fullname = lbZipImageFileName.Items[i].ToString();
            ZipImageFile.OpenImageFile(fullname);
            if(image != null) {
                image.Dispose();
            }
            image = new Bitmap(ZipImageFile.stream);
            ImageWidth = image.Width;
            ImageHeight = image.Height;
            pbImage.Size = new Size(ImageWidth, ImageHeight);
            pbImage.Image = image;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // 縮小圖片
            pbImage.Size = new Size((int)(pbImage.Size.Width * 0.9), (int)(pbImage.Size.Height * 0.9));
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // 原始大小
            pbImage.Size = new Size(ImageWidth, ImageHeight);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // 放大圖片
            pbImage.Size = new Size((int)(pbImage.Size.Width * 1.1), (int)(pbImage.Size.Height * 1.1));
        }

        private void panel1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Update the drawing based upon the mouse wheel scrolling.

            int midMouse = e.Delta;
            if(Control.ModifierKeys == Keys.Control) {
                ((HandledMouseEventArgs)e).Handled = true;
                if(midMouse > 0) {
                    toolStripButton1_Click(sender, e);
                } else {
                    toolStripButton2_Click(sender, e);
                }
            } else {
                ((HandledMouseEventArgs)e).Handled = false;
            }
        }
    }
}
