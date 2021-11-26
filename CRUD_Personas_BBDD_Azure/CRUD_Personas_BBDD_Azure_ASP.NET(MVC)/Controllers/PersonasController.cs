using CRUD_Personas_BL.Listados;
using CRUD_Personas_Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            clsPersona oPersona = Listados_Personas_BL.PersonaIndicada_BL(id);
            return View(oPersona);
        }

        // GET: CRUDController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CRUDController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CRUDController/Edit/5
        public ActionResult Edit(int id)
        {
            clsPersona oPersona = Listados_Personas_BL.PersonaIndicada_BL(id);
            return View(oPersona);
        }

        // POST: CRUDController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Home/Index");
            }
        }

        // GET: CRUDController/Delete/5
        public ActionResult Delete(int id)
        {
            clsPersona oPersona = Listados_Personas_BL.PersonaIndicada_BL(id);
            return View(oPersona);
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
