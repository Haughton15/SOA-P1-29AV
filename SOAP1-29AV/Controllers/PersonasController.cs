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
            /*return Ok(_persona.GetEmpleados());*/
            return Ok();
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        public IActionResult PostEmpleados([FromBody] PostEmpleadoRequest request)
        {
            return Ok(_persona.RegisterEmpleado(request));
        }
    }
}
