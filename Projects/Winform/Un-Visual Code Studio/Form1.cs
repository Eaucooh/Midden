using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Diagnostics;
using System.Drawing;

namespace Un_Visual_Code_Studio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        private void Form1_Load(object sender, EventArgs e)
        {
            Console.Write("Application Start!");
            richTextBox1.Text.Insert(0, "\r\n");
            string first = config.AppSettings.Settings["version"].Value.ToString();
            string second = config.AppSettings.Settings["value"].Value.ToString();
            string before = first + "\r\n" + second;
            richTextBox1.Text = before;
            richTextBox3.Text = @"Shell:>" + "\r\n";
            richTextBox1.ReadOnly = true;
            richTextBox2.ReadOnly = true;
            richTextBox3.ReadOnly = true;
        }

        public Form fomr = new Form();
        public Form aet = new Form();
        public TextBox tb = new TextBox();
        public Button bu2 = new Button();
        public FlowLayoutPanel tu = new FlowLayoutPanel();
        public string atuy;

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            string first = config.AppSettings.Settings["version"].Value.ToString();
            string second = config.AppSettings.Settings["value"].Value.ToString();
            string before = first + "\r\n" + second;
            richTextBox1.Text = before;
        }

        private void RichTextBox3_TextChanged(object sender, EventArgs e)
        {
            richTextBox3.Text = @"Shell:>" + "\r\n";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string nt = textBox1.Text.ToString();
            if (nt == "help" || nt == "/?")
            {
                string helpNum = config.AppSettings.Settings["ways"].Value.ToString();
                int helpNumber = int.Parse(helpNum);
                for (int i = 0; i < helpNumber; i++)
                {
                    int o = i + 1;
                    string way = "way" + o;
                    string helpText = config.AppSettings.Settings[way].Value.ToString();
                    richTextBox2.Text = richTextBox2.Text + helpText + "\r\n";
                }
                textBox1.Text = "";
            }
            else if (nt == "form")
            {
                Form fom = new Form();
                fom.Width = 500;
                fom.Height = 500;
                fom.Show();
                string result = "Create Success!";
                richTextBox2.Text = richTextBox2.Text + result + "\r\n";
                textBox1.Text = "";
            }
            else if (nt == "button")
            {
                Form fom = new Form();
                fom.Width = 500;
                fom.Height = 500;
                Button buton = new Button();
                buton.Text = "Button";
                fom.Controls.Add(buton);
                fom.Show();
                string result = "Create Success!";
                richTextBox2.Text = richTextBox2.Text + result + "\r\n";
                textBox1.Text = "";
            }
            else if (nt == "webbrowser")
            {
                Form fom = new Form();
                fom.Width = 1500;
                fom.Height = 800;
                WebBrowser web = new WebBrowser();
                web.Url = new System.Uri(@"http://www.baidu.com");
                web.Width = 500;
                web.Height = 500;
                web.Dock = DockStyle.Fill;
                fom.Controls.Add(web);
                fom.Show();
                string result = "Create Success!";
                richTextBox2.Text = richTextBox2.Text + result + "\r\n";
                textBox1.Text = "";
            }
            else if (nt == "messagebox")
            {
                MessageBox.Show("MessageBox", "MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string result = "Show MessageBox Success!";
                richTextBox2.Text = richTextBox2.Text + result + "\r\n";
                textBox1.Text = "";
            }
            else if (nt == "dispose")
            {
                Dispose();
                string result = "Dispose Success!";
                richTextBox2.Text = richTextBox2.Text + result + "\r\n";
                textBox1.Text = "";
            }
            else if (nt == "exit")
            {
                string result = "Environment.Exit(0) Success!";
                richTextBox2.Text = richTextBox2.Text + result + "\r\n";
                Environment.Exit(0);
            }
            else if (nt == "cd")
            {
                richTextBox2.Text = richTextBox2.Text + "Create Wrong!" + "\r\n";
                textBox1.Text = "";
            }
            else if (nt == "exit")
            {
                textBox1.Text = "";
                Application.Exit();
            }
            else
            {
                richTextBox2.Text = richTextBox2.Text + "Wrong Order!Check your code!" + "\r\n";
                textBox1.Text = "";
            }
        }

        private void Fomr_SizeChanged(object sender, EventArgs e)
        {
            fomr.Width = 200;
            fomr.Height = 70;
        }   
    }
}
