<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left.aspx.cs" Inherits="left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
     
        
        if (item1.className == "style1")
         {
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
<li  ><a href="#" onclick="onclick1()" style=" background-image:url(images/teacher/1.jpg);" >&nbsp;</a><!--学生信息管理-->
<ul id="meun1" class="style1">
<li><a href="addstudent.aspx" target="mainFrame" style=" background-image:url(images/teacher/1-1.jpg);">&nbsp;</a></li><!--添加学生-->
<li><a href="deletestudent_step1.aspx" target="mainFrame" style=" background-image:url(images/teacher/1-2.jpg);">&nbsp;</a></li><!--删除学生-->
<li><a href="lookallstudent.aspx" target="mainFrame" style=" background-image:url(images/teacher/1-3.jpg);">&nbsp;</a></li><!--查看所有学生-->
<li><a href="pingjia_step1.aspx" target="mainFrame" style=" background-image:url(images/teacher/1-4.jpg);">&nbsp;</a></li><!--评价-->
</ul>
</li>
<li ><a href="#" onclick="onclick2()" style=" background-image:url(images/teacher/2.jpg);">&nbsp;</a><!--学生成绩管理-->
<ul id="meun2" class="style1">
<li><a href="addchengji.aspx" target="mainFrame" style=" background-image:url(images/teacher/2-1.jpg);">&nbsp;</a></li><!--录入成绩-->
<li><a href="xiugaichengji_step1.aspx" target="mainFrame" style=" background-image:url(images/teacher/2-2.jpg);">&nbsp;</a></li><!--修改成绩-->

</ul>
</li>
<li ><a href="#" onclick="onclick3()"  style=" background-image:url(images/teacher/3.jpg);">&nbsp;</a><!--学生成绩统计-->
<ul id="meun3" class="style1" >
<li><a href="pingjunchengji.aspx" target="mainFrame" style=" background-image:url(images/teacher/3-1.jpg);">&nbsp;</a></li><!--各科平均成绩-->
<li><a href="paiming.aspx" target="mainFrame" style=" background-image:url(images/teacher/3-2.jpg);">&nbsp;</a></li><!--排名-->
</ul>
</li>
<li ><a href="#" onclick="window.parent.location ='http://localhost:17077/WebSite2/login.aspx'" style=" background-image:url(images/teacher/4.jpg);">&nbsp;</a></li><!--退出-->
</ul>
</div>
</body>
</html>
