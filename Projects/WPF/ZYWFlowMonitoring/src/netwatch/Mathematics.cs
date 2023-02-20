using System;
using System.Globalization;

namespace netwatch
{
    public static class Mathematics
    {
        public static long GetUpperRounded(long value)
        {
            int len = value.ToString(CultureInfo.InvariantCulture).Length;
            double returnValue = 1.0;
            for (int i = 1; i < len; i++)
            {
                returnValue *= 10;
            }
            returnValue = (Math.Round(4*value/returnValue, MidpointRounding.AwayFromZero)*returnValue)/4;
            // 下载于www.mycodes.net
            return (long) returnValue;
        }
    }
}