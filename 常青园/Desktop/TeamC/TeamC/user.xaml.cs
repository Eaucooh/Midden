using System.Windows.Controls;

namespace TeamC
{
    /// <summary>
    /// user.xaml 的交互逻辑
    /// </summary>
    public partial class user : UserControl
    {
        public user()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 联系人项的构造方法
        /// </summary>
        /// <param name="ip">要显示的IP地址</param>
        /// <param name="dc">要显示的描述信息</param>
        public user(string ip, string dc)
        {
            InitializeComponent();
            IP.Text = ip; Go.ToolTip = dc;
        }
    }
}
