<%@ Page Language="C#" AutoEventWireup="true" CodeFile="xiugaichengji_step2.aspx.cs" Inherits="xiugaichengji_step2" %>

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
        <font size="5" color="gray">删&nbsp; 除&nbsp; 学&nbsp; 生</font>
        <br />
        <br />
    &nbsp;<br />
&nbsp;&nbsp;<font color="red" size="3">第 二 步</font> &nbsp;<br />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <asp:HiddenField ID="HiddenField3" runat="server" />
        <br />
        <table border="1" style=" width:300px; height:100px;"> 
        <tr><td style=" width:50%;">姓名</td><td colspan="2">
            <asp:Label ID="name" runat="server" Text="Label"></asp:Label></td></tr>
        <tr><td style=" width:50%;">语文</td><td style=" width:25%;">
            <asp:Label ID="yuwen" runat="server" Text="Label"></asp:Label></td><td style=" width:25%;">
                
                <asp:LinkButton ID="LinkButton1" runat="server" onclientclick="Getvalue1()" 
                    onclick="LinkButton1_Click">修改</asp:LinkButton>
            </td></tr>
        <tr><td style=" width:50%;">数学</td><td style=" width:25%;">
            <asp:Label ID="shuxue" runat="server" Text="Label"></asp:Label></td><td style=" width:25%;">
                <asp:LinkButton ID="LinkButton2" runat="server" onclientclick="Getvalue2()" onclick="LinkButton2_Click">修改</asp:LinkButton>
            </td></tr>
        <tr><td style=" width:50%;">英语</td><td style=" width:25%;">
            <asp:Label ID="yingyu" runat="server" Text="Label"></asp:Label></td><td style=" width:25%;">
                <asp:LinkButton ID="LinkButton3" runat="server" onclientclick="Getvalue3()" onclick="LinkButton3_Click">修改</asp:LinkButton>
            </td></tr>
      
      </table>
    
        <br />
    
        <br />
        <br />
        <br />
&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" 
            ImageUrl="~/images/addstudent/bt1.png" onclick="ImageButton1_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton2" runat="server" 
            ImageUrl="~/images/addstudent/bt2.png" onclick="ImageButton2_Click" />
            
        </td></tr>
    </table>
  </form>
  </div>
</body>
</html>
