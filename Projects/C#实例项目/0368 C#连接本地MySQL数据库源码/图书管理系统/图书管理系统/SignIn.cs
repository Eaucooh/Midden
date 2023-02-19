using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace 图书管理系统
{
    public partial class SignIn : Form,InfoInterface
    {

        const string nameLimit = @"^[a-zA-Z0-9]*$";
        const string passwordLimit = @"^[a-zA-Z0-9]*$";
        const string idCardLimit = @"^[1-9]\d{5}(18|19|([23]\d))\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{3}[0-9Xx]$";
        const string phoneNumberLimit = @"^(13[0-9]|14[579]|15[0-3,5-9]|16[6]|17[0135678]|18[0-9]|19[89])\d{8}$";
        private string name;
        private string password;
        private string idCardNumber;
        private string phoneNumber;
        private string sex;
        private string workUnit;
        private string userID;
        private string signinTime;

        Form form;
        DataBaseConection dataBaseConection = new DataBaseConection();

        public string CommonName { get { return name; } }
        public string Password { get { return password; } }
        public string IDCardNumber { get { return idCardNumber; } }
        public string Sex { get { return sex; } }
        public string PhoneNumber { get { return phoneNumber; } }
        public string WorkUnit { get { return workUnit; } }
        public string UserId { get { return userID; } }
        public string  SigninTime { get { return signinTime; } }

        public SignIn(Form form)
        {
            InitializeComponent();
            this.form = form;
        }

        public void SignInfo()
        {

            if (nameTextBox.Text ==String.Empty|| passwordTextBox.Text == String.Empty
                || IDCardTextBox.Text == String.Empty)
            {
                hintNameLabel.Text = "用户名称不能为空";             
            }
            if (!Regex.IsMatch(nameTextBox.Text, nameLimit ))
            {
                hintNameLabel.Text = "用户名称应由字母和数字组成";
                nameTextBox.Clear();
                nameTextBox.Focus();
                return;
            }
            if (IDCardTextBox.Text == String.Empty)
            {
                hintIDCardNumberLabel.Text = "身份证号码不能为空";
                IDCardTextBox.Clear();
            }
            if (!Regex.IsMatch(IDCardTextBox.Text, idCardLimit))
            {
                hintIDCardNumberLabel.Text="请输入正确形式的身份证号码";
                IDCardTextBox.Clear();
                IDCardTextBox.Focus();
                return;
            }
            if (workUnitTextBox.Text == String.Empty)
            {
                hintWorkUnitLabel.Text = "单位不能为空";
            }
            if (phoneNumberTextBox.Text == String.Empty)
            {
                hintPhoneNumberLabel.Text = "联系手机不能为空";
            }
            if (!Regex.IsMatch(phoneNumberTextBox.Text, phoneNumberLimit))
            {
                hintPhoneNumberLabel.Text = "请输入正确手机号码";
                phoneNumberTextBox.Clear();
                phoneNumberTextBox.Focus();
                return;
            }
            if (passwordTextBox.Text == String.Empty)
            {
                hintPasswordLabel.Text = "用户密码不能为空";
               
            }
            if (!Regex.IsMatch(passwordTextBox.Text, passwordLimit ))
            {
                hintPasswordLabel.Text = "用户密码只能由字母和数字组成";
                passwordTextBox.Clear();
                passwordTextBox.Focus();
                return;
            }
            if (passwordTextBox.Text != confirmPasswordTextBox.Text)
            {
                hintConfirmPasswordLabel.Text = "前后密码不相同";
                passwordTextBox.Clear();
                confirmPasswordTextBox.Clear();
                passwordTextBox.Focus();
                return;
            }
            else
            {
                name = nameTextBox.Text;
                if (manRadioButton.Checked )
                    sex = manRadioButton.Text;
                else
                    sex = womanRadioButton.Text;
                idCardNumber = IDCardTextBox.Text;
                phoneNumber = phoneNumberTextBox.Text;
                password = passwordTextBox.Text;
                workUnit = workUnitTextBox.Text;
                userID = name;
                signinTime = DateTime.Today.ToString();


                if (dataBaseConection.userAdd(CommonName, Password, Sex, IDCardNumber,
                    WorkUnit, PhoneNumber, UserId, SigninTime))
                    MessageBox.Show("感谢您注册本系统", "消息提示");
                else
                    MessageBox.Show("用户已经存在", "注册终止");
                Clear();
            }
        }

        public void Clear()
        {
            nameTextBox.Clear();
            IDCardTextBox.Clear();
            workUnitTextBox.Clear();
            phoneNumberTextBox.Clear();
            passwordTextBox.Clear();
            confirmPasswordTextBox.Clear();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            form.Show();
        }

        private void signInButtom_Click(object sender, EventArgs e)
        {
            SignInfo();
        }
    }
}
