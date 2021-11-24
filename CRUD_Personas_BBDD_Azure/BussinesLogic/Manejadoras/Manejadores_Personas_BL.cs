using CRUD_Personas_DAL.Manejadora;
using CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personas_BL.Manejadoras
{
    public class Manejadores_Personas_BL
    {
        /// <summary>
        /// Cabecera: public static int Insertar_Persona_BL(clsPersona persona)
        /// Descripción: Añade una persona a la base de datos
        /// Precondiciones: Ninguna
        /// Postcondiciones: El entero devuelto es 1 en caso de que una persona haya sido insertada y 0 en caso contrario
        /// </summary>
        /// <param name="persona">los datos de la persona que queremoos añadir</param>
        /// <returns>Un entero que indica el número de filas afectadas en la inserción</returns>
        public static int Insertar_Persona_DAL(clsPersona persona)
        {
            return Manejadores_Personas_DAL.Insertar_Persona_DAL(persona);
        }
        /// <summary>
        /// Cabecera: public static int Borrar_Persona_BL(int idPpersona)
        /// Descripción: Elimina una persona a la base de datos
        /// Precondiciones: Ninguna
        /// Postcondiciones: El entero devuelto es 1 en caso de que una persona haya sido insertada y 0 en caso contrario
        /// </summary>
        /// <param name="idPpersona">el id de la persona que queremoos eliminar</param>
        /// <returns>Un entero que indica el número de filas afectadas en la eliminación</returns>
        public static int Borrar_Persona_DAL(int idPpersona)
        {
            return Manejadores_Personas_DAL.Borrar_Persona_DAL(idPpersona);
        }
        /// <summary>
        /// Cabecera: public static int Editar_Persona_DAL(clsPersona personaEditada)
        /// Descripción: Modifica una persona a la base de datos
        /// Precondiciones: Ninguna
        /// Postcondiciones: El entero devuelto es 1 en caso de que una persona haya sido insertada y 0 en caso contrario
        /// </summary>
        /// <param name="personaEditada">los datos de la persona que queremoos modificar</param>
        /// <returns>Un entero que indica el número de filas afectadas en la edición</returns>
        public static int Editar_Persona_DAL(clsPersona personaEditada)
        {
            return Manejadores_Personas_DAL.Editar_Persona_DAL(personaEditada);
        }
    }
}
