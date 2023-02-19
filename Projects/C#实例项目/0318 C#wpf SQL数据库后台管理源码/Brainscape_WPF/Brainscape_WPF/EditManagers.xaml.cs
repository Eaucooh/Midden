using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Brainscape_WPF
{
    /// <summary>
    /// EditManagers.xaml 的交互逻辑
    /// </summary>
    public partial class EditManagers : Window
    {
        public EditManagers()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.CanMinimize;
            ManagerMessage m = new ManagerMessage();
            EditGrid.DataContext = m;
            List<ManagerGrade> i = new List<ManagerGrade>();
            i = ManagerMessageBll.QueryGrade();
            comboBox.ItemsSource = i;
        }
        public bool EditModel { get; set; }
        private void OKbtn_Click(object sender, RoutedEventArgs e)
        {
            ManagerMessage edit = (ManagerMessage)EditGrid.DataContext;
           

            if (EditModel == true)   //增加
            {
                if (Yanzheng())
                {
                    edit.ManagerType = comboBox.SelectedIndex;
                    ManagerMessageBll.AddManager(edit);
                    this.Close();
                }
            }
            else
            {
                if (Yanzheng())
                {
                    edit.ManagerType = comboBox.SelectedIndex;
                    ManagerMessageBll.UpdateManagerMessage(edit);  //编辑
                    this.Close();
                }
            }
        }
        private void CloseEdit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (EditModel == true)
            {
               
                
                this.EditText.Content = "增加管理员：";
                OKbtn.Content = "添加";



            }
            else
            {
                this.EditText.Content = "修改管理员：";
                OKbtn.Content = "修改";
            }
        }

        public bool Yanzheng()
        {
            if (txtID.Text == "" || txtName.Text == "" || txtPassword.Text == "" || comboBox.SelectedIndex == -1)
            {
                label4.Content = "*请填写完整资料！";

                return false;
            }
            else if (ManagerMessageBll.ManagerQueryID(txtID.Text) > 0)
            {
                if (EditModel == true)
                {
                    label4.Content = "*该账号已被注册，请重新输入！";
                    return false;
                }
                else
                { return true; }
            }
            else return true;


        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ManagerMessage edit = (ManagerMessage)EditGrid.DataContext;


            if (comboBox.SelectedIndex == 0)
            {
               
                ManagerGrade u =  ManagerMessageBll.QueryGradeID(0);
               
                edit.ManagerPower= u.Power;
               // txtPower.Text = u.Power;
            }
            if (comboBox.SelectedIndex == 1)
            {
              //  edit.ManagerPower = u.Power;
                ManagerGrade u = ManagerMessageBll.QueryGradeID(1);
                edit.ManagerPower = u.Power;

              //  txtPower.Text = u.Power;
            }
            if (comboBox.SelectedIndex == 2)
            {
             //   edit.ManagerPower = u.Power;
                ManagerGrade u = ManagerMessageBll.QueryGradeID(2);
                edit.ManagerPower = u.Power;
              //  txtPower.Text = u.Power;
            }
            if (comboBox.SelectedIndex == 3)
            {
              
                ManagerGrade u = ManagerMessageBll.QueryGradeID(3);
                edit.ManagerPower = u.Power;
              //  txtPower.Text = u.Power;
            }
            if (comboBox.SelectedIndex == 4)
            {

                ManagerGrade u = ManagerMessageBll.QueryGradeID(4);
                edit.ManagerPower = u.Power;
                //  txtPower.Text = u.Power;
            }
        }
    }
}
