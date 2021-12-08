﻿using CRUD_Personas_BBDD_Azure_UWP.ViewModels.Utilidades;
using CRUD_Personas_BL.Listados;
using CRUD_Personas_BL.Manejadoras;
using CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
        
        #endregion
        #region propiedades publicas
        public ObservableCollection<clsDepartamento> ListaDepartamentos { get => listaDepartamentos; set => listaDepartamentos = value; }
        public clsPersona OPersona { get => oPersona; set =>  oPersona = value; }
        public DelegateCommand SeleccionarFoto { get => seleccionarFoto;}
        public DelegateCommand GuardarFoto { get => guardarFoto;}
        public clsImagen Foto { get => foto; set => foto = value; }
        #endregion
        #region Commands
        private async void Seleccionar()
        {
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
        private bool SePuedeSeleccionar()
        {
            return true;
        }
        private async void Guardar()
        {
            OPersona.Foto = Foto.ArrayFoto; //Settear al seleccionar no almacena la foto en el objeto persona
            //TODO: unificar el metodo de insercion y edicion en la DAL
            try
            {
                if (OPersona.Id == 0)
                    Manejadores_Personas_BL.Insertar_Persona_BL(OPersona);
                else
                    Manejadores_Personas_BL.Editar_Persona_BL(OPersona);

                ContentDialog mensajeConfirmacion = new ContentDialog()
                {
                    Title = "PERSONA GUARDADA",
                    Content = "La persona se ha guardado",
                    CloseButtonText = "Confirmar"
                };

                ContentDialogResult respuesta = await mensajeConfirmacion.ShowAsync();
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
        private bool SePuedeGuardar()
        {
            return (!String.IsNullOrEmpty(OPersona.Nombre) && !String.IsNullOrEmpty(OPersona.Apellidos));
        }
        #endregion
    }
}