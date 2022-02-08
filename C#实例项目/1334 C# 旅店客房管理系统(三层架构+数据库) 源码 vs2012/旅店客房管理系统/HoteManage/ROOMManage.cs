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
    public partial class ROOMManage : Form
    {
        public ROOMManage()
        {
            InitializeComponent();

        }
        public void DataBind()
        {
            string sql = "select*from RoomInfo";
            DataSet ds = DBHelper.GetDataSet(sql);
            dgvRoomInfo.DataSource = ds.Tables[0];
        }
        

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string sql;
            string roomType = cboRoomType.Text;
            string roomNumber = txtRoomNumber.Text;
            float roomPrice = float.Parse(txtRoomPrice.Text);
            string remarks = txtRemarks.Text;
            int result;
            sql = "update RoomInfo set RoomType='" + roomType + "',RoomPrice=" + roomPrice + ",Remarks='" + remarks + "'where RoomNumber='" + roomNumber + "'";
            if (txtRoomNumber.Text != "" && txtRoomPrice.Text != "" && cboRoomType.Text != "")
            {
                result = DBHelper.ExecuteSq1(sql);
                if (result == 1)
                {
                    MessageBox.Show("客房修改成功！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataBind();
                }
                else
                {
                    MessageBox.Show("客房修改失败！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("请检查数据输入的正确性！","错误提示",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string sql;
            string RoomNumber = txtRoomNumber.Text;
            sql = "delete RoomInfo where RoomNumber='" + RoomNumber + "'";
            int result = DBHelper.ExecuteSq1(sql);
            if (result == 1)
            {
                MessageBox.Show("客房删除成功！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataBind();
            }
            else
            {
                MessageBox.Show("客房删除失败！","错误提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }

        private void dgvRoomInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cboRoomType.Text = dgvRoomInfo.CurrentCell.OwningRow.Cells[1].Value.ToString();
            txtRoomNumber.Text = dgvRoomInfo.CurrentCell.OwningRow.Cells[0].Value.ToString();
            txtRoomPrice.Text = dgvRoomInfo.CurrentCell.OwningRow.Cells[2].Value.ToString();
            txtRemarks.Text = dgvRoomInfo.CurrentCell.OwningRow.Cells[4].Value.ToString();
        }

        private void RoomManage_Load(object sender, EventArgs e)
        {
            DataBind();
        }
    }
}