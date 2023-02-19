using DAL;
using Model;
using System.Collections.Generic;

namespace BLL
{

    public class UserInfoBLL
	{


		/// <summary>
		/// 获取所有信息集合
		/// </summary>
		/// <returns>List集合</returns>
		public List<UserInfoInfo> GetUserInfoInfoList(string where)
		{
			try
			{
				return UserInfoDAL.GetUserInfoInfoList(where);
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// 根据 主键 获取一个实体对象
		/// <param name="UserName">主键</param>
		/// </summary>
		public static UserInfoInfo GetUserInfoInfoById(string UserName)
		{
			try
			{
				return UserInfoDAL.GetUserInfoInfoById(UserName);
			}
			catch
			{
				throw;
			}
		}

		/// 添加数据
		/// </summary>
		/// <param name="info">数据表实体对象</param>
		public  bool AddUserInfo(UserInfoInfo info)
		{
			try
			{
				return UserInfoDAL.AddUserInfo(info);
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// 根据主键删除一个对象
		/// </summary>
		/// <param name="_UserName">主键</param>
		/// <returns></returns>
		public static bool DeleteUserInfoInfo(UserInfoInfo info)
		{
			try
			{
				return UserInfoDAL.DeleteUserInfoInfo(info);
			}
			catch
			{
				throw;
			}
		}

		/// 更新数据
		/// </summary>
		/// <param name="info">数据表实体</param>
		public static bool UpdateUserInfoInfo(UserInfoInfo info)
		{
			try
			{
				return UserInfoDAL.UpdateUserInfoInfo(info);
			}
			catch
			{
				throw;
			}
		}
	}
}
