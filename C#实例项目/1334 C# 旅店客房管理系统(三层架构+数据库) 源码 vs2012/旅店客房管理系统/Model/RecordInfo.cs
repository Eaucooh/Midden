using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{

	public class RecordInfo
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

		private string _Sex;
		/// <summary>
		/// 获取或设置 Sex 的值
		/// </summary>
		public string Sex
		{
			get { return _Sex; }
			set { _Sex = value; }
		}

		private string _CredentialNumber;
		/// <summary>
		/// 获取或设置 CredentialNumber 的值
		/// </summary>
		public string CredentialNumber
		{
			get { return _CredentialNumber; }
			set { _CredentialNumber = value; }
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

		private string _CheckInTime;
		/// <summary>
		/// 获取或设置 CheckInTime 的值
		/// </summary>
		public string CheckInTime
		{
			get { return _CheckInTime; }
			set { _CheckInTime = value; }
		}

		private string _CheckOutTime;
		/// <summary>
		/// 获取或设置 CheckOutTime 的值
		/// </summary>
		public string CheckOutTime
		{
			get { return _CheckOutTime; }
			set { _CheckOutTime = value; }
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

		private double _Spending;
		/// <summary>
		/// 获取或设置 Spending 的值
		/// </summary>
		public double Spending
		{
			get { return _Spending; }
			set { _Spending = value; }
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
