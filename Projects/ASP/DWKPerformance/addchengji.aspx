<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addchengji.aspx.cs" Inherits="addchengji" %>

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
    </style>
</head>
<body style=" margin:0; padding:0;  text-align:center; background-image:url(images/teacher/menu.jpg);">  
<div style=" width:100%; height:100%; ">
<form id="Form1" runat="server" style=" margin-top:20px;   font-size:4;  font-family:黑体;">
    <table border="1" style=" background-color:White;" >
    <tr style=" width:500;"><td class="style1" align="center">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <font size="5" color="gray">&nbsp;录&nbsp; 入&nbsp; 成&nbsp; 绩 </font>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 姓&nbsp; 名：&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="TB_name" runat="server" Width="120px"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 语&nbsp; 文：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="TB_yuwen" runat="server" Width="60px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RangeValidator ID="RangeValidator1" runat="server"  ControlToValidate="TB_yuwen" MinimumValue="0" MaximumValue="100" Type="Double" Font-Size="15px"
            ErrorMessage="请输入0-100">
            
            </asp:RangeValidator>
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 数&nbsp; 学：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox 
            ID="TB_shuxue" runat="server" Width="60px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:RangeValidator ID="RangeValidator2" runat="server"  ControlToValidate="TB_shuxue" MinimumValue="0" MaximumValue="100" Type="Double" Font-Size="15px"
            ErrorMessage="请输入0-100"></asp:RangeValidator>
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 英&nbsp; 语：&nbsp; 
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   
        <asp:TextBox ID="TB_yingyu" runat="server" Width="60px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RangeValidator ID="RangeValidator3" runat="server" MinimumValue="0" MaximumValue="100" Type="Double" Font-Size="15px" ControlToValidate="TB_yingyu"
            ErrorMessage="请输入0-100"></asp:RangeValidator>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton1" runat="server" 
            ImageUrl="~/images/addstudent/bt1.png" onclick="ImageButton1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton2" runat="server" 
            ImageUrl="~/images/addstudent/bt2.png" onclick="ImageButton2_Click" />
        </td></tr>
    </table>
  </form>
  </div>
</body>
</html>
