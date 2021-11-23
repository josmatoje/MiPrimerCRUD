using System;

namespace CRUD_Personas_Entities
{
    public class clsPersona
    {
        #region propiedades publicas
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public Byte[] Foto { get; set; }
        public int IdDepartamento { get; set; }
        #endregion
        #region cosntructores
        public clsPersona(){}//Constructor vacio para rellenar con valores
        public clsPersona(int id, string nombre, string apellidos, DateTime fechaNacimiento, string direccion, string telefono, Byte[] foto, int idDepartamento)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            FechaNacimiento = fechaNacimiento;
            Direccion = direccion;
            Telefono = telefono;
            Foto = foto;
            IdDepartamento = idDepartamento;
        }
        #endregion
    }
}
