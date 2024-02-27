using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace csharp_project.Converters
{
    public class InitializedToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Assuming your uninitialized value is null or an empty string.
            // You may need to adjust this logic based on your actual data type and uninitialized state.
            if (value is string stringValue)
            {
                return string.IsNullOrEmpty(stringValue) ? Visibility.Collapsed : Visibility.Visible;
            }
            else
            {
                return value == null ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
