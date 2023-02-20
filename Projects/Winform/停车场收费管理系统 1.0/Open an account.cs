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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            Gaa();
        }
        /// <summary>
        /// 下拉选项绑定卡号
        /// </summary>
        private void Gaa()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("请选择");
            foreach (Consumer item in Magager.Park.Diy.Values)
            {
                if (item.Types == Type.nember&& item.States==State.NotOpenaccount)
                {
                    comboBox1.Items.Add(item.ID);
                }
                
            }
            comboBox1.SelectedIndex = 0;
        }
        private string Number;//卡号
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Number = comboBox1.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Account(Number);
        }
        /// <summary>
        /// 开户
        /// </summary>
        /// <param name="a"></param>
        private void Account(string a)
        {
            if (comboBox1.Text != "请选择")
            {
                if (textBox2.Text.Trim().ToString() != "" && textBox3.Text.Trim().ToString() != "" && textBox4.Text.Trim().ToString() != "" && textBox5.Text.Trim().ToString() != "")
                {
                    (Magager.Park.Diy[a] as MemberConsumer).Account(textBox4.Text.Trim().ToString(), textBox3.Text.Trim().ToString(), textBox5.Text.Trim().ToString(), textBox2.Text.Trim().ToString(), DateTime.Now.ToString("yyy年MM月dd日 HH:mm:ss"), State.Openaccount);
                    Gaa();
                    MessageBox.Show("开户成功");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("开户信息请填写完整");
                }
            }
            else
            {
                MessageBox.Show("请选择开户卡号");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
