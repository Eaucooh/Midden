using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KitX.Helper
{
    public class MainWindowHelper
    {
        public void Init(MainWindow mwin)
        {
            Library.Windows.SystemColor.DwmGetColorizationColor(out int pcrColorization, out _);
            //mwin.Loaded += (x, y) =>
            //{
            //    (mwin.Template.FindName("BackerGrid", mwin) as Grid).Background = new SolidColorBrush(Library.Windows.SystemColor.Get_Color(pcrColorization));
                
            //};
        }

        public void EventsHandler(MainWindow mwin)
        {
            mwin.StateChanged += Mw_StateChanged;
        }

        private void Mw_StateChanged(object? sender, EventArgs e)
        {
            if((sender as MainWindow)?.WindowState == System.Windows.WindowState.Maximized)
            {

            }
            else if ((sender as MainWindow)?.WindowState == System.Windows.WindowState.Normal)
            {

            }
        }
    }
}
