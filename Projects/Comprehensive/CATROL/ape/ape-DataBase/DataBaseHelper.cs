using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Text;

namespace ape_DataBase
{
    public class DataBaseHelper
    {
        string dbIP;
        string dbName;
        string userName;
        string userPassword;

        /// <summary>
        /// DataBaseHelper的构造函数
        /// </summary>
        /// <param name="dbi">数据库地址</param>
        /// <param name="dbn">数据库名称</param>
        /// <param name="un">用户名</param>
        /// <param name="up">用户密码</param>
        public DataBaseHelper(string dbi, string dbn, string un, string up)
        {
            dbIP = dbi;
            dbName = dbn;
            userName = un;
            userPassword = up;
        }

        private SqlConnectionStringBuilder ConnectionString()
        {
            SqlConnectionStringBuilder ConnectionBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = dbIP,
                InitialCatalog = dbName,
                UserID = userName,
                Password = userPassword
            };
            return ConnectionBuilder;
        }

        /// <summary>
        /// 获取指定列数据
        /// </summary>
        /// <param name="sql">查询的SQL语句</param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public StringBuilder Read(string sql, string columnName)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                //SQL = "USE MFC_Persons;SELECT * FROM Students Where id = 0;"
                using (SqlConnection connection = new SqlConnection(ConnectionString().ToString()))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader sdr = command.ExecuteReader();
                    while (sdr.Read())
                    {
                        sb.Append($"{sdr[columnName]}^");
                    }
                    connection.Close();
                }
                return sb;
            }
            catch (Exception ex)
            {
                sb.Clear();
                sb.Append(ex.Message);
                return sb;
            }
        }
    }
}
