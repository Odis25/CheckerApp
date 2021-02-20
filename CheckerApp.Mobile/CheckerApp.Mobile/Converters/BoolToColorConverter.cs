using System;
using System.Globalization;
using Xamarin.Forms;

namespace CheckerApp.Mobile.Converters
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ? Device.GetNamedColor("Green") : Device.GetNamedColor("Red");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
