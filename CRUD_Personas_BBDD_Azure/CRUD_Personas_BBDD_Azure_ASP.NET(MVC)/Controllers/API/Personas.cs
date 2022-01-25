using CRUD_Personas_BL.Listados;
using CRUD_Personas_BL.Manejadoras;
using CRUD_Personas_Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD_Personas_BBDD_Azure_ASP.NET_MVC_.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class Personas : ControllerBase
    {
        // GET: api/<Personas>
        [HttpGet]
        public IEnumerable<clsPersona> Get()
        {
            List<clsPersona> listado;

            try
            {
                listado = Listados_Personas_BL.Listado_Completo_Personas_BL();
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }

            return listado;
        }

        // GET api/<Personas>/5
        [HttpGet("{id}")]
        public clsPersona Get(int id)
        {
            clsPersona clsPersona;

            try
            {
                clsPersona = Listados_Personas_BL.PersonaIndicada_BL(id);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            return clsPersona;
        }

        // POST api/<Personas>
        [HttpPost]
        public void Post([FromBody] clsPersona persona)
        {
            try
            {
                if(Manejadores_Personas_BL.Insertar_Persona_BL(persona)==0)
                    throw new HttpResponseException(HttpStatusCode.NoContent);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
        }

        // PUT api/<Personas>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] clsPersona persona)
        {
            try
            {
                if (Manejadores_Personas_BL.Editar_Persona_BL(persona) == 0)
                    throw new HttpResponseException(HttpStatusCode.NoContent);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
        }

        // DELETE api/<Personas>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                if (Manejadores_Personas_BL.Borrar_Persona_BL(id) == 0)
                    throw new HttpResponseException(HttpStatusCode.NoContent);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
        }
    }
}
