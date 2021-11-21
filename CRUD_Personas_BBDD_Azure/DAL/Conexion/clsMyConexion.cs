using System;
using System.Data.SqlClient;

namespace DAL
{
    public class clsMyConexion
    {
        #region atributos
        private SqlConnection sqlConexion;
        private string miCadena;
        #endregion atributos
        #region constructores
        public clsMyConexion()
        {
            miCadena = "server = josmatoje.database.windows.net; database = LaBaseTheBase; uid = saboresdelatierra; pwd = #Mitesoro;";
            sqlConexion = new SqlConnection();
        }
        #endregion
        #region propiedades
        public SqlConnection SqlConexion { get => sqlConexion; set => sqlConexion = value; }
        #endregion
        #region metodos publicos
        /// <summary>
        /// Cabecera: public bool abrirConexion()
        /// Descripción: abre la SqlConnection del objeto MyConexion
        /// Precondiciones: ninguna
        /// Postcondicion: la propiedad SqlConexion está abierta
        /// </summary>
        /// <returns></returns>
        public bool abrirConexion()
        {
            bool conexionAbierta = false;
            try
            {
                SqlConexion.ConnectionString = miCadena;
                SqlConexion.Open();
                conexionAbierta = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return conexionAbierta;
        }
        /// <summary>
        /// Cabecera: public void cerrarConexion()
        /// Descripción: cierra la SqlConnection del objeto MyConexion
        /// Precondiciones: la conexión debe estar abierta(?)
        /// Postcondicion: la propiedad SqlConexion está cerrada
        /// </summary>
        public void cerrarConexion() => SqlConexion.Close();
        #endregion
    }
}
