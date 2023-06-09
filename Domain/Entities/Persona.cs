﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Personas")]
    public class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Nombre { get; set; }
        [StringLength(50)]
        [Required]
        public string Apellidos { get; set; }
        [StringLength(18)]
        [Required]
        public string CURP { get; set; }
        [StringLength(50)]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        [ForeignKey("Empleado")]
        public int? Id_Empleado { get; set; }
        public virtual Empleado Empleado { get; set; }
    }
}
