@echo off
for /L %%a in (
 10,-1,0
) do (
 echo 10秒后将运行QuickSetup.exe
 echo 还剩余 %%a 秒
 ping -n 2 localhost 1>nul 2>nul
 cls
)
start QuickSetup.exe
PAUSE