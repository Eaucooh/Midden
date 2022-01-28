using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace center_installer_x86_x64_online_or_offline
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InstallingPage.Visibility = Visibility.Hidden;
            Closing += (x, y) =>
              {
                  if (IsInstalling)
                  {
                      MessageBoxResult choose = MessageBox.Show("安装正在进行，是否回滚已安装内容？", "提示", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                      if (choose == MessageBoxResult.Yes)
                      {
                          if (TurnInstalling())
                          {
                              MessageBox.Show("回滚完成，程序即将退出", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                              y.Cancel = false;
                          }
                          else
                          {
                              MessageBox.Show("回滚失败，程序即将退出", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
                          }
                      }
                      else if (choose == MessageBoxResult.No)
                      {
                          MessageBox.Show("已安装内容将不会删除，程序即将退出", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                      }
                      else
                      {
                          y.Cancel = true;
                      }
                  }
                  else if(Turning)
                  {
                      MessageBox.Show("正在回滚已安装内容，请勿在此时关闭程序", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                      y.Cancel = true;
                  }
                  else
                  {
                      if (MessageBox.Show("是否要退出伊莫特控制中心客户端的安装？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                      {
                          y.Cancel = true;
                      }
                  }
              };
        }

        bool IsInstalling = false;
        bool Turning = false;

        private void StartInstall(object sender, RoutedEventArgs e)
        {
            if(UserAgreement.IsChecked == true)
            {
                IsInstalling = true;
                InstallingPage.Visibility = Visibility.Visible;
                if(!Install())
                {
                    MessageBox.Show("安装失败，程序即将退出", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("请勾选“我已详细阅读并同意《服务条款》和《隐私政策》”！", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private bool Install()
        {
            return true;
        }

        private bool TurnInstalling()
        {
            Turning = true;
            return true;
        }
    }
}
