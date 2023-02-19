using System.Windows.Controls;

namespace TeamC
{
    /// <summary>
    /// Bubble.xaml 的交互逻辑
    /// </summary>
    public partial class Bubble : UserControl
    {
        public new string Content;
        public bool IsSendByMe;

        public Bubble()
        {
            InitializeComponent();
            Text.Text = Content;
            if(IsSendByMe)
            {
                Docker.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            }
            else
            {
                Docker.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            }
        }

        public Bubble(string content, bool isSendByMe)
        {
            InitializeComponent();
            Text.Text = content;
            if (isSendByMe)
            {
                Docker.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            }
            else
            {
                Docker.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            }
        }

        public void Dispose()
        {

        }
    }
}
