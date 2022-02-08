using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{

    public class RoomInfoDAL
	{

		/// <summary>
		/// 获取所有信息
		/// </summary>
		/// <param name="where">条件</param>
		/// <returns>结果集</returns>
		public static SqlDataReader GetRoomInfoInfo(string where)
		{
			string sqlStr = "SELECT * FROM RoomInfo where ";
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
		public static List<RoomInfoInfo> GetRoomInfoInfoList(string where)
		{
			List<RoomInfoInfo> infoList = new List<RoomInfoInfo>();

			SqlDataReader reader = null;
			try
			{
				reader = GetRoomInfoInfo(where);
			}
			catch (Exception)
			{
				throw;
			}

			while (reader.Read())
			{
				RoomInfoInfo info = new RoomInfoInfo();
				info.RoomNumber=reader["RoomNumber"].ToString();
				info.RoomType=reader["RoomType"].ToString();
				info.RoomPrice=double.Parse(reader["RoomPrice"].ToString());
				info.RoomStatus=reader["RoomStatus"].ToString();
				info.Remarks=reader["Remarks"].ToString();
				infoList.Add(info);
			}
			reader.Close();
			return infoList;
		}

		/// <summary>
		/// 根据 主键 获取一个实体对象
		/// <param name="RoomNumber">主键</param>
		/// </summary>
		public static RoomInfoInfo GetRoomInfoInfoById(string RoomNumber)
		{
			string strWhere = "RoomNumber =" + RoomNumber;
			List<RoomInfoInfo> list = GetRoomInfoInfoList(strWhere);
			if (list.Count > 0)
			return list[0];
			return null;
		}

		/// 添加数据
		/// </summary>
		/// <param name="info">数据表实体对象</param>
		public static bool AddRoomInfo(RoomInfoInfo info)
		{
            string _RoomNumber = info.RoomNumber;
            string _RoomType = info.RoomType;
            double _RoomPrice = info.RoomPrice;
            string _RoomStatus = info.RoomStatus;
            string _Remarks = info.Remarks;

            string sql = "INSERT INTO RoomInfo VALUES (@_RoomNumber,@_RoomType,@_RoomPrice,@_RoomStatus,@_Remarks)";
            int rst = DBManager.ExecuteUpdate(sql, new object[] { new SqlParameter("@_RoomNumber", _RoomNumber), new SqlParameter("@_RoomType", _RoomType), new SqlParameter("@_RoomPrice", _RoomPrice), new SqlParameter("@_RoomStatus", _RoomStatus), new SqlParameter("@_Remarks", _Remarks) });
            if (rst > 0)
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
		/// <param name="RoomNumber">主键</param>
		/// <returns></returns>
		public static bool DeleteRoomInfoInfo(RoomInfoInfo info)
		{
			bool rst = false;
			string sqlStr = "DELETE FROM RoomInfo WHERE RoomNumber=" + info.RoomNumber;
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
		public static bool UpdateRoomInfoInfo(RoomInfoInfo info)
		{
			string _RoomType = info.RoomType;
			double _RoomPrice = info.RoomPrice;
			string _RoomStatus = info.RoomStatus;
			string _Remarks = info.Remarks;
			string sql="UPDATE RoomInfo SET RoomType=@_RoomType, RoomPrice=@_RoomPrice, RoomStatus=@_RoomStatus, Remarks=@_Remarks  WHERE RoomNumber="+info.RoomNumber;
			int rst = DBManager.ExecuteUpdate(sql, new object[] { new SqlParameter("@_RoomType",_RoomType),new SqlParameter("@_RoomPrice",_RoomPrice),new SqlParameter("@_RoomStatus",_RoomStatus),new SqlParameter("@_Remarks",_Remarks) });
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
