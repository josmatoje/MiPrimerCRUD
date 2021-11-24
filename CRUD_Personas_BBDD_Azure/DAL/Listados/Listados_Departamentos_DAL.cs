using CRUD_Personas_Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_Personas_DAL.Listados
{
    public class Listados_Departamentos_DAL
    {
        private static clsMyConexion conexionDAL = new clsMyConexion();

        /// <summary>
        /// Cabecera: public static List<clsDepartamento> Listado_Departamentos_DAL()
        /// Descripcion: Devuelve el conjunto de departamentos que se encuentran en la base de datos a la q se conecta
        /// Precondiciones: Las personas de la clase clsPersona siguen la estructura de la base de datos
        /// Postcondiciones: todos los datos de la lista existen en la base de datos
        /// </summary>
        /// <returns> El listado de todos los departamentos que existen en la base de datos</returns>
        public static List<clsDepartamento> Listado_Completo_Departamentos_DAL()
        {
            List<clsDepartamento> departamentos = new List<clsDepartamento>();
            SqlCommand instruccion = new SqlCommand();
            SqlDataReader lector;
            clsDepartamento oDepartamento;

            try
            {
                conexionDAL.abrirConexion();
                instruccion.CommandText = "SELECT IdDepartamento, nombreDepartamento FROM Departamentos";
                instruccion.Connection = conexionDAL.SqlConexion;
                lector = instruccion.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read()){
                        oDepartamento = new clsDepartamento((int)lector["IDDepartamento"], (string)lector["nombreDepartamento"]);
                        departamentos.Add(oDepartamento);
                    }
                }
                lector.Close();
                conexionDAL.cerrarConexion();
            }
            catch (SqlException e)
            {
                throw;
            }

            return departamentos;
        }
        /// <summary>
        /// Cabecera: public static List<clsDepartamento> Listado_Departamentos_DAL()
        /// Descripcion: Devuelve el departamento que se encuentra en la base de datos a la q se conecta correspondiente con el id solicitado.
        /// Precondiciones: Las personas de la clase clsPersona siguen la estructura de la base de datos
        /// Postcondiciones: todos los datos de la lista existen en la base de datos
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <returns> El listado de todos los departamentos que existen en la base de datos</returns>
        public static clsDepartamento DepartamentoSeleccionado_DAL(int idDepartamento)
        {
            SqlCommand instruccion = new SqlCommand();
            SqlDataReader lector;
            clsDepartamento oDepartamento = null;

            try
            {
                conexionDAL.abrirConexion();
                instruccion.CommandText = @"SELECT IdDepartamento, nombreDepartamento FROM Departamentos WHERE IDDEpartamento= @idDepartamento";
                instruccion.Parameters.AddWithValue("@idDepartamento", idDepartamento);
                instruccion.Connection = conexionDAL.SqlConexion;
                lector = instruccion.ExecuteReader();
                if (lector.HasRows)
                {
                    lector.Read();
                    oDepartamento = new clsDepartamento((int)lector["IDPersona"], (string)lector["nombrePersona"]);
                }
                lector.Close();
                conexionDAL.cerrarConexion();
            }
            catch (SqlException e)
            {
                throw;
            }

            return oDepartamento;
        }
    }
}
