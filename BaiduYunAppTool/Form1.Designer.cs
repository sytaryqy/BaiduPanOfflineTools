namespace BaiduYunAppTool
{
    partial class Form1
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
            this.btnLoadApp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoadApp
            // 
            this.btnLoadApp.Location = new System.Drawing.Point(39, 25);
            this.btnLoadApp.Name = "btnLoadApp";
            this.btnLoadApp.Size = new System.Drawing.Size(75, 23);
            this.btnLoadApp.TabIndex = 0;
            this.btnLoadApp.Text = "加载";
            this.btnLoadApp.UseVisualStyleBackColor = true;
            this.btnLoadApp.Click += new System.EventHandler(this.btnLoadApp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 289);
            this.Controls.Add(this.btnLoadApp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadApp;
    }
}

