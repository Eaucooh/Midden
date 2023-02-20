<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chakanchengji.aspx.cs" Inherits="chakanchengji" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 825px;
            height: 455px;
        }
        .style2
        {
            width: 142px;
        }
    </style>
</head>
<body style=" margin:0; padding:0;  text-align:center; background-image:url(images/teacher/menu.jpg);">  
<div style=" width:100%; height:100%; ">
<form id="Form1" runat="server" style=" margin-top:20px;   font-size:4;  font-family:黑体;">
    <table border="1" style=" background-color:White;" >
    <tr style=" width:500;"><td class="style1" align="center">
        <font size="5" color="gray">&nbsp; </font>&nbsp;<br />
        <br />
    &nbsp;<br />
&nbsp;&nbsp;<font color="red" size="4">&nbsp; 你 的 成 绩：</font> &nbsp;<br />
        <br />
        <br />
        <br />
        <br />
        <table border="1" style=" width:600px; height:200px;"> 
        <tr><td style=" width:50%;">姓名</td><td class="style2">
            <asp:Label ID="name" runat="server" Text="Label"></asp:Label></td></tr>
        <tr><td style=" width:50%;">语文</td><td class="style2">
            <asp:Label ID="yuwen" runat="server" Text="Label"></asp:Label></td></tr>
        <tr><td style=" width:50%;">数学</td><td class="style2">
            <asp:Label ID="shuxue" runat="server" Text="Label"></asp:Label></td></tr>
        <tr><td style=" width:50%;">英语</td><td class="style2">
            <asp:Label ID="yingyu" runat="server" Text="Label"></asp:Label></td></tr>
      
      </table>
    
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
        </td></tr>
    </table>
  </form>
  </div>
</body>
</html>
