using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Requests
{
    public class PatchPersonaRequest
    {
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? CURP { get; set; }
        public string? Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int NumEmpleado { get; set; }
        public bool Estatus { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}
