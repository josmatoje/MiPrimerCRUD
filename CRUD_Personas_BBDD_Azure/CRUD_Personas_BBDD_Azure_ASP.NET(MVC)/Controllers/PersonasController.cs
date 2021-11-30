using CRUD_Personas_BBDD_Azure_ASP.NET_MVC_.Models;
using CRUD_Personas_BBDD_Azure_ASP.NET_MVC_.Models.ViewModels;
using CRUD_Personas_BL.Listados;
using CRUD_Personas_DAL.Manejadora;
using CRUD_Personas_Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace CRUD_Personas_BBDD_Azure_ASP.NET_MVC_.Controllers
{
    public class PersonasController : Controller
    {
        // GET: CRUDController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CRUDController/Details/5
        public ActionResult Details(int id)
        {
            ActionResult action = null;
            try {
                clsPersona oPersona = Listados_Personas_BL.PersonaIndicada_BL(id);
                PersonaNombreDepartamentoVM oPersonaNombreDepartamento = new PersonaNombreDepartamentoVM(oPersona, Listados_Departamentos_BL.DepartamentoSeleccionado_BL(oPersona.IdDepartamento).Nombre);
                action= View(oPersonaNombreDepartamento);
            }
            catch
            {
                ErrorViewModel evm = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
                action = View("Error", evm);
            }
            return action;
        }

        // GET: CRUDController/Create
        public ActionResult Create()
        {
            ActionResult action = null;
            try {
                PersonaListaDepartamentoVM oPersonaListaDepartamento = new PersonaListaDepartamentoVM(new clsPersona(), Listados_Departamentos_BL.Listado_Completo_Departamentos_BL());
                action = View(oPersonaListaDepartamento);
            }
            catch
            {
                ErrorViewModel evm = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
                action = View("Error", evm);
            }
            return action;
        }

        // POST: CRUDController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(clsPersona oPersona)
        {
            ActionResult action = null;
            try
            {
                Manejadores_Personas_DAL.Editar_Persona_DAL(oPersona);
                PersonaListaDepartamentoVM oPersonaListaDepartamento = new PersonaListaDepartamentoVM(oPersona, Listados_Departamentos_BL.Listado_Completo_Departamentos_BL());
                action = RedirectToAction(nameof(Index));
            }
            catch
            {
                ErrorViewModel evm = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
                action = View("Error", evm);
            }
            return action;
        }

        // GET: CRUDController/Edit/5
        public ActionResult Edit(int id)
        {
            ActionResult action=null;
            try {
                clsPersona oPersona = Listados_Personas_BL.PersonaIndicada_BL(id);
                PersonaListaDepartamentoVM oPersonaListaDepartamento = new PersonaListaDepartamentoVM(oPersona, Listados_Departamentos_BL.Listado_Completo_Departamentos_BL());
                action = View(oPersonaListaDepartamento);
            }catch
            {
                ErrorViewModel evm = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
                action= View("Error", evm);
            }
            return action;
        }

        // POST: CRUDController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(clsPersona oPersona)
        {
            try
            {
                Manejadores_Personas_DAL.Editar_Persona_DAL(oPersona);
                PersonaListaDepartamentoVM oPersonaListaDepartamento = new PersonaListaDepartamentoVM (oPersona, Listados_Departamentos_BL.Listado_Completo_Departamentos_BL());
                return RedirectToAction();
            }
            catch
            {
                return View("Home/Index");
            }
        }

        // GET: CRUDController/Delete/5
        public ActionResult Delete(int id)
        {
            try {
                clsPersona oPersona = Listados_Personas_BL.PersonaIndicada_BL(id);
                PersonaNombreDepartamentoVM oPersonaDepartamento = new PersonaNombreDepartamentoVM(oPersona, Listados_Departamentos_BL.DepartamentoSeleccionado_BL(oPersona.IdDepartamento).Nombre);
                return View(oPersonaDepartamento);
            }catch
            {
                ErrorViewModel evm = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
                return View("Error", evm);
            }
        }

        // POST: CRUDController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
