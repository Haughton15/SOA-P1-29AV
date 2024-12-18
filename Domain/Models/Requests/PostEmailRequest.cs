﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Requests
{
    public class PostEmailRequest
    {
        [Required, MaxLength(50)]
        public string Message { get; set; } = string.Empty;
    }
}
