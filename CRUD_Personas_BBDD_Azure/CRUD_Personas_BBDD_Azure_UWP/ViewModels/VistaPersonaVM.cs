using CRUD_Personas_BL;
using CRUD_Personas_BL.Listados;
using CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_Personas_BBDD_Azure_UWP.ViewModels.Utilidades;

namespace CRUD_Personas_BBDD_Azure_UWP.ViewModels
{
    public class VistaPersonaVM : clsVMBase
    {
        #region atributos
        private DelegateCommand buscador;
        private DelegateCommand anhadidor;
        private DelegateCommand eliminador;
        private ObservableCollection<clsPersona> listaPersonaCompleto;
        private ObservableCollection<clsPersona> listaPersonaOfrecido;
        private string textBoxBuscar;
        private clsPersona personaSeleccionada;
        #endregion
        #region constructor
        public VistaPersonaVM()
        {
            buscador = new DelegateCommand(Buscar, SePuedeBuscar);
            anhadidor = new DelegateCommand(Anhadir, SePuedeAnhadir);
            eliminador = new DelegateCommand(Eliminar, SePuedeEliminarar);
            ListaPersonaCompleto = new ObservableCollection<clsPersona>(Listados_Personas_BL.Listado_Completo_Personas_BL());
            ListaPersonaOfrecido = ListaPersonaCompleto;
        }
        #endregion
        #region propiedades publicas
        public DelegateCommand Buscador { get => buscador; }
        public DelegateCommand Anhadidor { get => anhadidor; set => anhadidor = value; }
        public DelegateCommand Eliminador { get => eliminador; }
        public ObservableCollection<clsPersona> ListaPersonaCompleto { get => listaPersonaCompleto; set => listaPersonaCompleto = value; }
        public ObservableCollection<clsPersona> ListaPersonaOfrecido { get => listaPersonaOfrecido; set => listaPersonaOfrecido = value; }
        public string TextBoxBuscar
        {
            get => textBoxBuscar;
            set
            {
                textBoxBuscar = value;
                if (String.IsNullOrEmpty(value))
                {
                    listaPersonaOfrecido = listaPersonaCompleto;
                    NotifyPropertyChanged("ListaPersonaOfrecido");
                }
                buscador.RaiseCanExecuteChanged();
            }
        }
        public clsPersona PersonaSeleccionada
        {
            get => personaSeleccionada;
            set
            {
                personaSeleccionada = value;
                eliminador.RaiseCanExecuteChanged();
            }
        }

        #endregion
        #region propiedades privadas
        private void Buscar()
        {
            listaPersonaOfrecido = new ObservableCollection<clsPersona>(from personas in listaPersonaCompleto
                                                                        where personas.Nombre.ToLower().Contains(textBoxBuscar) ||
                                                                                personas.Apellidos.ToLower().Contains(textBoxBuscar)
                                                                        select personas);
            NotifyPropertyChanged("ListaPersonaOfrecido");
        }
        private bool SePuedeBuscar()
        {   
            return !String.IsNullOrEmpty(textBoxBuscar);
        }
        private void Anhadir()
        {
            //Leva a pagina anhadir
        }
        private bool SePuedeAnhadir()
        {
            return true;
        }
        private void Eliminar()
        {

            ListaPersonaCompleto.Remove(personaSeleccionada);
            if (ListaPersonaOfrecido.Contains(personaSeleccionada))
                ListaPersonaOfrecido.Remove(personaSeleccionada);
        }

        private bool SePuedeEliminarar()
        {   
            return !(personaSeleccionada is null);
        }
        #endregion
    }
}
