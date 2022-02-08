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

namespace HoteManage
{
    public partial class USERManage : Form
    {
        public USERManage()
        {
            InitializeComponent();
        }
        public void DataBind()
        {
            string sql = "select*from UserInfo";
            DataSet ds = DBHelper.GetDataSet(sql);
            dgvUserInfo.DataSource = ds.Tables[0];
        }


        private void UserManage_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string sql;
            string userName = txtUserName.Text;
            string userPassword = txtUserPassword.Text;
            string userType = cboUserType.Text;
            int result;
            sql = " update UserInfo set UserPassword ='" + userPassword + "',UserType ='" + userType + "'where UserName='"+userName+ "'";
            if (txtUserName.Text != "" && txtUserPassword.Text != "" && cboUserType.Text != "")
            {
                result = DBHelper.ExecuteSq1(sql);
                if (result == 1)
                {
                    MessageBox.Show("用户修改成功！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataBind();
                }
                else
                {
                    MessageBox.Show("用户修改失败！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("请检查数据输入的正确性！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string sql;
            string userName=txtUserName.Text;
            sql="delete UserInfo where UserName='"+userName+"'";
            int result=DBHelper.ExecuteSq1(sql);
            if(result==1)
            {
                MessageBox.Show("用户删除成功！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataBind();
            }
            else
            {
                MessageBox.Show("用户删除失败！","错误提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void dgvUserInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUserName.Text=dgvUserInfo.CurrentCell.OwningRow.Cells[0].Value.ToString();
            txtUserPassword.Text=dgvUserInfo.CurrentCell.OwningRow.Cells[1].Value.ToString();
            cboUserType.Text=dgvUserInfo.CurrentCell.OwningRow.Cells[2].Value.ToString();
        }
    }
}
