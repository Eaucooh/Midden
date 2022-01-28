set Hone=WScript.CreateObject("WScript.Shell")
Hone.AppActivate "Ëï³¿ÔÆ£¨Ïø´­£©"
do
WScript.sleep 1000
Hone.SendKeys "^v"
Hone.SendKeys "%s"
loop