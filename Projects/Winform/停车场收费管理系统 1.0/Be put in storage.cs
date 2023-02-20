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
    public partial class Form9 : Form
    {
        public Form9()
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
                if ((item.Types == Type.nember && item.States == State.Openaccount && item.ParkingStates == ParkingState.NotParking) || (item.Types == Type.temporary && item.ParkingStates == ParkingState.NotParking))
                {
                    comboBox1.Items.Add(item.ID);
                }

            }
            comboBox1.SelectedIndex = 0;
        }
        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="a"></param>
        private void Daa(string a)
        {
            Magager.Park.Diy[a].ParkingStates = ParkingState.Parking;
            Magager.Park.Diy[a].InTime = DateTime.Now.ToString("yyy年MM月dd日 HH:mm:ss");
            Magager.Park.Pak.ParkingD();
            MessageBox.Show("入库成功");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "请选择")
            {
                Daa(comboBox1.Text);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
