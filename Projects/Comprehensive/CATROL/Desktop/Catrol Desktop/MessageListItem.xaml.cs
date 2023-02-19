using ape_Network;
using ape_UI.Animation;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Catrol_Desktop
{
    /// <summary>
    /// MessageListItem.xaml 的交互逻辑
    /// </summary>
    public partial class MessageListItem : UserControl
    {
        ThicknessAnimation DA_Expand;
        ThicknessAnimation DA_Shrink;
        BasicHelper basicHelper = new BasicHelper();
        Download download = new Download();
        Network_Info info = new Network_Info();
        string WorkBase = AppDomain.CurrentDomain.BaseDirectory;
        string HeadStorePath;
        string HeadBase;

        #region 新建 预览属性

        public string Title = "王二麻子";
        public string LastMessage = "你好，我是王二麻子，很高兴认识你";
        public int Hours = 14;
        public int Minutes = 38;
        public int NewMessages = 22;
        public string HeadUri = "";
        //https://is1-ssl.mzstatic.com/image/thumb/Purple124/v4/cb/2b/0e/cb2b0ee8-2869-ea58-3a14-719aeab468c7/AppIcon-0-0-1x_U007emarketing-0-0-0-8-0-0-85-220.png/128x128bb-80.jpg
        #endregion

        public MessageListItem()
        {
            InitializeComponent();
            Title_TextBlock.Text = Title;
            Message_Last_TextBlock.Text = LastMessage;
            Time_Hours.Text = Hours.ToString();
            Time_Minutes.Text = Minutes.ToString();
            Message_New_Number.Text = NewMessages.ToString();

            SetHead();
            Animationed();
        }

        public MessageListItem(string title, string lastMessage, int hours, int minutes, int newMessages, string headUri)
        {
            InitializeComponent();

            Title = title;
            LastMessage = lastMessage;
            Hours = hours;
            Minutes = minutes;
            NewMessages = newMessages;
            HeadUri = headUri;

            Title_TextBlock.Text = Title;
            Message_Last_TextBlock.Text = LastMessage;
            Time_Hours.Text = Hours.ToString();
            Time_Minutes.Text = Minutes.ToString();
            Message_New_Number.Text = NewMessages.ToString();

            SetHead();
            Animationed();
        }

        private void SetHead()
        {
            if (info.HasNetworkConect())
            {
                HeadBase = $"{WorkBase}\\Temp\\Images\\";
                HeadStorePath = $"{WorkBase}\\Temp\\Images\\{Title}{Path.GetExtension(HeadUri)}";
                if (!Directory.Exists(HeadBase))
                {
                    Directory.CreateDirectory(HeadBase);
                }
                if (download.DownloadFile_ByWebClient(HeadUri, HeadStorePath))
                {
                    ImageBrush imageBrush = new ImageBrush(new BitmapImage(new Uri(HeadStorePath)));
                    Header_Holder.Background = imageBrush;
                }
                //Header.Source = new BitmapImage(new Uri(HeadStorePath));
            }
        }

        private void Animationed()
        {
            DA_Expand = basicHelper.CreateThicknessAnimation(new TimeSpan(0, 0, 0, 0, 500), new Thickness(5),
                new Thickness(1), FillBehavior.HoldEnd, BasicHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0);
            DA_Shrink = basicHelper.CreateThicknessAnimation(new TimeSpan(0, 0, 0, 0, 500), new Thickness(1),
                new Thickness(5), FillBehavior.HoldEnd, BasicHelper.EasingFunction.Cubic, EasingMode.EaseOut, 0, 0);

            MouseEnter += MessageListItem_MouseEnter;
            MouseLeave += MessageListItem_MouseLeave;
        }

        private void MessageListItem_MouseEnter(object sender, MouseEventArgs e)
        {
            Container.BeginAnimation(MarginProperty, DA_Expand);
        }

        private void MessageListItem_MouseLeave(object sender, MouseEventArgs e)
        {
            Container.BeginAnimation(MarginProperty, DA_Shrink);
        }
    }
}
