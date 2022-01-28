using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace UNAUP_Pojie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void startThisAgainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        string usna;
        string jusd;

        private void button1_Click(object sender, EventArgs e)
        {
            usna = textBox1.Text;
            jusd = usna + "gan" + usna + "xie" + usna + "gou" + usna + "mai" + usna;
            MessageBox.Show("Successful Apply","success",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = jusd;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter myStream;
                SaveFileDialog filepath = new SaveFileDialog();
                filepath.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                filepath.FilterIndex = 1;
                filepath.RestoreDirectory = true;
                if (filepath.ShowDialog() == DialogResult.OK)
                {
                    myStream = new StreamWriter(filepath.FileName);
                    myStream.Write(textBox2.Text);
                    myStream.Close();
                }
            }
            catch
            {
                MessageBox.Show("(art)*.dll.error = 0x0000001010001", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void joinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("(art)*.dll.error = 0x0000001010001", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string selfPath = Application.ExecutablePath;
                Process.Start(selfPath);
            }
            catch
            {
                MessageBox.Show("(Keygen)*.dll.error = 0x0000001010001", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string selfPath = Application.ExecutablePath;
                Process.Start(selfPath);
            }
            catch
            {
                MessageBox.Show("(Keygen)*.dll.error = 0x0000001010001", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string selfPath = Application.ExecutablePath;
                Process.Start(selfPath);
            }
            catch
            {
                MessageBox.Show("(Keygen)*.dll.error = 0x0000001010001", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openPasswordMarketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string selfPath = Application.ExecutablePath;
                Process.Start(selfPath);
            }
            catch
            {
                MessageBox.Show("(Keygen)*.dll.error = 0x0000001010001", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Width = 345;
            Height = 489;
        }
    }
}
