using CRUD_Personas_BBDD_Azure_UWP.ViewModels.Utilidades;
using CRUD_Personas_BBDD_Azure_UWP.Views;
using CRUD_Personas_BL.Listados;
using CRUD_Personas_BL.Manejadoras;
using CRUD_Personas_Entities;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.UI.Xaml.Controls;

namespace CRUD_Personas_BBDD_Azure_UWP.ViewModels
{
    public class VistaAnhadirEditarPersonaVM : clsVMBase
    {
        #region atributos
        private ObservableCollection<clsDepartamento> listaDepartamentos;
        private clsPersona oPersona;
        private clsImagen foto;
        private DelegateCommand seleccionarFoto;
        private DelegateCommand guardarFoto;
        private string tipo;
        #endregion
        #region construccion

        public VistaAnhadirEditarPersonaVM()
        {
            //En caso de haber numerosos DelegateComand crearlos en el get de cada comand (solo se llama una vez, igual de eficiente)
            seleccionarFoto = new DelegateCommand(Seleccionar, SePuedeSeleccionar);
            guardarFoto = new DelegateCommand(Guardar, SePuedeGuardar);
            ListaDepartamentos = new ObservableCollection<clsDepartamento>(Listados_Departamentos_BL.Listado_Completo_Departamentos_BL());
            OPersona = new clsPersona();
            Foto = new clsImagen();
            Tipo = "Crear";
        }

        #endregion
        #region propiedades publicas
        public ObservableCollection<clsDepartamento> ListaDepartamentos { get => listaDepartamentos; set => listaDepartamentos = value; }
        public clsPersona OPersona { get => oPersona; set =>  oPersona = value; }
        public DelegateCommand SeleccionarFoto { get => seleccionarFoto;}
        public DelegateCommand GuardarFoto { get => guardarFoto;}
        public clsImagen Foto { get => foto; set => foto = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        #endregion
        #region Commands
        /// <summary>
        /// Cabecera: private void Seleccionar()
        /// Descripcion: Abre el navegador para seleccionar una foto
        /// Precondiciones: ninguna
        /// Postcondiciones:ninguna
        /// </summary>
        private async void Seleccionar() //Se puede hacer simplemente un metodo
        {
            //Podria ser un metodo
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                Foto.Fichero = file;
            //    NotifyPropertyChanged(nameof(Foto.Fichero));
            //    OPersona.Foto = Foto.ArrayFoto;
            //    NotifyPropertyChanged(nameof(Foto.Bitmap));
            }
        }
        /// <summary>
        /// Cabecera: private bool SePuedeSeleccionar()
        /// Descripcion: Metodo necesario construir el Command de seleccionar
        /// Precondiciones: ninguna
        /// Postcondiciones:ninguna
        /// </summary>
        /// <returns> true</returns>
        private bool SePuedeSeleccionar()
        {
            return true;
        }
        /// <summary>
        /// Cabecera: private async void Guardar()
        /// Descripcion: Asegura setear una serie de propiedades de la clase persona
        /// Precondiciones: ninguna
        /// Postcondiciones:ninguna
        /// </summary>
        private async void Guardar()
        {
            OPersona.Foto = Foto.ArrayFoto; //Settear al seleccionar no almacena la foto en el objeto persona
            if (OPersona.IdDepartamento == 0)
                OPersona.IdDepartamento = 1; //Seteamos el departamento al epartamento por defecto
        }
        /// <summary>
        /// Cabecera: private bool SePuedeGuardar()
        /// Descripcion: Habilitar y deshabilitar el Command de Guardar si se han rellenado los campos requeridos
        /// Precondiciones: ninguna
        /// Postcondiciones:ninguna
        /// </summary>
        /// <returns> Un buleano que indica si se debe habilitar el boton de guardar</returns>

        private bool SePuedeGuardar()
        {
            return (!String.IsNullOrEmpty(OPersona.Nombre) && !String.IsNullOrEmpty(OPersona.Apellidos));
        }
        #endregion
    }
}
