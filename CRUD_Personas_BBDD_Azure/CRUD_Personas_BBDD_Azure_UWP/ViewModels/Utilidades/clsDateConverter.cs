using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace CRUD_Personas_BBDD_Azure_UWP.ViewModels.Utilidades
{
    public class clsDateConverter : IValueConverter
    {
        /// <summary>
        /// Cabecera: public object Convert(object value, Type targetType, object parameter, string language)
        /// Descripcion: Convierte una fecha de tipo DateTime a DateTimeOffSet
        /// Precondiciones: value es de tipo DateTime y se desea devolver un DateTimeOffSet
        /// Postcondiciones:ninguna
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime date = (DateTime)value == DateTime.MinValue?DateTime.Now:(DateTime)value;

            DateTimeOffset result = date;

            return result;
        }
        /// <summary>
        /// Cabecera: public object ConvertBack(object value, Type targetType, object parameter, string language)
        /// Descripcion: Convierte una fecha de tipo DateTimeOffSet a DateTime
        /// Precondiciones: value es de tipo DateTimeOffSet y se desea devolver un DateTime
        /// Postcondiciones:ninguna
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return ((DateTimeOffset)value).Date;
        }
    }
}
