using CRUD_Personas_BL;
using CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U11_ejerciciosUWP_ej3.ViewModels.Utilidades;

namespace CRUD_Personas_BBDD_Azure_UWP.ViewModels
{
    public class VistaPersonaVM : clsVMBase
    {
        private DelegateCommand eliminador;
        private List<clsPersona> listadoPersonas;
        private clsPersona personaSeleccionada;

        public VistaPersonaVM()
        {
            eliminador = new DelegateCommand(Eliminar, SePuedeEliminarar);
            ListadoPersonas = BusinessLogicLayer.Listado_Personas_BL();
        }

        public List<clsPersona> ListadoPersonas { get => listadoPersonas; set => listadoPersonas = value; }
        public clsPersona PersonaSeleccionada { get => personaSeleccionada; set => personaSeleccionada = value; }
        public DelegateCommand Eliminador { get => eliminador; set => eliminador = value; }

        private void Eliminar()
        {

            listadoPersonas.Remove(personaSeleccionada);
            //Mejor actualizar de la completa
            if (listadoPersonas.Contains(personaSeleccionada))
                listadoPersonas.Remove(personaSeleccionada);
        }

        private bool SePuedeEliminarar()
        {   //Texto distinto de vacio y null
            return !(personaSeleccionada is null);
        }



    }
}
