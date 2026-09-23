using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Modelos
{
    [Table("Especialidades")]
    public class Especialidad
    {
        [Key]
        [Column("id_especialidad")]
        public int idEspeciliadad { get; set; }
        [Required]
        [MaxLength(10)]
        [Column("nombre_especialidad")]
        public string nombreEspecialidad { get; set; }
        [Required]
        [MaxLength(200)]

        public string descripcion { get; set; }

    }
}
