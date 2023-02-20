using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace 停车场项目
{
    public partial class Inquire : Form
    {
        public Inquire()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "卡号")
            {
                Daa(textBox1.Text.Trim().ToString());
            }
            else if (comboBox1.Text == "姓名")
            {
                Daa(textBox1.Text.Trim().ToString());
            }
            else
            {
                MessageBox.Show("请选择查询条件");
            }
        }
        private void Daa(string a)
        {
            dataGridView1.Rows.Clear();
            aa = 0;
            try
            {
                foreach (Consumer item in Magager.Park.Diy.Values)
                {
                    if (comboBox1.Text == "卡号")
                    {
                        if (item.States == State.Openaccount && item.ID == a)
                        {
                            Gaa(item);
                        }
                    }
                    if (comboBox1.Text == "姓名")
                    {
                        if (item.States == State.Openaccount && (item as MemberConsumer).CustName == a)
                        {
                            Gaa(item);
                        }
                    }
                    
                }
                if (dataGridView1.Rows.Count <= 0)
                {
                    MessageBox.Show("没有查询到数据");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("没有查询到数据");
            }
           
        }



       private int aa = 0;
        private void Gaa(Consumer item)
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows[aa].Cells[0].Value = (item as MemberConsumer).ID;
            dataGridView1.Rows[aa].Cells[1].Value = (item as MemberConsumer).PlateNumber;
            dataGridView1.Rows[aa].Cells[2].Value = (item as MemberConsumer).CustName;
            dataGridView1.Rows[aa].Cells[3].Value = (item as MemberConsumer).CustTel;
            dataGridView1.Rows[aa].Cells[4].Value = (item as MemberConsumer).RegDate;
            dataGridView1.Rows[aa].Cells[5].Value = (item as MemberConsumer).Balance;
            aa++;
        }
    }
}
