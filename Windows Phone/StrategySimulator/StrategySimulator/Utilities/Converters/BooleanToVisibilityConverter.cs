using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StrategySimulator.Utilities.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        /// <summary>
        /// Todo Add Description
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool?)
            {
                value = ((bool?)value).Value;
            }

            if (value is bool)
            {
                return (bool)value ? Visibility.Visible : Visibility.Collapsed;
            }

            return Visibility.Collapsed;
        }

        /// <summary>
        /// Todo Add Description
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Visibility)value == Visibility.Visible;
        }

        #endregion
    }
}
