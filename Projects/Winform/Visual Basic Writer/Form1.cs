using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Visual_Basic_Writer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string NowPath;
        public string NowText = "";
        public string BeforeText;

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("程序已经准备就绪!", "启动完成!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selfPath = Application.ExecutablePath;
            Process.Start(selfPath);
        }

        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "VBS文件(*.vbs)|*.vbs|VBE文件(*.vbe)|*.vbe";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.Default);
                    richTextBox1.Text = sr.ReadToEnd();
                    sr.Close();
                    NowPath = Path.GetFullPath(openFileDialog1.FileName);
                }
                catch
                {
                    MessageBox.Show("文件打开错误", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter myStream;
                myStream = new StreamWriter(openFileDialog1.FileName);
                myStream.Write(richTextBox1.Text);
                myStream.Close();
                if (MessageBox.Show("保存成功,是否调试程序?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Process m_Process = new Process();
                    string notePath = NowPath;
                    m_Process.StartInfo.FileName = notePath;
                    m_Process.Start();
                }
            }
            catch
            {
                MessageBox.Show("错误", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 调试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process m_Process = new Process();
                string notePath = NowPath;
                m_Process.StartInfo.FileName = notePath;
                m_Process.Start();
            }
            catch
            {
                MessageBox.Show("没有打开的文件,无法调试", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            NowText = richTextBox1.Text.ToString();
        }

        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeforeText = richTextBox1.Text.ToString();
            richTextBox1.Text = NowText;
        }

        private void 重做ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NowText = richTextBox1.Text.ToString();
            richTextBox1.Text = BeforeText;
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter myStream;
            SaveFileDialog filepath = new SaveFileDialog();
            filepath.Filter = "VBS Files(*.vbs)|*.vbs|VBE Files(*.vbe)|*.vbe";
            filepath.FilterIndex = 1;
            filepath.RestoreDirectory = true;
            if (filepath.ShowDialog() == DialogResult.OK)
            {
                myStream = new StreamWriter(filepath.FileName);
                myStream.Write(richTextBox1.Text);
                myStream.Close();
            }
        }

        private void 帮助ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Process m_Process = new Process();
                string selfPath = Application.StartupPath;
                string helpPath = selfPath + @"\help.hta";
                m_Process.StartInfo.FileName = helpPath;
                m_Process.Start();
            }
            catch
            {
                MessageBox.Show("程序找不到帮助文档了。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process m_Process = new Process();
                string selfPath = Application.StartupPath;
                string helpPath = selfPath + @"\about.docx";
                m_Process.StartInfo.FileName = helpPath;
                m_Process.Start();
            }
            catch
            {
                MessageBox.Show("关于文档丢失。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 技术支持ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process m_Process = new Process();
                string selfPath = Application.StartupPath;
                string helpPath = selfPath + @"\support.txt";
                m_Process.StartInfo.FileName = helpPath;
                m_Process.Start();
            }
            catch
            {
                MessageBox.Show("程序找不到技术支持文档了。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 购买许可证ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("无法连接服务器\r\n请稍后再试。\r\n\r\n具体原因请致电或者发送反馈报告至www.paper.com。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog printRich = new PrintDialog();
                printRich.Tag = richTextBox1.Text.ToString();
                printRich.ShowDialog();
            }
            catch
            {
                MessageBox.Show("打印失败。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
    }
}
