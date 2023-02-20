using System.Windows.Controls;
using iphelper;

namespace netwatch.IpTable
{
    public class TcpViewModelDataType
    {
        public TcpViewModelDataType(TcpRow data)
        {
            Data = data;
            ProccessIcon = new Image();
            ImageName = "Skipped";
            FullPath = "Skipped";
        }

        public TcpViewModelDataType(TcpRow data, Image icon, string name, string path)
        {
            Data = data;
            ProccessIcon = icon;
            ImageName = name;
            FullPath = path;
        }

        public string Protocol
        {
            get { return "TCP"; }
        }

        public TcpRow Data { get; set; }

        public Image ProccessIcon { get; set; }

        public string ImageName { get; set; }

        public string FullPath { get; set; }
    }
}