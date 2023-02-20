On Error Resume Next
strComputer = "."
arrTargetProcs = Array("QQBrowser.exe")
Set SINK = WScript.CreateObject("WbemScripting.SWbemSink","SINK_")
Set objWMIService = GetObject("winmgmts:" & _
 "{impersonationLevel=impersonate}!\\" & strComputer & "\root\cimv2")
objWMIService.ExecNotificationQueryAsync SINK, _
 "SELECT * FROM __InstanceCreationEvent WITHIN 1 " & _
  "WHERE TargetInstance ISA 'Win32_Process'"
Wscript.Echo "Are monitoring processes ..."
Do
 WScript.Sleep 1000
Loop
Sub SINK_OnObjectReady(objLatestEvent, objAsyncContext)
'Trap asynchronous events.
 For Each strTargetProc In arrTargetProcs
  If LCase(objLatestEvent.TargetInstance.Name) = LCase(strTargetProc) Then
   intReturn = objLatestEvent.TargetInstance.Terminate
   If intReturn = 0 Then
    Wscript.Echo "Time: " & Now & ", Succeed!" & chr(9) & _
     "Name: " & objLatestEvent.TargetInstance.Name
    Else
    Wscript.Echo "Time: " & Now & ", Failed!" & chr(9) & _
     "Name: " & objLatestEvent.TargetInstance.Name
   End If
  End If
 Next
End Sub