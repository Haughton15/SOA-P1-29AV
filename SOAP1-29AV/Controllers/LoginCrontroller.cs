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
        public LoginController(ILogin login)
        {
            _loginService = login;
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        public Task<IActionResult> PostILogin([FromBody] PostLoginRequest request)
        {
            return Task.FromResult<IActionResult>(Ok(_loginService.Login(request)));
        }
    }
}
