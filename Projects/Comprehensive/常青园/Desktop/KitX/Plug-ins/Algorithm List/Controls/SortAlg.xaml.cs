using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Algorithm_List.Controls
{
    /// <summary>
    /// SortAlg.xaml 的交互逻辑
    /// </summary>
    public partial class SortAlg : UserControl
    {
        public MainWindow win;

        public SortAlg()
        {
            InitializeComponent();
        }

        private string[] algs = new string[6]
        {
            "crpx", "mppx", "dpx", "kspx", "tpx", "gbpx"
        };

        private void ReloadSortPanelSources()
        {
            if (!Directory.Exists($"{win.WorkBase}\\codes"))
            {
                Directory.CreateDirectory($"{win.WorkBase}\\codes");
            }
            for (int i = 0; i < algs.Length; i++)
            {
                string fp = $"{win.WorkBase}\\codes\\{algs[i]}.txt";
                if (!File.Exists(fp))
                {
                    new Thread(() =>
                    {
                        if (Library.NetHelper.NetHelper.IsWebConected("42.193.5.54", 3000))
                        {
                            Library.NetHelper.NetHelper.WebDownloadFile("https://source.catrol.cn/codes/Algorithm_List/" + $"{algs[i - 1]}.txt", fp);
                            string text = Library.FileHelper.FileHelper.ReadAll(fp);
                            Dispatcher.BeginInvoke(new Action(() =>
                            {
                                switch (i)
                                {
                                    case 0:
                                        crpx.Text = text;
                                        break;
                                    case 1:
                                        mppx.Text = text;
                                        break;
                                    case 2:
                                        dpx.Text = text;
                                        break;
                                    case 3:
                                        kspx.Text = text;
                                        break;
                                    case 4:
                                        tpx.Text = text;
                                        break;
                                    case 5:
                                        gbpx.Text = text;
                                        break;
                                }
                            }));
                        }                        
                    }).Start();
                }
                else
                {
                    string text = Library.FileHelper.FileHelper.ReadAll(fp);
                    switch (i)
                    {
                        case 0:
                            crpx.Text = text;
                            break;
                        case 1:
                            mppx.Text = text;
                            break;
                        case 2:
                            dpx.Text = text;
                            break;
                        case 3:
                            kspx.Text = text;
                            break;
                        case 4:
                            tpx.Text = text;
                            break;
                        case 5:
                            gbpx.Text = text;
                            break;
                    }
                }
            }
        }

        private void ReloadSortPanel_Click(object sender, RoutedEventArgs e) => ReloadSortPanelSources();
    }
}
