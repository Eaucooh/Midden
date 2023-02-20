using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class addstudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RadioButton1.Checked = true;
        

    }
    //提交按钮 

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        DataBase db = new DataBase();
        db.OpenDataBase();
        string str="select * from users where name='"+TB_name.Text+"'";
        SqlCommand cmd = new SqlCommand(str, db.CONN);
        SqlDataReader result = cmd.ExecuteReader();
        if (result.Read())
        {
            Response.Write("<script language=javascript>alert('学生已存在！');</script>");
            result.Close();
        }
        else
        {
            result.Close();

        //判空
            if (TB_name.Text == "" || TB_password.Text == "")
                Response.Write("<script language=javascript>alert('姓名和密码不能为空！');</script>");
            else //非空
            {
                string sex = "";
                if (RadioButton1.Checked == true)
                    sex = "男";
                else
                    sex = "女 ";
                string str1 = "insert into users(name,password,sex,role) values('" + TB_name.Text + "','" + TB_password.Text + "','" + sex + "'," + 2 + ")";
                cmd.CommandText = str1;
                cmd.ExecuteNonQuery();
                Response.Write("<script language=javascript>alert('添加成功！');</script>");
                TB_name.Text = "";
                TB_password.Text = "";


            }

        }
        db.CloseDataBase();
    }
    //取消按钮
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("welcome.html");

    }
}