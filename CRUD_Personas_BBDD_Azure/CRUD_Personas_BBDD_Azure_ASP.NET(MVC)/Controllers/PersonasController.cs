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
using System.IO;
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
                action = View("Error");
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
                action = View("Error");
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
                oPersona.FechaNacimiento=DateTime.Now; //Seteamos al día actual para comodida de la insercion de datos
                PersonaListaDepartamentoVM oPersonaListaDepartamento = new PersonaListaDepartamentoVM(oPersona, Listados_Departamentos_BL.Listado_Completo_Departamentos_BL());
                action = View(oPersonaListaDepartamento);
            }
            catch
            {
                action = View("Error");
            }
            return action;
        }

        // POST: CRUDController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonaListaDepartamentoVM oPersonaListaDepartamento, IFormFile foto)
        {
            ActionResult action = null;
            try
            {
                oPersonaListaDepartamento.ListaDepartamento=Listados_Departamentos_BL.Listado_Completo_Departamentos_BL();
                clsPersona opersona = Listados_Personas_BL.PersonaIndicada_BL(oPersonaListaDepartamento.Id);
                if (foto is not null)
                {
                    using (var ms = new MemoryStream())
                    {
                        foto.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        oPersonaListaDepartamento.Foto = fileBytes;
                    }
                }
                if (ModelState.IsValid)
                {
                    Manejadores_Personas_BL.Insertar_Persona_BL(oPersonaListaDepartamento);
                    action = RedirectToAction(nameof(Index));
                }
                else
                {
                    action = View(oPersonaListaDepartamento);
                }
            }
            catch
            {
                action = View("Error");
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
                action = View("Error");
            }
            return action;
        }

        // POST: CRUDController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonaListaDepartamentoVM oPersonaListaDepartamento, IFormFile foto)
        {
            ActionResult action = null;
            try
            {
                oPersonaListaDepartamento.ListaDepartamento = Listados_Departamentos_BL.Listado_Completo_Departamentos_BL();//Cargamos la lista de departamentos
                clsPersona opersona = Listados_Personas_BL.PersonaIndicada_BL(oPersonaListaDepartamento.Id);
                if (opersona.Foto is not null)
                    oPersonaListaDepartamento.Foto = opersona.Foto;
                if (foto is not null)
                {
                    using (var ms = new MemoryStream())
                    {
                        foto.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        oPersonaListaDepartamento.Foto = fileBytes;
                    }
                }
                if (ModelState.IsValid)
                {
                    Manejadores_Personas_BL.Editar_Persona_BL(oPersonaListaDepartamento);
                    action =  RedirectToAction(nameof(Details),new { id = oPersonaListaDepartamento.Id });//¿Por que es necesario un new id?
                }
                else
                {
                    action = View(oPersonaListaDepartamento);
                }
                
            }
            catch
            {
                action = View("Error");
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
                action = View(oPersonaDepartamento);
            }
            catch
            {
                action = View("Error");
            }
            return action;
        }

        // POST: CRUDController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            ActionResult action = null;
            try
            {
                Manejadores_Personas_BL.Borrar_Persona_BL(id);
                action =  RedirectToAction(nameof(Index));
            }
            catch
            {
                action = View("Error");
            }
            return action;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
