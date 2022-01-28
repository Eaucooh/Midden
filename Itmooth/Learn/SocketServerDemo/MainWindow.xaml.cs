using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SocketServerDemo
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
        /// 监听器
        /// </summary>
        private TcpListener _listener;

        /// <summary>
        /// 是否接收客户端
        /// </summary>
        private bool _isAccept = true;

        /// <summary>
        /// 客户端集合
        /// </summary>
        private Dictionary<string, TcpClient> _clients = new Dictionary<string, TcpClient>();

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //监听器
            _listener = new TcpListener(IPAddress.Any, 10800);
            _listener.Start();

            //接收客户端线程
            Thread acceptClientThread = new Thread(AcceptClient);
            acceptClientThread.Start();
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        private void Window_Closed(object sender, EventArgs e)
        {
            //释放资源
            foreach (KeyValuePair<string, TcpClient> kvp in _clients)
            {
                kvp.Value.Dispose();
            }
            _isAccept = false;
            _listener.Stop();
        }

        /// <summary>
        /// 接收客户端
        /// </summary>
        private void AcceptClient()
        {
            try
            {
                while (_isAccept)
                {
                    if (_listener.Pending())
                    {
                        TcpClient client = _listener.AcceptTcpClient();
                        IPEndPoint endpoint = client.Client.RemoteEndPoint as IPEndPoint;
                        _clients.Add(endpoint.ToString(), client);

                        //添加到前端客户端列表
                        lbx_Clients.Dispatcher.Invoke(() =>
                        {
                            lbx_Clients.Items.Add(endpoint.ToString());
                        });

                        //接收消息线程
                        Thread reciveMessageThread = new Thread(ReciveMessage);
                        reciveMessageThread.Start(client);
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="obj">TcpClient</param>
        private void ReciveMessage(object obj)
        {
            TcpClient client = obj as TcpClient;
            IPEndPoint endpoint = null;
            NetworkStream stream = null;

            try
            {
                endpoint = client.Client.RemoteEndPoint as IPEndPoint;
                stream = client.GetStream();

                while (true)
                {
                    byte[] data = new byte[1024];
                    //如果远程主机已关闭连接,Read将立即返回零字节
                    int length = stream.Read(data, 0, data.Length);
                    if (length > 0)
                    {
                        #region if
                        string msg = Encoding.UTF8.GetString(data, 0, length);

                        //添加到前端消息列表
                        lbx_Messages.Dispatcher.Invoke(() =>
                        {
                            lbx_Messages.Items.Add(string.Format("{0}:{1}", endpoint.ToString(), msg));
                        });

                        //发送到其他客户端
                        foreach (KeyValuePair<string, TcpClient> kvp in _clients)
                        {
                            if (kvp.Value != client)
                            {
                                string writeMsg = string.Format("{0}:{1}", endpoint.ToString(), msg);
                                byte[] writeData = Encoding.UTF8.GetBytes(writeMsg);
                                NetworkStream writeStream = kvp.Value.GetStream();
                                writeStream.Write(writeData, 0, writeData.Length);
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        //客户端断开连接 跳出循环
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                //Read是阻塞方法 客户端退出是会引发异常 释放资源 结束此线程
            }
            finally
            {
                //从前端客户端列表移除
                lbx_Clients.Dispatcher.Invoke(() =>
                {
                    lbx_Clients.Items.Remove(endpoint.ToString());
                });
                //释放资源
                stream.Dispose();
                _clients.Remove(endpoint.ToString());
                client.Dispose();
            }
        }
    }
}
