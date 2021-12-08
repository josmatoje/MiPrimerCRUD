using CRUD_Personas_BBDD_Azure_UWP.ViewModels.Utilidades;
using CRUD_Personas_BL.Manejadoras;
using CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace CRUD_Personas_BBDD_Azure_UWP.ViewModels
{
    public class VistaAnhadirEditarDepartamentoVM : clsVMBase
    {
        #region atributo
        private clsDepartamento nuevoDepartamento;
        private DelegateCommand guardador;
        #endregion
        #region constructor
        public VistaAnhadirEditarDepartamentoVM()
        {
            NuevoDepartamento = new clsDepartamento();
            guardador = new DelegateCommand(Guardar, SePuedeGuardar);
        }
        #endregion
        #region propiedades publicas
        public clsDepartamento NuevoDepartamento { get => nuevoDepartamento; set => nuevoDepartamento = value; }
        public DelegateCommand Guardador { get => guardador; }
        #endregion
        #region Comands
        private async void Guardar()
        {
            //TODO: unificar el metodo de insercion y edicion en la DAL
            if (nuevoDepartamento.ID == 0)
                Manejadores_Departamentos_BL.Insertar_Departamento_BL(NuevoDepartamento);
            else
                Manejadores_Departamentos_BL.Editar_Departamento_BL(NuevoDepartamento);

            ContentDialog mensajeConfirmacion = new ContentDialog()
            {
                Title = "DEPARTAMENTO GUARDADO",
                Content = "El departamento se ha guardado",
                CloseButtonText = "Confirmar"
            };

            ContentDialogResult respuesta = await mensajeConfirmacion.ShowAsync();
        }
        private bool SePuedeGuardar()
        {
            return !String.IsNullOrEmpty(NuevoDepartamento.Nombre);
        }
        #endregion
    }
}
