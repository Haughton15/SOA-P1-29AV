using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Requests
{
    public class PatchActivoEmpleado
    {
        [DataType(DataType.Date)]
        public DateTime FechaLiberacion { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaEntrega { get; set; }
    }
}
