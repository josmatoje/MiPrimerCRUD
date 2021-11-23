using CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Personas_BBDD_Azure_ASP.NET_MVC_.Models.ViewModels
{
    public class EditVm : clsPersona
    {
        private string nombreDepartamento;

        public EditVm(clsPersona persona)
        {

        }
        public string NombreDepartamento { get => nombreDepartamento; set => nombreDepartamento = value; }

    }
}
