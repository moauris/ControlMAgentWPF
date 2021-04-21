using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CtmaApp.Converters
{
    public class IPStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IPAddress result = (IPAddress)value;
            if (result == null)
                return "";
            return ((IPAddress)value).ToString();

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            string Address = (string)value;
            if (Address != null && Address.Length > 0)
            {

                return IPAddress.Parse(Address);
            }
            else
            {
                return null;
            }
        }
    }
}
