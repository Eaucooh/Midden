using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Library.FileHelper
{
    public class DirInfo
    {
        public static List<string> GetSubFolder(string path)
        {
            DirectoryInfo dirinfo = new DirectoryInfo(path);
            List<string> rst = new List<string>();
            foreach (DirectoryInfo item in dirinfo.GetDirectories())
            {
                rst.Add(item.FullName);
            }
            return rst;
        }

        public static List<string> GetSubFiles(string path)
        {
            DirectoryInfo dirinfo = new DirectoryInfo(path);
            List<string> rst = new List<string>();
            foreach (FileInfo item in dirinfo.GetFiles())
            {
                rst.Add(item.FullName);
            }
            return rst;
        }

        public static void SetOnTreeView(ref TreeView tv, string path)
        {
            List<string> ds = GetSubFolder(path);
            List<string> fs = GetSubFiles(path);
            foreach (string item in ds)
            {
                TreeViewItem tvi = new TreeViewItem()
                {
                    Header = Path.GetFileName(item),
                    Tag = item
                };
                SetTreeViewItem(ref tvi, item);
                tv.Items.Add(tvi);
            }
            foreach (string item in fs)
            {
                tv.Items.Add(new TreeViewItem()
                {
                    Header = Path.GetFileName(item),
                    Tag = item
                });
            }
        }

        public static void SetTreeViewItem(ref TreeViewItem tvi, string path)
        {
            List<string> ds = GetSubFolder(path);
            List<string> fs = GetSubFiles(path);
            foreach (string item in ds)
            {
                TreeViewItem tvii = new TreeViewItem()
                {
                    Header = Path.GetFileName(item),
                    Tag = item
                };
                SetTreeViewItem(ref tvii, item);
                tvi.Items.Add(tvii);
            }
            foreach (string item in fs)
            {
                tvi.Items.Add(new TreeViewItem()
                {
                    Header = Path.GetFileName(item),
                    Tag = item
                });
            }
        }
    }
}
