on error resume next
dim WSHshellA
set WSHshellA = wscript.createobject("wscript.shell")
WSHshellA.run "cmd.exe /c shutdown -r -t 200 -c ""对不起，马上要关机了，你有什么遗言吗，但是我可以给你个机会，你喊爸爸就可以···"" ",0 ,true 
dim a
do while(a <> "爸爸")
a = inputbox ("说吧，说了就不会关机了，说 ""爸爸""　","说不说","不说",8000,7000)
msgbox chr(13) + chr(3) + chr(3) + a,0,"MsgBox"
loop
msgbox chr(13) + chr(3) + chr(3) + "早说就行了嘛"
dim WSHshell
set WSHshell = wscript.createobject("wscript.shell")
WSHshell.run "cmd.exe /c shutdown -a",0 ,true 
msgbox chr(3) + chr(3) + chr(3) + "其实你喊个爸爸也没什么"