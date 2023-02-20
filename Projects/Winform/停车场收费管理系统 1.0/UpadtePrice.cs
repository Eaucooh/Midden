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
    public partial class UpadtePrice : Form
    {
        public UpadtePrice()
        {
            InitializeComponent();
            this.comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Daa();
        }
        private void Daa()
        {
            if (textBox1.Text.Trim().ToString() != "" && comboBox1.Text != "请选择")
            {
                Magager.Park.Pak.Price = textBox1.Text.Trim().ToString();
                Magager.Park.Pak.Discount = comboBox1.Text;
                MessageBox.Show("修改成功");
                this.Close();

            }
            else
            {
                MessageBox.Show("请填写完整");
            }
        }
    }
}
