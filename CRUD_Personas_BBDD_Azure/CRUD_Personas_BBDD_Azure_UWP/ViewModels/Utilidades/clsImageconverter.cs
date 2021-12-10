using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace CRUD_Personas_BBDD_Azure_UWP.ViewModels.Utilidades
{
    public class clsImageconverter      //Converter que finalmente no ha sido utilizado
    {
        public static BitmapImage ConvertByteArrayToBitMapImage(byte[] imageByteArray)
        {
            BitmapImage img = new BitmapImage();
            //img.StreamSource = new MemoryStream(imageByteArray); StramSource no funciona
            return img;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var imageByteArray = value as byte[];
            if (imageByteArray == null) return null;
            return ConvertByteArrayToBitMapImage(imageByteArray);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
