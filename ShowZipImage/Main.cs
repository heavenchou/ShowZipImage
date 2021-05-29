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
        string ProgramName = "神秀圖";
        CZipImageFile ZipImageFile = new CZipImageFile();
        CImageDir ImageDir = new CImageDir();
        Image image;
        public int ImageHeight;
        public int ImageWidth;
        public double ImageRate = 100.0; // 圖檔縮放比例
        string[] args;      // 傳入的參數
        int MouseX = 0;
        int MouseY = 0;
        int ScrollX = 0;
        int ScrollY = 0;
        bool InZip = false; // 用來判斷是不是在 Zip 中或一般目錄中
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

            RunArgs();  // 處理傳入的參數
        }

        // -----------------------------------------------------------
        // 成員函式
        // -----------------------------------------------------------

        #region 成員函式

        // 處理傳入的參數
        private void RunArgs()
        {
            // 有三種方式:
            // 1. 不傳參數, 開啟目前目錄
            // 2. 傳入一個參數, 可為目錄、壓縮檔或圖檔
            // 3. 傳入二個參數, 第二個通常是壓縮檔中的圖檔

            if(args.Length == 1) {
                // 沒有參數
                GetImageFileListByDir(Directory.GetCurrentDirectory());
            } else if (args.Length >= 2) {
                // 處理 1 個參數
                if(CheckFileType.IsDir(args[1])) {
                    // 傳入目錄
                    GetImageFileListByDir(args[1]);
                } else if(CheckFileType.IsZip(args[1])) {
                    // 傳入壓縮檔
                    GetZipFileList(args[1]);
                } else if(CheckFileType.IsImage(args[1])) {
                    // 傳入圖檔
                    string filename = args[1];
                    string dir = Path.GetDirectoryName(filename);
                    if (dir == "") {
                        // 沒有傳入目錄, 目錄是目前目錄
                        filename = Path.Combine(Directory.GetCurrentDirectory(), filename);
                    }
                    GetImageFileListByFile(filename);

                    string file = Path.GetFileName(filename);
                    int index = lbImageFileName.FindString(file);
                    if(index != ListBox.NoMatches) {
                        lbImageFileName.SelectedIndex = index;
                    } else {
                        MessageBox.Show($"找不到指定的圖檔 {file}");
                    }
                }
            }
                
            if(args.Length >= 3) {
                // 第二個參數是圖檔，有指定解開的檔名
                int index = lbImageFileName.FindString(args[2]);
                if(index != ListBox.NoMatches) {
                    lbImageFileName.SelectedIndex = index;
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
            InZip = true;
            ZipImageFile.FileName = filename;
            ZipImageFile.GetFileNameList();
            FillListBox();
        }

        // 由檔名取出該目錄下的檔案列表
        private void GetImageFileListByFile(string filename)
        {
            if(!File.Exists(filename)) {
                MessageBox.Show($"檔案 {filename} 不存在。");
                return;
            }
            GetImageFileListByDir(Path.GetDirectoryName(filename));
        }

        private void GetImageFileListByDir(string dir)
        {
            if(!Directory.Exists(dir)) {
                MessageBox.Show($"目錄 {dir} 不存在。");
                return;
            }
            InZip = false;
            ImageDir.DirName = dir;
            ImageDir.GetFileNameList();
            FillListBox();
        }

        // 呈現圖片
        public void ShowImage(int index)
        {
            string fullname = lbImageFileName.Items[index].ToString();

            if(InZip) {
                ZipImageFile.OpenImageFile(fullname);
                if(image != null) {
                    image.Dispose();
                }
                image = new Bitmap(ZipImageFile.stream);
            } else {
                string filename = Path.Combine(ImageDir.DirName, fullname);
                image = new Bitmap(filename);
            }

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

        // 傳入檔名，秀出這個圖
        void ShowThisFile(string filename)
        {
            string file = Path.GetFileName(filename);
            int index = lbImageFileName.FindString(file);
            if(index != ListBox.NoMatches) {
                lbImageFileName.SelectedIndex = index;
            } else {
                MessageBox.Show($"找不到指定的圖檔 {file}");
            }
        }

        // 執行某個 ListBox 的功能，IntoZipDir = true 開啟壓縮檔或進入子目錄
        // 一定能開啟圖檔
        void ProcessListBoxItem(bool IntoZipDir)
        {
            int index = lbImageFileName.SelectedIndex;

            // 判斷是目錄、壓縮檔或圖檔
            if(!InZip) {
                if(ImageDir.IsDir(index)) {
                    if(IntoZipDir) {
                        string dir = Path.Combine(ImageDir.DirName, lbImageFileName.Items[index].ToString());
                        GetImageFileListByDir(dir);
                    }
                } else if(ImageDir.IsZip(index)) {
                    if(IntoZipDir) {
                        string zipfile = Path.Combine(ImageDir.DirName, lbImageFileName.Items[index].ToString());
                        GetZipFileList(zipfile);
                    }
                } else {
                    ShowImage(index);
                }
            } else {
                ShowImage(index);
            }
        }

        #endregion

        // -----------------------------------------------------------
        // UI 物件事件
        // -----------------------------------------------------------

        private void lbImageFileName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbImageFileName.SelectedIndex;
            string file = "";

            if(InZip) {
                file = ZipImageFile.FileName;
            } else {
                file = Path.Combine(ImageDir.DirName, lbImageFileName.Items[index].ToString());
            }
            ShowTitle(file);
            ProcessListBoxItem(false);  // 只要開啟圖檔, 不要進入壓縮檔或子目錄
        }

        void ShowTitle(string title)
        {
            Text = ProgramName;
            if(title != "") {
                Text += " - " + title;
            }
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
                splitContainer.Panel2.AutoScrollPosition = new Point(newScrollX, newScrollY);
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
            // 儲存設定
            Properties.Settings.Default.FormSize = Size;
            Properties.Settings.Default.Save();
        }

        // 開啟圖檔或壓縮檔
        private void tbOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "圖檔和壓縮檔|*.jpg;*.tif;*.gif;*.zip";
            openFileDialog.ShowDialog();
            string filename = openFileDialog.FileName.ToString();
            if(filename.EndsWith(".zip", true, null)) {
                // 處理壓縮檔
                GetZipFileList(filename);
            } else {
                // 處理圖檔
                GetImageFileListByFile(filename);
                ShowThisFile(filename);
            }
        }

        private void lbImageFileName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) {
                ProcessListBoxItem(true);   // 進入目錄或壓縮檔
            }
        }

        private void lbImageFileName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ProcessListBoxItem(true);
        }

        // 回上一層目錄
        private void btUpDir_Click(object sender, EventArgs e)
        {
            string dir = "";
            if(InZip) {
                dir = ZipImageFile.FileName;
            } else {
                dir = ImageDir.DirName;
            }
            dir = Path.GetDirectoryName(dir);
            ShowTitle(dir);
            if(dir != null && dir != "") {
                GetImageFileListByDir(dir);
            }
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            FillListBox();
        }

        void FillListBox()
        {
            string filterString = tbFilter.Text;
            filterString = filterString.ToUpper();

            lbImageFileName.Items.Clear();
            if(InZip) {
                foreach(string file in ZipImageFile.FileNameList) {
                    if(file.ToUpper().Contains(filterString) || filterString == "") {
                        lbImageFileName.Items.Add(file);
                    }
                }
            } else {
                foreach(string file in ImageDir.FileNameList) {
                    if(file.ToUpper().Contains(filterString) || filterString == "") {
                        lbImageFileName.Items.Add(file);
                    }
                }
            }
        }

        private void btClearFilterText_Click(object sender, EventArgs e)
        {
            tbFilter.Text = "";
        }
    }
}
