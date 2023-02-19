using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{

	public static class DBManager
	{

		/// <summary>
		/// 连接字符串
		/// </summary>
		private static string connStr= @"Server=.;Integrated Security=SSPI;database=Hotel";

		/// <summary>
		/// 获取一个新的连接
		/// </summary>
		/// <param name="connStr">连接字符串</param>
		/// <returns></returns>
		public static SqlConnection Conn
		{
			get
			{
				return new SqlConnection(connStr);
			}
		}

		/// <summary>
		/// 执行增、删、改 SQL语句
		/// </summary>
		/// <param name="sqlStr">SQL语句</param>
		/// <param name="param">参数列表</param>
		/// <returns>影响的行数</returns>
		public static int ExecuteUpdate(string sqlStr,params object[] param)
		{
			SqlCommand cmd = new SqlCommand(sqlStr, Conn);
			cmd.Parameters.AddRange(param);
			cmd.Connection.Open();
			int rows = 0;
			try
			{
				rows = cmd.ExecuteNonQuery();
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				cmd.Connection.Close();
			}
			return rows;
		}

		/// <summary>
		/// 执行查询SQL语句
		/// </summary>
		/// <param name="sqlStr">SQL语句</param>
		/// <param name="param">参数列表</param>
		/// <returns></returns>
		public static SqlDataReader ExecuteQuery(string sqlStr,params object[] param)
		{
			SqlCommand cmd = new SqlCommand(sqlStr, Conn);
			cmd.Parameters.AddRange(param);
			cmd.Connection.Open();
			try
			{
				return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection) ;
			}
			catch (Exception)
			{
				cmd.Connection.Close();
				throw;
			}
		}
		/// <summary>
		/// 执行存储过程 - 无结果集
		/// </summary>
		/// <param name="paroName">存储过程名称</param>
		/// <param name="param">参数列表</param>
		/// <returns></returns>
		public static int ExecuteProc(string procName, params object[] param)
		{
			SqlCommand cmd = new SqlCommand(procName, Conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddRange(param);
			cmd.Connection.Open();
			try
			{
				return cmd.ExecuteNonQuery();
			}
			finally
			{
				cmd.Connection.Close();
			}
		}
		/// <summary>
		/// 执行存储过程 - 有结果集
		/// </summary>
		/// <param name="paroName">存储过程名称</param>
		/// <param name="param">参数列表</param>
		/// <returns></returns>
		public static SqlDataReader ExecuteProcByReader(string procName, params object[] param)
		{
			SqlCommand cmd = new SqlCommand(procName, Conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddRange(param);
			cmd.Connection.Open();
			try
			{
				return cmd.ExecuteReader();
			}
			catch
			{
				cmd.Connection.Close();
				throw;
			}
		}
	}
}
