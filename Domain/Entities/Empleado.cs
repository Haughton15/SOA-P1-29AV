using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain.Entities
{
    [Table("Empleados")]
    public class Empleado 
    {
        public Persona Persona { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmpleado { get; set; }
        [Required]
        public int NumEmpleado { get; set; }
        [Required]
        public bool Estatus { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }

        //public ICollection<ActivoEmpleado> ActivoEmpleados { get; set; } 
    }
}
