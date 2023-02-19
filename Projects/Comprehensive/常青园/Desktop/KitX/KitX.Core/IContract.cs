using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace KitX.Core
{
    /// <summary>
    /// 基本接口
    /// Version: 1.2.4
    /// </summary>

    [Description("基本接口 - Basic interface")]
    public interface IContract
    {
        /// <summary>
        /// 获取插件显示名称
        /// </summary>
        /// <returns></returns>
        string GetName();

        /// <summary>
        /// 获取插件版本号
        /// </summary>
        /// <returns></returns>
        string GetVersion();

        /// <summary>
        /// 获取插件出版商
        /// </summary>
        /// <returns></returns>
        string GetPublisher();

        /// <summary>
        /// 获取插件简单描述
        /// </summary>
        /// <returns></returns>
        string GetDescribe_Simple();

        /// <summary>
        /// 获取插件完整描述
        /// </summary>
        /// <returns></returns>
        string GetDescribe_Complex();

        /// <summary>
        /// 获取插件帮助链接
        /// </summary>
        /// <returns></returns>
        string GetHelpLink();

        /// <summary>
        /// 获取插件出版商主页链接
        /// </summary>
        /// <returns></returns>
        string GetHostLink();

        /// <summary>
        /// 获取此插件支持的语言
        /// </summary>
        /// <returns></returns>
        Languages GetLang();

        /// <summary>
        /// 获取此插件图标
        /// </summary>
        /// <returns></returns>
        BitmapImage GetIcon();

        /// <summary>
        /// 获取插件主窗体
        /// </summary>
        /// <returns></returns>
        Window GetWindow();

        /// <summary>
        /// 通知插件启动
        /// </summary>
        void Start();

        /// <summary>
        /// 通知插件结束
        /// </summary>
        void End();

        /// <summary>
        /// 通知插件设置主题色
        /// </summary>
        /// <param name="theme"></param>
        void SetTheme(Theme theme);

        /// <summary>
        /// 获取插件文件名
        /// </summary>
        /// <returns></returns>
        string GetFileName();

        /// <summary>
        /// 获取 QuickView
        /// </summary>
        /// <returns>QuickView</returns>
        UserControl GetQuickView();

        /// <summary>
        /// 获取标签
        /// </summary>
        /// <returns>标签</returns>
        Tags GetTag();

        /// <summary>
        /// 设定插件的临时路径
        /// </summary>
        void SetWorkBase(string path);
    }

    /// <summary>
    /// 标签
    /// </summary>
    public enum Tags
    {
        Process, Program, Normal, Design, System
    }

    /// <summary>
    /// 语言
    /// </summary>
    public enum Languages
    {
        general, zh_CN, en_US, zh_CHT, ja_JP
    }

    /// <summary>
    /// 主题
    /// </summary>
    public enum Theme
    {
        Light, Dark
    }
}
