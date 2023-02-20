using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class chakanchengji : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        name.Text = Session["DLZ1"].ToString();
        DataBase db = new DataBase();
        db.OpenDataBase();
        string str = "select * from chengji where name='" + name.Text + "'";
        SqlCommand cmd = new SqlCommand(str, db.CONN);
        SqlDataReader result = cmd.ExecuteReader();
        if (result.Read())
        {
            yuwen.Text = result["YW_chengji"].ToString();
            shuxue.Text = result["SX_chengji"].ToString();
            yingyu.Text = result["YY_chengji"].ToString();

        }
        else
        {
            yuwen.Text = "无";
            shuxue.Text = "无";
            yingyu.Text = "无";
        }
        result.Close();
        db.CloseDataBase();
        

    }
}