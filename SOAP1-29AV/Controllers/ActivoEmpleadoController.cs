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
    public class ActivoEmpleadoController : Controller
    {
        private readonly IActivoEmpleado _activoEmpleadoService;
        public ActivoEmpleadoController(IActivoEmpleado activoEmpleado)
        {
            _activoEmpleadoService = activoEmpleado;
        }

        [HttpDelete("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public ActionResult<bool> DeleteActivoEmpleado(int id)
        {
            var response = _activoEmpleadoService.DeleteActivoEmpleado(id);
            if (response == false)
            {
                return NotFound();
            }
            return Ok("Registro eliminado con exito");
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        public ActionResult<String> PostActivoEmpleado([FromBody] PostActivoEmpleado request)
        {
            var response = Ok(_activoEmpleadoService.CreateActivoEmpleado(request));

            if(response == null)
                return NotFound();

            return Ok("Activo creado");
        }

        [HttpPatch("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]

        public ActionResult<ActivoEmpleado> PatchActivoEmpleado([FromRoute] int id, [FromBody] PatchActivoEmpleado request)
        {
            var response = _activoEmpleadoService.PatchActivoEmpleado(id, request);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
