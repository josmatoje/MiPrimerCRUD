using CRUD_Personas_Entities;
using CRUD_Personas_DAL.Manejadora;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personas_BL.Manejadoras
{
    public class Manejadores_Departamentos_BL
    {
        /// <summary>
        /// Cabecera: public static int Insertar_Departamento_BL(clsDepartamento departamento)
        /// Descripción: Añade un departamento a la base de datos
        /// Precondiciones: Ninguna
        /// Postcondiciones: El entero devuelto es 1 en caso de que una persona haya sido insertada y 0 en caso contrario
        /// </summary>
        /// <param name="departamento">los datos del departamento que queremos añadir</param>
        /// <returns>Un entero que indica el número de filas afectadas en la inserción</returns>
        public static int Insertar_Departamento_BL(clsDepartamento departamento)
        {
            return Manejadores_Departamentos_DAL.Insertar_Departamento_DAL(departamento);
        }
        /// <summary>
        /// Cabecera: public static int Borrar_Departamento_BL(int idDepartamento)
        /// Descripción: Elimina un departamento de la base de datos
        /// Precondiciones: Ninguna
        /// Postcondiciones: El entero devuelto es 1 en caso de que una persona haya sido insertada y 0 en caso contrario
        /// </summary>
        /// <param name="idDepartamento">el id del departamento que queremos eliminar</param>
        /// <returns>Un entero que indica el número de filas afectadas en la eliminación</returns>
        public static int Borrar_Departamento_BL(int idDepartamento)
        {
            return Manejadores_Departamentos_DAL.Borrar_Departamento_DAL(idDepartamento);
        }
        /// <summary>
        /// Cabecera: public static int Editar_Departamento_BL(clsDepartamento departamento)
        /// Descripción: Modifica un departamento de la base de datos
        /// Precondiciones: Ninguna
        /// Postcondiciones: El entero devuelto es 1 en caso de que una persona haya sido insertada y 0 en caso contrario
        /// </summary>
        /// <param name="departamento">los datos del departamento que queremos añadir</param>
        /// <returns>Un entero que indica el número de filas afectadas en la edición</returns>
        public static int Editar_Departamento_BL(clsDepartamento departamento)
        {
            return Manejadores_Departamentos_DAL.Editar_Departamento_DAL(departamento);
        }
    }
}
