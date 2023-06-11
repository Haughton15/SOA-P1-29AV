﻿using Azure;
using Domain.Entities;
using Domain.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using Service.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace SOAP1_29AV.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonasController : Controller
    {

        private readonly IPersona _persona;

        public PersonasController(IPersona persona)
        {
            _persona = persona;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_persona.GetEmpleados());
        }

        [HttpGet("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public ActionResult<ActivoEmpleadoVM> GetPerson(int id)
        {
            var response = _persona.GetPerson(id);
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        public IActionResult PostEmpleados([FromBody] PostEmpleadoRequest request)
        {
            var response = _persona.RegisterEmpleado(request);
            if(response  == null)
                return BadRequest();
            
            return Ok("Usuario creado con exito");
        }

        [HttpPut("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]

        public ActionResult<ActivoEmpleado> PatchPersona([FromRoute] int id, [FromBody] PatchPersonaRequest request)
        {
            var response = _persona.PatchPersona(id, request);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public ActionResult<bool> DeletePersona(int id)
        {
            var response = _persona.DeletePerson(id);
            if (response == false)
            {
                return NotFound();
            }
            return Ok("Registro eliminado con exito");
        }
    }
}
