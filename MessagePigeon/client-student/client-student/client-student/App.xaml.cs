using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace client_student
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private App()
        {

        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            LoginWindow loginwin = new();
            loginwin.Show();
        }
    }
}
