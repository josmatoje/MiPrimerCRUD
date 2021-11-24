using CRUD_Personas_DAL.Listados;
using CRUD_Personas_Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CRUD_Personas_BL.Listados
{
    public class Listados_Personas_BL
    {/// <summary>
     /// Cabecera: public static List<clsPersona> Listado_Personas_DAL()
     /// Descripcion: Devuelve el conjunto de personas que se encuentran en la base de datos a la q se conecta
     /// Precondiciones: Ninguna
     /// Postcondiciones: todos los datos de la lista existen en la base de datos
     /// </summary>
     /// <returns> El listado de todas las personas que existen en la base de datos</returns>
        public static List<clsPersona> Listado_Completo_Personas_BL()
        {
            return Listados_Personas_DAL.Listado_Completo_Personas_DAL();
        }
        /// <summary>
        /// Cabecera: public static clsPersona Personas_DAL(int idPersona)
        /// Descripcion: Devuelve la persona que se encuentran en la base de datos a la q se conecta correspondiente con el id solicitado.
        /// Precondiciones: idPersona mayor que cero
        /// Postcondiciones: asociado al id se devuelve una persona
        /// </summary>
        /// <returns> La persona que existen en la base de datos</returns>
        public static clsPersona PersonaIndicada_BL(int idPersona)
        {
            return Listados_Personas_DAL.PersonaIndicada_DAL(idPersona);
        }
    }
}
