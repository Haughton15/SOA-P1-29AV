using Domain.Entities;
using Domain.Models.Requests;
using Microsoft.Extensions.Logging;
using Service.IServices;

namespace Service.Services
{
    public class LoginService : ILogin
    {
        private readonly IPersona _persona;
        private readonly ILogger<LoginService> _logger;
        private string _mensaje;
        public LoginService(IPersona persona, ILogger<LoginService> logger) {

            _persona = persona;
            _logger = logger;
        }
        public string Login(PostLoginRequest request)
        {
            EmpleadoVM? login =  _persona.GetPerson(request.Email);
            try
            {
                    if (login.Email != null)
                    {
                        _mensaje = "Login correcto, bienvenido: " + login.Nombre; 
                    } else
                    {
                        _mensaje = "Contraseña o correo incorrectos";
                    }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return _mensaje;
        }
    }
}
