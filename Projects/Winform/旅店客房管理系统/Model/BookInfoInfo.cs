using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{

	public class BookInfoInfo
	{
		private int _ID;
		/// <summary>
		/// 获取或设置 ID 的值
		/// </summary>
		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		private string _CustomerName;
		/// <summary>
		/// 获取或设置 CustomerName 的值
		/// </summary>
		public string CustomerName
		{
			get { return _CustomerName; }
			set { _CustomerName = value; }
		}

		private string _Phone;
		/// <summary>
		/// 获取或设置 Phone 的值
		/// </summary>
		public string Phone
		{
			get { return _Phone; }
			set { _Phone = value; }
		}

		private int _Deposit;
		/// <summary>
		/// 获取或设置 Deposit 的值
		/// </summary>
		public int Deposit
		{
			get { return _Deposit; }
			set { _Deposit = value; }
		}

		private string _CheckInTime;
		/// <summary>
		/// 获取或设置 CheckInTime 的值
		/// </summary>
		public string CheckInTime
		{
			get { return _CheckInTime; }
			set { _CheckInTime = value; }
		}

		private int _Days;
		/// <summary>
		/// 获取或设置 Days 的值
		/// </summary>
		public int Days
		{
			get { return _Days; }
			set { _Days = value; }
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

		private string _RoomType;
		/// <summary>
		/// 获取或设置 RoomType 的值
		/// </summary>
		public string RoomType
		{
			get { return _RoomType; }
			set { _RoomType = value; }
		}

		private string _RoomNumber;
		/// <summary>
		/// 获取或设置 RoomNumber 的值
		/// </summary>
		public string RoomNumber
		{
			get { return _RoomNumber; }
			set { _RoomNumber = value; }
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
