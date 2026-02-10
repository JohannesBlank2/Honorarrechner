using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace HonorarRechner.Wpf.Converters
{
    public class IndexToPastelBrushConverter : IValueConverter
    {
        private static readonly SolidColorBrush[] Brushes =
        {
            Create("#DDEEFF"),
            Create("#FFE2CC"),
            Create("#DDF4E3"),
            Create("#FFE0EE"),
            Create("#E6DDFF")
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int index)
            {
                var brush = Brushes[Math.Abs(index) % Brushes.Length];
                return brush;
            }

            return Brushes[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }

        private static SolidColorBrush Create(string hex)
        {
            var brush = (SolidColorBrush)new BrushConverter().ConvertFromString(hex)!;
            brush.Freeze();
            return brush;
        }
    }
}
