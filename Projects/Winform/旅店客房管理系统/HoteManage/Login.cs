using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using BLL;

namespace HoteManage
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string sql = String.Format("select*from UserInfo where UserName='{0}'and UserPassword='{1}'", txtUserName.Text, txtUserPassword.Text);
            DataSet ds = DBHelper.GetDataSet(sql);
            if (ds.Tables[0].Rows.Count < 1)
            {
                MessageBox.Show("该用户名或密码不存在！");}
                 else
                {
                    HOTElManage frmHoteManage =new HOTElManage();
                    frmHoteManage.Show();
                    this.Hide();
        }
            }
        }
    }
 