
namespace CBShowImage
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lbImageFileName = new System.Windows.Forms.ListBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbOpenFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cbShowRate = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ddbImageInitial = new System.Windows.Forms.ToolStripDropDownButton();
            this.aToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ddbAbout = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panelListBox = new System.Windows.Forms.Panel();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btUpDir = new System.Windows.Forms.Button();
            this.btClearFilterText = new System.Windows.Forms.Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slbImageSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.slbImageRate = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cbCopyFileName = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelListBox.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbImageFileName
            // 
            this.lbImageFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbImageFileName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lbImageFileName.FormattingEnabled = true;
            this.lbImageFileName.HorizontalScrollbar = true;
            this.lbImageFileName.ItemHeight = 25;
            this.lbImageFileName.Location = new System.Drawing.Point(0, 0);
            this.lbImageFileName.Name = "lbImageFileName";
            this.lbImageFileName.Size = new System.Drawing.Size(290, 315);
            this.lbImageFileName.TabIndex = 0;
            this.lbImageFileName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbImageFileName_DrawItem);
            this.lbImageFileName.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lbImageFileName_MeasureItem);
            this.lbImageFileName.SelectedIndexChanged += new System.EventHandler(this.lbImageFileName_SelectedIndexChanged);
            this.lbImageFileName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbImageFileName_KeyDown);
            this.lbImageFileName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbImageFileName_MouseDoubleClick);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(873, 54);
            this.panelTop.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbOpenFile,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripSeparator2,
            this.cbShowRate,
            this.toolStripSeparator3,
            this.ddbImageInitial,
            this.toolStripSeparator4,
            this.ddbAbout,
            this.toolStripSeparator5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(873, 55);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbOpenFile
            // 
            this.tbOpenFile.AutoSize = false;
            this.tbOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("tbOpenFile.Image")));
            this.tbOpenFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbOpenFile.Name = "tbOpenFile";
            this.tbOpenFile.Size = new System.Drawing.Size(52, 52);
            this.tbOpenFile.Text = "開啟";
            this.tbOpenFile.Click += new System.EventHandler(this.tbOpenFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 52);
            this.toolStripButton1.Text = "放大";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(52, 52);
            this.toolStripButton2.Text = "縮小";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(52, 52);
            this.toolStripButton3.Text = "原始大小";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // cbShowRate
            // 
            this.cbShowRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShowRate.Items.AddRange(new object[] {
            "800%",
            "400%",
            "300%",
            "200%",
            "150%",
            "100%",
            "75%",
            "50%",
            "25%",
            "10%"});
            this.cbShowRate.Name = "cbShowRate";
            this.cbShowRate.Size = new System.Drawing.Size(121, 55);
            this.cbShowRate.ToolTipText = "縮放比例";
            this.cbShowRate.SelectedIndexChanged += new System.EventHandler(this.cbShowRate_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // ddbImageInitial
            // 
            this.ddbImageInitial.AutoSize = false;
            this.ddbImageInitial.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ddbImageInitial.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aToolStripMenuItem1,
            this.bToolStripMenuItem1,
            this.cToolStripMenuItem1});
            this.ddbImageInitial.Image = ((System.Drawing.Image)(resources.GetObject("ddbImageInitial.Image")));
            this.ddbImageInitial.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ddbImageInitial.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbImageInitial.Name = "ddbImageInitial";
            this.ddbImageInitial.Size = new System.Drawing.Size(65, 52);
            this.ddbImageInitial.Text = "開啟圖檔的設定";
            this.ddbImageInitial.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ddbImageInitial_DropDownItemClicked);
            // 
            // aToolStripMenuItem1
            // 
            this.aToolStripMenuItem1.Checked = true;
            this.aToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aToolStripMenuItem1.Name = "aToolStripMenuItem1";
            this.aToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.aToolStripMenuItem1.Text = "原始大小";
            this.aToolStripMenuItem1.Click += new System.EventHandler(this.aToolStripMenuItem1_Click);
            // 
            // bToolStripMenuItem1
            // 
            this.bToolStripMenuItem1.Name = "bToolStripMenuItem1";
            this.bToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.bToolStripMenuItem1.Text = "適當全圖";
            this.bToolStripMenuItem1.Click += new System.EventHandler(this.bToolStripMenuItem1_Click);
            // 
            // cToolStripMenuItem1
            // 
            this.cToolStripMenuItem1.Name = "cToolStripMenuItem1";
            this.cToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.cToolStripMenuItem1.Text = "目前比例";
            this.cToolStripMenuItem1.Click += new System.EventHandler(this.cToolStripMenuItem1_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // ddbAbout
            // 
            this.ddbAbout.AutoSize = false;
            this.ddbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ddbAbout.Image = ((System.Drawing.Image)(resources.GetObject("ddbAbout.Image")));
            this.ddbAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ddbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbAbout.Name = "ddbAbout";
            this.ddbAbout.Size = new System.Drawing.Size(52, 52);
            this.ddbAbout.ToolTipText = "關於";
            this.ddbAbout.Click += new System.EventHandler(this.ddbAbout_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 55);
            // 
            // splitContainer
            // 
            this.splitContainer.DataBindings.Add(new System.Windows.Forms.Binding("SplitterDistance", global::CBShowImage.Properties.Settings.Default, "SplitDistance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panelListBox);
            this.splitContainer.Panel1.Controls.Add(this.panelFilter);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AutoScroll = true;
            this.splitContainer.Panel2.Controls.Add(this.pbImage);
            this.splitContainer.Size = new System.Drawing.Size(873, 362);
            this.splitContainer.SplitterDistance = global::CBShowImage.Properties.Settings.Default.SplitDistance;
            this.splitContainer.TabIndex = 7;
            // 
            // panelListBox
            // 
            this.panelListBox.Controls.Add(this.lbImageFileName);
            this.panelListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelListBox.Location = new System.Drawing.Point(0, 47);
            this.panelListBox.Name = "panelListBox";
            this.panelListBox.Size = new System.Drawing.Size(290, 315);
            this.panelListBox.TabIndex = 0;
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.panel2);
            this.panelFilter.Controls.Add(this.panel1);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 0);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(290, 47);
            this.panelFilter.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(121, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(169, 41);
            this.panel2.TabIndex = 4;
            // 
            // tbFilter
            // 
            this.tbFilter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbFilter.Location = new System.Drawing.Point(0, 7);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(169, 34);
            this.tbFilter.TabIndex = 3;
            this.toolTip1.SetToolTip(this.tbFilter, "過濾檔名");
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbCopyFileName);
            this.panel1.Controls.Add(this.btUpDir);
            this.panel1.Controls.Add(this.btClearFilterText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(121, 47);
            this.panel1.TabIndex = 3;
            // 
            // btUpDir
            // 
            this.btUpDir.Image = ((System.Drawing.Image)(resources.GetObject("btUpDir.Image")));
            this.btUpDir.Location = new System.Drawing.Point(3, 7);
            this.btUpDir.Name = "btUpDir";
            this.btUpDir.Size = new System.Drawing.Size(33, 35);
            this.btUpDir.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btUpDir, "回上層目錄");
            this.btUpDir.UseVisualStyleBackColor = true;
            this.btUpDir.Click += new System.EventHandler(this.btUpDir_Click);
            // 
            // btClearFilterText
            // 
            this.btClearFilterText.AutoSize = true;
            this.btClearFilterText.Image = ((System.Drawing.Image)(resources.GetObject("btClearFilterText.Image")));
            this.btClearFilterText.Location = new System.Drawing.Point(81, 7);
            this.btClearFilterText.Name = "btClearFilterText";
            this.btClearFilterText.Size = new System.Drawing.Size(33, 35);
            this.btClearFilterText.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btClearFilterText, "清除右邊過濾輸入欄位");
            this.btClearFilterText.UseVisualStyleBackColor = true;
            this.btClearFilterText.Click += new System.EventHandler(this.btClearFilterText_Click);
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(0, 0);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(342, 217);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            this.pbImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbImage_MouseDown);
            this.pbImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbImage_MouseMove);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slbImageSize,
            this.slbImageRate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(873, 25);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slbImageSize
            // 
            this.slbImageSize.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.slbImageSize.Name = "slbImageSize";
            this.slbImageSize.Size = new System.Drawing.Size(53, 19);
            this.slbImageSize.Text = "寬: 高:";
            // 
            // slbImageRate
            // 
            this.slbImageRate.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.slbImageRate.Name = "slbImageRate";
            this.slbImageRate.Size = new System.Drawing.Size(53, 19);
            this.slbImageRate.Text = "100%";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.statusStrip1);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 416);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(873, 25);
            this.panelBottom.TabIndex = 9;
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.splitContainer);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 54);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(873, 362);
            this.panelCenter.TabIndex = 10;
            // 
            // cbCopyFileName
            // 
            this.cbCopyFileName.Image = ((System.Drawing.Image)(resources.GetObject("cbCopyFileName.Image")));
            this.cbCopyFileName.Location = new System.Drawing.Point(42, 7);
            this.cbCopyFileName.Name = "cbCopyFileName";
            this.cbCopyFileName.Size = new System.Drawing.Size(33, 35);
            this.cbCopyFileName.TabIndex = 2;
            this.toolTip1.SetToolTip(this.cbCopyFileName, "複製選取欄位的文字");
            this.cbCopyFileName.UseVisualStyleBackColor = true;
            this.cbCopyFileName.Click += new System.EventHandler(this.cbCopyFileName_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 441);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::CBShowImage.Properties.Settings.Default, "FormLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.KeyPreview = true;
            this.Location = global::CBShowImage.Properties.Settings.Default.FormLocation;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "神秀圖";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelListBox.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lbImageFileName;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripDropDownButton ddbImageInitial;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cToolStripMenuItem1;
        private System.Windows.Forms.ToolStripComboBox cbShowRate;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel slbImageSize;
        private System.Windows.Forms.ToolStripStatusLabel slbImageRate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.ToolStripButton tbOpenFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel panelListBox;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Button btUpDir;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Button btClearFilterText;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton ddbAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Button cbCopyFileName;
    }
}

