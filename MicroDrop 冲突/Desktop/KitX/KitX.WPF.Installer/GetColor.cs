using System.Runtime.InteropServices;

namespace KitX.WPF.Installer
{
    public class GetSysColor
    {
        // See "https://docs.microsoft.com/en-us/windows/win32/api/dwmapi/nf-dwmapi-dwmgetcolorizationcolor"
        [DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern void DwmGetColorizationColor(out int pcrColorization, out bool pfOpaqueBlend);

        public static System.Drawing.Color GetColor(int argb) => System.Drawing.Color.FromArgb(argb);

        public static System.Windows.Media.Color Get_Color(int argb) => new System.Windows.Media.Color()
        {
            A = (byte)(argb >> 24),
            R = (byte)(argb >> 16),
            G = (byte)(argb >> 8),
            B = (byte)(argb)
        };
    }
}
