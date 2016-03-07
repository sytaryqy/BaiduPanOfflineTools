using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.IO;

namespace BaiduYunPanOfflineTool
{
    public partial class FormMain : Form
    {
        HtmlElement btnConfirm = null;
        List<string> listUrls = new List<string>();
        int intCurrentNo = 0;
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (btnLogin.Text == "退出")
            {
                npdDelayTime.Enabled = false;
                ckbIsChangeDir.Enabled = false;
                btnOfflineDownFile.Enabled = false;
                btnLogin.Text = "登录";
                //webBrowser1.Dispose();
                WebBrowser webNewBrowser = new WebBrowser();
                webBrowser1.Dispose();
                webBrowser1 = webNewBrowser;
                webBrowser1.Navigate("https://passport.baidu.com/v2/?login");
                webBrowser1.Visible = true;
                panViewWindow.Controls.Add(webBrowser1);
                panViewWindow.Controls[0].Dock = DockStyle.Fill;
                panViewWindow.Visible = false;
                webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
                lblErrorMsg.Text = "";
                webBrowser1.ScriptErrorsSuppressed = true;
                return;
            }
            this.webBrowser1.ScriptErrorsSuppressed = true;
            if (string.IsNullOrEmpty(txbUserName.Text) && string.IsNullOrEmpty(txbPassWord.Text))
            {
                lblErrorMsg.Text = "用户名或者密码不能为空，请输入！";
                return;
            }
            string strUserName = txbUserName.Text;
            string strPsw = txbPassWord.Text;
            //HttpWebRequest hwRequest = (HttpWebRequest) WebRequest.Create("https://passport.baidu.com/v2/?login");
            System.Windows.Forms.HtmlDocument document = this.webBrowser1.Document;
            if (document == null)
            {
                return;
            }
            document.All["TANGRAM__PSP_3__userName"].SetAttribute("Value", strUserName); //用户名   
            document.All["TANGRAM__PSP_3__password"].SetAttribute("Value", strPsw); //密码
            if (document.All["TANGRAM__PSP_3__memberPass"].GetAttribute("CHECKED") == "True")
            {
                document.All["TANGRAM__PSP_3__memberPass"].InvokeMember("click"); //是否自动登录
            }
            //string strIsAutoLogin= document.All["TANGRAM__PSP_3__memberPass"].GetAttribute("CHECKED");
            document.All["TANGRAM__PSP_3__submit"].InvokeMember("click"); //登录按钮的click方法
            //上面显示登录成功的界面，下面进行跳转，就没有用户了。
            
            Thread.Sleep(1000);//重点(需要引用using System.Threading;)
            this.webBrowser1.Navigate("http://pan.baidu.com/");

            //webBrowser1.Visible = true;
            
        }

        private void btnOfflineDownload_Click(object sender, EventArgs e)
        {
            string strOfflineFilePath = txbOfflineFilePath.Text;
            if (string.IsNullOrEmpty(strOfflineFilePath))
            {
                lblErrorMsg.Text = "文件为空，请重新选择";
                return;
            }
            using (StreamReader sr = new StreamReader (strOfflineFilePath))
            {
                //arrayFilePath = new byte[fs.Length];
                //fs.Read(arrayFilePath, 0, (int)(fs.Length - 1));
                while (!sr.EndOfStream)
                {
                    listUrls.Add(sr.ReadLine());
                }
                
            }

            if (listUrls.Count > 0)
            {
                intCurrentNo = 0;
            }
            else
            {
                lblErrorMsg.Text = "文件中没有行！";
                return;
            }
            System.Windows.Forms.HtmlDocument document = this.webBrowser1.Document;
            //webBrowser1.Update();
            if (document == null)
            {
                return;
            }
            var temp3 = document.All["layoutMain"];
            var tempa= temp3.FirstChild.GetElementsByTagName("a");
            HtmlElement heOfflineLink=null;
            foreach (System.Windows.Forms.HtmlElement temp in tempa)
            {
                if (temp.InnerText == "离线下载")
                {
                    heOfflineLink = temp;
                }
            }
            if (heOfflineLink != null)
            {
                heOfflineLink.InvokeMember("click");
                timOffileDown.Interval =(int) npdDelayTime.Value;
                timOffileDown.Start();
                
            }
            
            
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            System.Windows.Forms.HtmlDocument document = this.webBrowser1.Document;
            var htmlNewLinDown = document.All["_disk_id_2"];
            if (htmlNewLinDown != null)
            {
                htmlNewLinDown.InvokeMember("click");
            }
            //timOffileDown.Stop();
            timDown.Interval = (int)npdDelayTime.Value / 2;
            timDown.Start();
        }

        private void timDown_Tick(object sender, EventArgs e)
        {

            if (listUrls.Count > 0)
            {
                System.Windows.Forms.HtmlDocument document = this.webBrowser1.Document;
                string strOfflineUrl = listUrls[intCurrentNo];
                var txbOfflineLink = document.All["share-offline-link"];
                txbOfflineLink.SetAttribute("Value", strOfflineUrl); //离线下载链接
                if (listUrls.Count == intCurrentNo + 1)
                {
                    timOffileDown.Stop();
                }
                btnConfirm = GetBtnConfirm(document, "确定");
                if (btnConfirm != null)
                {
                    btnConfirm.InvokeMember("click");
                    intCurrentNo++;
                }
                else
                {
                    btnConfirm = GetBtnConfirm(document, "确定");
                    btnConfirm.InvokeMember("click");
                    intCurrentNo++;
                }
                timDown.Stop();
            }
            else
            {
                timOffileDown.Stop();
                timDown.Stop();
                System.Windows.Forms.HtmlDocument document = this.webBrowser1.Document;
                var linkChangeDir = GetBtnConfirm(document, "更改");
                if (linkChangeDir != null)
                {
                    linkChangeDir.InvokeMember("click");
                    timLoadFileTree.Interval = (int)npdDelayTime.Value;
                    timLoadFileTree.Start();
                }
            }


            
        }

        private HtmlElement GetBtnConfirm(System.Windows.Forms.HtmlDocument document,string strBtnName)
        {
            HtmlElement returnBtnObj = null;
            var htmlNewOfflineDialog = document.All["newoffline-dialog"];
            if (htmlNewOfflineDialog != null)
            {
                foreach (System.Windows.Forms.HtmlElement temp in htmlNewOfflineDialog.GetElementsByTagName("a"))
                {
                    if (temp.InnerText == strBtnName)
                    {
                        returnBtnObj = temp;
                    }
                }
            }
            if (returnBtnObj != null)
            {
                return returnBtnObj;
            }
            else
            {
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialogOfflineFile.ShowReadOnly=true;
            openFileDialogOfflineFile.ShowDialog();
            txbOfflineFilePath.Text = openFileDialogOfflineFile.FileName;
        }

        private void ckbIsChangeDir_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbIsChangeDir.Checked == true)
            {
                trvFileTreeOfBaiduPan.Enabled = true;
                ClickOfflineDown(this.webBrowser1.Document);
                timOffileDown.Interval = (int)npdDelayTime.Value;
                timOffileDown.Start();
            }
            else
            {
                trvFileTreeOfBaiduPan.Enabled = false;
            }
        }

        private static void ClickOfflineDown(System.Windows.Forms.HtmlDocument document)
        {
            
            var temp3 = document.All["layoutMain"];
            var tempa = temp3.FirstChild.GetElementsByTagName("a");
            HtmlElement heOfflineLink = null;
            foreach (System.Windows.Forms.HtmlElement temp in tempa)
            {
                if (temp.InnerText == "离线下载")
                {
                    heOfflineLink = temp;
                }
            }
            if (heOfflineLink != null)
            {
                heOfflineLink.InvokeMember("click");
            }
        }


        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.Host == "pan.baidu.com")
            {
                var temp3 = webBrowser1.Document.All["layoutMain"];
                if (webBrowser1.DocumentTitle == "百度云 网盘-全部文件")
                {
                    lblErrorMsg.Text = "登录成功";
                    ckbIsChangeDir.Enabled = true;
                    npdDelayTime.Enabled = true;
                    btnOfflineDownFile.Enabled = true;
                    btnLogin.Text = "退出";
                }
                else
                {
                    lblErrorMsg.Text = "登录失败，请重试";
                    this.webBrowser1.Navigate("https://passport.baidu.com/v2/?login");
                }
            }
        }

        private void timLoadFileTree_Tick(object sender, EventArgs e)
        {
            timLoadFileTree.Stop();
            System.Windows.Forms.HtmlDocument document = this.webBrowser1.Document;
            var htmlFileTree = document.All["fileTreeDialog"];
            HtmlElement htmlHome = htmlFileTree.GetElementsByTagName("LI")[0];
            string[] strSplit = { "\r\n" };
            string[] strFileList= htmlHome.OuterText.Split(strSplit,StringSplitOptions.RemoveEmptyEntries);
                //foreach (HtmlElement htmltemp in htmlFileTree.GetElementsByTagName("LI"))
                //{
                //    htmltemp.GetElementsByTagName("LI");
                //}
            TreeNode tn = trvFileTreeOfBaiduPan.Nodes.Add(strFileList[0]);
            for (int i = 1; i < strFileList.Length - 1; i++)
            {
                tn.Nodes.Add(strFileList[i]);
            }
            trvFileTreeOfBaiduPan.ExpandAll();
        }

        private void ckbShowWeb_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbShowWeb.Checked == true)
            {
                panViewWindow.Visible = true;
                webBrowser1.Visible = true;
            }
            else
            {
                webBrowser1.Visible = false;
                panViewWindow.Visible = false;
            }
        }


        private void txbPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

    }
}
