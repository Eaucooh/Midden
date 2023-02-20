using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
/// <summary>
///DataBase 的摘要说明
/// </summary>


    public class DataBase  //数据库类
    {
        // 下载于www.mycodes.net
        SqlConnection conn;
        public SqlConnection CONN
        {
            get
            {
                return conn;
            }
        }
        public void OpenDataBase() //连接数据库方法
        {
            string strconn = "Data Source=.\\SQL2005;Initial Catalog=DB_kechengsheji;uid=sa;pwd=sasasa;Integrated Security=True";
            conn = new SqlConnection(strconn);
            conn.Open();
        }
        public void CloseDataBase() //关闭数据库方法
        {
            conn.Close();
        }


    }

