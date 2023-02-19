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
using System.Collections;
using System.Windows.Threading;

namespace SaoLei
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        private const int GRID_NUM = 480;//游戏格子数
        private const int GRID_ROWS = 16;//格子行数
        private const int GRID_COLS = 30;//格子列数
        private const int RANDOM_MINES_NUM = 99;//地雷数量

        private List<Button> deepGridButton = new List<Button>();//存储底层按钮的集合
        private List<Button> topGridButton = new List<Button>();//存储上层按钮的集合

        private DispatcherTimer timer = null;//计时器
        private enum TimeState
        {//计时器的三种状态
            Start,
            Pause,
            End
        }
        TimeState timeState = TimeState.End;//初始时间状态
        private TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, 0);
        private string str = "";

        public MainWindow()
        {
            InitializeComponent();
            Title = "扫雷";
            Panel.SetZIndex(GridBorder, 1);//设置边框的层级在其他控价之上
            deepGridButton.Insert(0, Deep0);
            //计时器初始化
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Tick += OnTimer;
            timer.IsEnabled = true;
            timer.Start();

            MinesCounter.Text = RANDOM_MINES_NUM.ToString();//剩余地雷数初始化
            CreateDeepMinesAndNums(RANDOM_MINES_NUM);
            CreateTopGridButton(GRID_NUM);
            Deep0.Click += Num0_Click;
        }

        //时间回调方法
        private void OnTimer(object sender, EventArgs e)
        {
            switch (timeState)
            {
                case TimeState.Start: timeSpan += new TimeSpan(0, 0, 0, 1); break;
                case TimeState.Pause: { } break;
                case TimeState.End: timeSpan = new TimeSpan(); break;
            }
            TimerText.Text = (timeSpan.Hours * 3600 + timeSpan.Minutes * 60 + timeSpan.Seconds).ToString();
        }

        private void Num0_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(str);//显示地雷的索引
        }

        Dictionary<string, int> DeepButtonIndexDict = new Dictionary<string, int>();//存储底层按钮名字索引的字典

        //创建底层的地雷和数字
        private void CreateDeepMinesAndNums(int n)
        {
            //生成指定个随机不相等的数
            List<int> randomList = new List<int>();
            for (int i = 0; i < n; i++)
            {
            tryAgain:
                Random ra = new Random();
                int num = ra.Next(0, GRID_NUM);
                if (randomList.Count != 0 && randomList.Contains(num))
                    goto tryAgain;
                else
                    randomList.Insert(i, num);
            }
            //创建底层按钮
            for (int i = 1; i < GRID_NUM; i++)
            {
                Button btn = new Button();
                btn.Name = "Deep" + i.ToString();
                btn.Width = 28;
                btn.Height = 28;
                btn.FontSize = 22;
                btn.FontWeight = FontWeights.Bold;
                btn.Background = Brushes.AliceBlue;
                if (randomList.Contains(i))
                    btn.Content = "雷";
                btn.MouseDown += DeepButtonBothClick;
                deepGridButton.Insert(i, btn);
                DeepButtonIndexDict.Add(btn.Name, i);
                DeepGrid.Children.Add(btn);
            }
            //随机数集合排序
            int temp;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (randomList[i] > randomList[j])
                    {
                        temp = randomList[i];
                        randomList[i] = randomList[j];
                        randomList[j] = temp;
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                str += randomList[i].ToString() + "...";
            }
            //对生成的数字再次处理
            for (int i = 0; i < GRID_NUM; i++)
            {
                if (!randomList.Contains(i))
                    deepGridButton[i].Content = CreateNumBaseOnMinesAround(i, randomList);
                if (deepGridButton[i].Content.ToString() == "0")
                    deepGridButton[i].Content = "";
                //处理数字颜色
                switch (deepGridButton[i].Content.ToString())
                {
                    case "1": deepGridButton[i].Foreground = Brushes.DeepSkyBlue; break;
                    case "2": deepGridButton[i].Foreground = Brushes.Green; break;
                    case "3": deepGridButton[i].Foreground = Brushes.OrangeRed; break;
                    case "4": deepGridButton[i].Foreground = Brushes.DarkBlue; break;
                    case "5": deepGridButton[i].Foreground = Brushes.DarkRed; break;
                    case "6": deepGridButton[i].Foreground = Brushes.LightSeaGreen; break;
                    default: { } break;
                }
            }
        }

        //底层按钮左右键同时按下，触发清除事件
        private void DeepButtonBothClick(Object sender, MouseButtonEventArgs e)
        {
            var btn = sender as Button;
            int n = DeepButtonIndexDict[btn.Name];
            //判断鼠标左右键同时按下的状态
            if (e.LeftButton == MouseButtonState.Pressed && e.RightButton == MouseButtonState.Pressed)
            {
                if (deepGridButton[n].Content.ToString() == "")
                    return;
                int minesCount = int.Parse(deepGridButton[n].Content.ToString());//按下的按钮的数字
                int flagCount = 0;
                //格子周围8格的索引
                int[] indexArr = { n - GRID_COLS - 1, n - GRID_COLS, n - GRID_COLS + 1, n - 1, n + 1, n + GRID_COLS - 1, n + GRID_COLS, n + GRID_COLS + 1 };
                for (int i = 0; i < indexArr.Length; i++)
                {
                    //最左边的格子，单独判断，排除左边三个格子索引
                    if (n % 30 == 0)
                    {
                        indexArr[0] = -1;
                        indexArr[3] = -1;
                        indexArr[5] = -1;
                    }
                    //右边的格子
                    if (n % 30 == 29)
                    {
                        indexArr[2] = -1;
                        indexArr[4] = -1;
                        indexArr[7] = -1;
                    }
                    if (indexArr[i] >= 0 && indexArr[i] < GRID_NUM)//筛掉范围之外的格子
                        if (topGridButton[indexArr[i]].Content.ToString() == "旗")
                            flagCount++;
                }
                if (flagCount == minesCount)
                    Clean8GridWithIndex(n);
            }
        }

        //根据周围的地雷数生成数字
        private string CreateNumBaseOnMinesAround(int n, List<int> randList)
        {
            int count = 0;
            //格子周围8格的索引
            int[] indexArr = { n - GRID_COLS - 1, n - GRID_COLS, n - GRID_COLS + 1, n - 1, n + 1, n + GRID_COLS - 1, n + GRID_COLS, n + GRID_COLS + 1 };
            for (int i = 0; i < indexArr.Length; i++)
            {
                //最左边的格子，单独判断，排除左边三个格子索引
                if (n % 30 == 0)
                {
                    indexArr[0] = -1;
                    indexArr[3] = -1;
                    indexArr[5] = -1;
                }
                //右边的格子
                if (n % 30 == 29)
                {
                    indexArr[2] = -1;
                    indexArr[4] = -1;
                    indexArr[7] = -1;
                }
                if (indexArr[i] >= 0 && indexArr[i] < GRID_NUM)//筛掉范围之外的格子
                    if (randList.Contains(indexArr[i]))
                        count++;
            }
            return count.ToString();
        }

        Dictionary<string, int> TopButtonIndexDict = new Dictionary<string, int>();//存储上层按钮名字索引的字典

        //创建上层按钮格子
        private void CreateTopGridButton(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Button btn = new Button();
                btn.Name = "Top" + i.ToString();
                btn.Height = 28;
                btn.Width = 28;
                btn.FontSize = 22;
                btn.Content = "";
                btn.Background = Brushes.LightBlue;
                btn.Foreground = Brushes.Red;
                btn.FontWeight = FontWeights.Bold;
                btn.Click += Btn_MouseLeftButtonDown;
                btn.MouseDown += Btn_MouseRightButtonDown;
                TopButtonIndexDict.Add(btn.Name, i);
                topGridButton.Insert(i, btn);
                TopGrid.Children.Insert(i, btn);
            }

        }

        //上层按钮左键点击事件
        private void Btn_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            if (timeState == TimeState.End)
                timeState = TimeState.Start;
            var btn = sender as Button;
            int index = TopButtonIndexDict[btn.Name];
            //如果点击的是雷，游戏结束
            if (deepGridButton[index].Content.ToString() == "雷")
            {
                FailText.Visibility = Visibility.Visible;
                timeState = TimeState.End;
                restart.Visibility = Visibility.Visible;
            }
            //如果点中的按钮下为空，周围8格同时消除
            if (deepGridButton[index].Content.ToString() == "")
            {
                Clean8GridWithIndex(index);
            }
            btn.Visibility = Visibility.Hidden;
        }

        //上层按钮右键点击事件
        private void Btn_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var btn = sender as Button;
            int minesCounter = int.Parse(MinesCounter.Text);
            if (btn.Content.ToString() == "")
            {
                btn.Content = "旗";
                minesCounter--;
            }
            else
            {
                btn.Content = "";
                minesCounter++;
            }
            MinesCounter.Text = minesCounter.ToString();
            if (minesCounter == 0)
            {//排雷成功
                WinText.Visibility = Visibility.Visible;
                timeState = TimeState.Pause;
                MessageBox.Show("恭喜你赢得了游戏，游戏记录为：" + TimerText.Text + "s");
            }
        }

        //根据索引排除周围8格
        private void Clean8GridWithIndex(int index)
        {
            //格子周围8格的索引
            int[] indexArr = { index - GRID_COLS - 1, index - GRID_COLS, index - GRID_COLS + 1, index - 1, index + 1, index + GRID_COLS - 1, index + GRID_COLS, index + GRID_COLS + 1 };
            for (int i = 0; i < indexArr.Length; i++)
            {
                //最左边的格子，单独判断，排除左边三个格子索引
                if (index % 30 == 0)
                {
                    indexArr[0] = -1;
                    indexArr[3] = -1;
                    indexArr[5] = -1;
                }
                //右边的格子
                if (index % 30 == 29)
                {
                    indexArr[2] = -1;
                    indexArr[4] = -1;
                    indexArr[7] = -1;
                }
                if (indexArr[i] >= 0 && indexArr[i] < GRID_NUM && topGridButton[indexArr[i]].Visibility == Visibility.Visible)//筛掉范围之外的格子
                {
                    if (deepGridButton[indexArr[i]].Content.ToString() == "雷")
                        continue;
                    topGridButton[indexArr[i]].Visibility = Visibility.Hidden;
                    if (deepGridButton[indexArr[i]].Content.ToString() == "")
                    {
                        Clean8GridWithIndex(indexArr[i]);//利用递归把周围可消除的空格都消除
                    }
                }
            }
        }        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Application.Restart();
            Application.Current.Shutdown();
        }
    }
}