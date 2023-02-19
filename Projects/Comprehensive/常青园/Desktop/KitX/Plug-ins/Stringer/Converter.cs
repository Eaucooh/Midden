using System;
using System.Globalization;
using System.Windows.Data;

namespace Stringer
{
    [ValueConversion(typeof(string), typeof(int))]
    public class GetCNVerbs : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Library.TextHelper.Text.CharCount(Library.TextHelper.Chinese.Word_Verb, (string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Library.TextHelper.Text.CharCount(Library.TextHelper.Chinese.Word_Verb, (string)value);
        }
    }

    [ValueConversion(typeof(string), typeof(int))]
    public class GetLength : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value as string).Length;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value as string).Length;
        }
    }

    [ValueConversion(typeof(string), typeof(int))]
    public class GetHashCode : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value as string).GetHashCode();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value as string).GetHashCode();
        }
    }

    [ValueConversion(typeof(string), typeof(int))]
    public class Button_UTF : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (System.Convert.ToInt32(parameter) == 0)
            {
                return $"UTF-{(value as System.Windows.Controls.ComboBoxItem).Content} 编码";
            }
            else
            {
                return $"UTF-{(value as System.Windows.Controls.ComboBoxItem).Content} 解码";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (System.Convert.ToInt32(parameter) == 0)
            {
                return $"UTF-{(value as System.Windows.Controls.ComboBoxItem).Content} 编码";
            }
            else
            {
                return $"UTF-{(value as System.Windows.Controls.ComboBoxItem).Content} 解码";
            }
        }
    }

    [ValueConversion(typeof(string), typeof(int))]
    public class Format_FontSize : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $" 字号： {Math.Truncate((double)value)} px ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $" 字号： {Math.Truncate((double)value)} px ";
        }
    }

    [ValueConversion(typeof(string), typeof(string))]
    public class GetCharCounts : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Library.TextHelper.Text.CharCount(System.Convert.ToChar(parameter), (string)value).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Library.TextHelper.Text.CharCount(System.Convert.ToChar(parameter), (string)value).ToString();
        }
    }

    [ValueConversion(typeof(string), typeof(int))]
    public class FontSize : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{Math.Truncate((double)value)} px ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{Math.Truncate((double)value)} px ";
        }
    }

    [ValueConversion(typeof(string), typeof(int))]
    public class Volumn : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{Math.Truncate((double)value)}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{Math.Truncate((double)value)}";
        }
    }

    [ValueConversion(typeof(string), typeof(int))]
    public class ColorToSolid : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)value);
        }
    }

    [ValueConversion(typeof(string), typeof(int))]
    public class GetLines : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Library.TextHelper.Text.GetLines((string)value, Library.TextHelper.Text.GetLine_Type.Calculate).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Library.TextHelper.Text.GetLines((string)value, Library.TextHelper.Text.GetLine_Type.Calculate).ToString();
        }
    }

    [ValueConversion(typeof(string), typeof(string))]
    public class GetNums : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (parameter)
            {
                case "CN":
                    return Library.TextHelper.Text.GetNumCount((string)value, Library.TextHelper.Text.NumCount_Type.OnlyChineseNums).ToString();
                case "AB":
                    return Library.TextHelper.Text.GetNumCount((string)value, Library.TextHelper.Text.NumCount_Type.OnlyArabiaNums).ToString();
                case "BT":
                    return Library.TextHelper.Text.GetNumCount((string)value, Library.TextHelper.Text.NumCount_Type.Both).ToString();
                default:
                    return Library.TextHelper.Text.GetNumCount((string)value, Library.TextHelper.Text.NumCount_Type.Both).ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (parameter)
            {
                case "CN":
                    return Library.TextHelper.Text.GetNumCount((string)value, Library.TextHelper.Text.NumCount_Type.OnlyChineseNums).ToString();
                case "AB":
                    return Library.TextHelper.Text.GetNumCount((string)value, Library.TextHelper.Text.NumCount_Type.OnlyArabiaNums).ToString();
                case "BT":
                    return Library.TextHelper.Text.GetNumCount((string)value, Library.TextHelper.Text.NumCount_Type.Both).ToString();
                default:
                    return Library.TextHelper.Text.GetNumCount((string)value, Library.TextHelper.Text.NumCount_Type.Both).ToString();
            }
        }
    }

    [ValueConversion(typeof(string), typeof(int))]
    public class GetPWDLength : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((int)value)
            {
                case 0:
                    return 4;
                case 1:
                    return 4;
                case 2:
                    return 8;
                case 3:
                    return 16;
                case 4:
                    return 16;
                default:
                    return 4;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((int)value)
            {
                case 0:
                    return 4;
                case 1:
                    return 4;
                case 2:
                    return 8;
                case 3:
                    return 16;
                case 4:
                    return 16;
                default:
                    return 4;
            }
        }
    }
}
