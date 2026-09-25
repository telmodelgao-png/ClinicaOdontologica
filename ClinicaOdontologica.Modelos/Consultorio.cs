using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Modelos
{
    [Table("Consultorios")]
    public class Consultorio
    {
        [Key]
        [Column("id_consultorio")]
        public int idConsultorio { get; set; }
        [MaxLength(10)]
        [Column("numero_sala")]
        [Required]
        public string numeroSala { get; set; }
        [Required]
        public int piso { get; set; }

        [MaxLength(100)]
        [Required]
        [Column("equipamiento_principal")]
        public string EquipamientoPrincipal { get; set; }
        //relaciones
        List<Cita> Citas { get; set; }=new List<Cita>();
    }
}
