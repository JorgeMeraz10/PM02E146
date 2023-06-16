using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace PM2E146.Converters
{
    public class ByteImageConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ImageSource imageSource = null;
            if (value != null)

            {
                byte[] bytes = value as byte[];
                imageSource = ImageSource.FromStream(() => new MemoryStream(bytes));
            }
            return imageSource;
        }

        public object ConvertBack(object value,
               Type targetType,
               object parameter,
               System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
