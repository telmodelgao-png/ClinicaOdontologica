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
    [Table("citas")]
    public class Cita
    {
        [Key]
        [Column("id_cita")]
        public int IdCita { get; set; }
        [Required]
        [Column("fecha_cita" ,TypeName ="timestamp")]
        public DateTime fechaCita { get; set; }
        [Required]
        [MaxLength(100)]
        public string motivo { get; set; }
        [Required]
        [MaxLength(100)]
        public string estado { get; set; }
        //llave de paciente
        [ForeignKey("Paciente")]
        [Column("id_paciemte")]
        public int Idpaciente { get; set; }
        //llave odontologo
        [ForeignKey("Odontologo")]
        [Column("id_odontologo")]
        public int IdOdontologo { get; set; }
        //llave consultorio
        [ForeignKey("Consultorio")]
        [Column("id_consultorio")]
        public int IdConsultorio { get; set; }
        //objetos de navegacio
        public Consultorio? Consultorio { get; set; }
        public Odontologo? Odontologo { get; set; }
        public Paciente? Paciente { get; set; }



    }
}
