using DAL;
using Model;
using System.Collections.Generic;

namespace BLL
{

    public class RoomInfoBLL
	{


		/// <summary>
		/// 获取所有信息集合
		/// </summary>
		/// <returns>List集合</returns>
		public List<RoomInfoInfo> GetRoomInfoInfoList(string where)
		{
			try
			{
				return RoomInfoDAL.GetRoomInfoInfoList(where);
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// 根据 主键 获取一个实体对象
		/// <param name="RoomNumber">主键</param>
		/// </summary>
		public static RoomInfoInfo GetRoomInfoInfoById(string RoomNumber)
		{
			try
			{
				return RoomInfoDAL.GetRoomInfoInfoById(RoomNumber);
			}
			catch
			{
				throw;
			}
		}

		/// 添加数据
		/// </summary>
		/// <param name="info">数据表实体对象</param>
		public bool AddRoomInfo(RoomInfoInfo info)
		{
			try
			{
				return RoomInfoDAL.AddRoomInfo(info);
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// 根据主键删除一个对象
		/// </summary>
		/// <param name="_RoomNumber">主键</param>
		/// <returns></returns>
		public static bool DeleteRoomInfoInfo(RoomInfoInfo info)
		{
			try
			{
				return RoomInfoDAL.DeleteRoomInfoInfo(info);
			}
			catch
			{
				throw;
			}
		}

		/// 更新数据
		/// </summary>
		/// <param name="info">数据表实体</param>
		public bool UpdateRoomInfoInfo(RoomInfoInfo info)
		{
			try
			{
				return RoomInfoDAL.UpdateRoomInfoInfo(info);
			}
			catch
			{
				throw;
			}
		}
	}
}
