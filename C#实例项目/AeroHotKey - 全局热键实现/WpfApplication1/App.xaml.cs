using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Runtime.InteropServices;

namespace WpfApplication1
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {

      
        #region
        //private struct KBDLLHOOKSTRUCT
        //{
        //    public int vkCode;
        //    int scanCode;
        //    public int flags;
        //    int time;
        //    int dwExtraInfo;
        //}

        //private delegate int LowLevelKeyboardProcDelegate(int nCode, int wParam, ref KBDLLHOOKSTRUCT lParam);

        //[DllImport("user32.dll")]
        //private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProcDelegate lpfn, IntPtr hMod, int dwThreadId);

        //[DllImport("user32.dll")]
        //private static extern bool UnhookWindowsHookEx(IntPtr hHook);

        //[DllImport("user32.dll")]
        //private static extern int CallNextHookEx(int hHook, int nCode, int wParam, ref KBDLLHOOKSTRUCT lParam);

        //[DllImport("kernel32.dll")]
        //private static extern IntPtr GetModuleHandle(IntPtr path);

        //private IntPtr hHook;
        //LowLevelKeyboardProcDelegate hookProc; // prevent gc
        //const int WH_KEYBOARD_LL = 13;

        //public App()
        //{
        //    // hook keyboard
        //    IntPtr hModule = GetModuleHandle(IntPtr.Zero);
        //    hookProc = new LowLevelKeyboardProcDelegate(LowLevelKeyboardProc);
        //    hHook = SetWindowsHookEx(WH_KEYBOARD_LL, hookProc, hModule, 0);
        //    if (hHook == IntPtr.Zero)
        //    {
        //        MessageBox.Show("Failed to set hook, error = " + Marshal.GetLastWin32Error());
        //    }
        //}

        //protected override void OnExit(ExitEventArgs e)
        //{
        //    UnhookWindowsHookEx(hHook); // release keyboard hook
        //    base.OnExit(e);
        //}

        //private static int LowLevelKeyboardProc(int nCode, int wParam, ref KBDLLHOOKSTRUCT lParam)
        //{
        //    if (nCode >= 0)
        //        switch (wParam)
        //        {
        //            case 256: // WM_KEYDOWN
        //            case 257: // WM_KEYUP
        //            case 260: // WM_SYSKEYDOWN
        //            case 261: // M_SYSKEYUP
        //                if (
        //                    (lParam.vkCode == 0x09 && lParam.flags == 32) || // Alt+Tab
        //                    (lParam.vkCode == 0x1b && lParam.flags == 32) || // Alt+Esc
        //                    (lParam.vkCode == 0x73 && lParam.flags == 32) || // Alt+F4
        //                    (lParam.vkCode == 0x1b && lParam.flags == 0) || // Ctrl+Esc
        //                    (lParam.vkCode == 0x5b && lParam.flags == 1) || // Left Windows Key 
        //                    (lParam.vkCode == 0x5c && lParam.flags == 1))    // Right Windows Key 
        //                {
        //                    return 1;
        //                }
        //                break;
        //        }
        //    return CallNextHookEx(0, nCode, wParam, ref lParam);
        //}
        #endregion
    }
}
