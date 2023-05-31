using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Requests
{
    public class PostEmpleadoRequest
    {
        //Empleados
        [Required(ErrorMessage = "El campo numEmp es requerido")]
        public int NumEmp { get; set; }
        /*[Required(ErrorMessage = "El campo estatus es requerido")]
        public bool Estatus { get; set; }
        [Required(ErrorMessage = "El campo fecha de ingreso es requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }*/

        //Persona 
        [Required(ErrorMessage = "El campo nombre es requerido"),
         MaxLength(50, ErrorMessage = "El nombre tiene que ser menor a 50 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo apellidos es requerido"),
         MaxLength(50, ErrorMessage = "Los apellidos tiene que ser menor a 50 caracteres")]
        public string Apellidos { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo CURP es requerido"),
         MaxLength(50, ErrorMessage = "La CURP tiene que ser menor a 50 caracteres")]
        public string CURP { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo email es requerido"),
        MaxLength(50, ErrorMessage = "El email tiene que ser menor a 50 caracteres")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo fecha de nacimiento es requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
    }
}
