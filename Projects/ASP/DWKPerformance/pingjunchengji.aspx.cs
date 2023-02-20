using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class pingjunchengji : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 下载于www.mycodes.net
        DataBase db = new DataBase();
        db.OpenDataBase();
        string str1= "select AVG(YW_chengji) from chengji";
        SqlCommand cmd = new SqlCommand(str1, db.CONN);
        SqlDataReader result1 = cmd.ExecuteReader();
        if (result1.Read())  yuwen.Text = result1[0].ToString();
        result1.Close();
        string str2 = "select AVG(SX_chengji) from chengji";
        cmd.CommandText = str2;
        SqlDataReader result2 = cmd.ExecuteReader();
        if (result2.Read()) shuxue.Text = result2[0].ToString();
        result2.Close();
        string str3 = "select AVG(YY_chengji) from chengji";
        cmd.CommandText = str3;
        SqlDataReader result3 = cmd.ExecuteReader();
        if (result3.Read()) yingyu.Text = result3[0].ToString();
        result3.Close();
        string str4 = "select count(*) from chengji";
        cmd.CommandText = str4;
        SqlDataReader result4 = cmd.ExecuteReader();
        if (result4.Read()) count.Text = result4[0].ToString();
        result4.Close();
        double sum = (Convert.ToDouble(yuwen.Text) + Convert.ToDouble(shuxue.Text) + Convert.ToDouble(yingyu.Text)) / 3;
        all.Text = sum.ToString();
        db.CloseDataBase();



    }
}