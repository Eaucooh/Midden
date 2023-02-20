using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class deletestudent_step1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //搜索
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
       
        DataBase db = new DataBase();
        db.OpenDataBase();
        string str = "select * from users where name='" + TB_name.Text + "'and role=2";
        SqlCommand cmd = new SqlCommand(str, db.CONN);
        SqlDataReader result = cmd.ExecuteReader();
        if (result.Read())
        {
            Session["name"] = TB_name.Text;
            result.Close();
            Response.Redirect("deletestudent_step2.aspx");
        }
        else
        {
            result.Close();
            Response.Write("<script language=javascript>alert('学生不存在！');</script>");
        }
        db.CloseDataBase();


    }
}