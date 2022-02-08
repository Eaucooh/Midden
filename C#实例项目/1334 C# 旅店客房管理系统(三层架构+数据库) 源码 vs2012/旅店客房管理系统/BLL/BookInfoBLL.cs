using System.Collections.Generic;
using Model;
using DAL;

namespace BLL
{

    public class BookInfoBLL
	{


		/// <summary>
		/// 获取所有信息集合
		/// </summary>
		/// <returns>List集合</returns>
		public  List<BookInfoInfo> GetBookInfoInfoList(string where)
		{
			try
			{
				return BookInfoDAL.GetBookInfoInfoList(where);
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
		public static BookInfoInfo GetBookInfoInfoById(int ID)
		{
			try
			{
				return BookInfoDAL.GetBookInfoInfoById(ID);
			}
			catch
			{
				throw;
			}
		}

		/// 添加数据
		/// </summary>
		/// <param name="info">数据表实体对象</param>
		public bool AddBookInfo(BookInfoInfo info)
		{
			try
			{
				return BookInfoDAL.AddBookInfo(info);
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
		public bool DeleteBookInfoInfo(BookInfoInfo info)
		{
			try
			{
				return BookInfoDAL.DeleteBookInfoInfo(info);
			}
			catch
			{
				throw;
			}
		}

		/// 更新数据
		/// </summary>
		/// <param name="info">数据表实体</param>
		public static bool UpdateBookInfoInfo(BookInfoInfo info)
		{
			try
			{
				return BookInfoDAL.UpdateBookInfoInfo(info);
			}
			catch
			{
				throw;
			}
		}
	}
}
