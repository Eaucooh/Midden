using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemWatcherTest
{
    class Watcher
    {

        public MyWatcher(dynamic FormTest, string path)
        {
            this.FormTest = FormTest;
            this.Path = path;
        }
        private FileSystemWatcher watcher = null;
        private dynamic FormTest;
        internal string Path
        {
            set
            {
                //watcher.Path = value;
                WatcherStrat(value);
            }
        }
        private void WatcherStrat(string path)
        {
            if (watcher == null)
            {
                watcher = new FileSystemWatcher();
                System.IO.FileInfo f = new FileInfo(path);
                watcher.Path = f.DirectoryName;
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.EnableRaisingEvents = true;
                watcher.NotifyFilter = NotifyFilters.Attributes |
                                       NotifyFilters.CreationTime |
                                       NotifyFilters.DirectoryName |
                                       NotifyFilters.FileName |
                                       NotifyFilters.LastAccess |
                                       NotifyFilters.LastWrite |
                                       NotifyFilters.Security |
                                       NotifyFilters.Size;
                watcher.IncludeSubdirectories = true;
                watcher.Filter = "*" + f.Extension;
            }
            else
            {
                System.IO.FileInfo f = new FileInfo(path);
                watcher.Path = f.FullName;
                watcher.Filter = "*" + f.Extension;
            }
        }
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            FormTest.TxtChanged(watcher.Path + "\\" + e.Name);
        }
    }
}