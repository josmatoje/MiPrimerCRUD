using CRUD_Personas_DAL.Listados;
using CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personas_BL
{
    public class BusinessLogicLayer
    {
        public static List<clsPersona> Listado_Personas_BL()
        {
            return Listados_DAL.Listado_Personas_DAL();
        }
        public static List<clsDepartamento> Listado_Departamentos_BL()
        {
            return Listados_DAL.Listado_Departamentos_DAL();
        }
    }
}
