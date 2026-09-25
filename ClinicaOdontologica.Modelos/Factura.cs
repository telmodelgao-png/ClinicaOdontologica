using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Modelos
{
    [Table("Facturas")]
    public class Factura
    {
        [Key]
        [Column("id_factura")]
        public string IdFactura { get; set; }
        [Required]
        [Column("fecha_emision",TypeName = "timestamp")]
        public DateTime fechaEmision { get; set; }

        [Required]
        [Column(TypeName ="numeric(10,2)")]
        public decimal subtotal { get; set; }
        [Required]
        [Column(TypeName = "numeric(10,2)")]
        public decimal impuestos { get; set; }
        [Required]
        [Column(TypeName = "numeric(10,2)")]
        public decimal total { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("estado_pago")]
        public string estadoPago { get; set; }

        //lave citas
        [ForeignKey("Cita")]
        [Column("id_cita")]
        public int idCita { get; set; }
        //objeto de navegacion
        public Cita? Cita { get; set; }
    }
}
