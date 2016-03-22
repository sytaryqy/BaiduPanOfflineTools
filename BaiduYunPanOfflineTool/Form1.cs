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

        //the file list we want to offlinedownload
        List<string> listUrls = new List<string>();

        //current loading number
        int intCurrentNo = 0;


        public FormMain()
        {
            InitializeComponent();
        }


        //Login button Click event
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Judge the state of the web is logined or not.
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

            //Set the webBrowser1 do not show the alert dialog.
            this.webBrowser1.ScriptErrorsSuppressed = true;

            //If the user didn't login the BaiduPan,begin load the username and password and login.
            if (string.IsNullOrEmpty(txbUserName.Text) && string.IsNullOrEmpty(txbPassWord.Text))
            {
                lblErrorMsg.Text = "用户名或者密码不能为空，请输入！";
                return;
            }
            string strUserName = txbUserName.Text;
            string strPsw = txbPassWord.Text;
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
            document.All["TANGRAM__PSP_3__submit"].InvokeMember("click"); //登录按钮的click方法
            //上面显示登录成功的界面，下面进行跳转，就没有用户了。
            
            Thread.Sleep(1000);//重点(需要引用using System.Threading;)

            this.webBrowser1.Navigate("http://pan.baidu.com/");
            
        }


        //Offlinedownload Button Click Event Handler
        private void btnOfflineDownload_Click(object sender, EventArgs e)
        {
            string strOfflineFilePath = txbOfflineFilePath.Text;

            //Confirm the user has choiced the offlinedownload file. 
            if (string.IsNullOrEmpty(strOfflineFilePath))
            {
                lblErrorMsg.Text = "文件为空，请重新选择";
                return;
            }

            //Loading the offlinedownload file
            using (StreamReader sr = new StreamReader (strOfflineFilePath))
            {
                while (!sr.EndOfStream)
                {
                    listUrls.Add(sr.ReadLine());
                }
                
            }

            //Init the intCurrentNo if the file has lines
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

            //Make sure the current web is not null.
            if (document == null)
            {
                return;
            }

            //Find the htmlElement of offlinedownload button.
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

            //If the Offlinedownload exist,start the timOffileDown timer.
            if (heOfflineLink != null)
            {
                heOfflineLink.InvokeMember("click");

                //Use the value of npdDelayTime set the timer's interval.
                timOffileDown.Interval =(int) npdDelayTime.Value;
                btnOfflineDownload.Enabled = false;
                timOffileDown.Start();
                
            }
            
            
        }

        //If the timOffileDown ticked,find the 新建链接任务 button and click it 
        //then start the timDown timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            timOffileDown.Stop();

            System.Windows.Forms.HtmlDocument document = this.webBrowser1.Document;
            var htmlNewLinDown = document.All["_disk_id_2"];
            if (htmlNewLinDown != null)
            {
                htmlNewLinDown.InvokeMember("click");
            }
            //timOffileDown.Stop();
            timDown.Interval = (int)npdDelayTime.Value;
            timDown.Start();
        }

        //The timDown Timer Tick Event Handler
        private void timDown_Tick(object sender, EventArgs e)
        {
            //After downloaded all the files,we should stop the timDown timer.
            timDown.Stop();

            System.Windows.Forms.HtmlDocument document = this.webBrowser1.Document;
            //Find the htmlElement of 更改 and click it.
            var linkChangeDir = GetBtnConfirm(document, "更改");

            //If the expression listUrls.Count > 0 is true,means the timer was started by Offlinedownload
            //button.Otherwise,it means the timer was started by the ckbIsChangeDir checkbox and we should
            if (listUrls.Count > 0)
            {
               

                //Find the textbox of offlinedownload's url 
                string strOfflineUrl = listUrls[intCurrentNo];
                var txbOfflineLink = document.All["share-offline-link"];

                //Input the url
                txbOfflineLink.SetAttribute("Value", strOfflineUrl); //离线下载链接

                //Change the task's directory.
                if (ckbIsChangeDir.Checked == true)
                {
                    string strSelectedPath = trvFileTreeOfBaiduPan.SelectedNode.Text;
                    if (strSelectedPath != "全部文件")
                    {
                        linkChangeDir.InvokeMember("click");
                        timChangeDir.Interval = (int)npdDelayTime.Value;
                        timChangeDir.Start();
                        return;
                    }

                }

                //If offline downloaded all the files,we stop the timer timOffileDown.
                if (listUrls.Count == intCurrentNo + 1)
                {
                    //Clean up the variables.
                    listUrls = new List<string>();

                    //Finished offline download and enable the btnOfflineDownload
                    btnOfflineDownload.Enabled = true;

                }
                else
                {
                    timOffileDown.Start();
                }

                //Find the 确定 button
                HtmlElement btnConfirm = GetBtnConfirm(document, "确定");
                
                //If we found the button then we click it.
                if (btnConfirm != null)
                {
                    btnConfirm.InvokeMember("click");
                    //Add the variable of current loaded number.
                    intCurrentNo++;
                }
                else
                {
                    //If the btnConfirm is null,we should find it first.
                    btnConfirm = GetBtnConfirm(document, "确定");
                    btnConfirm.InvokeMember("click");
                    intCurrentNo++;
                }



            }
            else
            {
                
                if (linkChangeDir != null)
                {
                    linkChangeDir.InvokeMember("click");
                    timLoadFileTree.Interval = (int)npdDelayTime.Value;

                    //Start the timLoadFileTree timer to load the list of BaiduPan directory.
                    timLoadFileTree.Start();
                }
            }


            
        }

        //Find the button of confirm from the document by strBtnName.
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

        /// <summary>
        /// Show the OpenFileDialog window.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialogOfflineFile.ShowReadOnly=true;
            openFileDialogOfflineFile.ShowDialog();
            txbOfflineFilePath.Text = openFileDialogOfflineFile.FileName;
        }


        /// <summary>
        /// According to the state of the ckbIsChangeDir checkbox, change the state of others.
        /// </summary>
        private void ckbIsChangeDir_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbIsChangeDir.Checked == true)
            {
                btnReadDirList.Enabled = true;
                ClickOfflineDown(this.webBrowser1.Document);
                timOffileDown.Interval = (int)npdDelayTime.Value;

                //Lock the btnOfflineDownload button while the directory change process is running.
                btnOfflineDownload.Enabled = false;
            }
            else
            {
                trvFileTreeOfBaiduPan.Enabled = false;
                btnReadDirList.Enabled = false;
                btnOfflineDownload.Enabled = true;
            }
        }


        /// <summary>
        /// Click the "离线下载" button of the web
        /// </summary>
        /// <param name="document">current web document</param>
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

        /// <summary>
        /// Use the DocumentCompleted event judge the login state
        /// </summary>
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

        /// <summary>
        /// The timer that begin load TreeViewList datas
        /// </summary>
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
                if (strFileList[i] == "百度云收藏")
                {
                    tn.Nodes.Add("我的收藏");
                    continue;
                }
                tn.Nodes.Add(strFileList[i]);
            }
            trvFileTreeOfBaiduPan.ExpandAll();
        }

        /// <summary>
        /// Change the visable state of webBrowser1
        /// </summary>
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


        /// <summary>
        /// Automaticlly press the btnLogin button
        /// </summary>
        private void txbPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        /// <summary>
        /// TreeViewList Node AfterSelect Event Handler
        /// </summary>
        private void trvFileTreeOfBaiduPan_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            HtmlElement eleTreeDilogClose = this.GetHtmlElement(webBrowser1.Document, "fileTreeDialog", "H3", "", "dialog-icon dialog-close");
            if (eleTreeDilogClose != null)
            {
                eleTreeDilogClose.NextSibling.FirstChild.InvokeMember("click");
            }

            btnOfflineDownload.Enabled = true;
                       
        }

        /// <summary>
        /// btnReadDirList button click event handler
        /// </summary>
        private void btnReadDirList_Click(object sender, EventArgs e)
        {
            //Use the treeview show the directory of the BaiduPan
            trvFileTreeOfBaiduPan.Enabled = true;

            //Start load the directory
            timOffileDown.Start();
        }

        /// <summary>
        /// Get html element by foreach search the document
        /// </summary>
        /// <param name="document">html document which you want get element from </param>
        /// <param name="strElementId">element Id</param>
        /// <param name="strElementTagName">element tag name which you want</param>
        /// <param name="strAttribute">element attribute which you want</param>
        /// <param name="strBtnName">element inner text</param>
        /// <returns>html element</returns>
        private HtmlElement GetHtmlElement(System.Windows.Forms.HtmlDocument document, string strElementId ,string strElementTagName ,string strAttribute,string strBtnName)
        {
            //statment the return object
            HtmlElement returnBtnObj = null;
            var htmlNewOfflineDialog = document.All[strElementId];
            if (htmlNewOfflineDialog != null)
            {
                if (string.IsNullOrEmpty(strAttribute))
                {
                    returnBtnObj = htmlNewOfflineDialog.GetElementsByTagName(strElementTagName)[0];
                }
                else
                {
                    //Find out the object equals that the attribute of strAttribute is strBtnName
                    foreach (System.Windows.Forms.HtmlElement temp in htmlNewOfflineDialog.GetElementsByTagName(strElementTagName))
                    {
                        if (temp.GetAttribute(strAttribute) == strBtnName)
                        {
                            returnBtnObj = temp;
                        }
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


        //Change the directory to the selected directory
        private void timChangeDir_Tick(object sender, EventArgs e)
        {
            //Stop the timer to finish the change directory process.
            timChangeDir.Stop();

            System.Windows.Forms.HtmlDocument document = this.webBrowser1.Document;

            //Get the directory list htmlElement.
            var htmlDirList= GetHtmlElement(webBrowser1.Document, "fileTreeDialog", "SPAN", "InnerText", "全部文件").Parent.Parent.NextSibling;

            //Search the selected directory
            foreach (HtmlElement htmlnode in htmlDirList.GetElementsByTagName("SPAN"))
            {
                if (htmlnode.InnerText == trvFileTreeOfBaiduPan.SelectedNode.Text)
                {
                    //check the directory
                    htmlnode.InvokeMember("click");
                    
                    //press the confirm button
htmlDirList.Parent.Parent.Parent.Parent.NextSibling.FirstChild.NextSibling.FirstChild.InvokeMember("click");
                    break;
                }
            }

            timChangDirDownload.Interval = (int)npdDelayTime.Value;
            timChangDirDownload.Start();

        }

        private void timChangDirDownload_Tick(object sender, EventArgs e)
        {
            timChangDirDownload.Stop();

            if (listUrls.Count == intCurrentNo + 1)
            {
                //Clean up the variables.
                listUrls = new List<string>();

                btnOfflineDownload.Enabled = true;

            }
            else
            {
                timDown.Start();
            }

            //Find the 确定 button
            HtmlElement btnConfirm = GetBtnConfirm(webBrowser1.Document, "确定");

            //If we found the button then we click it.
            if (btnConfirm != null)
            {
                btnConfirm.InvokeMember("click");
                //Add the variable of current loaded number.
                intCurrentNo++;
            }

           
        }

    }
}
