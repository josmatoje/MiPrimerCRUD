using CRUD_Personas_BL;
using CRUD_Personas_BL.Listados;
using CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_Personas_BBDD_Azure_UWP.ViewModels.Utilidades;
using CRUD_Personas_BL.Manejadoras;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using CRUD_Personas_BBDD_Azure_UWP.Model;
using CRUD_Personas_BBDD_Azure_UWP.Views;

namespace CRUD_Personas_BBDD_Azure_UWP.ViewModels
{
    public class VistaPersonasVM : clsVMBase
    {
        #region atributos
        private DelegateCommand buscador;
        private DelegateCommand editor;
        private DelegateCommand eliminador;
        private List <clsPersona> listaPersonaCompleto;
        private ObservableCollection<PersonaNombreDepartamento> listaPersonaOfrecido;
        private List<clsDepartamento> listaDepartamentos;
        private string textBoxBuscar;
        private PersonaNombreDepartamento personaSeleccionada;
        private clsImagen oImagen;
        #endregion
        #region constructor
        public VistaPersonasVM()
        {
            //En caso de haber numerosos DelegateComand crearlos en el get de cada comand (solo se llama una vez, igual de eficiente)
            buscador = new DelegateCommand(Buscar, SePuedeBuscar);
            editor = new DelegateCommand(Editar, SePuedeEliminararEditar);
            eliminador = new DelegateCommand(Eliminar, SePuedeEliminararEditar);
            try
            {
                ListaPersonaCompleto = new List<clsPersona>(Listados_Personas_BL.Listado_Simple_Personas_BL()); //Se recoge una lista simple con Id, Nobre, Apellidos
                ListaDepartamentos = new List<clsDepartamento>(Listados_Departamentos_BL.Listado_Completo_Departamentos_BL());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ListaPersonaOfrecido = new ObservableCollection<PersonaNombreDepartamento>();
            ListaPersonaCompleto.ForEach(persona => ListaPersonaOfrecido.Add(new PersonaNombreDepartamento(persona)));
            //ListaPersonaOfrecido = new ObservableCollection<PersonaNombreDepartamento>((IEnumerable<PersonaNombreDepartamento>)ListaPersonaCompleto);
            OImagen = new clsImagen();
        }
        #endregion
        #region propiedades publicas
        public DelegateCommand Buscador { get => buscador; }
        public DelegateCommand Editor { get => editor; }
        public DelegateCommand Eliminador { get => eliminador; }
        public List<clsPersona> ListaPersonaCompleto { get => listaPersonaCompleto; set => listaPersonaCompleto = value; }
        public ObservableCollection<PersonaNombreDepartamento> ListaPersonaOfrecido { get => listaPersonaOfrecido; set => listaPersonaOfrecido = value; }
        public string TextBoxBuscar
        {
            get => textBoxBuscar;
            set
            {
                textBoxBuscar = value;
                if (String.IsNullOrEmpty(value))
                {
                    ListaPersonaOfrecido = new ObservableCollection<PersonaNombreDepartamento>();
                    ListaPersonaCompleto.ForEach(persona => ListaPersonaOfrecido.Add(new PersonaNombreDepartamento(persona)));
                    NotifyPropertyChanged(nameof(ListaPersonaOfrecido));
                }
                Buscador.RaiseCanExecuteChanged();
            }
        }
        public PersonaNombreDepartamento PersonaSeleccionada
        {
            get => personaSeleccionada;
            set
            {
                personaSeleccionada=value;
                try
                {
                    if(!(personaSeleccionada is null)) { //Valoramos el caso de desseleccionar (eliminar)
                        if (personaSeleccionada.Foto is null) { //En caso de que la foto sea nula, la consulta no será tan lenta y es posible que no se hayan recogido los datos completos de la persona
                                                                                                //Si la foto no es nula solo puede darse el caso de haber recogido los datos de la persona
                            clsPersona personaSinDepartamento = new clsPersona(Listados_Personas_BL.PersonaIndicada_BL(personaSeleccionada.Id));
                            if (ListaPersonaCompleto.First(x => x.Id == value.Id).FechaNacimiento == DateTime.MinValue)
                            {
                                ListaPersonaCompleto.First(x => x.Id == value.Id).FechaNacimiento = personaSinDepartamento.FechaNacimiento;
                                personaSeleccionada.FechaNacimiento = personaSinDepartamento.FechaNacimiento;
                            }
                            if (ListaPersonaCompleto.First(x => x.Id == value.Id).Direccion == null)
                            {
                                ListaPersonaCompleto.First(x => x.Id == value.Id).Direccion = personaSinDepartamento.Direccion;
                                personaSeleccionada.Direccion = personaSinDepartamento.Direccion;
                            }
                            if (ListaPersonaCompleto.First(x => x.Id == value.Id).Telefono == null)
                            {
                                ListaPersonaCompleto.First(x => x.Id == value.Id).Telefono = personaSinDepartamento.Telefono;
                                personaSeleccionada.Telefono = personaSinDepartamento.Telefono;
                            }
                            if (ListaPersonaCompleto.First(x => x.Id == value.Id).Foto == null)
                            {
                                ListaPersonaCompleto.First(x => x.Id == value.Id).Foto = personaSinDepartamento.Foto;
                                personaSeleccionada.Foto = personaSinDepartamento.Foto;
                            }
                            if ((ListaPersonaCompleto.First(x => x.Id == value.Id).IdDepartamento) == 0)
                            {
                                ListaPersonaCompleto.First(x => x.Id == value.Id).IdDepartamento = personaSinDepartamento.IdDepartamento==0?1:personaSeleccionada.IdDepartamento;//Caso de error, ya solucionado
                                personaSeleccionada.IdDepartamento = personaSinDepartamento.IdDepartamento;
                            }
                        }

                        personaSeleccionada.NombreDepartamento = ListaDepartamentos.First(x => x.ID == personaSeleccionada.IdDepartamento).Nombre; //Asignamos el nombre departamento a la persona asignada
                    }
                }
                catch
                {
                    MensajeError();
                }
                NotifyPropertyChanged(nameof(PersonaSeleccionada));
                oImagen.ArrayFoto = personaSeleccionada==null?null:personaSeleccionada.Foto ;
                NotifyPropertyChanged(nameof(OImagen));
                eliminador.RaiseCanExecuteChanged();
                editor.RaiseCanExecuteChanged();
            }
        }
        public List<clsDepartamento> ListaDepartamentos { get => listaDepartamentos; set => listaDepartamentos = value; }
        public clsImagen OImagen { get => oImagen; set => oImagen = value; }
        #endregion
        #region comands
        /// <summary>
        /// Cabecera: private void Buscar()
        /// Descripcion: Metodo que filtra la lista de personas segun los datos introducidos
        /// Precondiciones: ninguna
        /// Postcondiciones:ninguna
        /// </summary>
        private void Buscar()
        {
            ListaPersonaOfrecido = new ObservableCollection<PersonaNombreDepartamento>();
            List<clsPersona> auxPersonas = ListaPersonaCompleto.Where(personas => personas.Nombre.ToLower().Contains(textBoxBuscar) ||
                                                   personas.Apellidos.ToLower().Contains(textBoxBuscar)).ToList();
                                                                        //from personas in listaPersonaCompleto
                                                                        //where personas.Nombre.ToLower().Contains(textBoxBuscar) ||
                                                                        //        personas.Apellidos.ToLower().Contains(textBoxBuscar)
                                                                        //        select personas);
            auxPersonas.ForEach(x => ListaPersonaOfrecido.Add(new PersonaNombreDepartamento(x)));
            
            NotifyPropertyChanged(nameof(ListaPersonaOfrecido));
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
            return !String.IsNullOrEmpty(textBoxBuscar);
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
        /// Descripcion: Muestra un mensaje para pedir la confirmacion de eliminar la persona indicada y, en caso afirmativo, la elimina
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

            if(respuesta.HasFlag(ContentDialogResult.Secondary))
            {
                try
                {
                    Manejadores_Personas_BL.Borrar_Persona_BL(PersonaSeleccionada.Id);
                    ListaPersonaCompleto.Remove(PersonaSeleccionada);
                    if (ListaPersonaOfrecido.Contains(PersonaSeleccionada))
                        ListaPersonaOfrecido.Remove(PersonaSeleccionada);
                }
                catch
                {
                    MensajeError();
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
        private bool SePuedeEliminararEditar()
        {   
            return !(personaSeleccionada is null);
        }
        #endregion
        #region mensaje error
        /// <summary>
        /// Cabecera: private async void MensajeError()
        /// Descripcion: Método asincrono que muestra un mensaje de error
        /// Precondiciones: ninguna
        /// Postcondiciones:ninguna
        /// </summary>
        private async void MensajeError()
        {
            ContentDialog mensajeExito = new ContentDialog()
            {
                Title = "ERROR",
                Content = "Ha ocurrido un error inesperado",
                SecondaryButtonText = "Volver"
            };

            ContentDialogResult resultado = await mensajeExito.ShowAsync();
        }
        #endregion
    }
}
