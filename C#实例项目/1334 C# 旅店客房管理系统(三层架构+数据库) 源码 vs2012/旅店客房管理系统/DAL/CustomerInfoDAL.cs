using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{

    public class CustomerInfoDAL
	{

		/// <summary>
		/// 获取所有信息
		/// </summary>
		/// <param name="where">条件</param>
		/// <returns>结果集</returns>
		public static SqlDataReader GetCustomerInfoInfo(string where)
		{
			string sqlStr = "SELECT * FROM CustomerInfo where ";
			if (String.IsNullOrEmpty(where))
			{
				sqlStr += "1=1";
			}
			else
			{
				sqlStr += where;
			}
			SqlDataReader reader = null;
			try
			{
				reader = DBManager.ExecuteQuery(sqlStr);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			return reader;
		}

		/// <summary>
		/// 获取所有信息集合
		/// </summary>
		/// <returns>List集合</returns>
		public static List<CustomerInfoInfo> GetCustomerInfoInfoList(string where)
		{
			List<CustomerInfoInfo> infoList = new List<CustomerInfoInfo>();

			SqlDataReader reader = null;
			try
			{
				reader = GetCustomerInfoInfo(where);
			}
			catch (Exception)
			{
				throw;
			}

			while (reader.Read())
			{
				CustomerInfoInfo info = new CustomerInfoInfo();
				info.ID=int.Parse(reader["ID"].ToString());
				info.CustomerName=reader["CustomerName"].ToString();
				info.Sex=reader["Sex"].ToString();
				info.CredentialNumber=reader["CredentialNumber"].ToString();
				info.Phone=reader["Phone"].ToString();
				info.Deposit=int.Parse(reader["Deposit"].ToString());
				info.CheckInTime=reader["CheckInTime"].ToString();
				info.Days=int.Parse(reader["Days"].ToString());
				info.RoomPrice=double.Parse(reader["RoomPrice"].ToString());
				info.RoomType=reader["RoomType"].ToString();
				info.RoomNumber=reader["RoomNumber"].ToString();
				info.Remarks=reader["Remarks"].ToString();
				infoList.Add(info);
			}
			reader.Close();
			return infoList;
		}

		/// <summary>
		/// 根据 主键 获取一个实体对象
		/// <param name="ID">主键</param>
		/// </summary>
		public static CustomerInfoInfo GetCustomerInfoInfoById(int ID)
		{
			string strWhere = "ID =" + ID;
			List<CustomerInfoInfo> list = GetCustomerInfoInfoList(strWhere);
			if (list.Count > 0)
			return list[0];
			return null;
		}

		/// 添加数据
		/// </summary>
		/// <param name="info">数据表实体对象</param>
		public static bool AddCustomerInfo(CustomerInfoInfo info)
		{
			string _CustomerName = info.CustomerName;
			string _Sex = info.Sex;
			string _CredentialNumber = info.CredentialNumber;
			string _Phone = info.Phone;
			int _Deposit = info.Deposit;
			string _CheckInTime = info.CheckInTime;
			int _Days = info.Days;
			double _RoomPrice = info.RoomPrice;
			string _RoomType = info.RoomType;
			string _RoomNumber = info.RoomNumber;
			string _Remarks = info.Remarks;

			string sql="INSERT INTO CustomerInfo VALUES (@_CustomerName,@_Sex,@_CredentialNumber,@_Phone,@_Deposit,@_CheckInTime,@_Days,@_RoomPrice,@_RoomType,@_RoomNumber,@_Remarks)";
			int rst = DBManager.ExecuteUpdate(sql, new object[] { new SqlParameter("@_CustomerName",_CustomerName),new SqlParameter("@_Sex",_Sex),new SqlParameter("@_CredentialNumber",_CredentialNumber),new SqlParameter("@_Phone",_Phone),new SqlParameter("@_Deposit",_Deposit),new SqlParameter("@_CheckInTime",_CheckInTime),new SqlParameter("@_Days",_Days),new SqlParameter("@_RoomPrice",_RoomPrice),new SqlParameter("@_RoomType",_RoomType),new SqlParameter("@_RoomNumber",_RoomNumber),new SqlParameter("@_Remarks",_Remarks) });
			if(rst>0)
			{ 
				return true;
			}
			else
			{ 
				return false;
			}
		}
		/// <summary>
		/// 删除一个对象
		/// </summary>
		/// <param name="ID">主键</param>
		/// <returns></returns>
		public static bool DeleteCustomerInfoInfo(CustomerInfoInfo info)
		{
			bool rst = false;
			string sqlStr = "DELETE FROM CustomerInfo WHERE ID=" + info.ID;
			int rows = DBManager.ExecuteUpdate(sqlStr);
			if (rows>0)
			{
				rst = true;
			}
			return rst;
		}


		/// 更新数据
		/// </summary>
		/// <param name="info">数据表实体</param>
		public static bool UpdateCustomerInfoInfo(CustomerInfoInfo info)
		{
			string _CustomerName = info.CustomerName;
			string _Sex = info.Sex;
			string _CredentialNumber = info.CredentialNumber;
			string _Phone = info.Phone;
			int _Deposit = info.Deposit;
			string _CheckInTime = info.CheckInTime;
			int _Days = info.Days;
			double _RoomPrice = info.RoomPrice;
			string _RoomType = info.RoomType;
			string _RoomNumber = info.RoomNumber;
			string _Remarks = info.Remarks;
			string sql="UPDATE CustomerInfo SET CustomerName=@_CustomerName, Sex=@_Sex, CredentialNumber=@_CredentialNumber, Phone=@_Phone, Deposit=@_Deposit, CheckInTime=@_CheckInTime, Days=@_Days, RoomPrice=@_RoomPrice, RoomType=@_RoomType, RoomNumber=@_RoomNumber, Remarks=@_Remarks  WHERE ID="+info.ID;
			int rst = DBManager.ExecuteUpdate(sql, new object[] { new SqlParameter("@_CustomerName",_CustomerName),new SqlParameter("@_Sex",_Sex),new SqlParameter("@_CredentialNumber",_CredentialNumber),new SqlParameter("@_Phone",_Phone),new SqlParameter("@_Deposit",_Deposit),new SqlParameter("@_CheckInTime",_CheckInTime),new SqlParameter("@_Days",_Days),new SqlParameter("@_RoomPrice",_RoomPrice),new SqlParameter("@_RoomType",_RoomType),new SqlParameter("@_RoomNumber",_RoomNumber),new SqlParameter("@_Remarks",_Remarks) });
			if(rst>0)
			{ 
				return true;
			}
			else
			{ 
				return false;
			}
		}
	}
}
