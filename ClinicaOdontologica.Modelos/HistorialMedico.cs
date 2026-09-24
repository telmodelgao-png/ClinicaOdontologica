using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Modelos
{
    [Table("Historialesmedicos")]
    public class HistorialMedico
    {
        [Key]
        [Column("id_historialMedico")]
        public int IdHistorialMedico { get; set; }
        [Column("alergias")]
        [MaxLength(200)]
        public string alergias { get; set; }


        [Column("enfermedades_previas")]
        [MaxLength(200)]
        public string enfermedadesPrevias { get; set; }
        [Column("tipo_sangre")]
        [MaxLength(5)]
        [Required]
        public string tipoSangre { get; set; }
        //llave de paciente
        [ForeignKey("paciente")]
        [Column("id_paciente")]
        public int IdPaciente { get; set; }
        //objeto de navegacion
        public Paciente? paciente { get; set; }
    }
}
