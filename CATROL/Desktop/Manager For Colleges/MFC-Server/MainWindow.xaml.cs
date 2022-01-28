using HandyControl.Data;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MFC_Server
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Animations anis;
        WindowState latestState;
        Views.Home home = new Views.Home();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            StateChanged += MainWindow_StateChanged;

            LogIn();
        }

        private void LogIn()
        {
            Frame.Content = home;
            home.ParentWindow = this;
        }

        private void MainWindow_StateChanged(object sender, EventArgs e)
        {
            switch (latestState)
            {
                case WindowState.Normal:
                    break;
                case WindowState.Minimized:
                    anis.Dispose();
                    anis = new Animations();
                    anis.FadeIn.Completed += (x, y) =>
                    {
                        WindowState = WindowState.Normal;
                        anis.Dispose();
                    };
                    BeginAnimation(OpacityProperty, anis.FadeIn);
                    break;
                case WindowState.Maximized:
                    break;
            }
            latestState = WindowState;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            anis = new Animations();
            BeginAnimation(OpacityProperty, anis.FadeIn);
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
            if (e.ClickCount == 2)
            {
                WindowState = WindowState.Normal;
            }
        }

        private void ToggleButton_WinStater_Checked(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        private void ToggleButton_WinStater_Unchecked(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Normal;
        }

        private void Window_Minimize()
        {
            anis.Dispose();
            anis = new Animations();
            anis.FadeOut.Completed += (x, y) =>
            {
                WindowState = WindowState.Minimized;
                anis.Dispose();
                Opacity = 1;
            };
            BeginAnimation(OpacityProperty, anis.FadeOut);
        }

        private void Window_Close()
        {
            anis.Dispose();
            anis = new Animations();
            anis.FadeOut.Completed += (x, y) =>
            {
                Close();
            };
            BeginAnimation(OpacityProperty, anis.FadeOut);
        }

        private void Window_Hide()
        {
            if (int.TryParse(ConfigurationManager.AppSettings["IsCloserToClose"].ToString(), out int result))
            {
                switch (result)
                {
                    case 0:
                        Window_Minimize();
                        break;
                    case 1:
                        Window_Close();
                        break;
                }
            }
        }

        private void Button_HideWin_Click(object sender, RoutedEventArgs e)
        {
            Window_Minimize();
        }

        private void Button_CloseWin_Click(object sender, RoutedEventArgs e)
        {
            Window_Hide();
        }

        private void ToggleButton_Theme_Click(object sender, RoutedEventArgs e)
        {
            ModifyTheme(theme => theme.SetBaseTheme((bool)ToggleButton_Theme.IsChecked ? Theme.Dark : Theme.Light));
        }

        private static void ModifyTheme(Action<ITheme> modificationAction)
        {
            PaletteHelper paletteHelper = new PaletteHelper();
            ITheme theme = paletteHelper.GetTheme();
            modificationAction?.Invoke(theme);
            paletteHelper.SetTheme(theme);
        }

        public void ShowMessage(Models.EnumHelper.GrowlType growlType, GrowlInfo growlInfo)
        {
            switch (growlType)
            {
                case Models.EnumHelper.GrowlType.Ask:
                    HandyControl.Controls.Growl.Ask(growlInfo);
                    break;
                case Models.EnumHelper.GrowlType.Error:
                    HandyControl.Controls.Growl.Error(growlInfo);
                    break;
                case Models.EnumHelper.GrowlType.Fatal:
                    HandyControl.Controls.Growl.Fatal(growlInfo);
                    break;
                case Models.EnumHelper.GrowlType.Info:
                    HandyControl.Controls.Growl.Info(growlInfo);
                    break;
                case Models.EnumHelper.GrowlType.Success:
                    HandyControl.Controls.Growl.Success(growlInfo);
                    break;
                case Models.EnumHelper.GrowlType.Warning:
                    HandyControl.Controls.Growl.Warning(growlInfo);
                    break;
            }
        }

        private void Account_Exit(object sender, RoutedEventArgs e)
        {
            home = new Views.Home();
            LogIn();
        }
    }
}
