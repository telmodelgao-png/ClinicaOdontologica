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
    [Table("Odontologos")]
    public class Odontologo
    {
        [Key]
        [Column(TypeName = "serial")]
        public int IdOdontologo { get; set; }
        [Required]
        [MaxLength(50)]
        public string nombres { get; set; }

        [Required]
        [MaxLength(50)]
        public string apellidos { get; set; }
        [Required]
        [MaxLength(20)]
        [Column("registro_medico")]
        public string registoMedico { get; set; }
        //llave de odontologo
        [ForeignKey("Especialidad")]
        [Column("id_especialidad")]
        public int IdEspecialidad { get; set; }
        //objetos de navegacion
        public Especialidad? Especialidad { get; set; }
    }
}
