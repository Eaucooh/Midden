<%@ Page Language="C#" AutoEventWireup="true" CodeFile="paiming.aspx.cs" Inherits="paiming" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
 
    <style type="text/css">
        .style1
        {
            height: 443px;
            width: 515px;
        }
    </style>
 
</head>
<body style=" margin:0; padding:0;   background-image:url(images/teacher/menu.jpg);">  
<div style=" width:100%; height:100%; text-align:center; ">
<form id="Form1" runat="server" style=" margin-top:20px;   font-size:4;  font-family:黑体;">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <table border="1" style=" background-color:White;" >
    <tr ><td  class="style1">
        <font size="5" color="red">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 学生排名<br />
        </font>&nbsp;<asp:GridView ID="GridView1" runat="server"
            EnableModelValidation="True" 
            style="margin-left: 0px; margin-top: 0px" Width="753px" AllowPaging="True" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
            onrowdatabound="GridView1_RowDataBound" onpageindexchanging="GridView1_PageIndexChanging"  
           >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField HeaderText="姓  名" DataField="name"  >
                <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="zf" HeaderText="总  分" />
                <asp:BoundField HeaderText="名  次" DataField="mc" >
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerSettings FirstPageText="首页" LastPageText="末页" NextPageText="下一页" 
                PreviousPageText="上一页" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>

    
        </td></tr>
    </table>
  </form>
  </div>
</body>
</html>
