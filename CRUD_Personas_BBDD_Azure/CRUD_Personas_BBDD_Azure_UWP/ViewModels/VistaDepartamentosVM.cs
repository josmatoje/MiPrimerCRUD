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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ListaDepartamentoOfrecida = ListaDepartamentoCompleta;
        }
        #endregion
        #region propiedades publicas
        public DelegateCommand Buscador { get => buscador; }
        public DelegateCommand Editor { get => editor; }
        public DelegateCommand Eliminador { get => eliminador; }
        public ObservableCollection<clsDepartamento> ListaDepartamentoCompleta { get => listaDepartamentoCompleta; set => listaDepartamentoCompleta = value; }
        public ObservableCollection<clsDepartamento> ListaDepartamentoOfrecida { get => listaDepartamentoOfrecida; set => listaDepartamentoOfrecida = value; }
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
                Eliminador.RaiseCanExecuteChanged();
                Editor.RaiseCanExecuteChanged();
                NotifyPropertyChanged(nameof(DepartamentoSeleccionado));
            }
        }
        #endregion
        #region comands
        private void Buscar()
        {
            ListaDepartamentoOfrecida = new ObservableCollection<clsDepartamento>(from departamento in ListaDepartamentoOfrecida
                                                                        where departamento.Nombre.ToLower().Contains(textBoxBuscar)
                                                                        select departamento);
            NotifyPropertyChanged("ListaPersonaOfrecido");
        }
        private bool SePuedeBuscar()
        {
            return !String.IsNullOrEmpty(TextBoxBuscar);
        }
        private void Editar()
        {
            //Habilita edicion
        }
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

        private bool SePuedeEditarEliminarar()
        {
            return !(DepartamentoSeleccionado is null || DepartamentoSeleccionado.ID==1);
        }

        #endregion
    }
}
