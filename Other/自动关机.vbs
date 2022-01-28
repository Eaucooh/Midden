WScript.Echo("系统文件缺失，20秒后即将关机！！！")
WScript.Echo("请按确认键确认进程")
set ws=CreateObject("Wscript.Shell")
ws.run "cmd.exe /c shutdown -r -t 20 -c ""关机成功"" ",0 ,true