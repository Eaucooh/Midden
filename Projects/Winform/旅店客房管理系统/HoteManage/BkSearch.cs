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
    public partial class BkSearch : Form
    {
        public BkSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BookInfoBLL bll = new BookInfoBLL();
            string where;
            if (txtCustomerName.Text !="")
            {
                where = "CustomerName='" + txtCustomerName.Text + "'";
                dgvBookInfo.DataSource = bll.GetBookInfoInfoList(where);
            }
            if(txtRoomNumber.Text !="")
            {
                where = "RoomNumber='" + txtRoomNumber.Text + "'";
                dgvBookInfo.DataSource = bll.GetBookInfoInfoList(where);
            }
            if(txtPhone.Text !="")
            {
                where = "Phone='" + txtPhone.Text + "'";
                dgvBookInfo.DataSource = bll.GetBookInfoInfoList(where);
            }
            if(txtCheckInTime.Text !="")
            {
                where = "CheckInTime='" + txtCheckInTime.Text + "'";
                dgvBookInfo.DataSource = bll.GetBookInfoInfoList(where);
            }
        }
    }
}
