using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Requests
{
    public class PostActivoEmpleado
    {

        [Required(ErrorMessage = "El campo id_empleado es requerido")]
        public int id_empleado { get; set; }
        [Required(ErrorMessage = "El campo id_activo es requerido")]
        public int id_activo { get; set; }
        /*[Required(ErrorMessage = "El campo FechaAsignacion es requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaAsignacion { get; set; }*/
        [Required(ErrorMessage = "El campo FechaLiberacion es requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaLiberacion { get; set; }
        [Required(ErrorMessage = "El campo FechaEntrega es requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaEntrega { get; set; }

    }
}
