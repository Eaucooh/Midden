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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace wpf打字游戏
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //创建随机方法
        Random rd = new Random();
        //创建飞机图片
        Image plane = new Image();
        //创建泛型集合来装字母
        List<Label> letters = new List<Label>();
        //创建泛型集合来装子弹
        List<Image> bius = new List<Image>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //设置窗口区域
            this.Width = 800;
            this.Height = 600;
            this.Left = SystemParameters.FullPrimaryScreenWidth / 2 - this.Width / 2;
            this.Top = SystemParameters.FullPrimaryScreenHeight / 2 - this.Height / 2;
            this.Background = Brushes.Gray;

            //设置游戏区域
            Game.Width = 600;
            Game.Height = 500;
            Canvas.SetLeft(Game,20);
            Canvas.SetTop(Game,20);
            Game.Background = Brushes.LightGray;

            //创建飞机
            
            plane.Source = new BitmapImage(new Uri("/img/plan.png",UriKind.RelativeOrAbsolute));
            plane.Height = 50;
            plane.Width = 50;
            plane.Tag = "air";
            Canvas.SetLeft(plane,Game.Width/2-plane.Width/2);
            Canvas.SetTop(plane,Game.Height-plane.Height);
            Game.Children.Add(plane);

            //添加计时器控制字母生成
            DispatcherTimer bornLetter = new DispatcherTimer();
            bornLetter.Interval =new TimeSpan(5000000);
            bornLetter.Start();
            bornLetter.Tick += BornLetter_Tick;

            //添加计时器控制字母下落
            DispatcherTimer downletter = new DispatcherTimer();
            downletter.Interval = new TimeSpan(500000);
            downletter.Start();
            downletter.Tick += Downletter_Tick;

            //添加键盘事件
            this.KeyDown += this_KeyDown;
            
        }
        //添加键盘事件
        private void this_KeyDown(object sender, KeyEventArgs e)
        {
            //通过for循环来拿到每一个label
            for (int i=0;i<Game.Children.Count;i++)
            {
                //判断如果拿到的game中的控件为label,再进行下一步判断
                if (Game.Children[i].GetType().Name=="Label")
                {
                    
                    //Game.Children[i].
                    //e.key获取到按下键是哪个键
                    //判断按下的键和遍历到的game中控件的的文本内容是否相同
                    if (e.Key.ToString().ToLower()==
                        (Game.Children[i] as Label).Content.ToString()&&/*将对应i位置的控件转换为label类型后获取其中的内容*/
                        (Game.Children[i] as Label ).Tag.ToString()=="zm")
                    {
                        (Game.Children[i] as Label).Tag = "biuzm";
                        //double planet = Canvas.GetLeft(Game.Children[i] as Label );
                        Canvas.SetLeft(plane, Canvas.GetLeft(Game.Children[i])+(Game.Children[i] as Label).Width/2-plane.Width);
                        //Canvas.SetLeft(plane, Canvas.GetLeft(Game.Children[i]) + (Game.Children[i] as Label).Width / 2 - plane.Width / 2);
                        Image biu = new Image();
                        biu.Source = new BitmapImage(new Uri("/img/biu.png",UriKind.Relative));
                        biu.Width = 15;
                        biu.Height = 25;
                        biu.Tag = "biu";
                        Canvas.SetLeft(biu,Canvas.GetLeft(plane)+plane.Width/2-biu.Width/2);
                        Canvas.SetTop(biu, Canvas.GetTop(plane) - biu.Height);
                        Game.Children.Add(biu);
                        bius.Add(biu);

                        //如果相同则移除该元素
                       // Game.Children.Remove(Game.Children[i]);
                        return;
                    }
                }
            }          
        }

        //创建计时器字母下落       
        private void Downletter_Tick(object sender, EventArgs e)
        {
            foreach (UIElement item in letters)
            {
                if (((Label)item).Tag.ToString()=="zm"|| ((Label)item).Tag.ToString() == "biuzm")
                {
                    double t = Canvas.GetTop(item);
                    Canvas.SetTop(item, t += 10);
                    //判断字母掉出屏幕清除
                    if (t >= Game.Height)
                    {
                        Game.Children.Remove(item);
                        //清除掉children集合中的字母后还要将泛型集合中的字母清除掉
                        letters.Remove((Label)item);
                        //清除后跳出
                        break;
                    }
                }
                
            }
            //遍历子弹集合
            foreach (UIElement item in bius)
            {
                if (((Image)item).Tag.ToString()=="biu")
                {
                    double t = Canvas.GetTop(item);
                    Canvas.SetTop(item, t -= 5);
                    //判断子弹超出屏幕区域清除
                    if (t <=0)
                    {
                        Game.Children.Remove(item);
                        //清除掉children集合中的子弹后还要将泛型集合中的子弹清除掉
                        bius.Remove((Image)item);
                        //清除后跳出
                        break;
                    }
                    //判断子弹字母相撞
                    foreach (UIElement zm in letters)
                    {
                        if (((Label)zm).Tag.ToString()=="biuzm")
                        {
                            if (Canvas.GetTop(item)<=Canvas.GetTop(zm)+((Label)zm).Height&&
                                Canvas.GetLeft(item)<=Canvas.GetLeft(zm)+((Label)zm).Width&&
                                Canvas.GetLeft(item) >= Canvas.GetLeft(zm))
                            {
                                Game.Children.Remove(item);
                                Game.Children.Remove(zm);
                                int b = 0;
                                Image boom = new Image();
                                boom.Source = new BitmapImage(new Uri("/img/boom/1000"+b+".png",UriKind.Relative));
                                boom.Tag = 0;
                                DispatcherTimer boomgo = new DispatcherTimer();
                                boomgo.Interval = new TimeSpan(0,0,0,0,300);
                                boomgo.Tag = boom;
                                boomgo.Start();
                                boomgo.Tick += Boomgo_Tick;
                            }
                        }
                    }
                }
            }
            
        }
        //计时器控制爆炸动画播放
        private void Boomgo_Tick(object sender, EventArgs e)
        {
            DispatcherTimer boomb = (DispatcherTimer)sender;
            Image boombox = (Image)boomb.Tag;
            boombox.Source = new BitmapImage(new Uri("/img/boom/1000"+(int)boombox.Tag+".png",UriKind.Relative));
            boombox.Tag=(int)boombox.Tag+1;
            if ((int)boombox.Tag>=40)
            {
                Game.Children.Remove(boombox);
                boomb.Stop();
            }
        }

        //创建计时器控制字母生成
        private void BornLetter_Tick(object sender, EventArgs e)
        {
            Label letter = new Label();
            letter.Content = (char)rd.Next(97,123);
            letter.FontSize = 30;
            //letter.HorizontalContentAlignment.Equals(letter.Width);
            
            letter.Width = 70;
            letter.Height = 70;
            letter.Tag = "zm";            
            Canvas.SetLeft(letter,rd.Next(0,600));
            Canvas.SetTop(letter,0);
            Game.Children.Add(letter);
            letters.Add(letter);
        }
    }
}
