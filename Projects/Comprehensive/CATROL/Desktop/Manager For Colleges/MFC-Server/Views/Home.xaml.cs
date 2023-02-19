using ape_DataBase;
using ape_UI.Animation;
using HandyControl.Controls;
using MaterialDesignThemes;
using HandyControl.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using HandyControl.Tools.Extension;
using ape_System;
using MFC_Server.Pages;
using ape_Network;

namespace MFC_Server.Views
{
    /// <summary>
    /// Home.xaml 的交互逻辑
    /// </summary>
    public partial class Home : Page
    {
        BasicHelper ani = new BasicHelper();
        Access Access = new Access();
        Student student;

        public Home()
        {
            InitializeComponent();
            int from = 5;
            int to = 10;
            HomeBGI.MouseEnter += (x, y) =>
              {
                  HomeBGI.BeginAnimation(MarginProperty, ani.CreateThicknessAnimation(TimeSpan.FromMilliseconds(450), new Thickness(from), new Thickness(to),
                      FillBehavior.HoldEnd, BasicHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0));
              };
            HomeBGI.MouseLeave += (x, y) =>
            {
                HomeBGI.BeginAnimation(MarginProperty, ani.CreateThicknessAnimation(TimeSpan.FromMilliseconds(450), new Thickness(to), new Thickness(from),
                    FillBehavior.HoldEnd, BasicHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0));
            };
            Loger.MouseEnter += (x, y) =>
            {
                Loger.BeginAnimation(MarginProperty, ani.CreateThicknessAnimation(TimeSpan.FromMilliseconds(450), new Thickness(from), new Thickness(to),
                    FillBehavior.HoldEnd, BasicHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0));
            };
            Loger.MouseLeave += (x, y) =>
            {
                Loger.BeginAnimation(MarginProperty, ani.CreateThicknessAnimation(TimeSpan.FromMilliseconds(450), new Thickness(to), new Thickness(from),
                    FillBehavior.HoldEnd, BasicHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0));
            };
            Log_Card.MouseEnter += (x, y) =>
            {
                Log_Card.BeginAnimation(MarginProperty, ani.CreateThicknessAnimation(TimeSpan.FromMilliseconds(450), new Thickness(5, 40, 5, 5), new Thickness(0, 40, 0, 0),
                    FillBehavior.HoldEnd, BasicHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0));
            };
            Log_Card.MouseLeave += (x, y) =>
            {
                Log_Card.BeginAnimation(MarginProperty, ani.CreateThicknessAnimation(TimeSpan.FromMilliseconds(450), new Thickness(0, 40, 0, 0), new Thickness(5, 40, 5, 5),
                    FillBehavior.HoldEnd, BasicHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0));
            };
        }

        private void Log_In_Click(object sender, RoutedEventArgs e)
        {
            string ID = id.Text;
            string PWD = pwd.Password;
            if (ID != "" && PWD != "")
            {
                DataBaseHelper dbh = new DataBaseHelper("127.0.0.1", "MFC_Persons", "sa", "Zty213970");
                StringBuilder password = dbh.Read($"USE MFC_Persons;SELECT * FROM Students Where id={ID};", "Password");
                StringBuilder access = dbh.Read($"USE MFC_Persons;SELECT * FROM Students Where id={ID};", "Access");
                StringBuilder name = dbh.Read($"USE MFC_Persons;SELECT * FROM Students Where id={ID};", "Name");
                string[] array = password.ToString().Split('^');
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Equals(PWD))
                    {
                        ParentWindow.ShowMessage(Models.EnumHelper.GrowlType.Success, new GrowlInfo()
                        {
                            Message = $"{Access.ToString(access.ToString().Replace('^', '\0'))}: {name.Replace('^', '\0')}登录成功",
                            ShowCloseButton = true,
                            WaitTime = 2,
                            ShowDateTime = true
                        });
                        student = new Student(ID);
                        ShowStudentInfo();
                        break;
                    }
                    else
                    {
                        ErrorInfo($"{Access.ToString(access.ToString().Replace('^', '\0'))}: {name.Replace('^', '\0')}登陆失败\n账户或密码不正确");
                    }
                }
            }
            else
            {
                ErrorInfo("账户或密码不能为空！");
            }
        }

        private void ErrorInfo(string info)
        {
            ParentWindow.ShowMessage(Models.EnumHelper.GrowlType.Error, new GrowlInfo()
            {
                Message = info,
                ShowCloseButton = true,
                WaitTime = 2,
                ShowDateTime = true,
            });
        }

        private void ShowStudentInfo()
        {
            string[] infos = student.GetInfos().ToString().Split('^');
            NameBox.Text = infos[0];
            IDBox.Text = infos[1];
            NationBox.Text = infos[2];
            HeightBox.Text = infos[3];
            WidthBox.Text = infos[4];
            GenderBox.Text = infos[5];
            AgesBox.Text = infos[6];
            AddressBox.Text = infos[7];

            GradeBox.Text = infos[8];
            ClassBox.Text = infos[9];
            DepartmentBox.Text = infos[10];
            PeriodBox.Text = infos[11];
            AccessBox.Text = infos[12];
            TimeBox.Text = infos[13];

            StringBuilder[] sb = student.GetSpecialInfoS();
            string[] pns = sb[0].ToString().Split('^');
            string[] adr = sb[1].ToString().Split('^');
            string[] hob = sb[2].ToString().Split('^');
            string[] ctf = sb[3].ToString().Split('^');
            for (int i = 0; i < pns.Length - 1; i++)
            {
                PhoneNumbersBox.Children.Add(new TextBlock
                {
                    Text = pns[i],
                    TextAlignment = TextAlignment.Center
                });
            }
            for (int i = 0; i < adr.Length - 1; i++)
            {
                EMailAddressBox.Children.Add(new TextBlock
                {
                    Text = adr[i],
                    TextAlignment = TextAlignment.Center
                });
            }
            for (int i = 0; i < hob.Length - 1; i++)
            {
                HobbiesBox.Children.Add(new TextBlock
                {
                    Text = hob[i],
                    TextAlignment = TextAlignment.Center
                });
            }
            for (int i = 0; i < ctf.Length - 1; i++)
            {
                CertificatesBox.Children.Add(new TextBlock
                {
                    Text = ctf[i],
                    TextAlignment = TextAlignment.Center
                });
            }
            LogWin.Visibility = Visibility.Hidden;
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {

        }

        public MainWindow ParentWindow { get; set; }
    }
}
