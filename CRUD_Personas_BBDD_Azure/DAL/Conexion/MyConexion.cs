using System;
using System.Data.SqlClient;

namespace DAL
{
    public class clsMyConexion
    {
        #region atributos
        private SqlConnection sqlConexion = new SqlConnection();
        private string miCadena = "server = josmatoje.database.windows.net; database = LaBaseTheBase; uid = saboresdelatierra; pwd = #Mitesoro;";
        #endregion atributos
        #region constructores
        public clsMyConexion()
        {
            miCadena = "server = josmatoje.database.windows.net; database = LaBaseTheBase; uid = saboresdelatierra; pwd = #Mitesoro;";

        }
        #endregion
        #region propiedades
        public SqlConnection SqlConexion { get => sqlConexion; set => sqlConexion = value; }
        //public string MiCadena { get => miCadena; set => miCadena = value; }
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
        public void hola()
        {

        }
        public void cerrarConexion() => SqlConexion.Close();
        #endregion
    }
}
