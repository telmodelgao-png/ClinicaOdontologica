using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Modelos
{
    [Table("Pacientes")]
    public class Paciente
    {
        [Key]
        [Column("id_paciente",TypeName ="serial")]
        public int idPaciente { get; set; }
        [Required]
        [MaxLength(10)]
        public string dni { get; set; }
        [Required]
        [MaxLength(50)]
        public string nombres { get; set; }
        [Required]
        [MaxLength(50)]
        public string apellidos { get; set; }
        
        [Required]
        [Column("fecha_nacimiento",TypeName = "timestamp")]
        public DateOnly fechaNacimiento { get; set; }
        [Required]
        [MaxLength(10)]
        public string email { get; set; }
        [Required]
        [MaxLength(10)]
        public string telefono { get; set; }
    }
}
