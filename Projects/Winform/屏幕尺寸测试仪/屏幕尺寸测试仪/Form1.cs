using System;
using System.Windows.Forms;
using System.Threading;
using WebKit;

namespace 屏幕尺寸测试仪
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int qer;
        int qwr;
        int t1 = 1;
        int t12 = 1;

        private WebKit.WebKitBrowser WebBox;

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            WebBox = new WebKitBrowser();
            WebBox.Width = 1000;
            WebBox.Height = 500;
            WebBox.Left= 180;
            WebBox.Top= 0;
            */
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            qer = Width;
            qwr = Height;
            textBox1.Text = qer.ToString();
            textBox2.Text = qwr.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            qer = Width;
            qwr = Height;
            textBox1.Text = qer.ToString();
            textBox2.Text = qwr.ToString();
        }
    }
}
