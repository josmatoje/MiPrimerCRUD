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
    public sealed partial class VistaDepartamentos : Page
    {
        public VistaDepartamentos()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// Evento que muestra la vista VistaAnhadirEditarDepartamento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Anhadir_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(VistaAnhadirEditarDepartamento));
        }
        /// <summary>
        /// Evento  que muestra la vista VistaAnhadirEditarDepartamento con la persona a editar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(VistaAnhadirEditarDepartamento), (this.DataContext as VistaDepartamentosVM).DepartamentoSeleccionado as clsDepartamento);
        }
        /// <summary>
        /// Evento que envia a la VistaPersona en la que se ha hecho doble Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listadoPersonas_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            clsPersona oPersona = ((ListView)sender).SelectedItem as clsPersona;
            this.Frame.Navigate(typeof(VistaPersona),oPersona);
        }
    }
}
