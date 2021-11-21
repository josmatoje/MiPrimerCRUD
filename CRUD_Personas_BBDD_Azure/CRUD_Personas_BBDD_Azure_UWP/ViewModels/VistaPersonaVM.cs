using CRUD_Personas_BL;
using CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Personas_BBDD_Azure_UWP.ViewModels
{
    public class VistaPersonaVM
    {
        private List<clsPersona> personajes;

        public VistaPersonaVM()
        {
            Personajes = BusinessLogicLayer.Listado_Personas_BL();
        }

        public List<clsPersona> Personajes { get => personajes; set => personajes = value; }
    }
}
