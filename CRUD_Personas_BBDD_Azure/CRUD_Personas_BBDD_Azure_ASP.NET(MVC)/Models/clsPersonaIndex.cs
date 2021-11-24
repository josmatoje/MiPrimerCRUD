using CRUD_Personas_BL.Listados;
using CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Personas_BBDD_Azure_ASP.NET_MVC_.Models
{
    #region propiedades publicas
    public class clsPersonaIndex
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Departamento { get; set; }
        #endregion
        #region constructor
        public clsPersonaIndex(clsPersona oPersona)
        {
            Id = oPersona.Id;
            Nombre = oPersona.Nombre;
            Apellidos = oPersona.Apellidos;
            FechaNacimiento = oPersona.FechaNacimiento;
            Direccion = oPersona.Direccion;
            Telefono = oPersona.Telefono;
            try
            {
                Departamento = Listados_Departamentos_BL.DepartamentoSeleccionado_BL(oPersona.IdDepartamento).Nombre;
            }catch(SqlException e)
            {

            }
        }
        #endregion

    }
}
