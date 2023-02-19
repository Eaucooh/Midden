using System;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Xml;

namespace JDK_Version_Manager
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string WorkBase = AppDomain.CurrentDomain.BaseDirectory;
        private string StoreBase;
        private string LogFile = AppDomain.CurrentDomain.BaseDirectory + "\\Info\\Log.txt";
        private string SelectedVersion;
        private string LatestVersion;
        readonly BasicHelper animation = new BasicHelper();
        readonly ape_System.Environment environment = new ape_System.Environment();
        readonly ape_System.Files files = new ape_System.Files();
        readonly ape_System.Log log = new ape_System.Log();
        readonly XmlDocument editions = new XmlDocument();
        readonly Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        DoubleAnimation Fade_In;
        DoubleAnimation Fade_Out;

        public MainWindow()
        {
            log.Log_Append(LogFile, "APP started!");
            InitializeComponent();
            LoadEditions();
            LoadAnimation();
            LoadComponents();
            LoadInfo();
            Win_Exchange(Wins.Selecting_Before);
        }

        private void Refresh()
        {
            LoadEditions();
            LoadInfo();
            log.Log_Append(LogFile, "Interface refreshed!");
        }

        private void LoadInfo()
        {
            StoreBase = ConfigurationManager.AppSettings["StoreFolder"].ToString();
            log.Log_Append(LogFile, "LoadInfo()!");
        }

        delegate void MyDelegate();
        delegate void ClearDir();

        private void LoadComponents()
        {
            GoHomer.Click += (x, y) =>
              {
                  Win_Exchange(Wins.Selecting_Before);
              };
            Enabler.Click += Enabler_Click;
            Unabler.Click += Unabler_Click;
            Installer.Click += Installer_Click;
            Installer_Re.Click += Installer_Click;
            Installer_Un.Click += Installer_Un_Click;
            log.Log_Append(LogFile, "LoadComponents()!");
        }

        private void Unabler_Click(object sender, RoutedEventArgs e)
        {
            XmlNode root = editions.DocumentElement;

            LatestVersion = ConfigurationManager.AppSettings["LatestVersion"];
            if (!LatestVersion.Equals("Null"))
            {
                foreach (XmlNode item in root.ChildNodes)
                {
                    if (item.Attributes["Version"].Value.Equals(LatestVersion))
                    {
                        foreach (XmlNode EV in item.ChildNodes)
                        {
                            if (EV.Name.Equals("EV"))
                            {
                                environment.SetSysEnvironment(EV.Attributes["Name"].Value, "");
                            }
                        }
                    }
                }
            }
        }

        private void Enabler_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists($"{StoreBase}\\JDK {SelectedVersion}\\"))
            {
                XmlNode root = editions.DocumentElement;

                LatestVersion = ConfigurationManager.AppSettings["LatestVersion"];
                foreach (XmlNode item in root.ChildNodes)
                {
                    if (item.Attributes["Version"].Value.Equals(SelectedVersion))
                    {
                        cfa.AppSettings.Settings["LatestVersion"].Value = SelectedVersion;
                        cfa.Save(ConfigurationSaveMode.Full);
                        foreach (XmlNode EV in item.ChildNodes)
                        {
                            if (EV.Name.Equals("EV"))
                            {
                                if (EV.Attributes["Value"].Value.IndexOf("#")==-1)
                                {
                                    environment.SetSysEnvironment(EV.Attributes["Name"].Value, EV.Attributes["Value"].Value);
                                }
                                else
                                {
                                    switch (EV.Attributes["Value"].Value)
                                    {
                                        case "#InstalledPath_JDK":
                                            environment.SetSysEnvironment(EV.Attributes["Name"].Value, $"{StoreBase}\\JDK {item.Attributes["Version"].Value}\\");
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {

            }
        }

        private void Installer_Un_Click(object sender, RoutedEventArgs e)
        {
            HandyControl.Controls.Growl.Info("开始卸载", null);

            targetPath = $"{StoreBase}\\JDK {SelectedVersion}\\";

            XmlNode root = editions.DocumentElement;
            foreach (XmlNode item in root.ChildNodes)
            {
                if (item.Attributes["Version"].Value.Equals(SelectedVersion))
                {
                    item.Attributes["IsInstalled"].InnerText = "False";
                }
            }
            editions.Save($"{WorkBase}\\Info\\Editions.xml");
            Refresh();

            //建立委托
            ClearDir clearDir = new ClearDir(ClearDirectory);
            //异步调用委托，获取委托执行函数返回的执行结果
            _ = clearDir.BeginInvoke(null, null);
        }

        private void ClearDirectory()
        {
            int errorDeletes = files.Directory_Delete(targetPath, true);
            if (errorDeletes != 0)
            {
                HandyControl.Controls.Growl.Warning("卸载失败", null);
                MessageBox.Show(this, $"卸载过程中有{errorDeletes}个文件无法删除！\n目标路径：{targetPath}", "卸载异常", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                HandyControl.Controls.Growl.Success("卸载完毕", null);
                log.Log_Append(LogFile, $"Remove({targetPath})!");
            }
        }

        private void Installer_Click(object sender, RoutedEventArgs e)
        {
            HandyControl.Controls.Growl.Info("开始安装", null);
            filePath = $"{WorkBase}\\Sources\\{SelectedVersion}.zip";
            targetPath = $"{StoreBase}\\JDK {SelectedVersion}\\";
            if (File.Exists(filePath))
            {
                if (Directory.Exists(targetPath))
                {
                    int errorDeletes = files.Directory_Delete(targetPath, true);
                    if (!(errorDeletes == 0))
                    {
                        MessageBox.Show(this, $"目标安装路径有{errorDeletes}个文件无法删除！\n可能会引发JDKVM的异常或是JDK使用中的异常\n目标路径：{targetPath}", "安装异常", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    Directory.CreateDirectory(targetPath);
                }

                XmlNode root = editions.DocumentElement;
                foreach (XmlNode item in root.ChildNodes)
                {
                    if (item.Attributes["Version"].Value.Equals(SelectedVersion))
                    {
                        item.Attributes["IsInstalled"].InnerText = "True";
                    }
                }
                editions.Save($"{WorkBase}\\Info\\Editions.xml");
                Refresh();

                //建立委托
                MyDelegate myDelegate = new MyDelegate(ExtractZip);
                //异步调用委托，获取委托执行函数返回的执行结果
                _ = myDelegate.BeginInvoke(null, null);
            }
            else
            {
                HandyControl.Controls.Growl.Warning("安装失败", null);
                MessageBox.Show(this, $"安装文件丢失，请在”设置“-“资源”中单击“还原资源文件”\n" +
                    $"{filePath}", "安装失败", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        string filePath;
        string targetPath;

        private void ExtractZip()
        {
            ZipFile.ExtractToDirectory(filePath, targetPath);
            HandyControl.Controls.Growl.Success($"JDK {System.IO.Path.GetFileNameWithoutExtension(filePath)} 已经安装完毕", null);
            log.Log_Append(LogFile, $"Install({targetPath})!");
        }

        private void LoadAnimation()
        {
            Fade_In = animation.CreateDoubleAnimation(TimeSpan.FromMilliseconds(500), 0, 1, FillBehavior.HoldEnd, BasicHelper.EasingFunction.Cubic,
                EasingMode.EaseOut, 0, 0);
            Fade_Out = animation.CreateDoubleAnimation(TimeSpan.FromMilliseconds(500), 1, 0, FillBehavior.HoldEnd, BasicHelper.EasingFunction.Cubic,
                EasingMode.EaseOut, 0, 0);
        }

        private enum Wins
        {
            Selecting_Before = 1,
            Selecting_After = 2
        }

        private void Win_Exchange(Wins to)
        {
            switch (to)
            {
                case Wins.Selecting_Before:
                    Win_Selecting_Before.BeginAnimation(OpacityProperty, Fade_In);
                    Win_Selecting_After.BeginAnimation(OpacityProperty, Fade_Out);
                    break;
                case Wins.Selecting_After:
                    Win_Selecting_Before.BeginAnimation(OpacityProperty, Fade_Out);
                    Win_Selecting_After.BeginAnimation(OpacityProperty, Fade_In);
                    break;
            }
        }

        private void LoadEditions()
        {
            Navigater.Children.Clear();
            Navigater.Children.Add(new Label()
            {
                Style = null
            });
            editions.Load($"{WorkBase}\\Info\\Editions.xml");
            XmlNode root = editions.DocumentElement;
            foreach (XmlNode item in root.ChildNodes)
            {
                string version = $"JDK {item.Attributes["Version"].Value}";
                Button btn = new Button()
                {
                    Content = version,
                    Style = (Style)FindResource("MaterialDesignRaisedButton")
                };
                btn.Click += (x, y) =>
                  {
                      Win_Exchange(Wins.Selecting_After);
                      SelectedVersion = item.Attributes["Version"].Value;
                      SelectedVersion_Title.Text = version;
                      Button_Refresh();
                      if (item.Attributes["IsEnable"].Value.Equals("True"))
                      {
                          Enabler.Visibility = Visibility.Hidden;
                          Unabler.Visibility = Visibility.Visible;
                      }
                      else
                      {
                          Enabler.Visibility = Visibility.Visible;
                          Unabler.Visibility = Visibility.Hidden;
                      }
                      if (item.Attributes["IsInstalled"].Value.Equals("False"))
                      {
                          Installer_Re.IsEnabled = false;
                          Installer_Un.IsEnabled = false;
                          Enabler.Visibility = Visibility.Hidden;
                          Unabler.Visibility = Visibility.Hidden;
                      }
                      else
                      {
                          Installer.IsEnabled = false;
                      }
                  };
                Navigater.Children.Add(btn);
                Navigater.Children.Add(new Label()
                {
                    Style = null
                });
            }
            log.Log_Append(LogFile, "LoadEditions()!");
        }

        private void Button_Refresh()
        {
            Enabler.Visibility = Visibility.Visible;
            Unabler.Visibility = Visibility.Visible;
            Installer.IsEnabled = true;
            Installer_Re.IsEnabled = true;
            Installer_Un.IsEnabled = true;
        }
    }

    public class BasicHelper
    {
        public enum EasingFunction
        {
            Back = 0, Bounce = 1, Circle = 2, Cubic = 3, Elastic = 4, Exponential = 5, Power = 6, Quadratic = 7, Quartic = 8, Qudoubleic = 9, Sine = 10
        }

        public ColorAnimation CreateColorAnimation(TimeSpan Duration, Color From, Color To, FillBehavior fillBehavior,
            EasingFunction easingFunction, EasingMode mode, double em_double, int em_int)
        {
            ColorAnimation colorAnimation = new ColorAnimation(From, To, Duration, fillBehavior);
            switch (easingFunction)
            {
                case EasingFunction.Back:
                    BackEase backEase = new BackEase
                    {
                        EasingMode = mode,
                        Amplitude = em_double
                    };
                    colorAnimation.EasingFunction = backEase;
                    break;
                case EasingFunction.Bounce:
                    BounceEase bounceEase = new BounceEase
                    {
                        EasingMode = mode,
                        Bounces = em_int,
                        Bounciness = em_double
                    };
                    colorAnimation.EasingFunction = bounceEase;
                    break;
                case EasingFunction.Circle:
                    CircleEase circleEase = new CircleEase
                    {
                        EasingMode = mode
                    };
                    colorAnimation.EasingFunction = circleEase;
                    break;
                case EasingFunction.Cubic:
                    CubicEase cubicEase = new CubicEase
                    {
                        EasingMode = mode
                    };
                    colorAnimation.EasingFunction = cubicEase;
                    break;
                case EasingFunction.Elastic:
                    ElasticEase elasticEase = new ElasticEase
                    {
                        EasingMode = mode,
                        Oscillations = em_int,
                        Springiness = em_double
                    };
                    colorAnimation.EasingFunction = elasticEase;
                    break;
                case EasingFunction.Exponential:
                    ExponentialEase exponentialEase = new ExponentialEase
                    {
                        EasingMode = mode,
                        Exponent = em_double
                    };
                    colorAnimation.EasingFunction = exponentialEase;
                    break;
                case EasingFunction.Power:
                    PowerEase powerEase = new PowerEase
                    {
                        EasingMode = mode,
                        Power = em_double
                    };
                    colorAnimation.EasingFunction = powerEase;
                    break;
                case EasingFunction.Quadratic:
                    QuadraticEase quadraticEase = new QuadraticEase
                    {
                        EasingMode = mode
                    };
                    colorAnimation.EasingFunction = quadraticEase;
                    break;
                case EasingFunction.Quartic:
                    QuarticEase quarticEase = new QuarticEase
                    {
                        EasingMode = mode
                    };
                    colorAnimation.EasingFunction = quarticEase;
                    break;
                case EasingFunction.Qudoubleic:
                    QuinticEase quinticEase = new QuinticEase
                    {
                        EasingMode = mode
                    };
                    colorAnimation.EasingFunction = quinticEase;
                    break;
                case EasingFunction.Sine:
                    SineEase sineEase = new SineEase
                    {
                        EasingMode = mode
                    };
                    colorAnimation.EasingFunction = sineEase;
                    break;
            }
            return colorAnimation;
        }

        public ThicknessAnimation CreateThicknessAnimation(TimeSpan Duration, Thickness From, Thickness To, FillBehavior fillBehavior,
            EasingFunction easingFunction, EasingMode mode, double em_double, int em_int)
        {
            ThicknessAnimation thicknessAnimation = new ThicknessAnimation(From, To, Duration, fillBehavior);
            switch (easingFunction)
            {
                case EasingFunction.Back:
                    BackEase backEase = new BackEase
                    {
                        EasingMode = mode,
                        Amplitude = em_double
                    };
                    thicknessAnimation.EasingFunction = backEase;
                    break;
                case EasingFunction.Bounce:
                    BounceEase bounceEase = new BounceEase
                    {
                        EasingMode = mode,
                        Bounces = em_int,
                        Bounciness = em_double
                    };
                    thicknessAnimation.EasingFunction = bounceEase;
                    break;
                case EasingFunction.Circle:
                    CircleEase circleEase = new CircleEase
                    {
                        EasingMode = mode
                    };
                    thicknessAnimation.EasingFunction = circleEase;
                    break;
                case EasingFunction.Cubic:
                    CubicEase cubicEase = new CubicEase
                    {
                        EasingMode = mode
                    };
                    thicknessAnimation.EasingFunction = cubicEase;
                    break;
                case EasingFunction.Elastic:
                    ElasticEase elasticEase = new ElasticEase
                    {
                        EasingMode = mode,
                        Oscillations = em_int,
                        Springiness = em_double
                    };
                    thicknessAnimation.EasingFunction = elasticEase;
                    break;
                case EasingFunction.Exponential:
                    ExponentialEase exponentialEase = new ExponentialEase
                    {
                        EasingMode = mode,
                        Exponent = em_double
                    };
                    thicknessAnimation.EasingFunction = exponentialEase;
                    break;
                case EasingFunction.Power:
                    PowerEase powerEase = new PowerEase
                    {
                        EasingMode = mode,
                        Power = em_double
                    };
                    thicknessAnimation.EasingFunction = powerEase;
                    break;
                case EasingFunction.Quadratic:
                    QuadraticEase quadraticEase = new QuadraticEase
                    {
                        EasingMode = mode
                    };
                    thicknessAnimation.EasingFunction = quadraticEase;
                    break;
                case EasingFunction.Quartic:
                    QuarticEase quarticEase = new QuarticEase
                    {
                        EasingMode = mode
                    };
                    thicknessAnimation.EasingFunction = quarticEase;
                    break;
                case EasingFunction.Qudoubleic:
                    QuinticEase quinticEase = new QuinticEase
                    {
                        EasingMode = mode
                    };
                    thicknessAnimation.EasingFunction = quinticEase;
                    break;
                case EasingFunction.Sine:
                    SineEase sineEase = new SineEase
                    {
                        EasingMode = mode
                    };
                    thicknessAnimation.EasingFunction = sineEase;
                    break;
            }
            return thicknessAnimation;
        }

        /// <summary>
        /// 返回一个创建完毕的DoubleAnimation对象
        /// </summary>
        /// <param name="Duration">动画持续时间</param>
        /// <param name="From">动画起始值</param>
        /// <param name="To">动画结束值</param>
        /// <param name="fillBehavior"></param>
        /// <param name="easingFunction"></param>
        /// <param name="mode">缓动动画模板</param>
        /// <param name="em_double">缓动动画扩展浮点参数</param>
        /// <param name="em_int">缓动动画扩展整数参数</param>
        /// <returns></returns>
        public DoubleAnimation CreateDoubleAnimation(TimeSpan Duration, double From, double To, FillBehavior fillBehavior,
            EasingFunction easingFunction, EasingMode mode, double em_double, int em_int)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation(From, To, Duration, fillBehavior);
            switch (easingFunction)
            {
                case EasingFunction.Back:
                    BackEase backEase = new BackEase
                    {
                        EasingMode = mode,
                        Amplitude = em_double
                    };
                    doubleAnimation.EasingFunction = backEase;
                    break;
                case EasingFunction.Bounce:
                    BounceEase bounceEase = new BounceEase
                    {
                        EasingMode = mode,
                        Bounces = em_int,
                        Bounciness = em_double
                    };
                    doubleAnimation.EasingFunction = bounceEase;
                    break;
                case EasingFunction.Circle:
                    CircleEase circleEase = new CircleEase
                    {
                        EasingMode = mode
                    };
                    doubleAnimation.EasingFunction = circleEase;
                    break;
                case EasingFunction.Cubic:
                    CubicEase cubicEase = new CubicEase
                    {
                        EasingMode = mode
                    };
                    doubleAnimation.EasingFunction = cubicEase;
                    break;
                case EasingFunction.Elastic:
                    ElasticEase elasticEase = new ElasticEase
                    {
                        EasingMode = mode,
                        Oscillations = em_int,
                        Springiness = em_double
                    };
                    doubleAnimation.EasingFunction = elasticEase;
                    break;
                case EasingFunction.Exponential:
                    ExponentialEase exponentialEase = new ExponentialEase
                    {
                        EasingMode = mode,
                        Exponent = em_double
                    };
                    doubleAnimation.EasingFunction = exponentialEase;
                    break;
                case EasingFunction.Power:
                    PowerEase powerEase = new PowerEase
                    {
                        EasingMode = mode,
                        Power = em_double
                    };
                    doubleAnimation.EasingFunction = powerEase;
                    break;
                case EasingFunction.Quadratic:
                    QuadraticEase quadraticEase = new QuadraticEase
                    {
                        EasingMode = mode
                    };
                    doubleAnimation.EasingFunction = quadraticEase;
                    break;
                case EasingFunction.Quartic:
                    QuarticEase quarticEase = new QuarticEase
                    {
                        EasingMode = mode
                    };
                    doubleAnimation.EasingFunction = quarticEase;
                    break;
                case EasingFunction.Qudoubleic:
                    QuinticEase quinticEase = new QuinticEase
                    {
                        EasingMode = mode
                    };
                    doubleAnimation.EasingFunction = quinticEase;
                    break;
                case EasingFunction.Sine:
                    SineEase sineEase = new SineEase
                    {
                        EasingMode = mode
                    };
                    doubleAnimation.EasingFunction = sineEase;
                    break;
            }
            return doubleAnimation;
        }
    }
}
