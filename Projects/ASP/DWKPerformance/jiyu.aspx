<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jiyu.aspx.cs" Inherits="jiyu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 825px;
            height: 460px;
        }
    </style>
</head>
<body style=" margin:0; padding:0;  text-align:center; background-image:url(images/teacher/menu.jpg);">  
<div style=" width:100%; height:100%; ">
<form id="Form1" runat="server" style=" margin-top:20px;   font-size:4;  font-family:黑体;">
    <table border="1" style=" background-color:White;" >
    <tr style=" width:500;"><td class="style1" align="center" colspan="1" >
        <br />
        <br />
&nbsp;<font size="5" color="gray">&nbsp;教&nbsp; 师&nbsp; 寄&nbsp; 语 </font>&nbsp;<br />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<br />
        <font color="red">老师对你的评价：</font>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;<asp:TextBox 
            ID="TextBox1" runat="server" Height="200px" Rows="10" style="margin-left: 0px" 
            TextMode="MultiLine" Width="300px" BorderStyle="Dotted" Columns="20"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <br />
        <br />
        </td></tr>
    </table>
  </form>
  </div>
</body>
</html>
