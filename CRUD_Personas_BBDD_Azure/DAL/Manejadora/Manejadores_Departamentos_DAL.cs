using CRUD_Personas_Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_Personas_DAL.Manejadora
{
    public class Manejadores_Departamentos_DAL
    {
        private static clsMyConexion conexionDAL = new clsMyConexion();

        /// <summary>
        /// Cabecera: public static int Insertar_Departamento_DAL(clsDepartamento departamento)
        /// Descripción: 
        /// Precondiciones: 
        /// Postcondiciones: 
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public static int Insertar_Departamento_DAL(clsDepartamento departamento)
        {
            conexionDAL.abrirConexion();
            int numFilasAfectadas;
            SqlCommand instruccion = new SqlCommand(@"INSERT INTO Departamentos(nombreDepartamento)
                                                        VALUES (@nombreDepartamento)",
                                                        conexionDAL.SqlConexion);
            instruccion.Parameters.AddWithValue("@nombreDepartamento", departamento.Nombre);
            numFilasAfectadas = instruccion.ExecuteNonQuery();
            conexionDAL.cerrarConexion();
            return numFilasAfectadas;
        }
        /// <summary>
        /// Cabecera: public static int Borrar_Departamento_DAL(int idDepartamento)
        /// Descripción: 
        /// Precondiciones: 
        /// Postcondiciones: 
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <returns></returns>
        public static int Borrar_Departamento_DAL(int idDepartamento)
        {
            conexionDAL.abrirConexion();
            int numFilasAfectadas;
            SqlCommand instruccion = new SqlCommand( @"DELETE FROM Departamentos 
                                                        WHERE IdDepartamento=@IdDepartamento",
                                                        conexionDAL.SqlConexion);
            instruccion.Parameters.AddWithValue("@IdDepartamento", idDepartamento);
            numFilasAfectadas = instruccion.ExecuteNonQuery();
            conexionDAL.cerrarConexion();
            return numFilasAfectadas;
        }
        /// <summary>
        /// Cabecera: public static int Editar_Departamento_DAL(clsDepartamento departamento)
        /// Descripción: 
        /// Precondiciones: 
        /// Postcondiciones: 
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public static int Editar_Departamento_DAL(clsDepartamento departamento)
        {
            conexionDAL.abrirConexion();
            int numFilasAfectadas;
            SqlCommand instruccion = new SqlCommand(@"UPDATE Departamentos SET nombreDepartamento=@nombreDepartamento)
                                                        WHERE (IDDepartamento=@IDDepartamento)",
                                                        conexionDAL.SqlConexion);
            instruccion.Parameters.AddWithValue("@nombreDepartamento", departamento.Nombre);
            numFilasAfectadas = instruccion.ExecuteNonQuery();
            conexionDAL.cerrarConexion();
            return numFilasAfectadas;
        }
    }
}
