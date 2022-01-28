using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TeamC_Serve_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server started!");
            //监听器
            _listener = new TcpListener(IPAddress.Any, 10800);
            _listener.Start();

            //接收客户端线程
            Thread acceptClientThread = new Thread(AcceptClient);
            acceptClientThread.Start();
        }

        static void End()
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
        /// 监听器
        /// </summary>
        private static TcpListener _listener;

        /// <summary>
        /// 是否接收客户端
        /// </summary>
        private static bool _isAccept = true;

        /// <summary>
        /// 客户端集合
        /// </summary>
        private static Dictionary<string, TcpClient> _clients = new Dictionary<string, TcpClient>();

        private static void showClients()
        {
            foreach (string item in _clients.Keys)
            {
                Console.WriteLine($"client ip:{item}");
            }
        }

        /// <summary>
        /// 接收客户端
        /// </summary>
        private static void AcceptClient()
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

                        showClients();

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
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="obj">TcpClient</param>
        private static void ReciveMessage(object obj)
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

                        Console.WriteLine(string.Format("{0}:{1}", endpoint.ToString(), msg));

                        //发送到其他客户端
                        foreach (KeyValuePair<string, TcpClient> kvp in _clients)
                        {
                            if (kvp.Value != client)
                            {
                                //string writeMsg = string.Format("{0}:{1}", endpoint.ToString(), msg);
                                //byte[] writeData = Encoding.UTF8.GetBytes(writeMsg);
                                byte[] writeData = Encoding.UTF8.GetBytes(msg);
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
                //释放资源
                stream.Dispose();
                _clients.Remove(endpoint.ToString());
                client.Dispose();
            }
        }

        //private void btn_Send_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        string msg = tbx_Message.Text.ToString();

        //        //添加到前端消息列表
        //        lbx_Messages.Dispatcher.Invoke(() =>
        //        {
        //            lbx_Messages.Items.Add(string.Format("{0}:{1}", "我", msg));
        //        });

        //        //发送到其他客户端
        //        foreach (KeyValuePair<string, TcpClient> kvp in _clients)
        //        {
        //            string writeMsg = string.Format("{0}：{1}", myName.Text, msg);
        //            byte[] writeData = Encoding.UTF8.GetBytes(writeMsg);
        //            NetworkStream writeStream = kvp.Value.GetStream();
        //            writeStream.Write(writeData, 0, writeData.Length);
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}
    }
}
