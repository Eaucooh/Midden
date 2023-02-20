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
using BLL;

namespace HoteManage
{
    public partial class CustomerSEARCH : Form
    {
        public CustomerSEARCH()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CustomerInfoBLL bll = new CustomerInfoBLL();
            string where;
            if (txtCustomerName.Text != "")
            {
                where = "CustomerName='" + txtCustomerName.Text + "'";
                dgvCustomerInfo.DataSource = bll.GetCustomerInfoInfoList(where);
            }
            if(txtRoomNumber.Text!="")
            {
                where = "RoomNumber='" + txtRoomNumber.Text + "'";
                dgvCustomerInfo.DataSource = bll.GetCustomerInfoInfoList(where);
            }
            if(txtCredentialNumber.Text !="")
            {
                where = "CredentialNumber='" + txtCredentialNumber.Text + "'";
                dgvCustomerInfo.DataSource = bll.GetCustomerInfoInfoList(where);
            }
            if(cboSex.Text !="")
            {
                where = "Sex='"+cboSex.Text+"'";
                dgvCustomerInfo.DataSource = bll.GetCustomerInfoInfoList(where);
            }
               
        }
    }
}

