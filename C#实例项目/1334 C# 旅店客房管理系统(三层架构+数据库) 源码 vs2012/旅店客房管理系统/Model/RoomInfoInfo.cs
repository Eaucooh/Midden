using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{

	public class RoomInfoInfo
	{
		private string _RoomNumber;
		/// <summary>
		/// 获取或设置 RoomNumber 的值
		/// </summary>
		public string RoomNumber
		{
			get { return _RoomNumber; }
			set { _RoomNumber = value; }
		}

		private string _RoomType;
		/// <summary>
		/// 获取或设置 RoomType 的值
		/// </summary>
		public string RoomType
		{
			get { return _RoomType; }
			set { _RoomType = value; }
		}

		private double _RoomPrice;
		/// <summary>
		/// 获取或设置 RoomPrice 的值
		/// </summary>
		public double RoomPrice
		{
			get { return _RoomPrice; }
			set { _RoomPrice = value; }
		}

		private string _RoomStatus;
		/// <summary>
		/// 获取或设置 RoomStatus 的值
		/// </summary>
		public string RoomStatus
		{
			get { return _RoomStatus; }
			set { _RoomStatus = value; }
		}

		private string _Remarks;
		/// <summary>
		/// 获取或设置 Remarks 的值
		/// </summary>
		public string Remarks
		{
			get { return _Remarks; }
			set { _Remarks = value; }
		}

	}
}
