using Domain.Entities;
using Domain.Models.Requests;
using Microsoft.Extensions.Logging;
using Service.IServices;
using BCrypt.Net;

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
            bool passwordsMatch;
            try
            {
                if (login == null)
                {
                    throw new ArgumentNullException("Credenciales incorrectas");
                }
                passwordsMatch = BCrypt.Net.BCrypt.Verify(request.Password, login.Password);
                if (!passwordsMatch)
                {
                    throw new ArgumentNullException("Credenciales incorrectas");
                }

                _mensaje = "Login correcto, bienvenido: " + login.Nombre; 
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return _mensaje;
        }
    }
}
