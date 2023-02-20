<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>登陆页面</title>
<link  type="text/css" href="css/login.css" rel="Stylesheet" />
<script  type="text/javascript">
    
</script>
   
</head>
<body>
<div>
<div class="top"></div>
<div class="mid">
<table class="login"><tr><td colspan="3" class="style1" ></td></tr>
<tr><td class="style2"></td><td>
<form runat="server">
<table class="login_box">
<tr><td class="style4"><span>用户名：</span></td> <td> <asp:TextBox ID="usersname" 
        runat="server" Width="100px"></asp:TextBox>
      </td></tr>
<tr><td class="style5" ><span>密&nbsp;&nbsp;  码：</span></td><td class="style6">
      <asp:TextBox runat="server" TextMode="Password" Width="100px" ID="password"></asp:TextBox> </td></tr>
<tr><td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp; 
    <asp:ImageButton ID="bt_login" runat="server" 
        ImageUrl="~/images/login/button1.jpg" Height="25px" Width="70px" 
        onclick="bt_login_Click" />
    <asp:ImageButton ID="bt_clear" ImageUrl="~/images/login/button2.jpg" Height="25px"  
        Width="70px"  runat="server" onclick="bt_clear_Click" />
    </td></tr> 
</table>
</form>
    
</td><td class="style3"></td></tr>
    
<tr><td class="foot" colspan="3"><p>--成 绩 管 理 系 统--<br /> 版 权 所 有 ：X X X</p></td></tr>
</table>  
</div>

</div>
</body>
</html>
