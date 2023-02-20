<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pingjia_step2.aspx.cs" Inherits="pingjia_step2" %>

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
    <tr style=" width:500;"><td class="style1" align="center" >
        <br />
        <br />
&nbsp;<font size="5" color="gray">&nbsp;教&nbsp; 师&nbsp; 评&nbsp; 价 </font>&nbsp;<br />
        <br />
        <br />
        <font size="4" color="red">第 二 步</font><br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        请在下面写出对 <asp:Label ID="name" runat="server" Text="Label" ForeColor="#FF3300"></asp:Label>
        同学的评价：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;<asp:TextBox 
            ID="TextBox1" runat="server" Height="200px" Rows="10" style="margin-left: 0px" 
            TextMode="MultiLine" Width="300px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <br />
        <br />
        <br />
        <asp:ImageButton ID="ImageButton1" runat="server" 
            ImageUrl="~/images/addstudent/bt1.png" onclick="ImageButton1_Click" 
            Height="26px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:ImageButton ID="ImageButton2" runat="server" 
            ImageUrl="~/images/addstudent/bt2.png" onclick="ImageButton2_Click" />
        <br />
        <br />
        </td></tr>
    </table>
  </form>
  </div>
</body>
</html>
