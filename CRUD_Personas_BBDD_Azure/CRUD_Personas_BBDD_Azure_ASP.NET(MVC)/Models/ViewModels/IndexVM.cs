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
            List<clsPersona> listaPersonas = new List<clsPersona> (Listados_Personas_BL.Listado_Completo_Personas_BL());
            List<clsDepartamento> listaDepartamentos =new List<clsDepartamento> (Listados_Departamentos_BL.Listado_Completo_Departamentos_BL());
            listaPrincipal = new ObservableCollection<clsPersonaIndex>();
            listaPersonas.ForEach(x => ListaPrincipal.Add(new clsPersonaIndex(x, listaDepartamentos.First(y=>y.ID==x.IdDepartamento).Nombre)));
        }

        public ObservableCollection<clsPersonaIndex> ListaPrincipal { get => listaPrincipal; set => listaPrincipal = value; }
    }
}
