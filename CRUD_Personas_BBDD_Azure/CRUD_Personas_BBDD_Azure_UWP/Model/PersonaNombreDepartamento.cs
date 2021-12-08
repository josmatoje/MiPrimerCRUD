using CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Personas_BBDD_Azure_UWP.Model
{
    public class PersonaNombreDepartamento : clsPersona
    {
        private string nombreDepartamento;

        public PersonaNombreDepartamento(clsPersona persona, string nombreDepartamento) : base(persona)
        {
            NombreDepartamento = nombreDepartamento;
        }
        public PersonaNombreDepartamento(clsPersona persona) : base(persona) { }
        public PersonaNombreDepartamento() { }

        public string NombreDepartamento { get => nombreDepartamento; set => nombreDepartamento = value; }

    }
}
