using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aesthetic_Standard
{
    /// <summary>
    /// MessageBox.xaml 的交互逻辑
    /// </summary>
    public partial class MessageBox : Window
    {
        ErrorList el = new ErrorList();

        private void Value(ref string content, ref string title, ref Theme theme, ref Buttons buttons, ref Icons icon_theme)
        {
            InitializeComponent();
            switch (theme)
            {
                case Theme.Light:
                    StandardBox_Dark.Visibility = Visibility.Hidden;
                    StandardBox_Light_Title.Text = title;
                    StandardBox_Light_Contents.Text = content;
                    switch (buttons)
                    {
                        case Buttons.OK:
                            Cancel_Stop_Retry_Light.Visibility = Visibility.Hidden;
                            StandardBox_Light_Cancel_OK.Visibility = Visibility.Hidden;
                            break;
                        case Buttons.Cancel_OK:
                            Cancel_Stop_Retry_Light.Visibility = Visibility.Hidden;
                            break;
                        case Buttons.Cancel_Stop_Retry:
                            OK_Cancel_Light.Visibility = Visibility.Hidden;
                            break;
                    }
                    try
                    {
                        if (icon_theme != Icons.Null)
                        {
                            switch (icon_theme)
                            {
                                case Icons.Null:
                                    StandardBox_Light_Icon.Source = null;
                                    break;
                                case Icons.Information:
                                    StandardBox_Light_Icon.Source = new BitmapImage(new Uri("Images/Icon-Information.png", UriKind.Relative));
                                    break;
                                case Icons.Warn:
                                    StandardBox_Light_Icon.Source = new BitmapImage(new Uri("Images/Icon-Warn.png", UriKind.Relative));
                                    break;
                                case Icons.Error:
                                    StandardBox_Light_Icon.Source = new BitmapImage(new Uri("Images/Icon-Error.png", UriKind.Relative));
                                    break;
                                case Icons.Funny:
                                    StandardBox_Light_Icon.Source = new BitmapImage(new Uri("Images/Icon-Funny.png", UriKind.Relative));
                                    break;
                            }
                        }
                    }
                    catch (Exception p)
                    {
                        System.Windows.MessageBox.Show("Aesthetic Standard Error", $"Error Content: {p.Message}\nError Code: {el.ReturnErrorCode(ErrorList.Errors.MessageBox_Icon_Lost)}");
                    }
                    break;
                case Theme.Dark:
                    StandardBox_Light.Visibility = Visibility.Hidden;
                    StandardBox_Dark_Title.Text = title;
                    StandardBox_Dark_Contents.Text = content;
                    switch (buttons)
                    {
                        case Buttons.OK:
                            Cancel_Stop_Retry_Dark.Visibility = Visibility.Hidden;
                            StandardBox_Dark_Cancel_OK.Visibility = Visibility.Hidden;
                            break;
                        case Buttons.Cancel_OK:
                            Cancel_Stop_Retry_Dark.Visibility = Visibility.Hidden;
                            break;
                        case Buttons.Cancel_Stop_Retry:
                            OK_Cancel_Dark.Visibility = Visibility.Hidden;
                            break;
                    }
                    try
                    {
                        if (icon_theme != Icons.Null)
                        {
                            switch (icon_theme)
                            {
                                case Icons.Null:
                                    StandardBox_Dark_Icon.Source = null;
                                    break;
                                case Icons.Information:
                                    StandardBox_Dark_Icon.Source = new BitmapImage(new Uri("Images/Icon-Information.png", UriKind.Relative));
                                    break;
                                case Icons.Warn:
                                    StandardBox_Dark_Icon.Source = new BitmapImage(new Uri("Images/Icon-Warn.png", UriKind.Relative));
                                    break;
                                case Icons.Error:
                                    StandardBox_Dark_Icon.Source = new BitmapImage(new Uri("Images/Icon-Error.png", UriKind.Relative));
                                    break;
                                case Icons.Funny:
                                    StandardBox_Dark_Icon.Source = new BitmapImage(new Uri("Images/Icon-Funny.png", UriKind.Relative));
                                    break;
                            }
                        }
                    }
                    catch (Exception p)
                    {
                        System.Windows.MessageBox.Show("Aesthetic Standard Error", $"Error Content: {p.Message}\nError Code: {el.ReturnErrorCode(ErrorList.Errors.MessageBox_Icon_Lost)}");
                    }
                    break;
            }
            switch (theme)
            {
                case Theme.Light:
                    StandardBox_Light_Cancel_OK.Click += (x, y) =>
                      {
                          GoBack(ClickedButton.Cancel);
                      };
                    StandardBox_Light_OK.Click += (x, y) =>
                      {
                          GoBack(ClickedButton.OK);
                      };
                    StandardBox_Light_Cancel_StopAndRetry.Click += (x, y) =>
                    {
                        GoBack(ClickedButton.Cancel);
                    };
                    StandardBox_Light_Stop.Click += (x, y) =>
                      {
                          GoBack(ClickedButton.Stop);
                      };
                    StandardBox_Light_Retry.Click += (x, y) =>
                    {
                        GoBack(ClickedButton.Retry);
                    };
                    break;
                case Theme.Dark:
                    StandardBox_Dark_Cancel_OK.Click += (x, y) =>
                    {
                        GoBack(ClickedButton.Cancel);
                    };
                    StandardBox_Dark_OK.Click += (x, y) =>
                    {
                        GoBack(ClickedButton.OK);
                    };
                    StandardBox_Dark_Cancel_StopAndRetry.Click += (x, y) =>
                    {
                        GoBack(ClickedButton.Cancel);
                    };
                    StandardBox_Dark_Stop.Click += (x, y) =>
                    {
                        GoBack(ClickedButton.Stop);
                    };
                    StandardBox_Dark_Retry.Click += (x, y) =>
                    {
                        GoBack(ClickedButton.Retry);
                    };
                    break;
            }
        }

        private void GoBack(ClickedButton button)
        {
            ClickedButton = button;
            #region 定义动画
            CubicEase cubicEase = new CubicEase()
            {
                EasingMode = EasingMode.EaseOut
            };
            DoubleAnimation heightAnimation = new DoubleAnimation()
            {
                From = mainDocker.Height,
                To = 0,
                FillBehavior = FillBehavior.Stop,
                Duration = new TimeSpan(0, 0, 0, 500),
                EasingFunction = cubicEase
            };
            DoubleAnimation widthAnimation = new DoubleAnimation()
            {
                From = mainDocker.Width,
                To = 0,
                FillBehavior = FillBehavior.Stop,
                Duration = new TimeSpan(0, 0, 0, 500),
                EasingFunction = cubicEase
            };
            DoubleAnimation opacityAnimation = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                FillBehavior = FillBehavior.Stop,
                Duration = new TimeSpan(0, 0, 0, 500),
                EasingFunction = cubicEase
            };
            #endregion
            switch (startAnimation)
            {
                case Animation.Null:
                    break;
                case Animation.MiddleLine_To_TopAndBottom:
                    mainDocker.BeginAnimation(HeightProperty, heightAnimation);
                    break;
                case Animation.Center_To_Four_Corners:
                    mainDocker.BeginAnimation(HeightProperty, heightAnimation);
                    mainDocker.BeginAnimation(WidthProperty, widthAnimation);
                    break;
                case Animation.Fade:
                    mainDocker.BeginAnimation(OpacityProperty, opacityAnimation);
                    break;
                case Animation.MiddleLine_To_TopAndBottom_With_Fade:
                    mainDocker.BeginAnimation(HeightProperty, heightAnimation);
                    mainDocker.BeginAnimation(OpacityProperty, opacityAnimation);
                    break;
                case Animation.Center_To_Four_Corners_With_Fade:
                    mainDocker.BeginAnimation(HeightProperty, heightAnimation);
                    mainDocker.BeginAnimation(WidthProperty, widthAnimation);
                    mainDocker.BeginAnimation(OpacityProperty, opacityAnimation);
                    break;
            }
            Close();
        }

        public void Show(Animation animation, WindowStartupLocation windowStartupLocation)
        {
            WindowStartupLocation = windowStartupLocation;
            startAnimation = animation;
            #region 定义动画
                CubicEase cubicEase = new CubicEase()
                {
                    EasingMode = EasingMode.EaseOut
                };
                DoubleAnimation heightAnimation = new DoubleAnimation()
                {
                    From = 0,
                    To = mainDocker.Height,
                    FillBehavior = FillBehavior.Stop,
                    Duration = new TimeSpan(0, 0, 0, 500),
                    EasingFunction = cubicEase
                };
                DoubleAnimation widthAnimation = new DoubleAnimation()
                {
                    From = 0,
                    To = mainDocker.Width,
                    FillBehavior = FillBehavior.Stop,
                    Duration = new TimeSpan(0, 0, 0, 500),
                    EasingFunction = cubicEase
                };
                DoubleAnimation opacityAnimation = new DoubleAnimation()
                {
                    From = 0,
                    To = 1,
                    FillBehavior = FillBehavior.Stop,
                    Duration = new TimeSpan(0, 0, 0, 500),
                    EasingFunction = cubicEase
                };
                #endregion
            switch (animation)
            {
                case Animation.Null:
                    break;
                case Animation.MiddleLine_To_TopAndBottom:
                    mainDocker.Height = 0;
                    ShowDialog();
                    mainDocker.BeginAnimation(HeightProperty, heightAnimation);
                    break;
                case Animation.Center_To_Four_Corners:
                    mainDocker.Height = 0;
                    mainDocker.Width = 0;
                    ShowDialog();
                    mainDocker.BeginAnimation(HeightProperty, heightAnimation);
                    mainDocker.BeginAnimation(WidthProperty, widthAnimation);
                    break;
                case Animation.Fade:
                    mainDocker.Opacity = 0;
                    ShowDialog();
                    mainDocker.BeginAnimation(OpacityProperty, opacityAnimation);
                    break;
                case Animation.MiddleLine_To_TopAndBottom_With_Fade:
                    mainDocker.Height = 0;
                    mainDocker.Opacity = 0;
                    ShowDialog();
                    mainDocker.BeginAnimation(HeightProperty, heightAnimation);
                    mainDocker.BeginAnimation(OpacityProperty, opacityAnimation);
                    break;
                case Animation.Center_To_Four_Corners_With_Fade:
                    mainDocker.Height = 0;
                    mainDocker.Width = 0;
                    mainDocker.Opacity = 0;
                    ShowDialog();
                    mainDocker.BeginAnimation(HeightProperty, heightAnimation);
                    mainDocker.BeginAnimation(WidthProperty, widthAnimation);
                    mainDocker.BeginAnimation(OpacityProperty, opacityAnimation);
                    break;
            }
        }

        public ClickedButton ClickedButton;
        Animation startAnimation;
        string Null_String = null;
        Icons Null_Icon = Icons.Null;

        /// <summary>
        /// 消息框的构造方法
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="theme">主题</param>
        /// <param name="buttons">按钮</param>
        /// <param name="animation">动画方式</param>
        public MessageBox(string content, Theme theme, Buttons buttons)
        {
            Value(ref content, ref Null_String, ref theme, ref buttons, ref Null_Icon);
        }

        /// <summary>
        /// 消息框的构造方法
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="title">标题</param>
        /// <param name="theme">主题</param>
        /// <param name="buttons">按钮</param>
        /// <param name="animation">动画方式</param>
        public MessageBox(string content, string title, Theme theme, Buttons buttons)
        {
            Value(ref content, ref title, ref theme, ref buttons, ref Null_Icon);
        }

        /// <summary>
        /// 消息框的构造方法
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="title">标题</param>
        /// <param name="theme">主题</param>
        /// <param name="buttons">按钮</param>
        /// <param name="icon">从主题选择插图</param>
        /// <param name="animation">动画方式</param>
        public MessageBox(string content, string title, Theme theme, Buttons buttons, Icons icon)
        {
            Value(ref content, ref title, ref theme, ref buttons, ref icon);
        }
    }

    public enum Theme
    {
        Light, Dark
        //Light - 淡雅白主题
        //Dark - 玄武黑主题
    }

    public enum Buttons
    {
        OK, Cancel_OK, Cancel_Stop_Retry
        //OK - 仅“好的”按钮
        //Cancel_OK - “取消”-“好的”按钮
        //Cancel_Stop_Retry - “取消”-“中止”-“重试”按钮
    }

    public enum ClickedButton
    {
        OK, Cancel, Stop, Retry
        //OK - "好的"
        //Cancel - "取消"
        //Stop - "中止 "
        //Retry - "重试"
    }

    public enum Icons
    {
        Null, Information, Warn, Error, Funny
        //Null - 不包含插图
        //Information - 感叹号
        //Warn - 黄色三角形加一个感叹号
        //Error - 叉叉
        //Funny - 滑稽
    }

    public enum Animation
    {
        Null, MiddleLine_To_TopAndBottom, Center_To_Four_Corners, Fade, MiddleLine_To_TopAndBottom_With_Fade, Center_To_Four_Corners_With_Fade
        //Null - 无动画
        //MiddleLine_To_TopAndBottom - 自水平中线向上下展开
        //Center_To_Four_Corners - 自中点向四周展开
        //Fade - 淡入
        //MiddleLine_To_TopAndBottom_With_Fade - 自水平中线向上下淡入展开
        //Center_To_Four_Corners_With_Fade - 自中点向四周淡入展开
    }
}