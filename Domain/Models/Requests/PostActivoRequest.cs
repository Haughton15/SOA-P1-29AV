using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Requests
{
    public class PostActivoRequest
    {
        [Required(ErrorMessage = "El campo nombre es requerido"),
         MaxLength(50, ErrorMessage = "El nombre tiene que ser menor a 50 caracteres")]
        public string Nombre { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo descripcion es requerido"),
         MaxLength(50, ErrorMessage = "La descripcion tiene que ser menor a 50 caracteres")]
        public string Descripcion { get; set; } = string.Empty;
    }
}
