<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left_student.aspx.cs" Inherits="left_student" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

<style type="text/css">
    body
{
	font-size:20px;
        width: 200px;
        height:auto;
    }
	a{
		width:200px;
		display:block;
		color:#000;
		text-align:center;
		 text-decoration:none;
		}
		a:hover{
			 color:#CF0;
			 background:#C90;
			  }
#meun
{
	list-style-type:none;
	line-height:50px;
	  margin-left:0;
	
	}
	#meun li
	{
		width:200px;
		
		background:#900;
		margin-top:1px;
		

		}
	
			#meun li ul li
			{
				
				background:#999;
				
				}
			#meun li ul.style1
				{
			list-style-type:none;
			width:200px;
			   margin-left:0; /*IE8*/
		     position:absolute;
		     top:-1000px;
				    }
				    
				#meun li ul.style2
				    {	        	    
			list-style-type:none;
			width:200px;
			   margin-left:0;  /*IE8*/
		     position:static;
				        }
</style>
<script type="text/javascript">
    function onclick1() {
        var item1 = document.getElementById("meun1");
        var item2 = document.getElementById("meun2");
        var item3 = document.getElementById("meun3");


        if (item1.className == "style1") {
            item1.className = "style2";
            item2.className = "style1";
            item3.className = "style1";

        }
        else item1.className = "style1";

    }
    function onclick2() {

        var item1 = document.getElementById("meun1");
        var item2 = document.getElementById("meun2");
        var item3 = document.getElementById("meun3");

        if (item2.className == "style1") {
            item2.className = "style2";
            item1.className = "style1";
            item3.className = "style1";

        }
        else item2.className = "style1";

    }

    function onclick3() {
        var item1 = document.getElementById("meun1");
        var item2 = document.getElementById("meun2");
        var item3 = document.getElementById("meun3");

        if (item3.className == "style1") {
            item3.className = "style2";
            item2.className = "style1";
            item1.className = "style1";

        }
        else item3.className = "style1";
    }
    function close() {
        window.top.close();
    }
   
</script>
</head>

<body>
<div style=" height:500px; width:200px; background-image:url(images/teacher/menu.jpg);">
<ul id="meun">
<li  ><a href="chakanchengji.aspx"  target="mainFrame" style=" background-image:url(images/student/1.jpg);" >&nbsp;</a><!--查看成绩--></li>
<li  ><a href="jiyu.aspx"  target="mainFrame" style=" background-image:url(images/student/2.jpg);" >&nbsp;</a><!--老师寄语--></li>

<li ><a href="#" onclick="window.parent.location ='http://localhost:17077/WebSite2/login.aspx'" style=" background-image:url(images/teacher/4.jpg);">&nbsp;</a></li><!--退出-->
</ul>
</div>
</body>
</html>
