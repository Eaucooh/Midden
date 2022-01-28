using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace 小沙记事本
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void 主页ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 视图ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter myStream;
                myStream = new StreamWriter(openFileDialog1.FileName);
                myStream.Write(richTextBox1.Text);
                myStream.Close();
                if (MessageBox.Show("保存成功,是否打开文件?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.Default);
                    richTextBox1.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch
            {
                MessageBox.Show("错误", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
        }

        OpenFileDialog openFileDialog1 = new OpenFileDialog();        

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "文本文件(*.txt)|*.txt|(*.rtf)|*.rtf";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.Default);
                    richTextBox1.Text = sr.ReadToEnd();
                    sr.Close();
                }
                catch
                {
                    MessageBox.Show("文件打开错误","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter myStream;
            SaveFileDialog filepath = new SaveFileDialog();
            filepath.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            filepath.FilterIndex = 1;
            filepath.RestoreDirectory = true;
            if (filepath.ShowDialog() == DialogResult.OK)
            {
                myStream = new StreamWriter(filepath.FileName);
                myStream.Write(richTextBox1.Text);
                myStream.Close();
            }
            if (MessageBox.Show("保存成功,是否打开文件?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(filepath.FileName, Encoding.Default);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selfPath = Application.ExecutablePath;
            Process.Start(selfPath);
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int a = 0;
                if (a == 0)
                {
                    MessageBox.Show("文件打印错误", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("文件打印错误", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 atui = new Form2();
            atui.ShowDialog();
        }

        private void 关于小沙ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 qrto = new Form3();
            qrto.Show();
        }

        private void 设置中心ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 sadr = new Form4();
            sadr.ShowDialog();
        }
    }
}
