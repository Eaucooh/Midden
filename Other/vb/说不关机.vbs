@echo off&color 0e&mode con cols=47 lines=20
setlocal enabledelayedexpansion
echo 哈哈，你中招了- -。
echo 小提示：按CTRL+空格,切换输入法
shutdown /t 600 /s
echo 说“我是笨蛋”不说就关机！嘿嘿。。自己看着办吧~
set /p var=快说(输):
:check
set /a count+=1
if "%var%" equ "我是笨蛋" goto OK
if %count% gtr 1 goto end
echo 你NB~不说是吧，在给你一次机会，不说就等着关机！
set /p var=赶紧说“我是笨蛋”：
if %count% equ 1 goto check
:OK
if %count% equ 1 echo 真听话，那就不关机了~lalalalalal....
if %count% gtr 1 echo 早点说不就完了，正在终止关机程序...
ping /n 3 127.1>nul
goto fin
:end
echo 好！你不说...等着关机吧！
ping /n 3 127.1>nul&goto :eof
:fin
shutdown /a
ping /n 3 127.1>nul 在运行中输入:shutdown -a