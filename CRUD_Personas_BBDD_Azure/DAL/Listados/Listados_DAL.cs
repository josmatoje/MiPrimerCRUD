using CRUD_Personas_Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_Personas_DAL.Listados
{
    public class Listados_DAL
    {
        private static clsMyConexion conexionDAL = new clsMyConexion();

        /// <summary>
        /// Cabecera: public static List<clsPersona> Listado_Personas_DAL()
        /// Descripcion: Devuelve el conjunto de personas que se encuentran en la base de datos a la q se conecta
        /// Precondiciones: Las personas de la base de datos siguen la estructura de la clase clsPersona
        /// Postcondiciones: todos los datos de la lista existen en la base de datos
        /// </summary>
        /// <returns> El listado de todas las personas que existen en la base de datos</returns>
        public static List<clsPersona> Listado_Personas_DAL()
        {
            List<clsPersona> personas = new List<clsPersona>();
            SqlCommand instruccion = new SqlCommand();
            SqlDataReader lector;
            clsPersona oPersona = new clsPersona();

            try
            {
                conexionDAL.abrirConexion();
                instruccion.CommandText = "SELECT * FROM Personas";
                instruccion.Connection = conexionDAL.SqlConexion;
                lector = instruccion.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        oPersona = generaPersonaLeida(lector);
                        personas.Add(oPersona);
                    }
                }
                lector.Close();
                conexionDAL.cerrarConexion();
            }
            catch (SqlException e)
            {

            }

            return personas;
        }
        /// <summary>
        /// Cabecera: public static List<clsDepartamento> Listado_Departamentos_DAL()
        /// Descripcion: Devuelve el conjunto de departamentos que se encuentran en la base de datos a la q se conecta
        /// Precondiciones: Las personas de la base de datos siguen la estructura de la clase clsDepartamento
        /// Postcondiciones: todos los datos de la lista existen en la base de datos
        /// </summary>
        /// <returns> El listado de todos los departamentos que existen en la base de datos</returns>
        public static List<clsDepartamento> Listado_Departamentos_DAL()
        {
            List<clsDepartamento> personas = new List<clsDepartamento>();
            SqlCommand instruccion = new SqlCommand();
            SqlDataReader lector;
            clsDepartamento oDepartamento;

            try
            {
                conexionDAL.abrirConexion();
                instruccion.CommandText = "SELECT * FROM Departamentos";
                instruccion.Connection = conexionDAL.SqlConexion;
                lector = instruccion.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        oDepartamento = new clsDepartamento ((int)lector["IDPersona"],(string)lector["nombrePersona"]);
                        personas.Add(oDepartamento);
                    }

                }
                lector.Close();
                conexionDAL.cerrarConexion();
            }
            catch (SqlException e)
            {

            }

            return personas;
        }
        /// <summary>
        /// Cabecera: public static List<clsPersona> Listado_Personas_DAL()
        /// Descripcion: Devuelve el conjunto de personas que se encuentran en la base de datos a la q se conecta
        /// Precondiciones: Las personas de la base de datos siguen la estructura de la clase clsPersona
        /// Postcondiciones: todos los datos de la lista existen en la base de datos
        /// </summary>
        /// <returns> El listado de todas las personas que existen en la base de datos</returns>
        public static clsPersona Personas_DAL(int idPersona)
        {
            clsPersona oPersona = new clsPersona();
            SqlCommand instruccion = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexionDAL.abrirConexion();
                instruccion.CommandText = "SELECT * FROM Personas";
                instruccion.Connection = conexionDAL.SqlConexion;
                lector = instruccion.ExecuteReader();
                if (lector.HasRows)
                {
                    lector.Read();
                    oPersona = generaPersonaLeida(lector);
                }
                lector.Close();
                conexionDAL.cerrarConexion();
            }
            catch (SqlException e)
            {

            }

            return oPersona;
        }
        /// <summary>
        /// Cabecera: private static clsPersona generaPersonaLeida(SqlDataReader lector)
        /// 
        /// </summary>
        /// <param name="lector"></param>
        /// <returns></returns>
        private static clsPersona generaPersonaLeida(SqlDataReader lector)
        {
            clsPersona oPersona = new clsPersona();
            oPersona.Id = (int)lector["IDPersona"];
            oPersona.Nombre = (string)lector["nombrePersona"];
            oPersona.Apellidos = (string)lector["apellidosPersona"];
            oPersona.FechaNacimiento = (DateTime)lector["fechaNacimiento"];
            oPersona.Telefono = (string)lector["telefono"];
            oPersona.Direccion = (string)lector["direccion"];
            oPersona.idDepartamento = (int)lector["IDDepartamento"];
            if (lector["Foto"] != System.DBNull.Value)
                oPersona.Foto = (Byte[])lector["Foto"];
            return oPersona;
        }
    }
}
