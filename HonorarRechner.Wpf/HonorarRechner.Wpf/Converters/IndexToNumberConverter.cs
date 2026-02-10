using System;
using System.Globalization;
using System.Windows.Data;

namespace HonorarRechner.Wpf.Converters
{
    public class IndexToNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int index)
            {
                return $"{index + 1})";
            }

            return "1)";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
