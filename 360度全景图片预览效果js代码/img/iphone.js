
/* --- 全景信息描述 --------------------------------------- 
显示在网页标题和全景信息窗里的描述信息，可自行设计内容和样式，和普通网页一样。
*/


vrTitle = '';
vrDescription = ""; 
/*
全景图地址，预览图使用横向或纵向条形图，全景图支持两种模式：立方体6张图，立方体条形图；
*/
preview = "img/cube/4/preview.jpg";
/*6张图*/
panoType = "cube";
cube_f = "img/cube/4/iphone_f.jpg";
cube_r = "img/cube/4/iphone_r.jpg";
cube_b = "img/cube/4/iphone_b.jpg";
cube_l = "img/cube/4/iphone_l.jpg";
cube_u = "img/cube/4/iphone_u.jpg";
cube_d = "img/cube/4/iphone_d.jpg";
/*条形图*/
//panoType = "cubestrip";
//cubestrip = "pano0.jpg";

/* --- 初始化设置：atartPan:初始横向角度，startTilt：初始纵向角度，startFov:初始视角 ------------------------------------ */
startPan = 0; 			/* 从左到右：-180 - 0 - 180 */
startTilt = 0; 			/* 从下到上：-90 - 0 - 90 */
startFov = 70; 			/* 视角：30 - 130 */
fovMax = 130;			/*最大视角*/
fovMin = 30;			/*最小视角*/

/* --- 视角限制 ------------------------------ */
useLimits = false;
topLimit = 60;  		/* 0 - 90 */
bottomLimit = -60;		/* 0 - -90 */
leftLimit = -120; 		/* 0 - -180 */
rightLimit = 120; 		/* 0 - 180*/

/* --- 控制面板 ----------------------------------*/

useControl = "";
autoRotateOnStart = false; 
autoRotateOnIdle = false; 
autoRotateDelay = 5; /* 秒 */ 
/* -------------------------------------------------- */

	
/* --- 背景声音 ----------------------------- 
背景声音,同audio标签属性 */

//bgSound = "src='sound.mp3' autobuffer autoplay loop";

