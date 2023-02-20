using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class deletestudent_step2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        name.Text= Session["name"].ToString();
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
    // 提交
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        DataBase db = new DataBase();
        db.OpenDataBase();
        //删除users表记录
        string str = "delete   from users where name = '" + name.Text + "'";
        SqlCommand cmd = new SqlCommand(str,db.CONN);
       cmd.ExecuteNonQuery();
        if (yuwen.Text != "无"||shuxue.Text!="无"||yingyu.Text!="无")
        {
            cmd.CommandText="delete   from chengji where name = '" + name.Text + "'";
            cmd.ExecuteNonQuery();
        }
        Response.Write("<script language=javascript>alert('删除成功！');</script>");
        db.CloseDataBase();

    }
    //取消
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("welcome.html");
    }
}