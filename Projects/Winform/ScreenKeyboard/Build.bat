Path="%systemroot%\Microsoft.NET\Framework\v3.5";
if exist Bin del /S /Q Bin
MSBuild ScreenKeyboard.sln /t:Rebuild /p:Configuration=Release