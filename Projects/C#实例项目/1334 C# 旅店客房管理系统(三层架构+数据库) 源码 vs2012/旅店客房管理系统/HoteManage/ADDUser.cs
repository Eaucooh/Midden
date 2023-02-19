using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoteManage
{
    public partial class ADDUser : Form
    {
        public ADDUser()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtUserName.Text != "" && txtUserPassword.Text != "" && cboUserType.Text != "")
            {
                UserInfoInfo info = new UserInfoInfo();
                info.UserName = txtUserName.Text;
                info.UserPassword = txtUserPassword.Text;
                info.UserType = cboUserType.Text;

                UserInfoBLL bll = new UserInfoBLL();
                bool result = bll.AddUserInfo(info);
                if (result)
                {
                    MessageBox.Show("用户添加成功！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("用户添加失败！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("请检查数据输入的正确性！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUserName.Text="";
            txtUserPassword.Text="";
            txtUserName.Focus();
        }
        }
    }

