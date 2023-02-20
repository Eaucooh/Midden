using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{

    public class RecordDAL
	{

		/// <summary>
		/// 获取所有信息
		/// </summary>
		/// <param name="where">条件</param>
		/// <returns>结果集</returns>
		public static SqlDataReader GetRecordInfo(string where)
		{
			string sqlStr = "SELECT * FROM Record where ";
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
		public static List<RecordInfo> GetRecordInfoList(string where)
		{
			List<RecordInfo> infoList = new List<RecordInfo>();

			SqlDataReader reader = null;
			try
			{
				reader = GetRecordInfo(where);
			}
			catch (Exception)
			{
				throw;
			}

			while (reader.Read())
			{
				RecordInfo info = new RecordInfo();
				info.ID=int.Parse(reader["ID"].ToString());
				info.CustomerName=reader["CustomerName"].ToString();
				info.Sex=reader["Sex"].ToString();
				info.CredentialNumber=reader["CredentialNumber"].ToString();
				info.Phone=reader["Phone"].ToString();
				info.CheckInTime=reader["CheckInTime"].ToString();
				info.CheckOutTime=reader["CheckOutTime"].ToString();
				info.Days=int.Parse(reader["Days"].ToString());
				info.Spending=double.Parse(reader["Spending"].ToString());
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
		public static RecordInfo GetRecordInfoById(int ID)
		{
			string strWhere = "ID =" + ID;
			List<RecordInfo> list = GetRecordInfoList(strWhere);
			if (list.Count > 0)
			return list[0];
			return null;
		}

		/// 添加数据
		/// </summary>
		/// <param name="info">数据表实体对象</param>
		public static bool AddRecord(RecordInfo info)
		{
			string _CustomerName = info.CustomerName;
			string _Sex = info.Sex;
			string _CredentialNumber = info.CredentialNumber;
			string _Phone = info.Phone;
			string _CheckInTime = info.CheckInTime;
			string _CheckOutTime = info.CheckOutTime;
			int _Days = info.Days;
			double _Spending = info.Spending;
			string _RoomType = info.RoomType;
			string _RoomNumber = info.RoomNumber;
			string _Remarks = info.Remarks;

			string sql="INSERT INTO Record VALUES (@_CustomerName,@_Sex,@_CredentialNumber,@_Phone,@_CheckInTime,@_CheckOutTime,@_Days,@_Spending,@_RoomType,@_RoomNumber,@_Remarks)";
			int rst = DBManager.ExecuteUpdate(sql, new object[] { new SqlParameter("@_CustomerName",_CustomerName),new SqlParameter("@_Sex",_Sex),new SqlParameter("@_CredentialNumber",_CredentialNumber),new SqlParameter("@_Phone",_Phone),new SqlParameter("@_CheckInTime",_CheckInTime),new SqlParameter("@_CheckOutTime",_CheckOutTime),new SqlParameter("@_Days",_Days),new SqlParameter("@_Spending",_Spending),new SqlParameter("@_RoomType",_RoomType),new SqlParameter("@_RoomNumber",_RoomNumber),new SqlParameter("@_Remarks",_Remarks) });
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
		public static bool DeleteRecordInfo(RecordInfo info)
		{
			bool rst = false;
			string sqlStr = "DELETE FROM Record WHERE ID=" + info.ID;
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
		public static bool UpdateRecordInfo(RecordInfo info)
		{
			string _CustomerName = info.CustomerName;
			string _Sex = info.Sex;
			string _CredentialNumber = info.CredentialNumber;
			string _Phone = info.Phone;
			string _CheckInTime = info.CheckInTime;
			string _CheckOutTime = info.CheckOutTime;
			int _Days = info.Days;
			double _Spending = info.Spending;
			string _RoomType = info.RoomType;
			string _RoomNumber = info.RoomNumber;
			string _Remarks = info.Remarks;
			string sql="UPDATE Record SET CustomerName=@_CustomerName, Sex=@_Sex, CredentialNumber=@_CredentialNumber, Phone=@_Phone, CheckInTime=@_CheckInTime, CheckOutTime=@_CheckOutTime, Days=@_Days, Spending=@_Spending, RoomType=@_RoomType, RoomNumber=@_RoomNumber, Remarks=@_Remarks  WHERE ID="+info.ID;
			int rst = DBManager.ExecuteUpdate(sql, new object[] { new SqlParameter("@_CustomerName",_CustomerName),new SqlParameter("@_Sex",_Sex),new SqlParameter("@_CredentialNumber",_CredentialNumber),new SqlParameter("@_Phone",_Phone),new SqlParameter("@_CheckInTime",_CheckInTime),new SqlParameter("@_CheckOutTime",_CheckOutTime),new SqlParameter("@_Days",_Days),new SqlParameter("@_Spending",_Spending),new SqlParameter("@_RoomType",_RoomType),new SqlParameter("@_RoomNumber",_RoomNumber),new SqlParameter("@_Remarks",_Remarks) });
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
