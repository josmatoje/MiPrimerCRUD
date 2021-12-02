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
        /// Descripción: Añade un departamento a la base de datos
        /// Precondiciones: Ninguna
        /// Postcondiciones: El entero devuelto es 1 en caso de que una persona haya sido insertada y 0 en caso contrario
        /// </summary>
        /// <param name="departamento">los datos del departamento que queremos añadir</param>
        /// <returns>Un entero que indica el número de filas afectadas en la inserción</returns>
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
        /// Descripción: Elimina un departamento de la base de datos
        /// Precondiciones: Ninguna
        /// Postcondiciones: El entero devuelto es 1 en caso de que una persona haya sido insertada y 0 en caso contrario
        /// </summary>
        /// <param name="idDepartamento">el id del departamento que queremos eliminar</param>
        /// <returns>Un entero que indica el número de filas afectadas en la eliminación</returns>
        public static int Borrar_Departamento_DAL(int idDepartamento)
        {
            conexionDAL.abrirConexion();
            int numFilasAfectadas;
            SqlCommand instruccion = new SqlCommand(@"execute EliminarDepartamento @IdDepartamento", //Procedimiento almacenado
                                                        conexionDAL.SqlConexion);
            instruccion.Parameters.AddWithValue("@IdDepartamento", idDepartamento);
            numFilasAfectadas = instruccion.ExecuteNonQuery();
            conexionDAL.cerrarConexion();
            return numFilasAfectadas;
        }
        /// <summary>
        /// Cabecera: public static int Editar_Departamento_DAL(clsDepartamento departamento)
        /// Descripción: Modifica un departamento de la base de datos
        /// Precondiciones: Ninguna
        /// Postcondiciones: El entero devuelto es 1 en caso de que una persona haya sido insertada y 0 en caso contrario
        /// </summary>
        /// <param name="departamento">los datos del departamento que queremos añadir</param>
        /// <returns>Un entero que indica el número de filas afectadas en la edición</returns>
        public static int Editar_Departamento_DAL(clsDepartamento departamento)
        {
            conexionDAL.abrirConexion();
            int numFilasAfectadas;
            SqlCommand instruccion = new SqlCommand(@"UPDATE Departamentos SET nombreDepartamento=@nombreDepartamento
                                                        WHERE (IDDepartamento=@IDDepartamento)",
                                                        conexionDAL.SqlConexion);
            instruccion.Parameters.AddWithValue("@nombreDepartamento", departamento.Nombre);
            instruccion.Parameters.AddWithValue("@IDDepartamento", departamento.ID);
            numFilasAfectadas = instruccion.ExecuteNonQuery();
            conexionDAL.cerrarConexion();
            return numFilasAfectadas;
        }
    }
}
