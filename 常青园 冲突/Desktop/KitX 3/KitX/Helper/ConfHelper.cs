using KitX.info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Xml;

namespace KitX.Helper
{
    public class ConfHelper
    {
        public runninginfo runninginfo;

        public ConfHelper(ref runninginfo runninginfo) => this.runninginfo = runninginfo ?? new runninginfo();

        public void LoadConf(string fp)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(fp);
            XmlNodeList nodes = xdoc.SelectNodes("/kitx/app");
            foreach (XmlNode item in nodes.Item(0).ChildNodes)
            {
                switch (item.Name)
                {
                    case "lastTheme":

                        break;
                    case "lastLanguage":
                        runninginfo.Now_Lang = StrToLang(item.InnerText);
                        break;
                    case "ranTimes":
                        item.InnerText = (int.Parse(item.InnerText.Trim()) + 1).ToString();
                        break;
                }
            }
            xdoc.Save(fp);
        }

        public Set.Language StrToLang(string str)
        {
            switch (str)
            {
                case "zh_cn": return Set.Language.zh_cn;
                case "zh_cnt": return Set.Language.zh_cnt;
                case "en_us": return Set.Language.en_us;
                case "ja_jp": return Set.Language.ja_jp;
                default: return Set.Language.zh_cn;
            }
        }

        public Set.UITheme StrToTheme(string str)
        {
            switch (str)
            {
                case "Light": return Set.UITheme.Light;
                case "Dark": return Set.UITheme.Dark;
                default: return Set.UITheme.Light;
            }
        }
    }
}
