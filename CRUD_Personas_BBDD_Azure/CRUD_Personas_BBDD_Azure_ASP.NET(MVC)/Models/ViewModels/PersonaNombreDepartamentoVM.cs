using CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Personas_BBDD_Azure_ASP.NET_MVC_.Models.ViewModels
{
    public class PersonaNombreDepartamentoVM : clsPersona
    {
        private string nombreDepartamento;

        public PersonaNombreDepartamentoVM(clsPersona persona, string nombreDepartamento): base(persona)
        {
            NombreDepartamento = nombreDepartamento;
        }
        public PersonaNombreDepartamentoVM() { }


        [Display(Name = "Nombre del departamento: ")]
        public string NombreDepartamento { get => nombreDepartamento; set => nombreDepartamento = value; }

    }
}
