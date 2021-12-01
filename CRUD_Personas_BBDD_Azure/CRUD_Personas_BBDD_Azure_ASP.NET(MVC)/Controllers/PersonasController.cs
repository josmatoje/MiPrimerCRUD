using CRUD_Personas_BBDD_Azure_ASP.NET_MVC_.Models;
using CRUD_Personas_BBDD_Azure_ASP.NET_MVC_.Models.ViewModels;
using CRUD_Personas_BL.Listados;
using CRUD_Personas_BL.Manejadoras;
using CRUD_Personas_Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Personas_BBDD_Azure_ASP.NET_MVC_.Controllers
{
    public class PersonasController : Controller
    {
        private readonly ILogger<PersonasController> _logger;

        public PersonasController(ILogger<PersonasController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            ActionResult action = null;
            try
            {
                IndexVM indice = new IndexVM();
                action = View(indice);
            }
            catch
            {
                ErrorViewModel evm = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
                action = View("Error", evm);
            }
            return action;
        }
        // GET: CRUDController/Details/5
        public ActionResult Details(int id)
        {
            ActionResult action = null;
            try
            {
                clsPersona oPersona = Listados_Personas_BL.PersonaIndicada_BL(id);
                PersonaNombreDepartamentoVM oPersonaNombreDepartamento = new PersonaNombreDepartamentoVM(oPersona, Listados_Departamentos_BL.DepartamentoSeleccionado_BL(oPersona.IdDepartamento).Nombre);
                action = View(oPersonaNombreDepartamento);
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
            try
            {
                clsPersona oPersona = new clsPersona();
                PersonaListaDepartamentoVM oPersonaListaDepartamento = new PersonaListaDepartamentoVM(oPersona, Listados_Departamentos_BL.Listado_Completo_Departamentos_BL());
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
                Manejadores_Personas_BL.Insertar_Persona_BL(oPersona);
                action = RedirectToAction("Index");
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
            ActionResult action = null;
            try
            {
                clsPersona oPersona = Listados_Personas_BL.PersonaIndicada_BL(id);
                PersonaListaDepartamentoVM oPersonaListaDepartamento = new PersonaListaDepartamentoVM(oPersona, Listados_Departamentos_BL.Listado_Completo_Departamentos_BL());
                action = View(oPersonaListaDepartamento);
            }
            catch
            {
                ErrorViewModel evm = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
                action = View("Error", evm);
            }
            return action;
        }

        // POST: CRUDController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(clsPersona oPersona, IFormFile foto)
        {
            ActionResult action = null;
            try
            {
                Manejadores_Personas_BL.Editar_Persona_BL(oPersona);
                PersonaListaDepartamentoVM oPersonaListaDepartamento = new PersonaListaDepartamentoVM(oPersona, Listados_Departamentos_BL.Listado_Completo_Departamentos_BL());
                return RedirectToAction();
            }
            catch
            {
                ErrorViewModel evm = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
                action = View("Error", evm);
            }
            return action;
        }

        // GET: CRUDController/Delete/5
        public ActionResult Delete(int id)
        {
            ActionResult action = null;
            try
            {
                clsPersona oPersona = Listados_Personas_BL.PersonaIndicada_BL(id);
                PersonaNombreDepartamentoVM oPersonaDepartamento = new PersonaNombreDepartamentoVM(oPersona, Listados_Departamentos_BL.DepartamentoSeleccionado_BL(oPersona.IdDepartamento).Nombre);
                return View(oPersonaDepartamento);
            }
            catch
            {
                ErrorViewModel evm = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
                action = View("Error", evm);
            }
            return action;
        }

        // POST: CRUDController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            ActionResult action = null;
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ErrorViewModel evm = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
                action = View("Error", evm);
            }
            return action;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
