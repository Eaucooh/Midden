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

namespace 贪吃蛇
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //设置窗口的边框为无边框
            this.WindowStyle = WindowStyle.None;
            //设置窗口是否支持背景透明
            this.AllowsTransparency = true;
        }

        double size = 20;
        //创建泛型来装蛇
        List<Border> snake = new List<Border>() ;
        
        //创建蛇活动区域
        Canvas game = new Canvas();
        //实例化一个随机对象
        Random rd= new Random();
        //添加计时器控制蛇移动
        DispatcherTimer time = new DispatcherTimer();
        //添加开始按钮
        Button start = new Button();
        //添加暂停按钮
        Button stop = new Button();
        //创建计分板
        int k = 0;
        //添加边框
        Border bd = new Border();
        //创建计分板
        Label defen = new Label();
        //添加声音计时器
        DispatcherTimer sound = new DispatcherTimer();
        //创建背景音乐
        MediaPlayer bgsing = new MediaPlayer();
        //创建泛型来装第二条蛇
        List<Border> snake2 = new List<Border>();
        //创建泛型来装食物

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Background = Brushes.Cyan;
            //设置窗口是否最大化
            this.WindowState = WindowState.Maximized;
            //this.Opacity = 0.6;

            //添加边框
            //Border bd = new Border();
            bd.Width = 60 * size;
            bd.Height = 35 * size;
            bd.BorderBrush = new RadialGradientBrush(Colors.Cyan, Colors.Orange);
            //设置border的宽度
            bd.BorderThickness = new Thickness(20);
            Canvas.SetLeft(bd, this.Width / 2 - bd.Width / 2);
            Canvas.SetTop(bd, this.Height / 2 - bd.Height / 2);
            Gamebg.Children.Add(bd);

            //添加蛇活动区域
            game.Width = bd.Width;
            game.Height = bd.Height;
            Canvas.SetLeft(game, Canvas.GetLeft(bd));
            Canvas.SetTop(game, Canvas.GetTop(bd));
            game.Background = Brushes.Gray;
            game.Opacity = 0.7;
            Image bg = new Image();
            bg.Source = new BitmapImage(new Uri("../../img/bg.jpg", UriKind.Relative));
            ImageBrush bgimg = new ImageBrush ();
            bgimg.ImageSource = bg.Source;
            game.Background = bgimg;
            Gamebg.Children.Add(game);

            //添加开始按钮
           // Button start = new Button();
            start.Width = 400;
            start.Height = 100;
            start.Content = "Start Game";
            start.FontSize = 30;
            start.Background = Brushes.Orange;
            start.Opacity = 1;
            Canvas.SetLeft(start, game.Width / 2 - start.Width / 2);
            Canvas.SetTop(start,game.Height/2-start.Height/2);
            game.Children.Add(start);
            start.Click += Start_Click;

            //添加暂停按钮
            //Button stop = new Button();
            stop.Content = "暂停";
            stop.Width = 60;
            stop.Height = 40;
            stop.FontSize = 28;
            stop.Opacity = 0.8;
            Canvas.SetLeft(stop,20);
            Canvas.SetTop(stop, 130);
            stop.Background = Brushes.Pink;
            Gamebg.Children.Add(stop);
            stop.Click += Stop_Click;

            //创建计分板
            //Label defen = new Label();
            defen.Content = k+"分";
            defen.Width = 60;
            defen.Height = 50;
            defen.FontSize = 28;
            //defen.ClipToBounds = true;
            Canvas.SetLeft(defen,20);
            Canvas.SetTop(defen,200);
            Gamebg.Children.Add(defen);

            //添加键盘事件
            this.KeyDown += MainWindow_KeyDown;
            this.KeyUp += MainWindow_KeyUp;

            //生成蛇
            snakeborn();
            //添加计时器控制蛇移动
            //DispatcherTimer time = new DispatcherTimer();
            time.Interval = new TimeSpan(4000000);            
            time.Tick += Time_Tick;


        }
      

        //暂停按钮
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            if (stop.Content.ToString() == "暂停")
            {
                time.Stop();
                stop.Content = "继续";
                return;
            }
            if (stop.Content.ToString() == "继续")
            {
                time.Start();
                stop.Content = "暂停";
                return;
            }
            
        }

        //开始按钮点击事件
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            time.Start();
            //创建食物
            foodborn();
            game.Children.Remove(start);

            //添加音频路径
            bgsing.Open(new Uri("../../sound/松鼠.mp3", UriKind.Relative));
            //添加事件,当音乐播放完时再次播放音乐
            bgsing.MediaEnded += Bgsing_MediaEnded;
            bgsing.Play();
        }

        private void Bgsing_MediaEnded(object sender, EventArgs e)
        {
            //设置再次播放音乐间隔为0
            bgsing.Position = new TimeSpan(0);           
        }

        //创建食物
        Border fd;
        private  void foodborn()
        {
            fd = new Border();
            fd.Width = 20;
            fd.Height = 20;
            //设置圆
            fd.CornerRadius = new CornerRadius(10);
            fd.Background = Brushes.Red;
            Canvas.SetLeft(fd, rd.Next(1, 59) * size);
            Canvas.SetTop(fd, rd.Next(1, 34) * size);
            game.Children.Add(fd);
        }

        //计时器控制蛇移动
        private void Time_Tick(object sender, EventArgs e)
        {
            snakemove();
            
            //将后一个蛇身体的tag改变和前一个的tag一样
            for (int i = snake.Count - 1; i > 0; i--)
            {
                snake[i].Tag = snake[i - 1].Tag;

            }

            //判断当蛇头和食物位置重叠
            if (Canvas.GetLeft(snake[0]) == Canvas.GetLeft(fd) && Canvas.GetTop(snake[0]) == Canvas.GetTop(fd))
            {
                //设置蛇吃食物音效
                MediaPlayer foodsong = new MediaPlayer();
                foodsong.Open(new Uri("../../sound/吃食物.wav",UriKind.Relative));
                foodsong.Play();
                //得分增加
                k++;
                defen.Content = k + "分";
                //如果分数大于5分速度变快
                if (k > 5)
                {
                    time.Interval = new TimeSpan(3000000);
                }
                //吃到食物后移除食物
                game.Children.Remove(fd);
                //当吃到食物后创建一个蛇身体添加到最后一节身体后边
                Border skb = new Border();
                skb.Width = skb.Height = size;
                //skb.Tag = snake[snake.];
                skb.Background = Brushes.Pink;
                skb.CornerRadius = new CornerRadius(10);
                Canvas.SetLeft(skb, Canvas.GetLeft(snake[snake.Count - 1]));
                Canvas.SetTop(skb, Canvas.GetTop(snake[snake.Count - 1]));
                game.Children.Add(skb);
                snake.Add(skb);
                //再次创建食物
                foodborn();
            }
            //判断蛇撞墙
            if (Canvas.GetLeft(snake[0]) <= 0 || Canvas.GetLeft(snake[0]) + size >= 1200 ||
                Canvas.GetTop(snake[0]) <= 0 || Canvas.GetTop(snake[0]) + size >= 700)
            {
                //暂停背景音乐
                bgsing.Pause();
                //设置死亡音效
                MediaPlayer oversong = new MediaPlayer();
                oversong.Open(new Uri("../../sound/死亡.mp3", UriKind.Relative));
                oversong.Play();
                //死亡时蛇停止移动
                time.Stop();
                //
                MessageBoxResult r = MessageBox.Show("重新开始", "返回", MessageBoxButton.YesNo);
                if (r == MessageBoxResult.Yes)
                {
                    k = 0;
                    defen.Content = k + "分";                   
                    game.Children.Clear();
                    snake.Clear();
                    game.Children.Add(start);
                    snakeborn();
                    return;
                }
                else
                {
                    this.Close();
                }
            }
            //判断蛇头碰到自己社身体减少一节
            for (int i=1;i<snake.Count;i++)
            {
                
              if (Canvas.GetTop(snake[0])==Canvas.GetTop(snake[i])&&Canvas.GetLeft(snake[0])==Canvas.GetLeft(snake[i]))
                 {
                    game.Children.RemoveAt(snake.Count-1 );
                    snake.RemoveAt(snake.Count-1);
                    k--;
                    defen.Content = k + "分";
                    if (k<0)
                    {
                        //暂停背景音乐
                        bgsing.Pause();
                        //设置死亡音效
                        MediaPlayer oversong = new MediaPlayer();
                        oversong.Open(new Uri("../../sound/死亡.mp3", UriKind.Relative));
                        oversong.Play();
                        //死亡时蛇停止移动
                        time.Stop();
                        MessageBoxResult s= MessageBox.Show("Game over","",MessageBoxButton.OK);
                        if (s==MessageBoxResult.Yes)
                        {
                            MessageBoxResult k=MessageBox.Show("自己吃自己,没资格重新开始","",MessageBoxButton.OK);
                            if (k==MessageBoxResult.Yes)
                            {
                                this.Close();
                            }
                        }
                    }
                }
                
            }
        }
        //控制当判断蛇头的tag值来控制蛇向哪个方向移动
        private void snakemove()
        {
            
            for (int i = 0; i < snake.Count; i++)
            {
                switch (snake[i].Tag)
                {
                    case "right":                        
                        Canvas.SetLeft(snake[i], Canvas.GetLeft(snake[i]) + size);
                        break;
                    case "left":
                        Canvas.SetLeft(snake[i], Canvas.GetLeft(snake[i]) - size);
                        break;
                    case "up":
                        Canvas.SetTop(snake[i], Canvas.GetTop(snake[i]) - size);
                        break;
                    case "down":
                        Canvas.SetTop(snake[i], Canvas.GetTop(snake[i]) + size);
                        break;                    
                }
            }
        }

        //添加键盘事件改变蛇的方向---当按下键盘时改变蛇头的tag值
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.Key)
            {
                case Key.Up:
                    if (snake[0].Tag.ToString()!="down")
                    {
                        //设置图片旋转,
                        RotateTransform transform = new RotateTransform(0,snake[0].Width/2,snake[0].Height/2);
                        snake[0].RenderTransform = transform;
                        snake[0].Tag = "up";
                    }
                    break;
                case Key.Down:
                    if (snake[0].Tag.ToString() != "up")
                    {
                        RotateTransform transform1 = new RotateTransform(180, snake[0].Width / 2, snake[0].Height / 2);
                        snake[0].RenderTransform = transform1;
                        snake[0].Tag = "down";
                    }
                    break;
                case Key.Left:
                    if (snake[0].Tag.ToString() != "right")
                    {
                        RotateTransform transform2 = new RotateTransform(270, snake[0].Width / 2, snake[0].Height / 2);
                        snake[0].RenderTransform = transform2;
                        snake[0].Tag = "left";
                    }
                    break;
                case Key.Right:
                    if (snake[0].Tag.ToString() != "left")
                    {
                        RotateTransform transform3 = new RotateTransform(90, snake[0].Width / 2, snake[0].Height / 2);
                        snake[0].RenderTransform = transform3;
                        snake[0].Tag = "right";
                    }
                    break;
                    //设置按下k键加速
                case Key.K:
                    time.Interval = new TimeSpan(300000);
                    break;
            }
        }
        //设置键盘抬起事件
        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                //抬起k键速度恢复
                case Key.K:
                    time.Interval = new TimeSpan(4000000);
                    break;
            }
        }

        //生成蛇
        private void snakeborn()
        {
            int length = 4;
            for (int i = 0; i < length; i++)
            {
                Border skb = new Border();
                skb.Width = skb.Height = size;
                //Image 
                skb.Tag = "right";
                //设置border的角度及半径----设置圆
                skb.CornerRadius = new CornerRadius(10);
                //实例化一个图片
                Image head = new Image();
                //图片路径设置为要添加的图片
                head.Source = new BitmapImage(new Uri("../../img/plan.png",UriKind.RelativeOrAbsolute));
                //实例化一个图像画刷区
                ImageBrush headimg = new ImageBrush();
                //给图像画刷区域的路径设置为头部图片的路径
                headimg.ImageSource = head.Source;
                if (i < 1)
                {
                    //让蛇头的背景换为头部图片
                    skb.Background = headimg;
                   
                }
                else
                {
                    skb.Background = Brushes.Pink;
                }
                Canvas.SetLeft(skb, game.Width / 2 - (skb.Width * i));
                Canvas.SetTop(skb, game.Height / 2 + skb.Height / 2+40);
                game.Children.Add(skb);
                snake.Add(skb);
                //设置蛇头初始朝向
                RotateTransform transform = new RotateTransform(90, snake[0].Width / 2, snake[0].Height / 2);
                snake[0].RenderTransform = transform;
            }
        }
    }
}
