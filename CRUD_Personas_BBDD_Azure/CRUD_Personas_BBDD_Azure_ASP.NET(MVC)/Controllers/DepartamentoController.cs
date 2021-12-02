using CRUD_Personas_BL.Listados;
using CRUD_Personas_BL.Manejadoras;
using CRUD_Personas_Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CRUD_Personas_BBDD_Azure_ASP.NET_MVC_.Controllers
{
    public class DepartamentoController : Controller
    {
        // GET: DepartamentoController
        public ActionResult Index()
        {
            ActionResult action = null;
            try
            {

                action = View(Listados_Departamentos_BL.Listado_Completo_Departamentos_BL().Where(departamento => departamento.ID != 1).ToList());
            }
            catch
            {
                action = View("Error");
            }
            return action;
        }

        // GET: DepartamentoController/Details/5
        public ActionResult Details(int id)
        {
            ActionResult action = null;
            try
            {
                action = View(Listados_Departamentos_BL.DepartamentoSeleccionado_BL(id));
            }
            catch
            {
                action = View("Error");
            }
            return action;
        }

        // GET: DepartamentoController/Create
        public ActionResult Create()
        {
            ActionResult action = null;
            try
            {
                action = View(new clsDepartamento());
            }
            catch
            {
                action = View("Error");
            }
            return action;
        }

        // POST: DepartamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(clsDepartamento departamento)
        {
            ActionResult action = null;
            try
            {
                Manejadores_Departamentos_BL.Insertar_Departamento_BL(departamento);
                action = RedirectToAction(nameof(Index));
            }
            catch
            {
                action = View("Error");
            }
            return action;
        }

        // GET: DepartamentoController/Edit/5
        public ActionResult Edit(int id)
        {
            ActionResult action = null;
            try
            {
                action = View(Listados_Departamentos_BL.DepartamentoSeleccionado_BL(id));
            }
            catch
            {
                action = View("Error");
            }
            return action;
        }

        // POST: DepartamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(clsDepartamento departamento)
        {
            ActionResult action = null;
            try
            {
                Manejadores_Departamentos_BL.Editar_Departamento_BL(departamento);
                action = RedirectToAction(nameof(Index));
            }
            catch
            {
                action = View("Error");
            }
            return action;
        }

        // GET: DepartamentoController/Delete/5
        public ActionResult Delete(int id)
        {
            ActionResult action = null;
            try
            {
                action = View(Listados_Departamentos_BL.DepartamentoSeleccionado_BL(id));
            }
            catch
            {
                action = View("Error");
            }
            return action;
        }

        // POST: DepartamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            ActionResult action = null;
            try
            {
                Manejadores_Departamentos_BL.Borrar_Departamento_BL(id);
                action = RedirectToAction(nameof(Index));
            }
            catch
            {
                action = View("Error");
            }
            return action;
        }
    }
}
