using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ape_Converters
{
    public class WindowStateToBoolean : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Equals(WindowState.Normal))
            {
                return false;
            }
            else if (value.Equals(WindowState.Maximized))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class BooleanToWindowState : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return WindowState.Normal;
            }
            else
            {
                return WindowState.Maximized;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
