using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Requests
{
    public class PostLoginRequest
    {
        [Required, MaxLength(50), EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        public string Email { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string Password { get; set; } = string.Empty;
    }
}
