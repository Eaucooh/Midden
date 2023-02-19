using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Xml;

namespace KitX.Updater
{
    public class KitXComponent
    {
        public string name { get; set; }
        public string path { get; set; }
        public string localVer { get; set; }
        public string ltsVer { get; set; }
        public long size { get; set; }
        public bool uper { get; set; }
        public string oper { get; set; }

        public void init()
        {
            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                ltsVer = wc.DownloadString($"https://source.catrol.cn/download/works/kitx/vers/{name}.txt");
            }
        }

        public static int[] getVers(string ver)
        {
            string[] vers = ver.Split('.');
            int[] version = new int[3];
            for (int i = 0; i < 3; i++)
            {
                version[i] = int.Parse(vers[i]);
            }
            return version;
        }

        public bool ShouldUpdate()
        {
            string ver = "", localTmp = localVer;
            if (ltsVer.StartsWith('v'))
            {
                ver = ltsVer.Substring(1);
            }
            if (localTmp.StartsWith('v'))
            {
                localTmp = localVer.Substring(1);
            }
            int[] upg = getVers(ver), now = getVers(localTmp);
            if(upg[0] > now[0])
            {
                return true;
            }
            else if(upg[1] > now[1])
            {
                return true;
            }
            else if(upg[2] > now[2])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<KitXComponent> datas = new List<KitXComponent>();
        private string kitxPath = new DirectoryInfo(Environment.CurrentDirectory).Parent.FullName;
        private string confPath = new DirectoryInfo(Environment.CurrentDirectory).Parent.FullName + "\\Config\\upgradeconfig.xml";

        public MainWindow()
        {
            InitializeComponent();
            XmlDocument doc = new XmlDocument();
            doc.Load(confPath);
            XmlElement root = doc.DocumentElement;
            foreach (XmlNode node in root.ChildNodes)
            {
                string path = node.Attributes["path"].InnerText;
                foreach (XmlNode item in node.ChildNodes)
                {
                    KitXComponent kc = new KitXComponent()
                    {
                        name = item.Attributes["file"].InnerText,
                        localVer = item.Attributes["version"].InnerText,
                        size = long.Parse(item.Attributes["size"].InnerText)
                    };
                    kc.path = path.Replace("..", kitxPath) + kc.name;
                    kc.init();
                    kc.oper = kc.ShouldUpdate() ? "更新" : "无需更新";
                    datas.Add(kc);
                }
            }
            dataGrid.ItemsSource = datas;
            Opacity = 0;
            Loaded += (_, _) =>
            {
                CubicEase ce = new CubicEase()
                {
                    EasingMode = EasingMode.EaseOut
                };
                BeginAnimation(OpacityProperty, new DoubleAnimation()
                {
                    From = 0,
                    To = 1,
                    Duration = new TimeSpan(0, 0, 0, 0, 500),
                    EasingFunction = ce,
                    FillBehavior = FillBehavior.HoldEnd
                });
            };
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if(e.ButtonState == MouseButtonState.Pressed && e.ChangedButton == MouseButton.Left)
            //{
            //    DragMove();
            //}
            if(Mouse.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
