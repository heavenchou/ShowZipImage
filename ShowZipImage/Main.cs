using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ShowZipImage
{
    public partial class MainForm : Form
    {
        CZipImageFile ZipImageFile = new CZipImageFile();
        Image image;
        public int ImageHeight;
        public int ImageWidth;
        public double ImageRate = 100.0; // 圖檔縮放比例
        string[] args;      // 傳入的參數
        int MouseX = 0;
        int MouseY = 0;
        int ScrollX = 0;
        int ScrollY = 0;
        enum EImageInitialState : int
        {
            Orig = 0,       // 原圖
            Full = 1,       // 全圖
            Rate = 3        // 比率
        }

        EImageInitialState ImageInitialState = EImageInitialState.Orig;

        public MainForm()
        {
            InitializeComponent();
            Size = Properties.Settings.Default.FormSize;
            pbImage.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pbImage_MouseWheel);
            args = Environment.GetCommandLineArgs();
            if(args.Length >= 2) {
                // 處理傳入的參數
                RunArgs();
            }
        }

        #region 成員函式

        // 處理傳入的參數
        private void RunArgs()
        {
            // 有傳入參數
            GetZipFileList(args[1]);
            if(args.Length >= 3) {
                // 有指定解開的檔名
                int index = lbZipImageFileName.FindString(args[2]);
                if(index != ListBox.NoMatches) {
                    lbZipImageFileName.SelectedIndex = index;
                } else {
                    MessageBox.Show($"找不到指定的圖檔 {args[2]}");
                }
            }
        }

        // 取出 Zip 的檔案列表
        private void GetZipFileList(string filename)
        {
            if(!File.Exists(filename)) {
                MessageBox.Show($"檔案 {filename} 不存在。");
                return;
            }
            ZipImageFile.FileName = filename;
            ZipImageFile.GetFileNameList();
            lbZipImageFileName.Items.Clear();
            foreach(string file in ZipImageFile.FileNameList) {
                lbZipImageFileName.Items.Add(file);
            }
        }

        // 呈現圖片
        public void ShowImage(int index)
        {
            string fullname = lbZipImageFileName.Items[index].ToString();
            ZipImageFile.OpenImageFile(fullname);
            if(image != null) {
                image.Dispose();
            }

            image = new Bitmap(ZipImageFile.stream);
            ImageWidth = image.Width;
            ImageHeight = image.Height;
            slbImageSize.Text = $"寬:{ImageWidth} 高:{ImageHeight}";
            pbImage.Image = image;
            splitContainer.Panel2.AutoScroll = false; // 還原捲軸位置用的
            splitContainer.Panel2.AutoScroll = true; // 還原捲軸位置用的
            if(ImageInitialState == EImageInitialState.Orig) {
                // 原圖呈現
                ShowImageInOrig();
            } else if(ImageInitialState == EImageInitialState.Full) {
                // 全圖呈現
                ShowImageInFull();
            } else {
                // 比例呈現
                ShowImageInRate(ImageRate);
            }
        }

        public void ShowImageInOrig()
        {
            // 原圖呈現
            pbImage.Size = new Size(ImageWidth, ImageHeight);
            ImageRate = 100.0;
            slbImageRate.Text = "100%";
        }
        public void ShowImageInFull()
        {
            // 全圖呈現
            double widthRate = (double)splitContainer.Panel2.ClientSize.Width / (double)ImageWidth;
            double heightRate = (double)splitContainer.Panel2.ClientSize.Height / (double)ImageHeight;
            if(widthRate > heightRate) {
                widthRate = heightRate;
            }
            pbImage.Size = new Size((int)(ImageWidth * widthRate), (int)(ImageHeight * heightRate));

            slbImageRate.Text = $"{(int)(widthRate * 100)}%";
        }
        public void ShowImageInRate(double Rate)
        {
            // 取得滑鼠在 Image 的相對位置
            Point MousePanelLocation = splitContainer.Panel2.PointToClient(Cursor.Position);
            Point MouseLocation = pbImage.PointToClient(Cursor.Position);

            // 比例呈現
            pbImage.Size = new Size((int)(ImageWidth * Rate / 100.0), (int)(ImageHeight * Rate / 100.0));


            Point newMouseLocation = new Point((int)(Rate * (double)MouseLocation.X / ImageRate), (int)(Rate * (double)MouseLocation.Y / ImageRate));

            ImageRate = Rate;
            slbImageRate.Text = $"{(int)Rate}%";

            int x = newMouseLocation.X - MousePanelLocation.X;
            int y = newMouseLocation.Y - MousePanelLocation.Y;

            splitContainer.Panel2.AutoScrollPosition = new Point(x, y);
        }

        #endregion

        #region UI 物件事件

        private void btShow_Click(object sender, EventArgs e)
        {
            GetZipFileList(tbZipFileName.Text);
        }

        private void lbZipImageFileName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbZipImageFileName.SelectedIndex;
            ShowImage(index);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // 縮小圖片
            ShowImageInRate(ImageRate * 0.9);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // 原始大小
            ShowImageInOrig();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // 放大圖片

            ShowImageInRate(ImageRate * 1.1);
        }

        // 處理滑鼠滾輪
        private void pbImage_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Update the drawing based upon the mouse wheel scrolling.

            int midMouse = e.Delta;
            if(Control.ModifierKeys == Keys.Control) {
                ((HandledMouseEventArgs)e).Handled = true;
                if(midMouse > 0) {
                    ShowImageInRate(ImageRate * 1.1);
                } else {
                    ShowImageInRate(ImageRate * 0.9);
                }
            } else {
                ((HandledMouseEventArgs)e).Handled = false;
            }
        }

        // 選擇圖檔最初要如何呈現
        private void ddbImageInitial_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach(ToolStripDropDownItem item in ddbImageInitial.DropDownItems) {
                ToolStripMenuItem menuitem = (ToolStripMenuItem)item;
                menuitem.Checked = false;
                if(item.Selected) {
                    menuitem.Checked = true;
                }
            }
        }

        private void aToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // 原圖呈現
            ImageInitialState = EImageInitialState.Orig;
        }

        private void bToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // 全圖呈現
            ImageInitialState = EImageInitialState.Full;
        }

        private void cToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // 比例呈現
            ImageInitialState = EImageInitialState.Rate;
        }


        private void pbImage_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left) {
                // 記錄滑鼠和捲軸位置
                MouseX = Cursor.Position.X;
                MouseY = Cursor.Position.Y;
                ScrollX = splitContainer.Panel2.HorizontalScroll.Value;
                ScrollY = splitContainer.Panel2.VerticalScroll.Value;
            }

            Point p = pbImage.PointToClient(Cursor.Position);
            Console.WriteLine($"ab m:({Cursor.Position.X}, {Cursor.Position.Y})");
            Console.WriteLine($"re m:({p.X}, {p.Y})");
            Console.WriteLine($"s:({splitContainer.Panel2.HorizontalScroll.Value}, {splitContainer.Panel2.VerticalScroll.Value})");

        }

        private void pbImage_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left) {
                int x = Cursor.Position.X - MouseX;
                int y = Cursor.Position.Y - MouseY;

                int newScrollX = ScrollX - x;
                int newScrollY = ScrollY - y;

                if(newScrollX < 0) {
                    newScrollX = 0;
                }
                if(newScrollY < 0) {
                    newScrollY = 0;
                }
                splitContainer.Panel2.HorizontalScroll.Value = newScrollX;
                splitContainer.Panel2.VerticalScroll.Value = newScrollY;
                pbImage.Refresh();  // 若不加會有殘影
            }
        }


        private void cbShowRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sRage = cbShowRate.SelectedItem.ToString();
            int iRage = Convert.ToInt32(sRage.Replace("%", ""));
            ShowImageInRate(iRage);
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '+') {
                ShowImageInRate(ImageRate * 1.1);
            } else if(e.KeyChar == '-') {
                ShowImageInRate(ImageRate * 0.9);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.FormSize = Size;
            Properties.Settings.Default.Save();
        }
        #endregion
    }
}
