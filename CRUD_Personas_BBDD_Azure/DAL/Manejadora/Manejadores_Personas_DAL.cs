using CRUD_Personas_Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_Personas_DAL.Manejadora
{
    public class Manejadores_Personas_DAL
    {
        private static clsMyConexion conexionDAL = new clsMyConexion();

        /// <summary>
        /// Cabecera: public static int Insertar_Persona_DAL(clsPersona persona)
        /// Descripción: Añade una persona a la base de datos
        /// Precondiciones: Ninguna
        /// Postcondiciones: El entero devuelto es 1 en caso de que una persona haya sido insertada y 0 en caso contrario
        /// </summary>
        /// <param name="persona">los datos de la persona que queremoos añadir</param>
        /// <returns>Un entero que indica el número de filas afectadas en la inserción</returns>
        public static int Insertar_Persona_DAL(clsPersona persona)
        {
            conexionDAL.abrirConexion();
            int numFilasAfectadas;
            SqlCommand instruccion = new SqlCommand(@"INSERT INTO Personas (nombrePersona, apellidosPersona, fechaNacimiento, telefono, direccion, IDDepartamento, Foto) 
                                            VALUES(@nombrePersona, @apellidosPersona, @fechaNacimiento, @telefono, @direccion, @IDDepartamento, @Foto)",
                                            conexionDAL.SqlConexion);
            instruccion.Parameters.AddWithValue("@nombrePersona", persona.Nombre);
            instruccion.Parameters.AddWithValue("@apellidosPersona", persona.Apellidos);
            instruccion.Parameters.AddWithValue("@fechaNacimiento", (persona.FechaNacimiento == null || persona.FechaNacimiento==System.Data.SqlTypes.SqlDateTime.MinValue) ? System.Data.SqlTypes.SqlDateTime.Null : persona.FechaNacimiento);
            instruccion.Parameters.AddWithValue("@telefono", (persona.Telefono == null) ? System.Data.SqlTypes.SqlString.Null : persona.Telefono);
            instruccion.Parameters.AddWithValue("@direccion", (persona.Direccion == null) ? System.Data.SqlTypes.SqlString.Null : persona.Direccion);
            instruccion.Parameters.AddWithValue("@IDDepartamento", persona.IdDepartamento);
            instruccion.Parameters.AddWithValue("@Foto", (persona.Foto==null)? System.Data.SqlTypes.SqlBinary.Null:persona.Foto);
            numFilasAfectadas = instruccion.ExecuteNonQuery();
            conexionDAL.cerrarConexion();
            return numFilasAfectadas;
        }
        /// <summary>
        /// Cabecera: public static int Borrar_Persona_DAL(int idPpersona)
        /// Descripción: Elimina una persona a la base de datos
        /// Precondiciones: Ninguna
        /// Postcondiciones: El entero devuelto es 1 en caso de que una persona haya sido insertada y 0 en caso contrario
        /// </summary>
        /// <param name="idPpersona">el id de la persona que queremoos eliminar</param>
        /// <returns>Un entero que indica el número de filas afectadas en la eliminación</returns>
        public static int Borrar_Persona_DAL(int idPpersona)
        {
            conexionDAL.abrirConexion();
            int numFilasAfectadas;
            SqlCommand instruccion = new SqlCommand(@"DELETE FROM Personas 
                                            WHERE IdPersona=@IdPersona",
                                            conexionDAL.SqlConexion);
            instruccion.Parameters.AddWithValue("@IdPersona", idPpersona);
            numFilasAfectadas = instruccion.ExecuteNonQuery();
            conexionDAL.cerrarConexion();
            return numFilasAfectadas;
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
            conexionDAL.abrirConexion();
            int numFilasAfectadas=0;
            SqlCommand instruccion = new SqlCommand(@"UPDATE Personas SET nombrePersona=@nombrePersona,
                                                                        apellidosPersona=@apellidosPersona,
                                                                        fechaNacimiento=@fechaNacimiento,
                                                                        telefono=@telefono, 
                                                                        direccion=@direccion, 
                                                                        IDDepartamento=@IDDepartamento, 
                                                                        Foto=@Foto
                                                    WHERE(IdPersona=@IdPersona)",
                                                    conexionDAL.SqlConexion);
            instruccion.Parameters.AddWithValue("@IdPersona", personaEditada.Id);
            instruccion.Parameters.AddWithValue("@nombrePersona", personaEditada.Nombre);
            instruccion.Parameters.AddWithValue("@apellidosPersona", personaEditada.Apellidos);
            instruccion.Parameters.AddWithValue("@fechaNacimiento", (personaEditada.FechaNacimiento == null || personaEditada.FechaNacimiento == System.Data.SqlTypes.SqlDateTime.MinValue) ? System.Data.SqlTypes.SqlDateTime.Null : personaEditada.FechaNacimiento);
            instruccion.Parameters.AddWithValue("@telefono", (personaEditada.Telefono == null) ? System.Data.SqlTypes.SqlString.Null : personaEditada.Telefono);
            instruccion.Parameters.AddWithValue("@direccion", (personaEditada.Direccion == null) ? System.Data.SqlTypes.SqlString.Null : personaEditada.Direccion);
            instruccion.Parameters.AddWithValue("@IDDepartamento", personaEditada.IdDepartamento);
            instruccion.Parameters.AddWithValue("@Foto", (personaEditada.Foto == null) ? System.Data.SqlTypes.SqlBinary.Null : personaEditada.Foto);
            numFilasAfectadas = instruccion.ExecuteNonQuery();
            conexionDAL.cerrarConexion();
            return numFilasAfectadas;
        }
    }
}
