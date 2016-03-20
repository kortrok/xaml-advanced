using System;
using Windows.UI;
using Windows.UI.Xaml.Data;

namespace RestaurantManager.Extensions
{
    public sealed class BoolToColorConverter : IValueConverter
    {
        public Color TrueColor { get; set; }
        public Color FalseColor { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value is bool ? (bool)value ? TrueColor : FalseColor : Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value is Color && (Color)value == TrueColor;
        }
    }
}
