using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTool
{
    public class Net
    {
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
