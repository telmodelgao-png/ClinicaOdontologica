using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Modelos
{
    [Table("recetas")]
    public class Receta
    {
        [Key]
        [Column("id_recetas",TypeName ="serial")]
        public int idRecetas { get; set; }
        [Required]
        [Column("fecha_emision")]
        public DateTime fechaEmision { get; set; }

        [Required]
        public string indicaciones { get; set; }
        [ForeignKey("Cita")]
        [Column("id_cita")]
        public int idCita { get; set; }
        public Cita? Cita { get; set; }
    }
}
