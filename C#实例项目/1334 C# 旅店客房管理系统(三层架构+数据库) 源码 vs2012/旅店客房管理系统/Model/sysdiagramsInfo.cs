using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{

	public class sysdiagramsInfo
	{
		private string _name;
		/// <summary>
		/// 获取或设置 name 的值
		/// </summary>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		private int _principal_id;
		/// <summary>
		/// 获取或设置 principal_id 的值
		/// </summary>
		public int Principal_id
		{
			get { return _principal_id; }
			set { _principal_id = value; }
		}

		private int _diagram_id;
		/// <summary>
		/// 获取或设置 diagram_id 的值
		/// </summary>
		public int Diagram_id
		{
			get { return _diagram_id; }
			set { _diagram_id = value; }
		}

		private int _version;
		/// <summary>
		/// 获取或设置 version 的值
		/// </summary>
		public int Version
		{
			get { return _version; }
			set { _version = value; }
		}

		private string _definition;
		/// <summary>
		/// 获取或设置 definition 的值
		/// </summary>
		public string Definition
		{
			get { return _definition; }
			set { _definition = value; }
		}

	}
}
