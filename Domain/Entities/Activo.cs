using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Activos")]
    public class Activo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Nombre { get; set; }
        [StringLength(50)]
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public bool Estatus { get; set; }

        //public ICollection<ActivoEmpleado> ActivoEmpleados { get; set; }
    }
}
