using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace CRUD_Personas_BBDD_Azure_UWP.ViewModels.Utilidades
{
    public class clsShortDateConverter : IValueConverter
    {
        /// <summary>
        /// Cabecera: public object Convert(object value, Type targetType, object parameter, string language)
        /// Descripcion: Convierte una fecha de tipo DateTime en una cadena tipo ShortDatTime
        /// Precondiciones: value es de tipo DateTime y se desea devolver un string
        /// Postcondiciones:ninguna
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((DateTime)value)==DateTime.MinValue?null:((DateTime)value).ToShortDateString();
        }
        /// <summary>
        /// No es usado ni necesario
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
