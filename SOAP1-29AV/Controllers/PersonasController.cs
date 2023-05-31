using Azure;
using Domain.Entities;
using Domain.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
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
            return Ok(_persona.RegisterEmpleado(request));
        }
    }
}
