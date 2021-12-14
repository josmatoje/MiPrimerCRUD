﻿using CRUD_Personas_BL.Listados;
using CRUD_Personas_BL.Manejadoras;
using CRUD_Personas_Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            return Listados_Personas_BL.Listado_Completo_Personas_BL();
        }

        // GET api/<Personas>/5
        [HttpGet("{id}")]
        public clsPersona Get(int id)
        {
            return Listados_Personas_BL.PersonaIndicada_BL(id);
        }

        // POST api/<Personas>
        [HttpPost]
        public void Post([FromBody] clsPersona persona)
        {
            Manejadores_Personas_BL.Insertar_Persona_BL(persona);
        }

        // PUT api/<Personas>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] clsPersona persona)
        {

            Manejadores_Personas_BL.Editar_Persona_BL(persona);
        }

        // DELETE api/<Personas>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            Manejadores_Personas_BL.Borrar_Persona_BL(id);
        }
    }
}