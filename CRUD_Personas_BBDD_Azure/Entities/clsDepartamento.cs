using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRUD_Personas_Entities
{
    public class clsDepartamento
    {
        #region propiedades publicas
        public int ID { get; set; }
        [Required, MaxLength(24)]
        public string Nombre { get; set; }
        #endregion propiedades
        #region constructores
        public clsDepartamento() { }
        public clsDepartamento(int id, string nombre)
        {
            ID = id;
            Nombre = nombre;
        }
        #endregion
    }
}
