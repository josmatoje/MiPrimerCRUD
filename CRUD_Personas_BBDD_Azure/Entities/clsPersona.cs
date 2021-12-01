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
        public clsPersona()
        {
            FechaNacimiento = DateTime.Now;
        }
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
        public clsPersona(string nombre, string apellidos, DateTime fechaNacimiento, string direccion, string telefono, Byte[] foto, int idDepartamento)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            FechaNacimiento = fechaNacimiento;
            Direccion = direccion;
            Telefono = telefono;
            Foto = foto;
            IdDepartamento = idDepartamento;
        }
        public clsPersona(clsPersona oPersona)
        {
            Id = oPersona.Id;
            Nombre = oPersona.Nombre;
            Apellidos = oPersona.Apellidos;
            FechaNacimiento = oPersona.FechaNacimiento;
            Direccion = oPersona.Direccion;
            Telefono = oPersona.Telefono;
            Foto = oPersona.Foto;
            IdDepartamento = oPersona.IdDepartamento;
        }
        #endregion
    }
}
