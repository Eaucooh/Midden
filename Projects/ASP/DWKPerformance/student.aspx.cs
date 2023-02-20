using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class student : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        name.Text = Session["DLZ1"].ToString() + "(学生)";
    }
}