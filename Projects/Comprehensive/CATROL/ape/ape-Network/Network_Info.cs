using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ape_Network
{
    public class Network_Info
    {
        public Network_Info()
        {

        }

        private const int INTERNET_CONNECTION_MODEM = 1;

        private const int INTERNET_CONNECTION_LAN = 2;

        private const int INTERNET_CONNECTION_PROXY = 4;

        private const int INTERNET_CONNECTION_MODEM_BUSY = 8;

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int connectionDescription, int reservedValue);


        private bool hasNetworkConect = false;
        Thread thread_NetworkConectChecking;

        public string netstatus = string.Empty;
        public Exception e_in_NetworkConectChecking;

        delegate bool MyDelegate();

        public bool HasNetworkConect()
        {
            //建立委托
            MyDelegate myDelegate = new MyDelegate(IsThereNetworkConect);
            //异步调用委托，获取委托执行函数返回的执行结果
            IAsyncResult result = myDelegate.BeginInvoke(null, null);

            //定义一个变量接收委托函数执行的返回结果
            bool data;

            //判断如果异步执行是否完
            while (result.IsCompleted == false)
            {
                Thread.Sleep(20);
            }

            //如果异步函数执行完成则获取返回结果
            data = myDelegate.EndInvoke(result);
            return data;
        }

        private bool IsThereNetworkConect()
        {
            try
            {
                var connection = 0;
                if (!InternetGetConnectedState(out connection, 0))
                    hasNetworkConect = false;
                if ((connection & INTERNET_CONNECTION_PROXY) != 0)
                    netstatus += " 采用代理上网  \n";
                if ((connection & INTERNET_CONNECTION_MODEM) != 0)
                    netstatus += " 采用调治解调器上网 \n";
                if ((connection & INTERNET_CONNECTION_LAN) != 0)
                    netstatus += " 采用网卡上网  \n";
                if ((connection & INTERNET_CONNECTION_MODEM_BUSY) != 0)
                    netstatus += " MODEM被其他非INTERNET连接占用  \n";
                hasNetworkConect = true;
                return true;
            }
            catch (Exception e)
            {
                hasNetworkConect = false;
                e_in_NetworkConectChecking = e;
                return false;
            }
        }


        /// <summary>
        /// 返回是否拥有网络连接
        /// </summary>
        /// <param name="target">指示用于测试的服务器地址，该值为服务器的IP地址，例如：172.168.0.1</param>
        /// <param name="waitTime">指示可以接受的等待响应时间</param>
        /// <returns></returns>
        public bool IsWebConected(string target, int waitTime)
        {
            try
            {
                System.Net.NetworkInformation.Ping objPingSender = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingOptions objPinOptions = new System.Net.NetworkInformation.PingOptions
                {
                    DontFragment = true
                };
                string data = "";
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                System.Net.NetworkInformation.PingReply objPinReply = objPingSender.Send(target, waitTime, buffer, objPinOptions);
                string strInfo = objPinReply.Status.ToString();
                if (strInfo == "Success")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 返回无网络连接的错误信息
        /// </summary>
        /// <param name="target">指示用于测试的服务器地址，该值为服务器的IP地址，例如：172.168.0.1</param>
        /// <param name="waitTime">指示可以接受的等待响应时间</param>
        /// <returns></returns>
        public Exception WebConectionError(string target, int waitTime)
        {
            try
            {
                System.Net.NetworkInformation.Ping objPingSender = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingOptions objPinOptions = new System.Net.NetworkInformation.PingOptions
                {
                    DontFragment = true
                };
                string data = "";
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                System.Net.NetworkInformation.PingReply objPinReply = objPingSender.Send(target, waitTime, buffer, objPinOptions);
                string strInfo = objPinReply.Status.ToString();
                return null;
            }
            catch (Exception p)
            {
                return p;
            }
        }
    }
}