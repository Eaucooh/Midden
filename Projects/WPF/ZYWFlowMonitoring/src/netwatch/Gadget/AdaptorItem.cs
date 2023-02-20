using System.Net.NetworkInformation;

namespace netwatch.Gadget
{
    public class AdaptorItem
    {
        public AdaptorItem(string adaptorName, NetworkInterface netInterface)
        {
            AdaptorName = adaptorName;
            NetInterface = netInterface;
            IsSelected = false;
        }

        public string AdaptorName { get; set; }
        public NetworkInterface NetInterface { get; set; }
        public bool IsSelected { get; set; }
    }
}