using CRUD_Personas_BL.Listados;
using CRUD_Personas_BL.Manejadoras;
using CRUD_Personas_Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD_Personas_BBDD_Azure_ASP.NET_MVC_.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class Departamentos : ControllerBase
    {
        // GET: api/<Departamentos>
        [HttpGet]
        public IEnumerable<clsDepartamento> Get()
        {
            return Listados_Departamentos_BL.Listado_Completo_Departamentos_BL();
        }

        // GET api/<Departamentos>/5
        [HttpGet("{id}")]
        public clsDepartamento Get(int id)
        {
            return Listados_Departamentos_BL.DepartamentoSeleccionado_BL(id);
        }

        // POST api/<Departamentos>
        [HttpPost]
        public void Post([FromBody] clsDepartamento value)
        {
            Manejadores_Departamentos_BL.Insertar_Departamento_BL(value);
        }

        // PUT api/<Departamentos>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] clsDepartamento value)
        {
            Manejadores_Departamentos_BL.Editar_Departamento_BL(value);
        }

        // DELETE api/<Departamentos>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Manejadores_Departamentos_BL.Borrar_Departamento_BL(id);
        }
    }
}
