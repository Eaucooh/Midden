using System;

namespace Center
{
    public class Win32Native
    {
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetParent")]
        public extern static IntPtr SetParent(IntPtr childPtr, IntPtr parentPtr);
    }
}