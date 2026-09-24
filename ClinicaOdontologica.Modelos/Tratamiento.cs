using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Modelos
{
    [Table("Tratamientos")]
    public class Tratamiento
    {
        [Key]
        [Column("id_tratamiento")]
        public int idTratamiento { get; set; }
        [Column("nombre_tratamiento")]
        [MaxLength(50)]
        [Required]
        public string nombreTratamiento { get; set; }
        [Column("costo_base",TypeName="numeric(10,2)")]
        [Required]
        public decimal costo { get; set; }
        [Column("Duracion_estimada_minutos")]
        [Required]
        public TimeOnly duracionEstimadaMinutos { get; set; }
    }
}
