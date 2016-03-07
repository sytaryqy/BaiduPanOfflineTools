using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var p = new Yyc.Net.PageSnatch();
            Yyc.Net.SnatchCompletedEventArgs ttt=new Yyc.Net.SnatchCompletedEventArgs ();
            p.Timeout = 20000;
            p.Url = "http://www.baidu.com";
            p.SnatchCompleted += new Yyc.Net.SnatchCompletedEventHandler(MySnatchCompletedEventHandler);
            p.Navigate();
            panWebBrowser.Controls[0].Dispose();
            WebBrowser web1 = new WebBrowser();
            web1.Navigate("http://www.baidu.com");
            panWebBrowser.Controls.Add(web1);
        }

        private void MySnatchCompletedEventHandler(object obj, Yyc.Net.SnatchCompletedEventArgs e)
        {
            textBox1.Text = e.TextAsync;
        }


    }
}
