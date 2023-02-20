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
    public partial class Payment : Form
    {
        public Payment()
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
                if (item.Types == Type.nember && item.States == State.Openaccount)
                {
                    comboBox1.Items.Add(item.ID);
                }

            }
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "请选择")
            {
                Texts(comboBox1.Text);
            }
            else
            {
                label6.Text = "无";
            }
        }
        /// <summary>
        /// 显示卡余额
        /// </summary>
        /// <param name="a"></param>
        private void Texts(string a)
        {
            label6.Text = (Magager.Park.Diy[a] as MemberConsumer).Balance == "" ? "0" : (Magager.Park.Diy[a] as MemberConsumer).Balance;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "请选择")
            {
                (Magager.Park.Diy[comboBox1.Text] as MemberConsumer).Recharge(textBox2.Text.Trim().ToString());
                MessageBox.Show("充值成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("请选择卡号");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
