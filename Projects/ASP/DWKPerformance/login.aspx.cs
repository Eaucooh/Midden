using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;



public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 下载于www.mycodes.net
    }

    protected void bt_clear_Click(object sender, ImageClickEventArgs e)
    {
        usersname.Text = "";
        password.Text = "";


    }
    protected void bt_login_Click(object sender, ImageClickEventArgs e)
    {
        if (usersname.Text == "" || password.Text == "")
        {
            Response.Write("<script language='javascript'> alert('用户名和密码不能为空！');</script>");
        }
        else
        {
            DataBase db = new DataBase();
            db.OpenDataBase();
            string str = "select * from users where name='" + usersname.Text + "'and password='" + password.Text + "'";
            SqlCommand cmd = new SqlCommand(str, db.CONN);
            SqlDataReader result = cmd.ExecuteReader();
            //判断用户名是否存在
            if (result.Read())
            {
                Session["DLZ1"] = usersname.Text; 
                result.Close();
                cmd.CommandText = "select * from users where name='" + usersname.Text + "'and password='" + password.Text + "'"+"and role=1";
                SqlDataReader result1 = cmd.ExecuteReader();
                //判断用户名类型
                if (result1.Read())
                {
                    result1.Close();
                   
                    Response.Redirect("teacher.aspx");
                }
                else
                {
                    result1.Close();
                    Response.Redirect("student.aspx");
                   
                    
                }


            }
            else
            {
                Response.Write("<script language='javascript'>alert('用户名或密码错误！');</script>");
                result.Close();
            }
            db.CloseDataBase();
            
        }

       

    }
}