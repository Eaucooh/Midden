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
    public partial class Form10 : Form
    {
        public Form10()
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
                if ((item.Types == Type.nember && item.States == State.Openaccount && item.ParkingStates == ParkingState.Parking) || (item.Types == Type.temporary && item.ParkingStates == ParkingState.Parking))
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
                Daa(comboBox1.Text);
            }
            else
            {
                textBox1.Text = "";
                textBox4.Text = "";
                dateTimePicker1.Value = Convert.ToDateTime(DateTime.Now.ToString("yyy年MM月dd日 HH:mm:ss"));
                label5.Text = "无";
            }


        }
        /// <summary>
        /// 显示卡信息
        /// </summary>
        public void Daa(string a)
        {
            if ((Magager.Park.Diy[a] as Consumer).Types == Type.nember)
            {
                label5.Text = (Magager.Park.Diy[a] as MemberConsumer).Balance;
                textBox1.Text = (Magager.Park.Diy[a] as MemberConsumer).Types == Type.nember ? "会员用户" : "临时用户";
                //(Magager.Park.Diy[a] as MemberConsumer).InTime = "2017年12月20日 08:49:07";
                dateTimePicker1.Value = Convert.ToDateTime((Magager.Park.Diy[a] as MemberConsumer).InTime);
                textBox4.Text = (Magager.Park.Diy[comboBox1.Text] as MemberConsumer).Charging().ToString("F2");
            }
            else
            {
                label5.Text = "无";
                textBox1.Text = (Magager.Park.Diy[a] as TemporaryConsumer).Types == Type.nember ? "会员用户" : "临时用户";
                dateTimePicker1.Value = Convert.ToDateTime((Magager.Park.Diy[a] as TemporaryConsumer).InTime);
                textBox4.Text = (Magager.Park.Diy[comboBox1.Text] as TemporaryConsumer).Charging().ToString("F2");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "请选择")
            {
                if ((Magager.Park.Diy[comboBox1.Text] as Consumer).Types == Type.nember)
                {
                    if ((Magager.Park.Diy[comboBox1.Text] as MemberConsumer).Fasmo(double.Parse(textBox4.Text)) == false)
                    {
                        MessageBox.Show("余额不足");
                        return;
                    }
                }
                (Magager.Park.Diy[comboBox1.Text] as Consumer).OutTime = DateTime.Now.ToString("yyy年MM月dd日 HH:mm:ss");
                MessageBox.Show("出库成功");
                saveFileDialog1.Title = "消费清单";
                saveFileDialog1.Filter = "文本文件|*.txt";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((Magager.Park.Diy[comboBox1.Text] as Consumer).Types == Type.nember)
                    {
                        Iprint hh = (Magager.Park.Diy[comboBox1.Text] as MemberConsumer);
                        hh.Print(saveFileDialog1.FileName,textBox4.Text);
                    }
                    else
                    {
                        Iprint hh = (Magager.Park.Diy[comboBox1.Text] as TemporaryConsumer);
                        hh.Print(saveFileDialog1.FileName, textBox4.Text);
                    }
                }
                Magager.Park.Pak.ParkingS(Magager.Park.Diy[comboBox1.Text]);
                this.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
