﻿using Domain.Entities;
using Domain.Models.Requests;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class MailService : IEmail
    {
        private readonly IConfiguration _configuration;
        private readonly SmtpClient _smtpClient;
        private readonly IActivoEmpleado _activoEmpleado;
        private readonly ILogger<MailService> _logger;
        public MailService(IConfiguration configuration,
            SmtpClient smtpClient, IActivoEmpleado activoEmpleado, ILogger<MailService> logger)
        {
            _smtpClient = smtpClient;
            _configuration = configuration;
            _activoEmpleado = activoEmpleado;
            _logger = logger;
        }


        public string SendMasiveMail(PostEmailRequest message)
        {
            List<ActivoEmpleado> list = _activoEmpleado.GetActivosEmpleadosEntrega();
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(_configuration["SmtpConfig:SmtpUsername"]);
                DateTime twoDaysLater = DateTime.Now.AddDays(2);
                foreach (var user in list)
                {
                    if(user.FechaEntrega == twoDaysLater)
                    {
                        mailMessage.To.Add(user.Empleado.Persona.Email);
                    }
                }
                mailMessage.Subject = "Subject of+ the email";
                mailMessage.Body = "La entrega de su activo es dentro de 2 dias";
                mailMessage.IsBodyHtml = true;
                _smtpClient.Send(mailMessage);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return "Se he enviado los correos exitosamente";
        }
    }
}
