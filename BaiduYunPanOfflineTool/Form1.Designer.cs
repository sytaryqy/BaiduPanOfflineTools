namespace BaiduYunPanOfflineTool
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txbUserName = new System.Windows.Forms.TextBox();
            this.txbPassWord = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassWord = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.txbOfflineFilePath = new System.Windows.Forms.TextBox();
            this.lblOfflineUrl = new System.Windows.Forms.Label();
            this.btnOfflineDownload = new System.Windows.Forms.Button();
            this.timOffileDown = new System.Windows.Forms.Timer(this.components);
            this.timDown = new System.Windows.Forms.Timer(this.components);
            this.btnOfflineDownFile = new System.Windows.Forms.Button();
            this.openFileDialogOfflineFile = new System.Windows.Forms.OpenFileDialog();
            this.lblErrorMsg = new System.Windows.Forms.Label();
            this.ckbIsChangeDir = new System.Windows.Forms.CheckBox();
            this.trvFileTreeOfBaiduPan = new System.Windows.Forms.TreeView();
            this.timLoadFileTree = new System.Windows.Forms.Timer(this.components);
            this.ckbShowWeb = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.npdDelayTime = new System.Windows.Forms.NumericUpDown();
            this.panViewWindow = new System.Windows.Forms.Panel();
            this.btnReadDirList = new System.Windows.Forms.Button();
            this.timChangeDir = new System.Windows.Forms.Timer(this.components);
            this.timChangDirDownload = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.npdDelayTime)).BeginInit();
            this.panViewWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbUserName
            // 
            this.txbUserName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txbUserName.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txbUserName.Location = new System.Drawing.Point(100, 501);
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Size = new System.Drawing.Size(161, 21);
            this.txbUserName.TabIndex = 0;
            // 
            // txbPassWord
            // 
            this.txbPassWord.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txbPassWord.Location = new System.Drawing.Point(100, 543);
            this.txbPassWord.Name = "txbPassWord";
            this.txbPassWord.Size = new System.Drawing.Size(161, 21);
            this.txbPassWord.TabIndex = 1;
            this.txbPassWord.UseSystemPasswordChar = true;
            this.txbPassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbPassWord_KeyDown);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.Location = new System.Drawing.Point(175, 578);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(87, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUserName.Location = new System.Drawing.Point(27, 504);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(57, 12);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "用户名：";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPassWord
            // 
            this.lblPassWord.AutoSize = true;
            this.lblPassWord.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPassWord.Location = new System.Drawing.Point(27, 546);
            this.lblPassWord.Name = "lblPassWord";
            this.lblPassWord.Size = new System.Drawing.Size(58, 12);
            this.lblPassWord.TabIndex = 4;
            this.lblPassWord.Text = "密  码：";
            this.lblPassWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(23, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(832, 463);
            this.webBrowser1.TabIndex = 5;
            this.webBrowser1.Url = new System.Uri("https://passport.baidu.com/v2/?login", System.UriKind.Absolute);
            this.webBrowser1.Visible = false;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // txbOfflineFilePath
            // 
            this.txbOfflineFilePath.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txbOfflineFilePath.Location = new System.Drawing.Point(462, 501);
            this.txbOfflineFilePath.Name = "txbOfflineFilePath";
            this.txbOfflineFilePath.ReadOnly = true;
            this.txbOfflineFilePath.Size = new System.Drawing.Size(274, 21);
            this.txbOfflineFilePath.TabIndex = 6;
            // 
            // lblOfflineUrl
            // 
            this.lblOfflineUrl.AutoSize = true;
            this.lblOfflineUrl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOfflineUrl.Location = new System.Drawing.Point(343, 504);
            this.lblOfflineUrl.Name = "lblOfflineUrl";
            this.lblOfflineUrl.Size = new System.Drawing.Size(96, 12);
            this.lblOfflineUrl.TabIndex = 7;
            this.lblOfflineUrl.Text = "批量离线文件：";
            this.lblOfflineUrl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOfflineDownload
            // 
            this.btnOfflineDownload.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOfflineDownload.Location = new System.Drawing.Point(706, 578);
            this.btnOfflineDownload.Name = "btnOfflineDownload";
            this.btnOfflineDownload.Size = new System.Drawing.Size(87, 23);
            this.btnOfflineDownload.TabIndex = 8;
            this.btnOfflineDownload.Text = "离线下载";
            this.btnOfflineDownload.UseVisualStyleBackColor = true;
            this.btnOfflineDownload.Click += new System.EventHandler(this.btnOfflineDownload_Click);
            // 
            // timOffileDown
            // 
            this.timOffileDown.Interval = 300;
            this.timOffileDown.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timDown
            // 
            this.timDown.Interval = 300;
            this.timDown.Tick += new System.EventHandler(this.timDown_Tick);
            // 
            // btnOfflineDownFile
            // 
            this.btnOfflineDownFile.Enabled = false;
            this.btnOfflineDownFile.Location = new System.Drawing.Point(755, 499);
            this.btnOfflineDownFile.Name = "btnOfflineDownFile";
            this.btnOfflineDownFile.Size = new System.Drawing.Size(38, 23);
            this.btnOfflineDownFile.TabIndex = 9;
            this.btnOfflineDownFile.Text = "...";
            this.btnOfflineDownFile.UseVisualStyleBackColor = true;
            this.btnOfflineDownFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialogOfflineFile
            // 
            this.openFileDialogOfflineFile.Filter = "文本文件(*.txt)|*.txt";
            this.openFileDialogOfflineFile.InitialDirectory = "c:\\";
            // 
            // lblErrorMsg
            // 
            this.lblErrorMsg.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMsg.Location = new System.Drawing.Point(30, 464);
            this.lblErrorMsg.Name = "lblErrorMsg";
            this.lblErrorMsg.Size = new System.Drawing.Size(357, 17);
            this.lblErrorMsg.TabIndex = 10;
            // 
            // ckbIsChangeDir
            // 
            this.ckbIsChangeDir.AutoSize = true;
            this.ckbIsChangeDir.Enabled = false;
            this.ckbIsChangeDir.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbIsChangeDir.Location = new System.Drawing.Point(345, 528);
            this.ckbIsChangeDir.Name = "ckbIsChangeDir";
            this.ckbIsChangeDir.Size = new System.Drawing.Size(128, 16);
            this.ckbIsChangeDir.TabIndex = 11;
            this.ckbIsChangeDir.Text = "是否更改存储目录";
            this.ckbIsChangeDir.UseVisualStyleBackColor = true;
            this.ckbIsChangeDir.CheckedChanged += new System.EventHandler(this.ckbIsChangeDir_CheckedChanged);
            // 
            // trvFileTreeOfBaiduPan
            // 
            this.trvFileTreeOfBaiduPan.Enabled = false;
            this.trvFileTreeOfBaiduPan.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trvFileTreeOfBaiduPan.Location = new System.Drawing.Point(479, 528);
            this.trvFileTreeOfBaiduPan.Name = "trvFileTreeOfBaiduPan";
            this.trvFileTreeOfBaiduPan.Size = new System.Drawing.Size(190, 105);
            this.trvFileTreeOfBaiduPan.TabIndex = 12;
            this.trvFileTreeOfBaiduPan.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvFileTreeOfBaiduPan_AfterSelect);
            // 
            // timLoadFileTree
            // 
            this.timLoadFileTree.Interval = 600;
            this.timLoadFileTree.Tick += new System.EventHandler(this.timLoadFileTree_Tick);
            // 
            // ckbShowWeb
            // 
            this.ckbShowWeb.AutoSize = true;
            this.ckbShowWeb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbShowWeb.Location = new System.Drawing.Point(29, 585);
            this.ckbShowWeb.Name = "ckbShowWeb";
            this.ckbShowWeb.Size = new System.Drawing.Size(102, 16);
            this.ckbShowWeb.TabIndex = 13;
            this.ckbShowWeb.Text = "是否显示窗口";
            this.ckbShowWeb.UseVisualStyleBackColor = true;
            this.ckbShowWeb.CheckedChanged += new System.EventHandler(this.ckbShowWeb_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(346, 561);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "延迟：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // npdDelayTime
            // 
            this.npdDelayTime.Enabled = false;
            this.npdDelayTime.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.npdDelayTime.Location = new System.Drawing.Point(396, 559);
            this.npdDelayTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.npdDelayTime.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.npdDelayTime.Name = "npdDelayTime";
            this.npdDelayTime.Size = new System.Drawing.Size(65, 21);
            this.npdDelayTime.TabIndex = 16;
            this.npdDelayTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.npdDelayTime.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // panViewWindow
            // 
            this.panViewWindow.Controls.Add(this.webBrowser1);
            this.panViewWindow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panViewWindow.Location = new System.Drawing.Point(0, 0);
            this.panViewWindow.Name = "panViewWindow";
            this.panViewWindow.Size = new System.Drawing.Size(832, 463);
            this.panViewWindow.TabIndex = 17;
            // 
            // btnReadDirList
            // 
            this.btnReadDirList.AutoSize = true;
            this.btnReadDirList.Enabled = false;
            this.btnReadDirList.Location = new System.Drawing.Point(358, 597);
            this.btnReadDirList.Name = "btnReadDirList";
            this.btnReadDirList.Size = new System.Drawing.Size(93, 23);
            this.btnReadDirList.TabIndex = 18;
            this.btnReadDirList.Text = "读取网盘目录";
            this.btnReadDirList.UseVisualStyleBackColor = true;
            this.btnReadDirList.Click += new System.EventHandler(this.btnReadDirList_Click);
            // 
            // timChangeDir
            // 
            this.timChangeDir.Interval = 300;
            this.timChangeDir.Tick += new System.EventHandler(this.timChangeDir_Tick);
            // 
            // timChangDirDownload
            // 
            this.timChangDirDownload.Interval = 300;
            this.timChangDirDownload.Tick += new System.EventHandler(this.timChangDirDownload_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 695);
            this.Controls.Add(this.btnReadDirList);
            this.Controls.Add(this.panViewWindow);
            this.Controls.Add(this.npdDelayTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckbShowWeb);
            this.Controls.Add(this.trvFileTreeOfBaiduPan);
            this.Controls.Add(this.ckbIsChangeDir);
            this.Controls.Add(this.lblErrorMsg);
            this.Controls.Add(this.btnOfflineDownFile);
            this.Controls.Add(this.btnOfflineDownload);
            this.Controls.Add(this.lblOfflineUrl);
            this.Controls.Add(this.txbOfflineFilePath);
            this.Controls.Add(this.lblPassWord);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txbPassWord);
            this.Controls.Add(this.txbUserName);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FormMain";
            this.Text = "BaiduPanOffilineDownloadTool";
            ((System.ComponentModel.ISupportInitialize)(this.npdDelayTime)).EndInit();
            this.panViewWindow.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbUserName;
        private System.Windows.Forms.TextBox txbPassWord;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassWord;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox txbOfflineFilePath;
        private System.Windows.Forms.Label lblOfflineUrl;
        private System.Windows.Forms.Button btnOfflineDownload;
        private System.Windows.Forms.Timer timOffileDown;
        private System.Windows.Forms.Timer timDown;
        private System.Windows.Forms.Button btnOfflineDownFile;
        private System.Windows.Forms.OpenFileDialog openFileDialogOfflineFile;
        private System.Windows.Forms.Label lblErrorMsg;
        private System.Windows.Forms.CheckBox ckbIsChangeDir;
        private System.Windows.Forms.TreeView trvFileTreeOfBaiduPan;
        private System.Windows.Forms.Timer timLoadFileTree;
        private System.Windows.Forms.CheckBox ckbShowWeb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown npdDelayTime;
        private System.Windows.Forms.Panel panViewWindow;
        private System.Windows.Forms.Button btnReadDirList;
        private System.Windows.Forms.Timer timChangeDir;
        private System.Windows.Forms.Timer timChangDirDownload;
    }
}

