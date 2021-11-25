using CRUD_Personas_BL.Listados;
using CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Personas_BBDD_Azure_ASP.NET_MVC_.Models.ViewModels
{
    public class IndexVM
    {
        private ObservableCollection<clsPersonaIndex> listaPrincipal;

        public IndexVM()
        {
            List<clsPersona> listaPersonas = Listados_Personas_BL.Listado_Completo_Personas_BL();
            listaPrincipal = new ObservableCollection<clsPersonaIndex>();
            foreach(clsPersona oPersona in listaPersonas)
            {
                ListaPrincipal.Add(new clsPersonaIndex(oPersona));
            }
        }

        public ObservableCollection<clsPersonaIndex> ListaPrincipal { get => listaPrincipal; set => listaPrincipal = value; }
    }
}
