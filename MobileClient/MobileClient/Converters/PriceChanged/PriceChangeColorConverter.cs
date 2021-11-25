using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace MobileClient.Converters.PriceChanged
{
    public class PriceChangeColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float? val = value as float?;
            if(val != null)
            {
                if(val == 0)
                {
                    return Color.Gray;
                }else if(val > 0)
                {
                    return Color.Green;
                }else if(val < 0)
                {
                    return Color.Red;
                }
            }

            return Color.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
