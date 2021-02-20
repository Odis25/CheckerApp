using System;
using System.Globalization;
using Xamarin.Forms;

namespace CheckerApp.Mobile.Converters
{
    public class BoolToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ? "Есть" : "Нет";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((string)value).Equals("есть", StringComparison.OrdinalIgnoreCase) ? true : false;
        }
    }
}
