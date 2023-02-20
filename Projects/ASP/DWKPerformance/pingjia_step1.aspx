<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pingjia_step1.aspx.cs" Inherits="pingjia" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<<head id="Head1" runat="server">
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
<form id="Form1" runat="server" style=" margin-top:20px;   font-size:4;  font-family:黑体;">
    <table border="1" style=" background-color:White;" >
    <tr style=" width:500;"><td class="style1" align="center">
    &nbsp;<font size="5" color="gray">教&nbsp; 师&nbsp; 评&nbsp; 价</font>
        <br />
        <br />
    &nbsp;<br />
&nbsp;&nbsp;<font color="red" size="3">第 一 步</font> &nbsp;<br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        <br />
        请输入学生姓名：&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="TB_name" runat="server"></asp:TextBox>
      
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton1" runat="server" 
            ImageUrl="~/images/deletestudent/serach.png" onclick="ImageButton1_Click" />
      
    
        </td></tr>
    </table>
  </form>
  </div>
</body>
</html>
