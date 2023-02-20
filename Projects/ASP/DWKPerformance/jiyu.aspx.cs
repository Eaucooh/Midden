using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class jiyu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataBase db = new DataBase();
        db.OpenDataBase();
        string str = "select pingjia from users where name='"+Session["DLZ1"].ToString()+"'";
        SqlCommand cmd = new SqlCommand(str, db.CONN);
        SqlDataReader result = cmd.ExecuteReader();
        if (result.Read())
        {
            TextBox1.Text = result[0].ToString().Trim();
            result.Close();
        }
        else
        {
            TextBox1.Text = "无评价！";
            result.Close();
        }
        db.CloseDataBase();
        // 下载于www.mycodes.net
    }
}