using System;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

namespace CnBlogs.Youzai.ScreenKeyboard {
    internal static class Program {
        [STAThread]
        private static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ScreenKeyboard());
        }
    }
}
