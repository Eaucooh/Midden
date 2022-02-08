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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SocketClientDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// tcp客户端
        /// </summary>
        private TcpClient _client;

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        private void Window_Closed(object sender, EventArgs e)
        {
            _client.Close();
            _client.Dispose();
        }

        /// <summary>
        /// 发送按钮点击事件
        /// </summary>
        private void btn_Send_Click(object sender, RoutedEventArgs e)
        {
            //发送消息至服务器
            string msg = tbx_Message.Text;
            byte[] data = Encoding.UTF8.GetBytes(msg);
            try
            {
                NetworkStream stream = _client.GetStream();
                stream.Write(data, 0, data.Length);

                //添加到前端消息列表
                lbx_Messages.Items.Add(string.Format("我:{0}", msg));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        private void ReciveMessage()
        {
            try
            {
                NetworkStream stream = _client.GetStream();
                while (true)
                {
                    byte[] data = new byte[1024];
                    int length = stream.Read(data, 0, data.Length);
                    if (length > 0)
                    {
                        string msg = Encoding.UTF8.GetString(data, 0, length);

                        //添加到前端消息列表
                        lbx_Messages.Dispatcher.Invoke(() =>
                        {
                            lbx_Messages.Items.Add(msg);
                        });
                    }
                    else
                    {
                        MessageBox.Show("服务器已关闭");
                        stream.Dispose();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                //Read是阻塞方法 程序退出释放资源是会引发异常 不做处理 线程结束
            }
        }

        private void btn_Connect_Click(object sender, RoutedEventArgs e)
        {
            if((string)btn_Connect.Content == "连接")
            {
                //初始化tcp客户端
                _client = new TcpClient();
                try
                {
                    _client.Connect(IPAddress.Parse("127.0.0.1"), 10800);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("未能连接到服务器 {0}", ex.Message));
                    this.Close();
                    return;
                }

                //接收消息线程
                Thread reciveMessageThread = new Thread(ReciveMessage);
                reciveMessageThread.Start();

                btn_Connect.Content = "断开";
            }
            else
            {
                _client.Close();
                _client.Dispose();
                btn_Connect.Content = "连接";
            }

        }
    }
}
