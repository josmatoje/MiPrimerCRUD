using CRUD_Personas_Entities;
using System.Collections.Generic;

namespace CRUD_Personas_BBDD_Azure_ASP.NET_MVC_.Models.ViewModels
{
    public class PersonaListaDepartamentoVM : clsPersona
    {
        #region atributos
        private List<clsDepartamento> listaDepartamento;
        #endregion
        #region constructores
        public PersonaListaDepartamentoVM() 
        {
            ListaDepartamento=new List<clsDepartamento>();
        }
        public PersonaListaDepartamentoVM(clsPersona persona, List<clsDepartamento> listaDepartamentos) : base(persona)
        {
            ListaDepartamento = listaDepartamentos;
        }
        public PersonaListaDepartamentoVM(clsPersona persona) : base(persona)
        {
            ListaDepartamento = new List<clsDepartamento>();
        }
        public PersonaListaDepartamentoVM(List<clsDepartamento> listaDepartamentos)
        {
            ListaDepartamento = listaDepartamentos;
        }
        #endregion
        #region propiedades publicas
        public List<clsDepartamento> ListaDepartamento { get => listaDepartamento; set => listaDepartamento = value; }
        #endregion
    }
}
