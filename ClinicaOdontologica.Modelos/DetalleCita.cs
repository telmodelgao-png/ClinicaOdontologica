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
    [Table("detallesCitas")]
    public class DetalleCita
    {
        [Key]
        [Column("id_detalle", TypeName = "serial")]
        public int IdDetalle { get; set; }


        [Column("costo_aplicado",TypeName ="numeric(10,2)")]
        public decimal costoAplicado { get; set; }

        public string observaciones { get; set; }
        //llave cita
        [ForeignKey("Cita")]
        [Column("id_cita")]
        public int idCita { get; set; }
        //llave tratamiento
        [ForeignKey("Tratamiento")]
        [Column("id_tratamiento")]
        public int idTratamiento { get; set; }
        //objetos de navegacion
        public Tratamiento? Tratamiento { get; set; }

        public Cita? Cita { get; set; }

    }
}
