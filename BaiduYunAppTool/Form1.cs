using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace BaiduYunAppTool
{
    public partial class Form1 : Form
    {
        string appName = "BaiduYunGuanjia.exe";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadApp_Click(object sender, EventArgs e)
        {
            try
            {
                //启动外部程序
                Process proc = Process.Start(appName);
                if (proc != null)
                {
                    //监视进程退出
                    proc.EnableRaisingEvents = true;
                    //指定退出事件方法
                    proc.Exited += new EventHandler(proc_Exited);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        ///启动外部程序退出事件
        /// </summary>
        void proc_Exited(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format("外部程序 {0} 已经退出！", this.appName), this.Text,
            MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
