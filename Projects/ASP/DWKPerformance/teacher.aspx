<%@ Page Language="C#" AutoEventWireup="true" CodeFile="teacher.aspx.cs" Inherits="teacher" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<style type="text/css">
  
   
        .style3
        {
            width: 357px;
        }
 
    .style4
    {
        width: 58px;
    }
 
</style>

    <title></title>
    <script type="text/javascript">
        function switchSysBar() {
      
            var item1 = document.getElementById("frmTitle");
         
            if (item1.style.display == 'none') 
                 item1.style.display = 'block';
            else item1.style.display = 'none';


        }
      
         

    </script>

  

</head>
<body style=" margin:0; padding:0; background-image:url(images/teacher/menu.jpg);" >
    <form id="form1" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%"  style=" height:100%;">
        <tr>
            <td width="100%" height="50" colspan="3" style="   border-bottom: 1px solid #000000" >
           
                <table style=" height:50px;" border="0" cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td style="background-image: url(images/teacher/top_left.jpg); background-repeat: no-repeat;
                            background-position: left top" class="style3">
                            
                          
                            <font size="4" color="#999999" face="Verdana, Arial, Helvetica, sans-serif">&nbsp; &nbsp;
                                &nbsp;&nbsp;成 绩 管 理 系 统</font> <br /><font style=" color:Red; font-size:3;">&nbsp;&nbsp;--->成 绩 管 理 界 面</font> 
                        </td>
                        <td style="background-image: url(images/teacher/top_right.jpg); background-repeat:repeat-x;
                            background-position: right top" >
                            &nbsp;
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
       
        
        <tr style="height:500px;">
            <td id="frmTitle"   align="center" style="border-right:1px solid #000000; " class="style4"
                >
                <iframe name="BoardTitle" style="height: 100%;width:220px;" 
                   scrolling="no" frameborder="0" src="left.aspx"></iframe>
            </td>
            <td   id="float">
                <table border="0" width="11" style="height:100%;  background-color:White;" align="right" cellpadding="0" cellspacing="0" >
                    <tr>
                        <td valign="middle" align="right"  style="width: 13px">
                            <img border="0" src="images/teacher/close.jpg" id="menuimg" alt="隐藏左栏"
                              onclick="switchSysBar()"
                                width="11" />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 100%; ">
                <iframe id="mainFrame" name="mainFrame" style="height: 100%; visibility: inherit;
                    width: 100%; z-index: 1" scrolling="auto" frameborder="0" src="welcome.html">
                </iframe>
            </td>
        </tr>
 
        <tr>
            <td colspan="3" height="20">
                <table border="1" cellpadding="0" cellspacing="0" width="100%" style=" height:20;   text-align:center; background-color:Gray;">
                    <tr>
                        <td colspan="1" height="20">
                            
                            <font size="3" color="blue"> 登陆者：</font><asp:Label ID="name"  
                                            runat="server" Text="Label"></asp:Label></td><td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                        <font size="3" color="blue">名称：C#课程设计</font>&nbsp;</td>
                                            
                                            
                                          </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
    

</html>
