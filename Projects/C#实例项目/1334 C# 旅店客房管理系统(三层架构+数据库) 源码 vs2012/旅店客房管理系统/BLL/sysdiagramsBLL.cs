using DAL;
using Model;
using System.Collections.Generic;

namespace BLL
{
    /// <summary>
    /// sysdiagramsBLL类
    /// BY：狂人代码生成器 V1.0
    /// 作者：金属狂人
    /// 日期：2019年06月03日 06:47:09
    /// </summary>
    public class sysdiagramsBLL
	{


		/// <summary>
		/// 获取所有信息集合
		/// </summary>
		/// <returns>List集合</returns>
		public static List<sysdiagramsInfo> GetsysdiagramsInfoList(string where)
		{
			try
			{
				return sysdiagramsDAL.GetsysdiagramsInfoList(where);
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// 根据 主键 获取一个实体对象
		/// <param name="diagramid">主键</param>
		/// </summary>
		public static sysdiagramsInfo GetsysdiagramsInfoById(int diagramid)
		{
			try
			{
				return sysdiagramsDAL.GetsysdiagramsInfoById(diagramid);
			}
			catch
			{
				throw;
			}
		}

		/// 添加数据
		/// </summary>
		/// <param name="info">数据表实体对象</param>
		public static bool Addsysdiagrams(sysdiagramsInfo info)
		{
			try
			{
				return sysdiagramsDAL.Addsysdiagrams(info);
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// 根据主键删除一个对象
		/// </summary>
		/// <param name="_diagram_id">主键</param>
		/// <returns></returns>
		public static bool DeletesysdiagramsInfo(sysdiagramsInfo info)
		{
			try
			{
				return sysdiagramsDAL.DeletesysdiagramsInfo(info);
			}
			catch
			{
				throw;
			}
		}

		/// 更新数据
		/// </summary>
		/// <param name="info">数据表实体</param>
		public static bool UpdatesysdiagramsInfo(sysdiagramsInfo info)
		{
			try
			{
				return sysdiagramsDAL.UpdatesysdiagramsInfo(info);
			}
			catch
			{
				throw;
			}
		}
	}
}
