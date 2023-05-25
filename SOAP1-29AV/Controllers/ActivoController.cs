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
    public class ActivoController : Controller
    {
        private readonly IActivo _activoService;
        public ActivoController(IActivo activo)
        {
            _activoService = activo;
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        public ActionResult<Activo> PostActivo([FromBody] PostActivoRequest request)
        {
            return Ok(_activoService.RegisterActivo(request));
        }
    }
}
