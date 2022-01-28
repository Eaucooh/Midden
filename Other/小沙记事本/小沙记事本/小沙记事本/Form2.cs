using System;
using System.Windows.Forms;

namespace 小沙记事本
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }

        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            Width = 580;
            Height = 300;
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }
    }
}
