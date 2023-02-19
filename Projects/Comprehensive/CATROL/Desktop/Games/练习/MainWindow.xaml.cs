using System;
using System.Collections.Generic;
using System.IO;
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

namespace 练习
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
        int rows = 10;
        //创建一个二维数组来记录地板和地雷
        int[,] maps;
        //创建一个二维数组来存放图片
        Image[,] images;
        //声明一个变量来记录雷数
        int boom = 10;
        //声明一个bool数组,判断点击的位置是否被判断过
        bool[,] bomOrgo;
        //设置一个计时器
        DispatcherTimer timer = new DispatcherTimer();
        int r = 0;
        int z = 0;



        //FileStream firsttxt = new FileStream("../../file/初级排名.txt",FileMode.Create);
        //FileStream secondtxt = new FileStream("../../file/中级排名.txt", FileMode.Create);
        // FileStream thirdtxt = new FileStream("../../file/高级排名.txt", FileMode.Create);
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //计时器初始文本
            time.Content = r+"s";
            
            //设置菜单栏点击事件
            first.Click += First_Click;
            second.Click += Second_Click;
            third.Click += Third_Click;
            goOut.Click += GoOut_Click;
            ocean.Click += Ocean_Click;
            rock.Click += Rock_Click;

            //设置开始按钮点击事件
            start.Click += Start_Click;

            //设置一个计时器
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            whoOne.Click += WhoOne_Click;
            
           
           // ph.Hide();

        }
        //排行榜点击事件
        private void WhoOne_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show("111");
                排行 ph = new 排行();
                ph.Show();

            //StreamReader reader = new StreamReader("../../file/chuji.txt");
            //string str1 = reader.ReadToEnd();
            //MessageBox.Show(str1);
            //reader.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        //开始按钮点击事件
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            //初始化游戏区域网格
            seeMap(rows);
            //设置游戏
            seeGame(rows, boom);

        }

        //更换石头地地图
        private void Rock_Click(object sender, RoutedEventArgs e)
        {
            bgimg.ImageSource = new BitmapImage(new Uri("../../img/bg.jpg", UriKind.Relative));
        }
        //更换海底地图
        private void Ocean_Click(object sender, RoutedEventArgs e)
        {
            bgimg.ImageSource = new BitmapImage(new Uri("../../img/bg1.jpg",UriKind.Relative));
        }

        //创建计时器来计时
        private void Timer_Tick(object sender, EventArgs e)
        {
            r++;
            time.Content = r+"s";            
        }
        //退出点击事件
        private void GoOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //高级模式
        private void Third_Click(object sender, RoutedEventArgs e)
        {
            r = 0;
            time.Content = r + "s";
            GameBG.RowDefinitions.Clear();
            GameBG.ColumnDefinitions.Clear();
            GameBG.Children.Clear();
            //高级定义雷数为30
            rows = 10;
            boom = 30;
            seeMap(rows);
            seeGame(rows,boom);

        }

        //中级模式
        private void Second_Click(object sender, RoutedEventArgs e)
        {

            GameBG.RowDefinitions.Clear();
            GameBG.ColumnDefinitions.Clear();
            GameBG.Children.Clear();
            r = 0;
            time.Content = r + "s";
            //中级定义雷数为20个
            rows = 10;
            boom = 20;
            seeMap(rows);
            seeGame(rows,boom);
        }

        //初级模式
        private void First_Click(object sender, RoutedEventArgs e)
        {
            //清除网格线;如果不线清除原本的网格线和新创建的网格线会冲突
            GameBG.RowDefinitions.Clear();
            GameBG.ColumnDefinitions.Clear();
            //清除游戏区域中的元素
            GameBG.Children.Clear();
            //将计时器变为0
            r = 0;
            time.Content = r + "s";
            //定义实参传进方法中
            rows = 10;
            boom = 10;
            //调用方法创建网格线,创建游戏区域中的元素
            seeMap(rows);
            seeGame(rows,boom);
        }

        //初始化游戏区域网格线
        private void seeMap(int rows )
        {

            for (int i = 0; i < rows; i++)
            {
                //在游戏区域实例化行
                RowDefinition row = new RowDefinition();
                //row.Height = new GridLength(40);
                
                //将创建的行添加进游戏区域
                GameBG.RowDefinitions.Add(row);
                //在游戏区域实例化列
                ColumnDefinition colum = new ColumnDefinition();
                //colum.Width = new GridLength(40);
                //将创建的列添加进游戏区域
                GameBG.ColumnDefinitions.Add(colum);
            }
            //设置网格线在游戏区域中可见
            GameBG.ShowGridLines = true;
        }

        Random rd = new Random();
        void seeGame( int rows ,int boom)
        {
            numboom.Content = boom.ToString();
            //设置二维数组大小
            maps = new int[rows,rows];
            images = new Image[rows, rows];
            bomOrgo = new bool[rows, rows];
            //实例化雷数让maps数组中为1的位置为雷
            for (int i=0;i<boom;i++)
            {
                int row = rd.Next(0,maps.GetLength(0));
                int colum = rd.Next(0,maps.GetLength(1));
                if (maps[row,colum]==1)
                {
                    i--;
                }
                else
                {
                    maps[row, colum] = 1;
                }
            }
            //初始化地图--添加地砖图片
            for (int i=0;i<maps.GetLength(0);i++)
            {
                for (int j=0;j<maps.GetLength(1);j++)
                {
                    //在遍历到的每一个位置实例化一个图片
                    images[i,j] = new Image();
                    //添加图片路径
                    images[i, j].Source = new BitmapImage(new Uri("/../../img/zhuan.gif", UriKind.Relative));
                    //设置图片margin
                    images[i, j].Width = 36;
                    images[i, j].Height = 36;
                    images[i, j].Margin = new Thickness(2,2,2,2);
                    //将图片添加进对应的网格区域
                    Grid.SetRow(images[i, j], i);
                    Grid.SetColumn(images[i,j],j);
                    images[i, j].Tag = new int[2] { i, j };
                    GameBG.Children.Add(images[i, j]);
                    //添加鼠标左键事件
                    images[i, j].MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;
                    //添加鼠标右键时间
                    images[i, j].MouseRightButtonDown += MainWindow_MouseRightButtonDown;
                }
            }
        }
        //设置鼠标右键点击图片事件
        private void MainWindow_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //通过sensender来判断点击的是谁
            Image img = sender as Image;
            //将图片路径改变为旗帜
            img.Source = new BitmapImage(new Uri("/../../img/qizi.gif", UriKind.Relative));
        }
        //设置鼠标左键点击图片事件
        private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //通过sender获取到点的是哪个图片
            Image img=sender as Image;
            //将获取到的图片的tag值赋给新建的index
            int[] index = img.Tag as int[];
            if (!IsBoom(index[0],index[1]))
            {
                //判断点击的如果不是雷而是空白,则向四周扩散,遇到数字停止
                //相邻的方块中最少存在3个雷(四个角),最多存在8个雷
                //若用(i,j)代表当前点击的位置,
                //则四周为(i-1,j-1)(i-1,j)(i-1,j+1)(i,j-1)(i,j+1)(i+1,j-1)(i+1,j)(i+1,j+1)
                CountMine(index[0],index[1],img);
                //定义一个变量来接收剩余的雷数
                int left = 0;
                //遍历数组,判断剩余的砖是否翻开
                for (int i=0;i<bomOrgo.GetLength(0);i++)
                {
                    for (int j=0;j<bomOrgo.GetLength(1);j++)
                    {
                        //判断该位置是否是false,如果是说明该位置未翻开
                        if (bomOrgo[i,j]==false)
                        {
                            left++;
                        }
                    }
                    
                }
                //判断剩下的是不是都为雷,如果未翻开的数量等于雷数则游戏胜利
                if (left == boom)
                {
                    //如果只剩地雷,则翻开所有的地雷
                    for (int i=0;i<maps.GetLength(0);i++)
                    {
                        for (int j=0;j<maps.GetLength(1);j++)
                        {
                            if (maps[i, j] == 1)
                            {
                                images[i, j].Source = new BitmapImage(new Uri("/../../img/lei.gif", UriKind.Relative));
                            }
                        }
                    }
                    timer.Stop();
                    try
                    {
                    FileStream file = new FileStream("../../file/chuji.txt", FileMode.Append, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(file);
                    string fenshu = r.ToString();
                    //string fenshu = time.Content.ToString();
                    writer.WriteLine(fenshu+";");
                    writer.Close();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }


                    MessageBoxResult t=MessageBox.Show("恭喜通关","",MessageBoxButton.OK);
                    if (t==MessageBoxResult.OK)
                    {
                        MessageBoxResult s = MessageBox.Show("下一关", "退出", MessageBoxButton.YesNo);
                        if (s==MessageBoxResult.Yes)
                        {
                            r = 0;  
                            time.Content = r + "s";
                            timer.Start();
                            //重新刷新游戏必须清空游戏区域已有东西
                            GameBG.RowDefinitions.Clear();
                            GameBG.ColumnDefinitions.Clear();
                            GameBG.Children.Clear();
                            //每次通过雷数加1,地砖行数列数分别加一
                            rows++;
                            boom++;
                            seeMap(rows);
                            seeGame(rows,boom);
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                //如果点击的位置是雷,那么图片改为雷
                images[index[0], index[1]].Source = new BitmapImage(new Uri("/../../img/lei.gif", UriKind.Relative));
                for (int i = 0; i < maps.GetLength(0); i++)
                {
                    for (int j = 0; j < maps.GetLength(1); j++)
                    {
                        if (maps[i, j] == 1)
                        {
                            images[i, j].Source = new BitmapImage(new Uri("/../../img/lei.gif", UriKind.Relative));
                        }
                    }
                }
                MessageBoxResult z=MessageBox.Show("bom bom bom你死了","",MessageBoxButton.OK);
                if (z==MessageBoxResult.OK)
                {
                    FileStream fileStream = new FileStream("../../file/chuji.txt",FileMode.Append, FileAccess.Write);
                    StreamWriter ww = new StreamWriter(fileStream);
                    ww.Write(0+"\r\n");
                    r = 0;
                    time.Content = r + "s";
                    GameBG.Children.Clear();
                    rows=10;
                    boom = 10;
                    seeGame(rows,boom);
                }
            }
        }
        //定义一个方法来判断点中的是否是雷
        bool IsBoom(int i,int j)
        {
            //判断是否超出游戏范围,如果超出返回false
            if (i<0||j<0||i>=maps.GetLength(0)||j>=maps.GetLength(1))
            {
                return false;
            }
            else
            {
                //判断是否是雷,如果是返回true
                if (maps[i,j]==1)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
        }
        void CountMine(int i,int j,Image img)
        {
            
            //判断当前位置是否判断过,如果判断过则跳出---作用防止反复判断自己造成死循环
            if (bomOrgo[i,j]==true)
            {
                return;
            }
            //将当前位置设置为true
            bomOrgo[i,j] = true;
            //创建一个变量来接收地雷数
            int count = 0;
            //判断当前位置四周的八个方向是否为雷,如果是则count++
            if (IsBoom(i - 1, j - 1))
            {
                count++;
            }
            if (IsBoom(i-1,j))
            {
                count++;
            }
            if (IsBoom(i - 1, j+1))
            {
                count++;
            }
            if (IsBoom(i, j-1))
            {
                count++;
            }
            if (IsBoom(i , j+1))
            {
                count++;
            }
            if (IsBoom(i +1, j-1))
            {
                count++;
            }
            if (IsBoom(i + 1, j))
            {
                count++;
            }
            if (IsBoom(i + 1, j+1))
            {
                count++;
            }
            //判断如果当前位置的8个方向都没有雷,则再以八个方向为中心重复调用自己这个方法往外判断
            if (count==0)
            {
                GameBG.Children.Remove(img);
                //外部if保证数组不超出索引
                if (i>0)
                {
                    CountMine(i - 1, j,images[i-1,j]);
                    if (j>0)
                    {
                        CountMine(i-1,j-1, images[i - 1, j-1]);
                    }
                }
                if (i<maps.GetLength(0)-1)
                {
                    CountMine(i + 1, j,images[i + 1, j]);
                }
                if (i>0&&j<maps.GetLength(1)-1)
                {
                    CountMine(i - 1, j + 1, images[i - 1, j+1]);
                }
                if (j<maps.GetLength(1)-1)
                {
                    CountMine(i , j+1, images[i, j+1]);
                }
                if (j>0)
                {
                    CountMine(i, j - 1, images[i , j-1]);
                }
                if (i < maps.GetLength(1)-1&&j>0)
                {
                    CountMine(i + 1, j - 1, images[i + 1, j-1]);
                }
                if (i < maps.GetLength(0)-1&& j < maps.GetLength(1)-1)
                {
                    CountMine(i + 1, j+1, images[i + 1, j+1]);
                }
            }
            else
            {
                //移除该处图片
                GameBG.Children.Remove(img);
                //实例化label
                Label lb = new Label();
                lb.Content = count.ToString();
                //将label设置网格的相应位置处
                Grid.SetRow(lb, i);
                Grid.SetColumn(lb, j);
                lb.FontSize = 24;
                //设置label水平居中
                lb.HorizontalContentAlignment = HorizontalAlignment.Center;
                //设置label竖直居中
                lb.VerticalContentAlignment = VerticalAlignment.Center;
                GameBG.Children.Add(lb);
            }
        }
    }
}
