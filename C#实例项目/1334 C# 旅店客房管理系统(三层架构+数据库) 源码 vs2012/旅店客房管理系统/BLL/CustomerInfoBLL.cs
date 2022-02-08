using DAL;
using Model;
using System.Collections.Generic;

namespace BLL
{

    public class CustomerInfoBLL
	{


		/// <summary>
		/// 获取所有信息集合
		/// </summary>
		/// <returns>List集合</returns>
		public List<CustomerInfoInfo> GetCustomerInfoInfoList(string where)
		{
			try
			{
				return CustomerInfoDAL.GetCustomerInfoInfoList(where);
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
		public static CustomerInfoInfo GetCustomerInfoInfoById(int ID)
		{
			try
			{
				return CustomerInfoDAL.GetCustomerInfoInfoById(ID);
			}
			catch
			{
				throw;
			}
		}

		/// 添加数据
		/// </summary>
		/// <param name="info">数据表实体对象</param>
		public bool AddCustomerInfo(CustomerInfoInfo info)
		{
			try
			{
				return CustomerInfoDAL.AddCustomerInfo(info);
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
		public static bool DeleteCustomerInfoInfo(CustomerInfoInfo info)
		{
			try
			{
				return CustomerInfoDAL.DeleteCustomerInfoInfo(info);
			}
			catch
			{
				throw;
			}
		}

		/// 更新数据
		/// </summary>
		/// <param name="info">数据表实体</param>
		public bool UpdateCustomerInfoInfo(CustomerInfoInfo info)
		{
			try
			{
				return CustomerInfoDAL.UpdateCustomerInfoInfo(info);
			}
			catch
			{
				throw;
			}
		}
	}
}
