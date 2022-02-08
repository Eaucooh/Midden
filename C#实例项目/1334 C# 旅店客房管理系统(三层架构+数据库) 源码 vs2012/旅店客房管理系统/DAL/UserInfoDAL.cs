using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{

    public class UserInfoDAL
	{
		/// <summary>
		/// 获取所有信息
		/// </summary>
		/// <param name="where">条件</param>
		/// <returns>结果集</returns>
		public static SqlDataReader GetUserInfoInfo(string where)
		{
			string sqlStr = "SELECT * FROM UserInfo where ";
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
		public static List<UserInfoInfo> GetUserInfoInfoList(string where)
		{
			List<UserInfoInfo> infoList = new List<UserInfoInfo>();

			SqlDataReader reader = null;
			try
			{
				reader = GetUserInfoInfo(where);
			}
			catch (Exception)
			{
				throw;
			}

			while (reader.Read())
			{
				UserInfoInfo info = new UserInfoInfo();
				info.UserName=reader["UserName"].ToString();
				info.UserPassword=reader["UserPassword"].ToString();
				info.UserType=reader["UserType"].ToString();
				infoList.Add(info);
			}
			reader.Close();
			return infoList;
		}

		/// <summary>
		/// 根据 主键 获取一个实体对象
		/// <param name="UserName">主键</param>
		/// </summary>
		public static UserInfoInfo GetUserInfoInfoById(string UserName)
		{
			string strWhere = "UserName =" + UserName;
			List<UserInfoInfo> list = GetUserInfoInfoList(strWhere);
			if (list.Count > 0)
			return list[0];
			return null;
		}

		/// 添加数据
		/// </summary>
		/// <param name="info">数据表实体对象</param>
		public static bool AddUserInfo(UserInfoInfo info)
		{
            string _UserName = info.UserName;
            string _UserPassword = info.UserPassword;
            string _UserType = info.UserType;

            string sql = "INSERT INTO UserInfo VALUES (@_UserName,@_UserPassword,@_UserType)";
            int rst = DBManager.ExecuteUpdate(sql, new object[] { new SqlParameter("@_UserName", _UserName), new SqlParameter("@_UserPassword", _UserPassword), new SqlParameter("@_UserType", _UserType) });
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
		/// <param name="UserName">主键</param>
		/// <returns></returns>
		public static bool DeleteUserInfoInfo(UserInfoInfo info)
		{
			bool rst = false;
			string sqlStr = "DELETE FROM UserInfo WHERE UserName=" + info.UserName;
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
		public static bool UpdateUserInfoInfo(UserInfoInfo info)
		{
			string _UserPassword = info.UserPassword;
			string _UserType = info.UserType;
			string sql="UPDATE UserInfo SET UserPassword=@_UserPassword, UserType=@_UserType  WHERE UserName="+info.UserName;
			int rst = DBManager.ExecuteUpdate(sql, new object[] { new SqlParameter("@_UserPassword",_UserPassword),new SqlParameter("@_UserType",_UserType) });
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
