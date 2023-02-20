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
    public partial class UpdatePassword : Form
    {
        public UpdatePassword()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Changepassword();
        }
        private void Changepassword()
        {
            if (textBox1.Text.Trim().ToString() == "" || textBox2.Text.Trim().ToString() == "" || textBox3.Text.Trim().ToString() == "")
            {
                MessageBox.Show("必填信息不能为空");
                return;
            }
            if (textBox1.Text.Trim().ToString() != Magager.Park.Adm.LongPassword)
            {
                MessageBox.Show("原密码输入错误！");
                return;
            }
            if (textBox2.Text.Trim().ToString() != textBox3.Text.Trim().ToString())
            {
                MessageBox.Show("前后输入密码不一致！");
            }
            else
            {
                Magager.Park.Adm.UpdatePwd(textBox3.Text.Trim().ToString());
                MessageBox.Show("修改成功！");
                this.Close();
            }

        }
    }
}
