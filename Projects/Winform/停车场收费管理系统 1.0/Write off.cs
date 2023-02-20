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
    public partial class Form7 : Form
    {
        public Form7()
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
                Show(comboBox1.Text);
            }
            else
            {
                Faa();
                label5.Text = "无";
            }
        }

        private void Show(string a)
        {
            textBox2.Text = (Magager.Park.Diy[a] as MemberConsumer).PlateNumber;
            textBox3.Text = (Magager.Park.Diy[a] as MemberConsumer).CustName;
            textBox5.Text = (Magager.Park.Diy[a] as MemberConsumer).CustTel;
            label5.Text = (Magager.Park.Diy[a] as MemberConsumer).Balance;
        }


        /// <summary>
        /// 清空文本框
        /// </summary>
        private void Faa()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "请选择")
            {
                Magager.Park.Remove(comboBox1.Text);
                MessageBox.Show("注销成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("请选择注销的卡号");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
