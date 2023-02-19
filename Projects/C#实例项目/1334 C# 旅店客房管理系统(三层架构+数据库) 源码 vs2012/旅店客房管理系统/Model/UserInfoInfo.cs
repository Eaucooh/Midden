using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{

	public class UserInfoInfo
	{
		private string _UserName;
		/// <summary>
		/// 获取或设置 UserName 的值
		/// </summary>
		public string UserName
		{
			get { return _UserName; }
			set { _UserName = value; }
		}

		private string _UserPassword;
		/// <summary>
		/// 获取或设置 UserPassword 的值
		/// </summary>
		public string UserPassword
		{
			get { return _UserPassword; }
			set { _UserPassword = value; }
		}

		private string _UserType;
		/// <summary>
		/// 获取或设置 UserType 的值
		/// </summary>
		public string UserType
		{
			get { return _UserType; }
			set { _UserType = value; }
		}

	}
}
