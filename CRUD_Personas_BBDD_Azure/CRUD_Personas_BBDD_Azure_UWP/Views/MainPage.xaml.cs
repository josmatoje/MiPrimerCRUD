using CRUD_Personas_BBDD_Azure_UWP.Views;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace CRUD_Personas_BBDD_Azure_UWP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            contenedor.Navigate(typeof(Bienvenida));
        }
        /// <summary>
        /// Evento que controla el NavigationViewItem sobre el que se hace click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void EleccionPrincipal_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            NavigationViewItem paginaSeleccionada = (NavigationViewItem)sender.SelectedItem;
            try
            {
                switch (paginaSeleccionada.Name)
                {
                    case "vistaPersonas":
                        contenedor.Navigate(typeof(VistaPersona));
                        break;
                    case "vistaDepartamentos":
                        contenedor.Navigate(typeof(VistaDepartamentos));
                        break;
                }
            }
            catch
            {
                contenedor.Navigate(typeof(Error));
            }
            
        }
    }
}
