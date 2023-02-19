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
    public partial class CancelReservation : Form
    {
        public CancelReservation()
        {
            InitializeComponent();
        }
        int bookInfoID;
        public void DataBind()
        {
            BookInfoInfo info = new BookInfoInfo();
            BookInfoBLL bll = new BookInfoBLL();

            List<BookInfoInfo> ds = bll.GetBookInfoInfoList("1=1");
            dgvBookInfo.DataSource = ds;

        }

        private void CancelReservation_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        private void btnCancelReservation_Click(object sender, EventArgs e)
        {
            BookInfoInfo info = new BookInfoInfo();
            info.ID = int.Parse(txtRoomNumber.Text);

            BookInfoBLL bll = new BookInfoBLL();
            bool deleteResult = bll.DeleteBookInfoInfo(info);
            if (deleteResult)
            {
                MessageBox.Show("预定信息删除成功！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataBind();
            }
            else
            {
                MessageBox.Show("预定信息删除失败！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        
        }

        private void dgvRoomInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bookInfoID = int.Parse(dgvBookInfo.CurrentCell.OwningRow.Cells[0].Value.ToString());
            txtCustomerName.Text = dgvBookInfo.CurrentCell.OwningRow.Cells[1].Value.ToString();
            txtPhone.Text = dgvBookInfo.CurrentCell.OwningRow.Cells[2].Value.ToString();
            cboDeposit.Text = dgvBookInfo.CurrentCell.OwningRow.Cells[3].Value.ToString();
            txtCheckInTime.Text = dgvBookInfo.CurrentCell.OwningRow.Cells[4].Value.ToString();
            txtDays.Text = dgvBookInfo.CurrentCell.OwningRow.Cells[5].Value.ToString();
            txtRoomPrice.Text = dgvBookInfo.CurrentCell.OwningRow.Cells[6].Value.ToString();
            txtRoomType.Text = dgvBookInfo.CurrentCell.OwningRow.Cells[7].Value.ToString();
            txtRoomNumber.Text = dgvBookInfo.CurrentCell.OwningRow.Cells[8].Value.ToString();
            txtRemarks.Text = dgvBookInfo.CurrentCell.OwningRow.Cells[9].Value.ToString();
        }
        }
    }

