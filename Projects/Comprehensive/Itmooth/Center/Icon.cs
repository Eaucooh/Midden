using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using ContextMenu = System.Windows.Controls.ContextMenu;
using Label = System.Windows.Controls.Label;
using UI = Panuon.UI.Silver;

namespace Center
{
    class NotiIcon
    {
        public string WorkBase = AppDomain.CurrentDomain.BaseDirectory;
        public NotifyIcon ico = new NotifyIcon();
        private readonly ContextMenu cms = new ContextMenu();

        public void NewIcon(Window mainwin)
        {
            Icon ti = new Icon(WorkBase + @"\Lib\Itmooth_256.ico");
            ico.Icon = ti;
            ico.Visible = true;
            Label Exit = new Label()
            {
                Content = "退出程序"
            };
            Exit.MouseDown += (m, n) =>
            {
                ico.Dispose();
                Environment.Exit(0);
            };
            System.Windows.Application.Current.Deactivated += (s, h) =>
            {
                cms.IsOpen = false;
            };
            cms.Items.Add(Exit);
            ico.MouseDown += (x, y) =>
            {
                if (y.Button == MouseButtons.Right)
                {
                    cms.IsOpen = true;
                    System.Windows.Application.Current.MainWindow.Activate();
                }
                else
                {
                    if (y.Clicks > 1)
                    {
                        if (mainwin.Visibility == Visibility.Visible)
                        {
                            mainwin.Visibility = Visibility.Hidden;
                            UI.Notice.Show("主窗口已最小化", "提示", 1.5, UI.MessageBoxIcon.Info);
                        }
                        else
                        {
                            mainwin.Visibility = Visibility.Visible;
                            UI.Notice.Show("主窗口已最大化", "提示", 1.5, UI.MessageBoxIcon.Info);
                        }
                    }
                }
            };
            System.Windows.Application.Current.Deactivated += (g, b) =>
            {
                if (cms.IsOpen == true)
                {
                    cms.IsOpen = false;
                }
            };
        }
    }
}
