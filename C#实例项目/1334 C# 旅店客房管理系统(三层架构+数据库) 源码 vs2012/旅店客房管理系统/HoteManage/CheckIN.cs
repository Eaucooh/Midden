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
using DAL;

namespace HoteManage
{
    public partial class CheckIN : Form
    {
        public CheckIN()
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

        private void CheckIn_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {

            if(txtCustomerName.Text != "" && cboSex.Text != "" && txtCredentialNumber.Text !="" && cboDeposit.Text !="" && txtCheckInTime.Text !="" && txtDays.Text !="" && txtRoomPrice.Text != "" && txtRoomType.Text !="" && txtRoomNumber.Text !="")
            {
                CustomerInfoInfo info = new CustomerInfoInfo();
                info.CustomerName = txtCustomerName.Text;
                info.Sex = cboSex.Text;
                info.CredentialNumber = txtCredentialNumber.Text;
                info.Phone = txtPhone.Text;
                info.Deposit = int.Parse(cboDeposit.Text);
                info.CheckInTime = txtCheckInTime.Text;
                info.Days = int.Parse(txtDays.Text);
                info.RoomPrice = float.Parse(txtRoomPrice.Text);
                info.RoomType = txtRoomType.Text;
                info.RoomNumber = txtRoomNumber.Text;
                info.Remarks = txtRemarks.Text;

                CustomerInfoBLL bll = new CustomerInfoBLL();

                bool InsertResult =bll.AddCustomerInfo(info);

                string updateSql;
                int updateResult;
                if(InsertResult)
                {
                    MessageBox.Show("宾客入住登记成功!","成功提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    /* RoomInfoInfo roominfo = new RoomInfoInfo();
                    roominfo.RoomStatus = "占用";
                    roominfo.RoomNumber = txtRoomNumber.Text;
                    RoomInfoBLL roombll = new RoomInfoBLL();
                    roombll.UpdateRoomInfoInfo(roominfo);*/
                    updateSql = "update RoomInfo set RoomStatus='占用'where RoomNumber='" + txtRoomNumber.Text + "'";
                    updateResult=DBHelper.ExecuteSq1(updateSql);
                    DataBind();
                }
                else
                {
                    MessageBox.Show("宾客入住登记失败!","错误提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            }
            else
            {          
                    MessageBox.Show("请检查数据输入的正确性!","错误提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
            }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCustomerName.Text = "";
            cboSex.Text = "男";
            txtCredentialNumber.Text = "";
            txtPhone.Text = "";
            cboDeposit.Text = "300";
            txtCheckInTime.Text = "";
            txtDays.Text = "";
            txtRoomPrice.Text="";
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
