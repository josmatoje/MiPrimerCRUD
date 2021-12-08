using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace CRUD_Personas_BBDD_Azure_UWP.ViewModels.Utilidades
{
    public class clsImagen: clsVMBase //IValueConverter
    {
        #region atributos
        private byte[] arrayFoto;
        private BitmapImage bitmap;
        private ImageSource sourceImage;
        private StorageFile fichero;
        #endregion
        #region propiedades publicas
        public byte[] ArrayFoto {
            get => arrayFoto;
            set { 
                arrayFoto = value;
                //if (value != null && value is byte[])
                //{
                //    //MemoryStream stream = new MemoryStream(arrayFoto);
                //    BitmapImage image = new BitmapImage();
                //    image.StreamSource = new MemoryStream(value);
                //    //image.SetSource((IRandomAccessStream)stream); 
                //    BitmapImage =image;
                //}
                //else
                //{
                //    BitmapImage = null;
                //}
                //////////////////////////////////////////////
                //BitmapImage biImg = new BitmapImage();
                //MemoryStream ms = new MemoryStream(value);
                //biImg.BeginInit();
                //biImg.StreamSource = ms;
                //biImg.EndInit();

                //ImageSource imgSrc = biImg as ImageSource;
                //////////////////////////////////////////////
                using (InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream())
                {
                    using (DataWriter writer = new DataWriter(ms.GetOutputStreamAt(0)))
                    {
                        writer.WriteBytes(value);

                        // The GetResults here forces to wait until the operation completes
                        // (i.e., it is executed synchronously), so this call can block the UI.
                        writer.StoreAsync().GetResults();
                    }

                    BitmapImage image = new BitmapImage();
                    image.SetSource(ms);
                    Bitmap = image;
                    NotifyPropertyChanged(nameof(Bitmap));
                    SourceImage = image;
                    NotifyPropertyChanged(nameof(SourceImage));
                }


            }
        }

        public BitmapImage Bitmap { 
            get => bitmap; 
            set => bitmap = value; 
        }
        public ImageSource SourceImage { get => sourceImage; set => sourceImage = value; }

        public StorageFile Fichero
        {
            get { return fichero; }
            set
            {
                fichero = value;
                rellenarArray();
                //Setter de arrayFoto setea bitmapimage y sourceimage
                rellenarImagen();
            }
        }
        #endregion
        #region constructor
        public clsImagen() {}
        #endregion
        #region metodos privados
        private async void rellenarArray()
        {
            if (Fichero != null)
            {
                //Crea un flujo de entrada sobre el StorageFile dado.
                using (var inputStream = await fichero.OpenSequentialReadAsync())
                {

                    var readStream = inputStream.AsStreamForRead();

                    //Crea un array de bytes con el tamaño del stream de lectura.
                    var byteArray = new byte[readStream.Length];

                    //Lee la secuencia de bytes del readStream (creo?) y lo va guardando en el array byteArray definido arriba.
                    await readStream.ReadAsync(byteArray, 0, byteArray.Length);

                    this.ArrayFoto = byteArray;
                    NotifyPropertyChanged(nameof(ArrayFoto));
                }
            }
        }

        /// <summary>
        /// Rellena la imagen BitMap desde el fichero
        /// </summary>
        private async void rellenarImagen()
        {
            if (Fichero != null)
            {
                using (var randomAccessStream = await fichero.OpenAsync(FileAccessMode.Read))
                {
                    var result = new BitmapImage();
                    await result.SetSourceAsync(randomAccessStream);
                    Bitmap = result;
                    NotifyPropertyChanged(nameof(Bitmap));
                }
            }

        }
        #endregion
        #region codigo posible converter
        //public static BitmapImage ConvertByteArrayToBitMapImage(byte[] imageByteArray)
        //{
        //    BitmapImage img = new BitmapImage();
        //    img.StreamSource = new MemoryStream(imageByteArray);
        //    return img;
        //}

        //public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    var imageByteArray = value as byte[];
        //    if (imageByteArray == null) return null;
        //    return ConvertByteArrayToBitMapImage(imageByteArray);
        //}

        //public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    return null;
        //}
        #endregion
    }
}
