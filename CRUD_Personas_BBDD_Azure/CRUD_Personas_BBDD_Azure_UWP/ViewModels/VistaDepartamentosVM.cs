using CRUD_Personas_BBDD_Azure_UWP.ViewModels.Utilidades;
using CRUD_Personas_BL.Listados;
using CRUD_Personas_BL.Manejadoras;
using CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace CRUD_Personas_BBDD_Azure_UWP.ViewModels
{
    public class VistaDepartamentosVM:clsVMBase
    {

        #region atributos
        private DelegateCommand buscador;
        private DelegateCommand editor;
        private DelegateCommand eliminador;
        private ObservableCollection<clsDepartamento> listaDepartamentoCompleta;
        private ObservableCollection<clsDepartamento> listaDepartamentoOfrecida;
        private ObservableCollection<clsPersona> listaPersonaCompleta;
        private ObservableCollection<clsPersona> listaPersonaOfrecida;
        private string textBoxBuscar;
        private clsDepartamento departamentoSeleccionado;
        #endregion
        #region constructor
        public VistaDepartamentosVM()
        {
            buscador = new DelegateCommand(Buscar, SePuedeBuscar);
            editor = new DelegateCommand(Editar, SePuedeEditarEliminarar);
            eliminador = new DelegateCommand(Eliminar, SePuedeEditarEliminarar);
            try
            {
                ListaDepartamentoCompleta = new ObservableCollection<clsDepartamento>(Listados_Departamentos_BL.Listado_Completo_Departamentos_BL());
                ListaPersonaCompleta = new ObservableCollection<clsPersona>(Listados_Personas_BL.Listado_Completo_Personas_BL());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ListaDepartamentoOfrecida = ListaDepartamentoCompleta;
            ListaPersonaOfrecida = new ObservableCollection<clsPersona>();
        }
        #endregion
        #region propiedades publicas
        public DelegateCommand Buscador { get => buscador; }
        public DelegateCommand Editor { get => editor; }
        public DelegateCommand Eliminador { get => eliminador; }
        public ObservableCollection<clsDepartamento> ListaDepartamentoCompleta { get => listaDepartamentoCompleta; set => listaDepartamentoCompleta = value; }
        public ObservableCollection<clsDepartamento> ListaDepartamentoOfrecida { get => listaDepartamentoOfrecida; set => listaDepartamentoOfrecida = value; }
        public ObservableCollection<clsPersona> ListaPersonaCompleta { get => listaPersonaCompleta; set => listaPersonaCompleta = value; }
        public ObservableCollection<clsPersona> ListaPersonaOfrecida { get => listaPersonaOfrecida; set => listaPersonaOfrecida = value; }
        public string TextBoxBuscar
        {
            get => textBoxBuscar;
            set
            {
                textBoxBuscar = value;
                if (String.IsNullOrEmpty(value))
                {
                    ListaDepartamentoOfrecida = ListaDepartamentoCompleta;
                    NotifyPropertyChanged("ListaPersonaOfrecido");
                }
                Buscador.RaiseCanExecuteChanged();
            }
        }

        public clsDepartamento DepartamentoSeleccionado { 
            get => departamentoSeleccionado;
            set
            {
                departamentoSeleccionado = value;
                NotifyPropertyChanged(nameof(DepartamentoSeleccionado));
                ListaPersonaOfrecida = new ObservableCollection<clsPersona> (ListaPersonaCompleta.Where(x => x.IdDepartamento==departamentoSeleccionado.ID));
                NotifyPropertyChanged(nameof(ListaPersonaOfrecida));
                Eliminador.RaiseCanExecuteChanged();
                Editor.RaiseCanExecuteChanged();
            }
        }
        #endregion
        #region comands
        /// <summary>
        /// Cabecera: private void Buscar()
        /// Descripcion: Metodo que filtra la lista de departamentos segun los datos introducidos
        /// Precondiciones: ninguna
        /// Postcondiciones:ninguna
        /// </summary>
        private void Buscar()
        {
            ListaDepartamentoOfrecida = new ObservableCollection<clsDepartamento>(from departamento in ListaDepartamentoOfrecida
                                                                        where departamento.Nombre.ToLower().Contains(textBoxBuscar)
                                                                        select departamento);
            NotifyPropertyChanged("ListaPersonaOfrecido");
        }
        /// <summary>
        /// Cabecera: private bool SePuedeBuscar()
        /// Descripcion: Metodo necesario para habilitar y deshabilitar el Command de buscar
        /// Precondiciones: ninguna
        /// Postcondiciones:ninguna
        /// </summary>
        /// <returns> Un buleano que indica si se debe habilitar el boton de buscar</returns>
        private bool SePuedeBuscar()
        {
            return !String.IsNullOrEmpty(TextBoxBuscar);
        }
        /// <summary>
        /// Cabecera: private void Editar()
        /// Descripcion: Metodo que sirve como funcion para construir el delegateComand
        /// Precondiciones: ninguna
        /// Postcondiciones:ninguna
        /// </summary>
        private void Editar()
        {
            //Habilita edicion
        }
        /// <summary>
        /// Cabecera: private void Eliminar()
        /// Descripcion: Muestra un mensaje para pedir la confirmacion de eliminar el departamento indicado y, en caso afirmativo, la elimina
        /// Precondiciones: ninguna
        /// Postcondiciones:ninguna
        /// </summary>
        private async void Eliminar()
        {
            ContentDialog mensajeConfirmacion = new ContentDialog()
            {
                Title = "ELIMINAR PERSONA",
                Content = "¿Está seguro de que desea eliminar a esta persona?",
                SecondaryButtonText = "Confirmar",
                CloseButtonText = "Cancelar"
            };

            ContentDialogResult respuesta = await mensajeConfirmacion.ShowAsync();

            if (respuesta.HasFlag(ContentDialogResult.Secondary))
            {
                try
                {
                    Manejadores_Departamentos_BL.Borrar_Departamento_BL(DepartamentoSeleccionado.ID);
                    ListaDepartamentoCompleta.Remove(DepartamentoSeleccionado);
                    if (listaDepartamentoOfrecida.Contains(DepartamentoSeleccionado))
                        listaDepartamentoOfrecida.Remove(DepartamentoSeleccionado);
                }
                catch
                {
                    ContentDialog mensajeExito = new ContentDialog()
                    {
                        Title = "ERROR",
                        Content = "No se ha eliminado la persona correctamente",
                        SecondaryButtonText = "Volver"
                    };

                    ContentDialogResult resultado = await mensajeExito.ShowAsync();
                }
            }
        }
        /// <summary>
        /// Cabecera: private bool SePuedeEliminararEditar()
        /// Descripcion: Metodo necesario para habilitar y deshabilitar el Command de elimitar y editar
        /// Precondiciones: ninguna
        /// Postcondiciones:ninguna
        /// </summary>
        /// <returns> Un buleano que indica si se debe habilitar el boton de editar y el de eliminar</returns>
        private bool SePuedeEditarEliminarar()
        {
            return !(DepartamentoSeleccionado is null || DepartamentoSeleccionado.ID==1);
        }

        #endregion
    }
}
