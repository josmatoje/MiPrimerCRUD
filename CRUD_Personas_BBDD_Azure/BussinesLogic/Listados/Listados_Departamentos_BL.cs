using CRUD_Personas_DAL.Listados;
using CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personas_BL.Listados
{
    public class Listados_Departamentos_BL
    {
        /// <summary>
        /// Cabecera: public static List<clsDepartamento> Listado_Departamentos_BL()
        /// Descripcion: Devuelve el conjunto de departamentos que recibe de la capa DAL
        /// Precondiciones: Las personas de la clase clsPersona siguen la estructura de la base de datos
        /// Postcondiciones: todos los datos de la lista existen en la base de datos
        /// </summary>
        /// <returns> El listado de todos los departamentos que existen en la base de datos</returns>
        public static List<clsDepartamento> Listado_Completo_Departamentos_BL()
        {
            return Listados_Departamentos_DAL.Listado_Completo_Departamentos_DAL();
        }
        /// <summary>
        /// Cabecera: public static List<clsDepartamento> Listado_Departamentos_BL()
        /// Descripcion: Devuelve el departamento que con el id solicitado que recibe de la capa DAL
        /// Precondiciones: Las personas de la clase clsPersona siguen la estructura de la base de datos
        /// Postcondiciones: todos los datos de la lista existen en la base de datos
        /// </summary>
        /// <returns> El listado de todos los departamentos que existen en la base de datos</returns>
        public static clsDepartamento DepartamentoSeleccionado_BL(int idDepartamento)
        {
            return Listados_Departamentos_DAL.DepartamentoSeleccionado_DAL(idDepartamento);
        }
    }
}
