using System;
using System.Windows.Controls;
using iphelper;

namespace netwatch.IpTable
{
    public class TaskItemQuick
    {
        public TaskItemQuick(Image img, string processName, Int32 pid)
        {
            ProcessName = processName;
            ProccessIcon = img;
            ProcessId = pid;
        }

        public string ProcessName { get; set; }

        public Image ProccessIcon { get; set; }

        public Int32 ProcessId { get; set; }
    }

    public class TaskItemDetailed : IComparable
    {
        public string Protocol
        {
            get { return "TCP"; }
        }

        public TaskItemDetailed(string processName, Int32 pid, TcpRow data, string processPath, Image processIcon)
        {
            ProcessName = processName;
            ProcessId = pid;
            InnerData = data;
            ProcessPath = processPath;
            ProcessIcon = processIcon;
        }

        public TaskItemDetailed(TaskItemDetailed data)
        {
            ProcessId = data.ProcessId;
            InnerData = data.InnerData;
            ProcessIcon = data.ProcessIcon;
            ProcessName = data.ProcessName;
            ProcessPath = data.ProcessPath;
        }

        public override int GetHashCode()
        {
            return InnerData.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            var taskItem = obj as TaskItemDetailed;

            if (taskItem == null)
                throw new ArgumentException("Object is not TaskItemDetailed");

            return this.ProcessName.CompareTo(taskItem.ProcessName);
        }

        //public override bool Equals(object obj)
        //{
        //    if (obj == null)
        //        return false;
        //    var data = obj as TcpRow;

        //    if (InnerData.Equals(data))
        //        return true;

        //    return false;
        //}

        public TcpRow InnerData { get; set; }

        public string ProcessName { get; set; }

        public Image ProcessIcon { get; set; }

        public Int32 ProcessId { get; set; }

        public string ProcessPath { get; set; }
    }
}