using DAL;
using Model;
using System.Collections.Generic;

namespace BLL
{

    public class RecordBLL
	{


		/// <summary>
		/// 获取所有信息集合
		/// </summary>
		/// <returns>List集合</returns>
		public static List<RecordInfo> GetRecordInfoList(string where)
		{
			try
			{
				return RecordDAL.GetRecordInfoList(where);
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// 根据 主键 获取一个实体对象
		/// <param name="ID">主键</param>
		/// </summary>
		public static RecordInfo GetRecordInfoById(int ID)
		{
			try
			{
				return RecordDAL.GetRecordInfoById(ID);
			}
			catch
			{
				throw;
			}
		}

		/// 添加数据
		/// </summary>
		/// <param name="info">数据表实体对象</param>
		public static bool AddRecord(RecordInfo info)
		{
			try
			{
				return RecordDAL.AddRecord(info);
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// 根据主键删除一个对象
		/// </summary>
		/// <param name="_ID">主键</param>
		/// <returns></returns>
		public static bool DeleteRecordInfo(RecordInfo info)
		{
			try
			{
				return RecordDAL.DeleteRecordInfo(info);
			}
			catch
			{
				throw;
			}
		}

		/// 更新数据
		/// </summary>
		/// <param name="info">数据表实体</param>
		public static bool UpdateRecordInfo(RecordInfo info)
		{
			try
			{
				return RecordDAL.UpdateRecordInfo(info);
			}
			catch
			{
				throw;
			}
		}
	}
}
