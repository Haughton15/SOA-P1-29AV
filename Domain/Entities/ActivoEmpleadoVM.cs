using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ActivoEmpleadoVM
    {
        public int IdEmpleado { get; set; }
        public string E_Nombre { get; set; }
        public string E_Apellidos { get; set; }
        public string E_Curp { get; set; }
        public string E_Email { get; set; }
        public int E_NumEmp { get; set; }
        public DateTime E_FechaNacimiento { get; set; }
        public int IdActivoEmpleado { get; set; }
        public DateTime AE_FechaAsignacion { get; set; }
        public DateTime AE_FechaLiberacion { get; set; }
        public DateTime AE_FechaEntrega { get; set; }
        public int IdActivo { get; set; }
        public string A_Nombre { get; set; }
        public string A_Descripcion { get; set; }

    }
}
