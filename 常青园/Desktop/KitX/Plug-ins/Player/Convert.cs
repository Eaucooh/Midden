using System;
using System.Globalization;
using System.Windows.Data;

namespace Player
{
    [ValueConversion(typeof(double), typeof(int))]
    public class GetVolIndex : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double vol = System.Convert.ToDouble(value);
            if (vol == 0)
            {
                return 0;
            }
            else if (0 < vol && vol < 0.33)
            {
                return 1;
            }
            else if (0.33 <= vol && vol < 0.66)
            {
                return 2;
            }
            else if (0.66 <= vol && vol <= 1)
            {
                return 3;
            }
            else
            {
                return -1;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }

    [ValueConversion(typeof(double), typeof(string))]
    public class GetProgressTime : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TimeSpan ts = new TimeSpan(0, 0, System.Convert.ToInt32(value));
            string str = null;
            if (ts.Hours > 0)
            {
                string hh = ts.Hours < 10 ? $"0{ts.Hours}" : ts.Hours.ToString();
                string mm = ts.Minutes < 10 ? $"0{ts.Minutes}" : ts.Minutes.ToString();
                string ss = ts.Seconds < 10 ? $"0{ts.Seconds}" : ts.Seconds.ToString();
                str = $"{hh}:{mm}:{ss}";
            }
            if (ts.Hours == 0 && ts.Minutes > 0)
            {
                string mm = ts.Minutes < 10 ? $"0{ts.Minutes}" : ts.Minutes.ToString();
                string ss = ts.Seconds < 10 ? $"0{ts.Seconds}" : ts.Seconds.ToString();
                str = $"00:{mm}:{ss}";
            }
            if (ts.Hours == 0 && ts.Minutes == 0)
            {
                string ss = ts.Seconds < 10 ? $"0{ts.Seconds}" : ts.Seconds.ToString();
                str = $"00:00:{ss}";
            }
            return str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TimeSpan ts = new TimeSpan(0, 0, System.Convert.ToInt32(value));
            string str = null;
            if (ts.Hours > 0)
            {
                str = $"{ts.Hours}:{ts.Minutes}:{ts.Seconds}";
            }
            if (ts.Hours == 0 && ts.Minutes > 0)
            {
                string mm = ts.Minutes < 10 ? $"0{ts.Minutes}" : ts.Minutes.ToString();
                string ss = ts.Seconds < 10 ? $"0{ts.Seconds}" : ts.Seconds.ToString();
                str = $"{mm}:{ss}";
            }
            if (ts.Hours == 0 && ts.Minutes == 0)
            {
                string ss = ts.Seconds < 10 ? $"0{ts.Seconds}" : ts.Seconds.ToString();
                str = $"00:{ss}";
            }
            return str;
        }
    }

    [ValueConversion(typeof(double), typeof(string))]
    public class GetMuted : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => System.Convert.ToDouble(value) == 0.00;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}
