Msgbox("闹钟开始计时")
Wscript.sleep 600000
a=0
do while a=0
CreateObject("SAPI.SpVoice").Speak"啦啦啦起床啦！"
CreateObject("SAPI.SpVoice").Speak"啦啦啦起床啦！"
CreateObject("SAPI.SpVoice").Speak"啦啦啦起床啦！"
CreateObject("SAPI.SpVoice").Speak"六点半啦再不起床就迟到了"
loop