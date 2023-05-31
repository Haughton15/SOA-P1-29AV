using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Requests
{
    public class GetOneEmpleado
    {
        [Required(ErrorMessage = "El campo id es requerido")]
        public int id { get; set; } 
    }
}
