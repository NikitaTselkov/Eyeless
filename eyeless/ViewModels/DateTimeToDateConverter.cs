using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace eyeless.ViewModels
{
    [ValueConversion(typeof(int), typeof(string))]
    public class DateTimeToDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var min = 0;
            var oldValue = ((int)value);
            while (oldValue > 60)
            {
                oldValue -= 60;
                min ++;
            }

            return $"{min}m {oldValue}s";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {           
            return value;
        }
    }

}
