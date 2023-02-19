using System;
using System.Globalization;
using System.Windows.Data;

namespace Algorithm_List
{
    [ValueConversion(typeof(double), typeof(string))]
    public class Sin : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                double v = System.Convert.ToDouble(value);
                return Math.Sin(v).ToString("0.000");
            }
            catch
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw null;
    }

    [ValueConversion(typeof(double), typeof(string))]
    public class Cos : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                double v = System.Convert.ToDouble(value);
                return Math.Cos(v).ToString("0.000");
            }
            catch
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw null;
    }

    [ValueConversion(typeof(double), typeof(string))]
    public class Tan : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                double v = System.Convert.ToDouble(value);
                return Math.Tan(v).ToString("0.000");
            }
            catch
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw null;
    }
}

