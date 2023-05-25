using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ActivoEmpleado
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Empleado")]
        public int? IdEmpleado { get; set; }
        public virtual Empleado Empleado { get; set; }
        [ForeignKey("Activo")]
        public int? IdActivo { get; set; }
        public virtual Activo Activo { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaAsignacion { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaLiberacion { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaEntrega { get; set; }

    }
}
