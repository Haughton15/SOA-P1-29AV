﻿using Domain.Entities;
using Domain.Models.Requests;
using Microsoft.Extensions.Logging;
using Repository.DAO;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class LoginService : ILogin
    {
        private readonly IPersona _persona;
        private readonly ILogger<LoginService> _logger;
        private string _mensaje;
        public LoginService(IPersona persona, ILogger<LoginService> logger)
        {

            _persona = persona;
            _logger = logger;
        }
        public string Login(PostLoginRequest request)
        {
            bool passwordsMatch;
            try
            {
                var persona = _persona.GetUserLogin(request.Email);
                if (persona == null)
                    throw new DirectoryNotFoundException("Credenciales incorrectas");

                passwordsMatch = BCrypt.Net.BCrypt.Verify(request.Password, persona.Password);
                if (!passwordsMatch)
                {
                    throw new DirectoryNotFoundException("Credenciales incorrectas");
                }

                _mensaje = "Login correcto, bienvenido: " + persona.Nombre; 
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return _mensaje;
        }
    }
}
