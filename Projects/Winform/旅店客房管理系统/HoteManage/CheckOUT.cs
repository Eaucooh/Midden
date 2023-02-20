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
    public partial class CheckOUT : Form
    {
        public CheckOUT()
        {

            InitializeComponent();
        }
        int id;
        string customerName;
        string sex;
        string credentialNumber;
        string phone;
        DateTime checkInTime;
        DateTime checkOutTime;
        int days = 1;
        float spending;
        string roomType;
        string roomNumber;
        string remarks;
        float deposit;

       
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql="";
            if (txtCustomerName.Text != "" && txtRoomNumber.Text == "")
            {
                sql = "select*from CustomerInfo where CustomerName='" + txtCustomerName.Text + "'";
            }
            if (txtCustomerName.Text == "" && txtRoomNumber.Text != "")
            {
                sql = "select*from CustomerInfo where RoomNumber='" + txtRoomNumber.Text + "'";
            }
            if (txtCustomerName.Text != "" && txtRoomNumber.Text != "")
            {
                sql = "selcet*from CustomerInfo where CustomerName='" + txtCustomerName.Text + "'and RoomNumber='" + txtRoomNumber.Text + "'"; ;
            }
            if (txtCustomerName.Text == "" && txtRoomNumber.Text == "")
            {
                MessageBox.Show("请输入宾客入住信息", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (sql != "")
            {
                DataSet ds = DBHelper.GetDataSet(sql);
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    dgvCustmerInfo.DataSource = ds.Tables[0];
                    id = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    customerName = ds.Tables[0].Rows[0][1].ToString();
                    sex = ds.Tables[0].Rows[0][2].ToString();
                    credentialNumber = ds.Tables[0].Rows[0][3].ToString();
                    phone = ds.Tables[0].Rows[0][4].ToString();
                    checkInTime = Convert.ToDateTime(ds.Tables[0].Rows[0][6].ToString());
                    checkOutTime = System.DateTime.Now;
                    roomType = ds.Tables[0].Rows[0][9].ToString();
                    roomNumber = ds.Tables[0].Rows[0][10].ToString();
                    remarks = ds.Tables[0].Rows[0][11].ToString();
                    TimeSpan nights = System.DateTime.Now - DateTime.Parse(ds.Tables[0].Rows[0][6].ToString());
                    days = int.Parse(nights.Days.ToString());
                    spending = float.Parse(ds.Tables[0].Rows[0][8].ToString()) * days;
                    txtAccountPayable.Text = Convert.ToString(float.Parse(ds.Tables[0].Rows[0][8].ToString()) * days);
                    txtDeposit.Text = ds.Tables[0].Rows[0][5].ToString();
                    deposit = float.Parse(ds.Tables[0].Rows[0][5].ToString());
                }
                else
                {
                    MessageBox.Show("您查找的信息不存在", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtPay_TextChanged(object sender, EventArgs e)
        {
            txtChange.Text = Convert.ToString(deposit + float.Parse(txtPay.Text) - spending);
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            string insertSql;
            string updateSql;
            string deleteSql;
            insertSql = "insert into Record(CustomerName,Sex,CredentialNumber,Phone,CheckInTime,checkOutTime,Days,Spending,RoomType,RoomNumber,Remarks)values('" + customerName + "','" + sex + "','" + credentialNumber + "','" + phone + "','" + checkInTime + "','" + checkOutTime + "'," + days + "," + spending + ",'" + roomType + "','" + roomNumber + "','" + remarks + "')";
            deleteSql="delete from CustomerInfo where ID="+id;
            updateSql="update RoomInfo set RoomStatus='可供'where RoomNumber='"+roomNumber+"'";
            int insertResult;
            int updateResult;
            int deleteResult;
            deleteResult=DBHelper.ExecuteSq1(deleteSql);
            if(deleteResult==1){
                MessageBox.Show("宾客退房结算成功！","成功提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                updateResult=DBHelper.ExecuteSq1(updateSql);
                insertResult=DBHelper.ExecuteSq1(insertSql);
                if(insertResult==1)
                {
                    MessageBox.Show("宾客入住历史记录保存成功！","成功提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("宾客入住历史记录保存失败！","错误提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else{
                    MessageBox.Show("宾客退房结算失败！","错误提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtRoomNumber.Text = "";
            txtCustomerName.Text = "";
            txtAccountPayable.Text = "";
            txtDeposit.Text = "";
            txtPay.Text = "";
            txtChange.Text = "";

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}