using KitX.Core;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KitX
{
    /// <summary>
    /// 工具栏控制类
    /// </summary>
    public class AppsBar_Controller
    {
        /// <summary>
        /// 新建工具栏实例
        /// </summary>
        AppsBar bar = new AppsBar();

        /// <summary>
        /// 添加工具
        /// </summary>
        /// <param name="item">接口实例</param>
        /// <param name="icon">图标</param>
        /// <param name="name"></param>
        public void AddTool(IContract item, BitmapImage icon, string name) => bar.AddTool(item, icon, name);

        /// <summary>
        /// 移除工具
        /// </summary>
        /// <param name="name">工具名称</param>
        public void RemoveTool(string name) => bar.RemoveTool(name);

        /// <summary>
        /// 刷新主题
        /// </summary>
        public void RefreshTheme() => bar.RefreshBackground();

        /// <summary>
        /// 通知刷新工具主题
        /// </summary>
        /// <param name="tem"></param>
        public void RefreshToolTheme(Core.Theme tem)
        {
            bar.RefreshToolTheme(tem);
            bar.NowTheme = tem;
        }

        public enum Fore { black, white }

        /// <summary>
        /// 设置前景色
        /// </summary>
        /// <param name="fore"></param>
        public void SetForeground(Fore fore)
        {
            switch (fore)
            {
                case Fore.black:
                    bar.Foreground = new SolidColorBrush(Colors.Black);
                    break;
                case Fore.white:
                    bar.Foreground = new SolidColorBrush(Colors.White);
                    break;
            }
        }

        /// <summary>
        /// 显示工具栏
        /// </summary>
        public void Show() => bar.Show();

        /// <summary>
        /// 隐藏工具栏
        /// </summary>
        public void Hide() => bar.Hide();

        /// <summary>
        /// 关闭工具栏
        /// </summary>
        public void Close()
        {
            bar.CanCloseNow = true;
            bar.Close();
            bar = null;
            bar = new AppsBar();
        }

        /// <summary>
        /// 完全退出工具栏
        /// </summary>
        public void Quit()
        {
            bar.CanCloseNow = true;
            bar.Close();
        }

        /// <summary>
        /// 锁定
        /// </summary>
        public void Lock() => bar.Locker(true);

        /// <summary>
        /// 解锁
        /// </summary>
        public void UnLock() => bar.Locker(false);

        /// <summary>
        /// 选择appsBar的位置
        /// </summary>
        /// <param name="loc"></param>
        public void SelectLocation(int loc) => bar.LS.SelectedIndex = loc;
    }
}
