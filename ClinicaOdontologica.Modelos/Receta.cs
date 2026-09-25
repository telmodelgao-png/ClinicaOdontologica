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
        [Column("id_recetas")]
        public int idRecetas { get; set; }
        [Required]
        [Column("fecha_emision", TypeName = "timestamp")]
        public DateTime fechaEmision { get; set; }

        [Required]
        public string indicaciones { get; set; }
        //llave citas
        [ForeignKey("Cita")]
        [Column("id_cita")]
        public int idCita { get; set; }
        //objeto de navegacion
        public Cita? Cita { get; set; }
    }
}
