using System.ComponentModel;
using System.Linq;
using System.Windows;
using MahApps.Metro;
using netwatch.Gadget;

namespace netwatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public static MainWindow Instance;

        private bool _isQuickModeEnable = true;
        private double _prevDetailedSizeHeight = 480;
        private double _prevDetailedSizeWidth = 720;
        private double _prevWinSizeHeight;
        private double _prevWinSizeWidth;

        public MainWindow()
        {
            Instance = this;
            InitializeComponent();
            ThemeManager.ChangeTheme(this, ThemeManager.DefaultAccents.First(a => a.Name == "Netw"), Theme.Light);
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            quickViewModeGadget.Start();
            _prevWinSizeWidth = Width;
            _prevWinSizeHeight = Height;
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            if (_isQuickModeEnable)
            {
                quickViewModeGadget.KillSelectedTask();
                ChangeVisibilityOfEndTaskBtn(Visibility.Visible);
            }
            else
            {
                detailedViewModelGadget.KillSelectedTask();
            }
        }

        private void ExpanMoreLessInfoExpanded(object sender, RoutedEventArgs e)
        {
            expan_MoreLessInfo.Header = "Fewer details";
            _prevWinSizeWidth = Width;
            _prevWinSizeHeight = Height;

            Height = _prevDetailedSizeHeight;
            Width = _prevDetailedSizeWidth;

            detailedViewModelGadget.Visibility = Visibility.Visible;
            quickViewModeGadget.Visibility = Visibility.Hidden;
            quickViewModeGadget.Stop();
            detailedViewModelGadget.Start();
            _isQuickModeEnable = false;
        }

        private void ExpanMoreLessInfoCollapsed(object sender, RoutedEventArgs e)
        {
            expan_MoreLessInfo.Header = "More details";

            _prevDetailedSizeWidth = Width;
            _prevDetailedSizeHeight = Height;

            Width = _prevWinSizeWidth;
            Height = _prevWinSizeHeight;

            detailedViewModelGadget.Visibility = Visibility.Hidden;
            quickViewModeGadget.Visibility = Visibility.Visible;
            quickViewModeGadget.Start();
            detailedViewModelGadget.Stop();
            _isQuickModeEnable = true;

            btnEndTask.Visibility = Visibility.Visible;
        }

        private void WindowClosing(object sender, CancelEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void ToolTipToolTipOpening(object sender, RoutedEventArgs e)
        {
            //TooltipTextBlock.Text = GenerateTooltip();
        }

        private void TaskbarIconTrayMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            ShowHideApplication();
        }

        private void MnuItemExitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(0);
        }

        private void MnuItemShowNetWatcherClick(object sender, RoutedEventArgs e)
        {
            ShowHideApplication();
        }

        private void ShowHideApplication()
        {
            Show();
            Focus();
        }

        private void MnuAddDesktopGadgetClick(object sender, RoutedEventArgs e)
        {
            var dialog = new SelectAdaptorDialog();
            dialog.ShowDialog();
        }


        private void SwitchTheme(Theme color)
        {
            if (color == Theme.Dark)
            {
                ThemeManager.ChangeTheme(this, ThemeManager.DefaultAccents.First(a => a.Name == "Netw"), Theme.Dark);
                quickViewModeGadget.SwitchTheme(color);
                detailedViewModelGadget.SwitchTheme(color);
            }
            else if (color == Theme.Light)
            {
                ThemeManager.ChangeTheme(this, ThemeManager.DefaultAccents.First(a => a.Name == "Netw"), Theme.Light);
                quickViewModeGadget.SwitchTheme(color);
                detailedViewModelGadget.SwitchTheme(color);
            }
        }

        private void BtnSettingsClick(object sender, RoutedEventArgs e)
        {
            if (BtnSwitchColors.Content.ToString() == "Dark")
            {
                SwitchTheme(Theme.Dark);
                BtnSwitchColors.Content = "Light";
            }
            else
            {
                SwitchTheme(Theme.Light);
                BtnSwitchColors.Content = "Dark";
            }
        }

        public void ChangeVisibilityOfEndTaskBtn(Visibility value)
        {
            btnEndTask.Visibility = value;
        }
    }
}