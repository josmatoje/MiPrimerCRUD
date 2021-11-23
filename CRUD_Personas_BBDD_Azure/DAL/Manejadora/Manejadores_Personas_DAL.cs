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
        /// 
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static int Insertar_Persona_DAL(clsPersona persona)
        {
            conexionDAL.abrirConexion();
            int numFilasAfectadas;
            SqlCommand instruccion = new SqlCommand(@"INSERT INTO Personas (nombrePersona, apellidosPersona, fechaNacimiento, telefono, direccion, IDDepartamento, Foto) 
                                            VALUES(@nombrePersona, @apellidosPersona, @fechaNacimiento, @telefono, @direccion, @IDDepartamento, @Foto)",
                                            conexionDAL.SqlConexion);
            instruccion.Parameters.AddWithValue("@nombrePersona", persona.Nombre);
            instruccion.Parameters.AddWithValue("@apellidosPersona", persona.Apellidos);
            instruccion.Parameters.AddWithValue("@fechaNacimiento", persona.FechaNacimiento);
            instruccion.Parameters.AddWithValue("@telefono", persona.Telefono);
            instruccion.Parameters.AddWithValue("@direccion", persona.Direccion);
            instruccion.Parameters.AddWithValue("@IDDepartamento", persona.IdDepartamento);
            instruccion.Parameters.AddWithValue("@Foto", persona.Foto);
            numFilasAfectadas = instruccion.ExecuteNonQuery();
            conexionDAL.cerrarConexion();
            return numFilasAfectadas;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPpersona"></param>
        /// <returns></returns>
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
            instruccion.Parameters.AddWithValue("@fechaNacimiento", personaEditada.FechaNacimiento);
            instruccion.Parameters.AddWithValue("@telefono", personaEditada.Telefono);
            instruccion.Parameters.AddWithValue("@direccion", personaEditada.Direccion);
            instruccion.Parameters.AddWithValue("@IDDepartamento", personaEditada.IdDepartamento);
            instruccion.Parameters.AddWithValue("@Foto", personaEditada.Foto);
            numFilasAfectadas = instruccion.ExecuteNonQuery();
            conexionDAL.cerrarConexion();
            return numFilasAfectadas;
        }
    }
}
