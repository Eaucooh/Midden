using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class xiugaichengji_step2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            name.Text = Session["name"].ToString();
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
   
    
    //修改数学
    protected void LinkButton2_Click(object sender, EventArgs e)
    {

        if (HiddenField1.Value != "")
        {
            string str = HiddenField2.Value;
            shuxue.Text = str;
        }
     
        

    }
    //修改英语
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        if (HiddenField3.Value != "")
        {
            string str = HiddenField3.Value;
            yingyu.Text = str;
        }
       

    }
    //取消
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("welcome.html");
        

    }

    //修改语文
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        if (HiddenField1.Value != "")
        {
            string str = HiddenField1.Value;
            yuwen.Text = str;
        }
      
        
        
    }
    //提交
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
       string YW,SX,YY;
        DataBase db = new DataBase();
        db.OpenDataBase();
        if (yuwen.Text == "无")
            YW = null;
        else YW = yuwen.Text;
        if (shuxue.Text == "无")
            SX = null;
        else SX = shuxue.Text;
        if (yingyu.Text == "无")
            YY = null;
        else YY = yingyu.Text;

     
        string str ="UPDATE chengji SET YW_chengji='"+YW+"',SX_chengji='"+SX+"',YY_chengji='"+YY+ "'  where name='"+name.Text+"'";
        SqlCommand cmd = new SqlCommand(str, db.CONN);
        cmd.ExecuteNonQuery();
        db.CloseDataBase();
        Response.Write("<script language=javascript>alert('修改成功 ！');</script>");

    }
}