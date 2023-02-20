using System.Globalization;

namespace netwatch
{
    public static class Helper
    {
        public static string UsageStringHelper(long number, NetworkSettings.UnitTypes unitType)
        {
            string str = unitType == NetworkSettings.UnitTypes.KBytepers ? "Bytes/s" : "Bites/s";

            if (unitType == NetworkSettings.UnitTypes.KBitepers)
                number *= 8;

            if (number >= 1000 && number < 1000000)
            {
                return (number/1000).ToString(CultureInfo.InvariantCulture) + " K" + str;
            }
            if (number >= 1000000 && number < 1000000000)
            {
                return (number/1000000).ToString(CultureInfo.InvariantCulture) + " M" + str;
            }
            if (number >= 1000000000)
            {
                return (number/1000000000).ToString(CultureInfo.InvariantCulture) + " G" + str;
            }
            if (number < 1000)
            {
                return number.ToString(CultureInfo.InvariantCulture) + " " + str;
            }
            return number.ToString(CultureInfo.InvariantCulture) + " " + str;
        }
    }
}