<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pingjunchengji.aspx.cs" Inherits="pingjunchengji" %>

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
            width: 50%;
            height: 22px;
        }
        .style3
        {
            height: 22px;
        }
        </style>
    <script type="text/javascript">


        function Getvalue1() {
            var value = prompt("输入修改的成绩(0-100)", "0");
            if (value == null)
                return false;
            else {
                if (value >= 0 && value <= 100)
                    document.getElementById("HiddenField1").value = value;
                else
                    alert("输入范围为：0-100");
            }
        }
        function Getvalue2() {
            var value = prompt("输入修改的成绩(0-100)", "0");
            if (value == null)
                return false;
            else {
                if (value >= 0 && value <= 100)
                    document.getElementById("HiddenField2").value = value;
                else
                    alert("输入范围为：0-100");

            }

        }
        function Getvalue3() {
            var value = prompt("输入修改的成绩(0-100)", "0");
            if (value == null)
                return false;
            else {
                if (value >= 0 && value <= 100)
                    document.getElementById("HiddenField3").value = value;
                else
                    alert("输入范围为：0-100");
            }
        }
      
    </script>
</head>
<body style=" margin:0; padding:0;  text-align:center; background-image:url(images/teacher/menu.jpg);">  
<div style=" width:100%; height:100%; ">
<form id="Form1" runat="server" style=" margin-top:20px;   font-size:4;  font-family:黑体;">
    <table border="1" style=" background-color:White;" >
    <tr style=" width:500;"><td class="style1" align="center">
        <font size="5" color="gray">平&nbsp; 均&nbsp; 成&nbsp; 绩</font>
        <br />
        <br />
    &nbsp;<br />
&nbsp;&nbsp; &nbsp;<br />
        <br />
        <table border="1" style=" width:450px; height:150px;"> 
        <tr><td class="style2" bgcolor="#CC3300">统计人数</td><td class="style3" 
                bgcolor="#CC3300">
            <asp:Label ID="count" runat="server" Text="Label"></asp:Label></td>
                </tr>
      
        <tr><td style=" width:50%;">科&nbsp;&nbsp;&nbsp; 目</td><td colspan="2">
            平均成绩</td></tr>
        <tr><td class="style2">语&nbsp;&nbsp;&nbsp; 文</td><td class="style3">
            <asp:Label ID="yuwen" runat="server" Text="Label"></asp:Label></td>
                
           </tr>
        <tr><td class="style2">数&nbsp;&nbsp;&nbsp; 学</td><td class="style3">
            <asp:Label ID="shuxue" runat="server" Text="Label"></asp:Label></td>
               </tr>
        <tr><td style=" width:50%;">英&nbsp;&nbsp;&nbsp; 语</td><td>
            <asp:Label ID="yingyu" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr><td class="style2">所有科目</td><td class="style3">
            <asp:Label ID="all" runat="server" Text="Label"></asp:Label></td>
                </tr>
      
      </table>
    
        <br />
    
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                    
        </td></tr>
    </table>
  </form>
  </div>
</body>
</html>
