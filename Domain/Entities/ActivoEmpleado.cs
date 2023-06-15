using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("ActivosEmpleados")]
    public class ActivoEmpleado
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Persona")]
        public int? IdPersona { get; set; }
        public virtual Persona Persona { get; set; }
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
