using CheckerApp.Mobile.Common.Enums;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace CheckerApp.Mobile.Converters
{
    public class HardwareTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((HardwareType)value).GetDisplayName();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
