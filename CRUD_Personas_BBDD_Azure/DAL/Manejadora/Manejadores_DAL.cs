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

        public static bool InsertaPersona(clsPersona persona)
        {
            SqlCommand instruccion = new SqlCommand(); 

            bool insertado = false;
            conexionDAL.abrirConexion();

            conexionDAL.cerrarConexion();
            return insertado;
        }

    }
}
