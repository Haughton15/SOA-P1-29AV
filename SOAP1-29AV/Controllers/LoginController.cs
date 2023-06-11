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
    public class LoginController : Controller
    {
        private readonly ILogin _loginService;
        private readonly IPersona _persona;
        public LoginController(ILogin login)
        {
            _loginService = login;
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        public IActionResult PostILogin([FromBody] PostLoginRequest request)
        {
            if(_loginService.Login(request) == false){
                return BadRequest("Credenciales incorrectas");

            } else {
                return Ok("Login correcto, bienvenido");

            }
        }
    }
}
