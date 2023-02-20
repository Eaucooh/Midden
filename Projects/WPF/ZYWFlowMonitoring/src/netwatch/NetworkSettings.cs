using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace netwatch
{
    public class NetworkSettings
    {
        #region AdoptorSettings enum

        public enum AdoptorSettings
        {
            AllTraffic,
            LocalOnly,
            InternetOnly,
            Custom
        }

        #endregion

        #region UnitTypes enum

        public enum UnitTypes
        {
            KBytepers,
            KBitepers
        }

        #endregion

        public AdoptorSettings Adoptors;
        public List<NetworkInterface> Interfaces = new List<NetworkInterface>();
        public UnitTypes Unit;
        // 下载于www.mycodes.net
        public NetworkSettings()
        {
            Adoptors = AdoptorSettings.AllTraffic;
            Unit = UnitTypes.KBytepers;
        }

        public NetworkSettings(AdoptorSettings adoptors, UnitTypes unit)
        {
            Adoptors = adoptors;
            Unit = unit;
        }

        public string InterfacesToString()
        {
            return Adoptors.ToString();
        }
    }
}