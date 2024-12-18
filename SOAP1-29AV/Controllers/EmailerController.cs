﻿using Domain.Entities;
using Domain.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace SOAP1_29AV.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailerController : Controller
    {
        private readonly IEmail _mailService;
        public EmailerController(IEmail mail)
        {
            _mailService = mail;
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        public IActionResult PostIMail([FromBody] PostEmailRequest request)
        {
            return Ok(_mailService.SendMasiveMail(request));
        }
    }
}
