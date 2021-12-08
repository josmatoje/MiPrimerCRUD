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
    public sealed partial class VistaAnhadirEditarPersona : Page
    {
        public VistaAnhadirEditarPersona()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var param = (clsPersona)e.Parameter;
            if(param != null){
                (this.DataContext as VistaAnhadirEditarPersonaVM).OPersona = param;
                (this.DataContext as VistaAnhadirEditarPersonaVM).Foto.ArrayFoto = param.Foto;
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
    }
}
