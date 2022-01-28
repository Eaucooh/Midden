using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace KitX.Core
{
    /// <summary>
    /// Web应用接口
    /// Version: 1.0.0
    /// </summary>

    [Description("WebApp接口 - WebApp interface")]
    public interface IWebApp
    {

        /// <summary>
        /// 获取插件工作方式
        /// </summary>
        /// <returns>Web - 在线网页工作; Local - 本地网页工作</returns>
        WorkPath GetPluginWorkPath();

        #region 在线运行的接口

        /// <summary>
        /// 获取应用URI
        /// </summary>
        /// <returns></returns>
        URI GetUri();

        /// <summary>
        /// 获取WebApp将要呈现的分辨率
        /// </summary>
        /// <returns></returns>
        Point GetDpi();

        /// <summary>
        /// 获取应用在线图标
        /// </summary>
        /// <returns>图标网址</returns>
        URI GetIconPath();

        #endregion

        #region 本地运行的接口

        /// <summary>
        /// 设定插件工作目录
        /// </summary>
        /// <param name="path"></param>
        void SetWorkBase(string path);

        #endregion
    }

    public enum WorkPath
    {
        Web, Local
    }

    public enum Head
    {
        http, https
    }

    public class URI
    {
        /// <summary>
        /// 返回一个标准URI
        /// </summary>
        /// <param name="head">域名头 http/https</param>
        /// <param name="secondary">二级域名 如 www / @</param>
        /// <param name="域名">域名 如 baidu.com</param>
        /// <param name="path">详细路径 如 /img/main.jpg</param>
        /// <param name="参数">参数 如 p=35;length=81;</param>
        /// <returns>标准URI</returns>
        public static string GetURI(Head head, string secondary, string 域名, string path, string 参数) => $"{(head == Head.http ? "http://" : "https://")}{secondary}.{域名}{path}?{参数}";
    }
}
