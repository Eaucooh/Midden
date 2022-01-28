using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Library.NetHelper
{
    public class NetHelper
    {
		/// <summary>
		/// 检验是否拥有网络连接
		/// </summary>
		/// <param name="target">测试的目标</param>
		/// <param name="waitTime">等待时间</param>
		/// <returns>是否拥有网络连接</returns>
		public static bool IsWebConected(string target, int waitTime)
		{
			try
			{
				Ping objPingSender = new Ping();
				PingOptions objPinOptions = new PingOptions
				{
					DontFragment = true
				};
				string data = "";
				byte[] buffer = Encoding.UTF8.GetBytes(data);
				PingReply objPinReply = objPingSender.Send(target, waitTime, buffer, objPinOptions);
				string strInfo = objPinReply.Status.ToString();
				if (strInfo == "Success")
				{
					return true;
				}
				return false;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// 返回网络连接失败的原因
		/// </summary>
		/// <param name="target">测试目标</param>
		/// <param name="waitTime">等待时间</param>
		/// <returns>返回失败原因</returns>
		public static Exception WebConectionError(string target, int waitTime)
		{
			try
			{
				Ping objPingSender = new Ping();
				PingOptions objPinOptions = new PingOptions
				{
					DontFragment = true
				};
				string data = "";
				byte[] buffer = Encoding.UTF8.GetBytes(data);
				PingReply objPinReply = objPingSender.Send(target, waitTime, buffer, objPinOptions);
				string strInfo = objPinReply.Status.ToString();
				return null;
			}
			catch (Exception result)
			{
				return result;
			}
		}
	}
}
