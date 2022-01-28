set Hone=WScript.CreateObject("WScript.Shell")
Hone.AppActivate "封号战神"
for i=1 to 100
WScript.sleep 1
Hone.SendKeys "^v"
Hone.SendKeys "%s"
Next
Msgbox"轰炸完毕!",7,"报告"
