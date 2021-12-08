using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Personas_Entities
{
    public class clsPersona //: clsVMBase
    {
        #region atributos
        private string nombre;
        private string apellidos;
        #endregion
        #region propiedades publicas
        public int Id { get; set; }
        [MaxLength(30), Required(ErrorMessage="Campo obligatoria"), Display(Name = "Nombre: ")]
        public string Nombre 
        { 
            get => nombre;
            set => nombre = value;
        }
        [MaxLength(30),Required(ErrorMessage = "Campo obligatoria"),Display(Name = "Apellido: ")]
        public string Apellidos {
            get => apellidos;
            set => apellidos = value;
        }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}" /*,ApplyFormatInEditMode = true*/),/* MaxLength(DateTime.Now.AddDays(-1)),*/ Display(Name = "Fecha de nacimiento: ")]
        public DateTime FechaNacimiento { get; set; }
        [MaxLength(50),Display(Name = "Direccion: ")]
        public string Direccion { get; set; }
        [MaxLength(12), Display(Name = "Telefono: ")]
        public string Telefono { get; set; }
        [Display(Name = "Foto: ")]
        public Byte[] Foto { get; set; }
        public int IdDepartamento { get; set; }
        #endregion
        #region cosntructores
        public clsPersona() { }
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
