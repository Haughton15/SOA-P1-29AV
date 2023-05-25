using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Empleado 
    {
        [Key]
        public int IdEmpleado { get; set; }
        [Required]
        public int NumEmpleado { get; set; }
        [Required]
        public bool Estatus { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }
    }
}
