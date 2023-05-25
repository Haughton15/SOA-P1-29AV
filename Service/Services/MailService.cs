using Domain.Entities;
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
        private readonly IPersona _persona;
        private readonly ILogger<MailService> _logger;
        public MailService(IConfiguration configuration,
            SmtpClient smtpClient, IPersona persona, ILogger<MailService> logger)
        {
            _smtpClient = smtpClient;
            _configuration = configuration;
            _persona = persona;
            _logger = logger;
        }


        /*public string SendMasiveMail(PostEmailRequest request)
        {
            List<EmpleadoVM> list = _persona.GetEmpleados();
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(_configuration["SmtpConfig:SmtpUsername"]);
                foreach (var user in list)
                {
                    mailMessage.To.Add(user.Email.Trim());
                    Console.WriteLine(user.Email.Trim());
                }
                mailMessage.Subject = "Subject of the email";
                mailMessage.Body = request.Message;
                mailMessage.IsBodyHtml = true;
                _smtpClient.Send(mailMessage);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return "Se he enviado los correos exitosamente";
        }*/
    }
}
