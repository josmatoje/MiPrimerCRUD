using CRUD_Personas_Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CRUD_Personas_DAL.Listados
{
    public class Listados_Personas_DAL
    {
        private static clsMyConexion conexionDAL = new clsMyConexion();

        /// <summary>
        /// Cabecera: public static List<clsPersona> Listado_Personas_DAL()
        /// Descripcion: Devuelve el conjunto de personas que se encuentran en la base de datos a la q se conecta
        /// Precondiciones: Ninguna
        /// Postcondiciones: todos los datos de la lista existen en la base de datos
        /// </summary>
        /// <returns> El listado de todas las personas que existen en la base de datos</returns>
        public static List<clsPersona> Listado_Completo_Personas_DAL()
        {
            List<clsPersona> personas = new List<clsPersona>();
            SqlCommand instruccion = new SqlCommand();
            SqlDataReader lector;
            clsPersona oPersona = new clsPersona();

            conexionDAL.abrirConexion();
            instruccion.CommandText = "SELECT IDPersona, nombrePersona, apellidosPersona, fechaNacimiento, telefono, direccion, IDDepartamento, Foto FROM Personas";
            instruccion.Connection = conexionDAL.SqlConexion;
            lector = instruccion.ExecuteReader();
            if (lector.HasRows)
            {
                while (lector.Read()){
                    oPersona = generaPersonaLeida(lector);
                    personas.Add(oPersona);
                }
            }
            lector.Close();
            conexionDAL.cerrarConexion();

            return personas;
        }
        /// <summary>
        /// Cabecera: public static clsPersona Personas_DAL(int idPersona)
        /// Descripcion: Devuelve la persona que se encuentra en la base de datos a la q se conecta correspondiente con el id solicitado.
        /// Precondiciones: idPersona mayor que cero
        /// Postcondiciones: asociado al id se devuelve una persona
        /// </summary>
        /// <returns> La persona que existen en la base de datos</returns>
        public static clsPersona PersonaIndicada_DAL(int idPersona)
        {
            clsPersona oPersona = new clsPersona();
            SqlCommand instruccion = new SqlCommand();
            SqlDataReader lector;

            conexionDAL.abrirConexion();
            instruccion.CommandText = @"SELECT IDPersona, nombrePersona, apellidosPersona, fechaNacimiento, telefono, direccion, IDDepartamento, Foto FROM Personas 
                                        WHERE IDPersona= @idPersona";
            instruccion.Parameters.AddWithValue("@idPersona", idPersona);
            instruccion.Connection = conexionDAL.SqlConexion;
            lector = instruccion.ExecuteReader();
            if (lector.HasRows)
            {
                lector.Read();
                oPersona = generaPersonaLeida(lector);
            }
            lector.Close();
            conexionDAL.cerrarConexion();
            
            return oPersona;
        }
        /// <summary>
        /// Cabecera: private static clsPersona generaPersonaLeida(SqlDataReader lector)
        /// Descripcion: Devuelve una persona leida por un lector
        /// Precondiciones: el SqlDataReader debe haber leido una fila de la consulta realizada
        /// Postcondiciones: la persona existe en la base de datos
        /// </summary>
        /// <param name="lector"> que ha leido una fila de la consulta previamente realizada</param>
        /// <returns>una persona que se encuentra en la base de datos</returns>
        private static clsPersona generaPersonaLeida(SqlDataReader lector)
        {
            clsPersona oPersona = new clsPersona();
            oPersona.Id = (int)lector["IDPersona"];
            oPersona.Nombre = (string)lector["nombrePersona"];
            oPersona.Apellidos = (string)lector["apellidosPersona"];
            oPersona.FechaNacimiento = (lector["fechaNacimiento"] != System.DBNull.Value) ? (DateTime)lector["fechaNacimiento"] : DateTime.MinValue;
            oPersona.Telefono = (string)lector["telefono"];
            oPersona.Direccion = (string)lector["direccion"];
            oPersona.IdDepartamento = (int)lector["IDDepartamento"];
            oPersona.Foto = lector["Foto"] != System.DBNull.Value ? (Byte[])lector["Foto"] : null;
                 
            DateTime time = new DateTime();
            Console.WriteLine(time);
            return oPersona;
        }
    }
}
