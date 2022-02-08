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
    public partial class PayDeposit : Form
    {
        public PayDeposit()
        {
            InitializeComponent();
        }
        int id;
        int deposit;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtInpuyRoomNumber.Text != "")
            {
                sql = "select*from CustomerInfo where RoomNumber='" + txtInpuyRoomNumber.Text + "'";
                DataSet ds = DBHelper.GetDataSet(sql);
                id = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                txtCustomerName.Text = ds.Tables[0].Rows[0][1].ToString();
                txtRoomNumber.Text = ds.Tables[0].Rows[0][10].ToString();
                txtCheckInTime.Text = ds.Tables[0].Rows[0][6].ToString();
                txtRoomPrice.Text = ds.Tables[0].Rows[0][8].ToString();
                txtDeposit.Text = ds.Tables[0].Rows[0][5].ToString();
                deposit = int.Parse(ds.Tables[0].Rows[0][5].ToString());
            }
            else
            {
                MessageBox.Show("请输入客房号！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string sql;
            int result;
            if (txtPayDeposit.Text != "")
            {
                deposit = deposit + int.Parse(txtPayDeposit.Text);
                sql = "update CustomerInfo set Deposit='" + deposit + "'where ID='" + id + "'";
                result = DBHelper.ExecuteSq1(sql);
                if (result == 1)
                {
                    MessageBox.Show("补交押金成功！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("补交押金失败！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("请输入押金数！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        }
        }
    

