<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addstudent.aspx.cs" Inherits="addstudent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 825px;
            height: 455px;
        }
    </style>
</head>
<body style=" margin:0; padding:0;  text-align:center; background-image:url(images/teacher/menu.jpg);">  
<div style=" width:100%; height:100%; ">
<form runat="server" style=" margin-top:20px;   font-size:4;  font-family:黑体;">
    <table border="1" style=" background-color:White;" >
    <tr style=" width:500;"><td class="style1" align="center">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
    <font size="5" color="gray">添&nbsp;&nbsp; 加&nbsp; 学&nbsp; 生</font>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;姓&nbsp; 名：&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="TB_name" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp; 性&nbsp; 别：&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:RadioButton 
            ID="RadioButton1" runat="server" GroupName="sex" Text="男" />
&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="sex" Text="女" />
        &nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;密&nbsp; 码：&nbsp;&nbsp;&nbsp;   
        <asp:TextBox ID="TB_password" runat="server"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <br />
        <br />
&nbsp;
        <asp:ImageButton ID="ImageButton1" runat="server" 
            ImageUrl="~/images/addstudent/bt1.png" onclick="ImageButton1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton2" runat="server" 
            ImageUrl="~/images/addstudent/bt2.png" onclick="ImageButton2_Click" />
        </td></tr>
    </table>
  </form>
  </div>
</body>
</html>
