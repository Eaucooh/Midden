using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class pingjia_step2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        name.Text = Session["name"].ToString();

    }
    //取消
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
     Response.Redirect("welcome.html");
    }
   //提交
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        DataBase db = new DataBase();
        db.OpenDataBase();
        string str = "UPDATE users SET  pingjia='"+TextBox1.Text+"' where name='" + name.Text + "'";
        SqlCommand cmd = new SqlCommand(str, db.CONN);
        cmd.ExecuteNonQuery();
        db.CloseDataBase();
        Response.Write("<script language=javascript>alert('评价成功 ！');</script>");

    }
}