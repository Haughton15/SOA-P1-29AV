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
        public string NombreEmpleado { get; set; }
        public string ApellidosEmpleado { get; set; }
        public string Email { get; set; }
        public int NumEmp { get; set; }
        //public Activo Activo { get; set; }
        public ActivoEmpleado activoEmpleado { get; set; }
    }
}
