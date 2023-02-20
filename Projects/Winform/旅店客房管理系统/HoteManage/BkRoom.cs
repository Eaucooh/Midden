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
    public partial class BkRoom : Form
    {
        public BkRoom()
        {
            InitializeComponent();
        }
        public void DataBind()
        {
            RoomInfoInfo info = new RoomInfoInfo();
            RoomInfoBLL bll = new RoomInfoBLL();

            List<RoomInfoInfo> ds = bll.GetRoomInfoInfoList("1=1");
            dgvRoomInfo.DataSource = ds;

        }

        private void BookRoom_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            
            if (txtCustomerName.Text != "" && txtPhone.Text != "" && cboDeposit.Text != "" && txtCheckInTime.Text != "" && txtDays.Text != "" && txtRoomPrice.Text != "" && txtRoomType.Text != "" && txtRoomNumber.Text != "")
            {
                BookInfoInfo info = new BookInfoInfo();
                info.CustomerName = txtCustomerName.Text;
                info.Phone = txtPhone.Text;
                info.Deposit = int.Parse(cboDeposit.Text);
                info.CheckInTime = txtCheckInTime.Text;
                info.Days = int.Parse(txtDays.Text);
                info.RoomPrice = float.Parse(txtRoomPrice.Text);
                info.RoomType = txtRoomType.Text;
                info.RoomNumber = txtRoomNumber.Text;
                info.Remarks = txtRemarks.Text;

                BookInfoBLL bll = new BookInfoBLL();
                bool InserResult = bll.AddBookInfo(info);
                if (InserResult)
                {
                    MessageBox.Show("宾客预定成功！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataBind();
                }
                else
                {
                    MessageBox.Show("宾客预定失败！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("请检查数据输入的正确性！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCustomerName.Text = "";
            txtPhone.Text = "";
            cboDeposit.Text = "300";
            txtCheckInTime.Text = "";
            txtDays.Text = "";
            txtRoomPrice.Text = "";
            txtRoomType.Text = "";
            txtRoomNumber.Text = "";
            txtRemarks.Text = "";
            txtRoomRemarks.Text = "";
            txtCustomerName.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvRoomInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRoomType.Text = dgvRoomInfo.CurrentCell.OwningRow.Cells[1].Value.ToString();
            txtRoomNumber.Text = dgvRoomInfo.CurrentCell.OwningRow.Cells[0].Value.ToString();
            txtRoomPrice.Text = dgvRoomInfo.CurrentCell.OwningRow.Cells[2].Value.ToString();
            txtRoomRemarks.Text = dgvRoomInfo.CurrentCell.OwningRow.Cells[4].Value.ToString();
        }
      
    }
}
