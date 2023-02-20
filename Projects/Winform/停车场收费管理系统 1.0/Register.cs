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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void Checking()
        {
            if (this.textBox1.Text.Trim().ToString() != "" && this.textBox2.Text.Trim().ToString() != "")
            {
                if (Magager.Park.Adm.Longin(this.textBox1.Text.Trim().ToString(), this.textBox2.Text.Trim().ToString()))
                {
                    this.DialogResult = DialogResult.OK;
                    
                }
                else
                {
                    MessageBox.Show("登录失败");
                }
            }
            else
            {
                MessageBox.Show("必填信息不能为空");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Checking();
        }
    }
}
