using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class addchengji : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 下载于www.mycodes.net
    }
    //提交
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (TB_name.Text == "" || TB_shuxue.Text == "" || TB_yingyu.Text == "" || TB_yuwen.Text == "")
            Response.Write("<script language=javascript>alert('输入不能为空！');</script>");
        else
        {
            DataBase db = new DataBase();
            db.OpenDataBase();
            string str = "select * from users where name='" + TB_name.Text + "'and role="+2;
              SqlCommand cmd = new SqlCommand(str, db.CONN);
              SqlDataReader result = cmd.ExecuteReader();
              if (result.Read())
              {
                  result.Close();
                  string str1 = "insert into chengji(name,YW_chengji,SX_chengji,YY_chengji) values('" + TB_name.Text + "','" +TB_yuwen.Text.ToString() + "','" + TB_shuxue.Text.ToString() + "','" + TB_yingyu.Text.ToString() + "')";
                  cmd.CommandText = str1;
                  cmd.ExecuteNonQuery();
                  Response.Write("<script language=javascript>alert('录入成功！');</script>");
                  TB_name.Text = "";
                  TB_shuxue.Text = "";
                  TB_yingyu.Text = "";
                  TB_yuwen.Text = "";

              }
              else
              {
                  Response.Write("<script language=javascript>alert('学生不存在！');</script>");
                  result.Close();
              }


            db.CloseDataBase();
            
        }


    }
    //取消
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("welcome.html");
    }
}