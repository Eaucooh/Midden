using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 图书管理系统
{
    public partial class UserManagement : Form
    {
        Form form;
        DataBaseConection dataBaseConection = new DataBaseConection();

        public UserManagement(Form form)
        {
            InitializeComponent();
            this.form = form;
            showUsers();
            usersClassComboBox.SelectedIndex = 0;
            


        }

        private void back_Click(object sender, EventArgs e)
        {
            form.Show();
            this.Close();
        }

        public void showUsers()
        {
            usersDGV.DataSource = dataBaseConection.commonUser();
        }

        private void seekUserButtom_Click(object sender, EventArgs e)
        {
            string userClass="";
            string value = "";

            if (usersClassComboBox.SelectedItem.ToString() == "读者编号")
            {
                userClass = "UserID";
                value = userIDTextBox.Text;
            }
            if (usersClassComboBox.SelectedItem.ToString() == "用户名")
            {
                userClass = "UserName";
                value= userNameTextBox.Text;
            }
            if (usersClassComboBox.SelectedItem.ToString() == "性别")
            {
                userClass = "Sex";
                value=  sexTextBox.Text;
            }
            if (usersClassComboBox.SelectedItem.ToString() == "身份证号")
            {
                userClass = "IDCardNumber";
                value = idCardNumberTextBox.Text;
            }
            if (usersClassComboBox.SelectedItem.ToString() == "单位")
            {
                userClass = "WorkUnit";
                value= workUnitTextBox.Text;

            }
            if (usersClassComboBox.SelectedItem.ToString() == "注册日期")
            {
                userClass = "SigninTime";
                value= signinDateTimePicker.Value.ToString();
            }

            usersDGV.DataSource= dataBaseConection.seekUser(userClass, value);
        }

        private void userDelteButton_Click(object sender, EventArgs e)
        {
            string name = usersDGV.CurrentCell.Value.ToString();
            dataBaseConection.deleteUser(name);
            MessageBox.Show("用户已经删除", "操作成功");
            showUsers();
        }
    }
}
