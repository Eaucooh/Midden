using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 停车场项目
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            DialogResult aa = MessageBox.Show("确认退出系统？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (aa == DialogResult.Yes)
            {
                Dispose();
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            UpadtePrice aa = new UpadtePrice();
            aa.ShowDialog();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Form10 aa = new Form10();
            aa.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            UpdatePassword aa = new UpdatePassword();
            aa.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form5 aa = new Form5();
            aa.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Payment aa = new Payment();
            aa.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Form7 aa = new Form7();
            aa.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Inquire aa = new Inquire();
            aa.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Form9 aa = new Form9();
            aa.ShowDialog();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            Magager.OnLoad();
        }
    }
}
