using CRUD_Personas_BBDD_Azure_UWP.Model;
using CRUD_Personas_BBDD_Azure_UWP.ViewModels;
using CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class VistaPersona : Page
    {
        public VistaPersona()
        {
            try
            {
                this.InitializeComponent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Cabecera:protected override void OnNavigatedTo(NavigationEventArgs e)
        /// Descripcion: Define la persona seleccionada para el VM de la vista en caso de recibir un parametro al ser invocada
        /// Precondicion: en caso de recibir un parametro colo puede ser de tipo clsPersona
        /// PostCondiciones: ninguna
        /// </summary>
        /// <param name="e">parametro que recibe al navegar hacia la vista de la clase</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var oPersona = e.Parameter; //Valoramos si la persona recibida por parametros es nula
            if (oPersona != null)   //Si ha recibido algo, seteamos la persona seleccionada a este parametro
                (this.DataContext as VistaPersonasVM).PersonaSeleccionada = new PersonaNombreDepartamento((clsPersona)oPersona); 
        }
        /// <summary>
        /// Cabecera: private void Anhadir_Click(object sender, RoutedEventArgs e)
        /// Descripcion:
        /// Precondicion: ninguna
        /// Postcondicion: ninguna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Anhadir_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(VistaAnhadirEditarPersona));
        }
        /// <summary>
        /// Cabecera: private void Editar_Click(object sender, RoutedEventArgs e)
        /// Descripcion:
        /// Precondicion: ninguna
        /// Postcondicion: ninguna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(VistaAnhadirEditarPersona), (this.DataContext as VistaPersonasVM).PersonaSeleccionada as clsPersona);
        }
    }
}
