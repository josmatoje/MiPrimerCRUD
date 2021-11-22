using CRUD_Personas_Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_Personas_DAL.Manejadora
{
    public class Manejadores_DAL
    {
        private static clsMyConexion conexionDAL = new clsMyConexion();
        public static int InsertaPersona(clsPersona persona)
        {
            SqlCommand instruccion = new SqlCommand();
            int numFilasAfectadas;

            conexionDAL.abrirConexion();
            instruccion.CommandText = @"INSERT INTO Personas (nombrePersona, apellidosPersona, fechaNacimiento, telefono, direccion, IDDepartamento, Foto) 
                                            VALUES(@nombrePersona, @apellidosPersona, @fechaNacimiento, @telefono, @direccion, @IDDepartamento, @Foto)";
            instruccion.Parameters.AddWithValue("@nombrePersona", persona.Nombre);
            instruccion.Parameters.AddWithValue("@apellidosPersona", persona.Apellidos);
            instruccion.Parameters.AddWithValue("@fechaNacimiento", persona.FechaNacimiento);
            instruccion.Parameters.AddWithValue("@telefono", persona.Telefono);
            instruccion.Parameters.AddWithValue("@direccion", persona.Direccion);
            instruccion.Parameters.AddWithValue("@IDDepartamento", persona.IdDepartamento);
            instruccion.Parameters.AddWithValue("@Foto", persona.Foto);
            instruccion.Connection = conexionDAL.SqlConexion;
            numFilasAfectadas = instruccion.ExecuteNonQuery();
            conexionDAL.cerrarConexion();
            return numFilasAfectadas;
        }
        public static int InsertaDepartamento(clsDepartamento departamento)
        {
            SqlCommand instruccion = new SqlCommand();
            int numFilasAfectadas;

            conexionDAL.abrirConexion();
            instruccion.CommandText = @"INSERT INTO Departamentos(nombreDepartamento)
                                            VALUES (@nombreDepartamento)";
            instruccion.Parameters.AddWithValue("@nombreDepartamento", departamento.Nombre);
            instruccion.Connection = conexionDAL.SqlConexion;
            numFilasAfectadas = instruccion.ExecuteNonQuery();
            conexionDAL.cerrarConexion();
            return numFilasAfectadas;
        }
        public static int BorrarPersona(int idPpersona)
        {
            SqlCommand instruccion = new SqlCommand();
            int numFilasAfectadas;

            conexionDAL.abrirConexion();
            instruccion.CommandText = @"DELETE FROM Personas 
                                            WHERE IdPersona=@IdPersona";
            instruccion.Parameters.AddWithValue("@IdPersona", idPpersona);
            instruccion.Connection = conexionDAL.SqlConexion;
            numFilasAfectadas = instruccion.ExecuteNonQuery();
            conexionDAL.cerrarConexion();
            return numFilasAfectadas;
        }
        public static int BorrarDepartamento(int idDepartamento)
        {
            SqlCommand instruccion = new SqlCommand();
            int numFilasAfectadas;

            conexionDAL.abrirConexion();
            instruccion.CommandText = @"DELETE FROM Departamentos 
                                            WHERE IdDepartamento=@IdDepartamento";
            instruccion.Parameters.AddWithValue("@IdDepartamento", idDepartamento);
            instruccion.Connection = conexionDAL.SqlConexion;
            numFilasAfectadas = instruccion.ExecuteNonQuery();
            conexionDAL.cerrarConexion();
            return numFilasAfectadas;
        }



    }
}
