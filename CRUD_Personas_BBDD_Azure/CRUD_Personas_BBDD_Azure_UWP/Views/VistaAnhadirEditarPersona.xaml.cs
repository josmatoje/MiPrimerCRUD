using CRUD_Personas_BBDD_Azure_UWP.ViewModels;
using CRUD_Personas_BL.Manejadoras;
using CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace CRUD_Personas_BBDD_Azure_UWP.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class VistaAnhadirEditarPersona : Page
    {
        public VistaAnhadirEditarPersona()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// Evento que recoge el parametro que se envia al navegar hacia esta vista y, en caso de ser una persona, lo asigna
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var param = (clsPersona)e.Parameter;
            if(param != null){
                vm.OPersona = param;
                vm.Foto.ArrayFoto = param.Foto;
                vm.Tipo="Editar";

            }
        }

        public void back_Click(object sender, RoutedEventArgs e)
        {
            //Button back = sender as Button;
            //if (back.Name.Equals("guardar"))
            //{
            //    WaitForChangedResult.ReferenceEquals(insertadoEditado, 1);
            //}
            this.Frame.Navigate(typeof(VistaPersona));
        }

        private void nombreApellido_TextChanged(object sender, TextChangedEventArgs e)
        {
            (this.DataContext as VistaAnhadirEditarPersonaVM).GuardarFoto.RaiseCanExecuteChanged();
        }

        private async void guardar_ClickAsync(object sender, RoutedEventArgs e)
        {
            bool guardar = true;
            try
            {
                //Mostrar mensajes de validaciones
                if (vm.OPersona.Nombre.Length > 30)
                {
                    nombreError.Visibility = Visibility.Visible;
                    guardar = false;
                }
                if (vm.OPersona.Apellidos.Length > 30)
                {
                    apellidosError.Visibility = Visibility.Visible;
                    guardar = false;
                }
                if(vm.OPersona.Telefono != null) //Comprobamos independientemente si telefono está nulo
                {
                    if (vm.OPersona.Telefono.Length > 12 )
                    {
                        telefonoError.Visibility = Visibility.Visible;
                        guardar = false;
                    }
                    else
                    {
                        try
                        {
                            int.Parse(vm.OPersona.Telefono);
                        }catch (FormatException)
                        {
                            telefonoFormatError.Visibility = Visibility.Visible;
                            guardar = false;
                        }
                    }
                }
                
                if (vm.OPersona.Direccion != null && vm.OPersona.Direccion.Length > 50)
                {
                    direccionError.Visibility = Visibility.Visible;
                    guardar = false;
                }
                if (vm.OPersona.FechaNacimiento != null && vm.OPersona.FechaNacimiento >= DateTime.Now)
                {
                    fechaError.Visibility = Visibility.Visible;
                    guardar = false;
                }
                if(guardar)
                {
                    //TODO: unificar el metodo de insercion y edicion en la DAL
                    if (vm.OPersona.Id == 0)
                        Manejadores_Personas_BL.Insertar_Persona_BL(vm.OPersona);
                    else
                        Manejadores_Personas_BL.Editar_Persona_BL(vm.OPersona);

                    ContentDialog mensajeConfirmacion = new ContentDialog()
                    {
                        Title = "PERSONA GUARDADA",
                        Content = "La persona se ha guardado",
                        CloseButtonText = "Confirmar"
                    };

                    ContentDialogResult respuesta = await mensajeConfirmacion.ShowAsync();

                    this.Frame.Navigate(typeof(VistaPersona),vm.OPersona);

                }
            }
            catch
            {
                ContentDialog mensajeExito = new ContentDialog()
                {
                    Title = "ERROR",
                    Content = "No se ha guardado la persona correctamente",
                    SecondaryButtonText = "Volver"
                };

                ContentDialogResult resultado = await mensajeExito.ShowAsync();
            }
        }
    }
}
