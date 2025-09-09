using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestSoftwareDeveloper.Entities.Models
{

    [Table("Factura")]
    public class Factura
    {
        [Column("idFactura")]
        [Key]
        public Guid idFactura { get; set; }
        public DateTime fecha { get; set; }
        public double monto { get; set; }

        [ForeignKey(nameof(Persona))]
        public Guid idPersona { get; set; }

        public Persona? Persona { get; set; }
    }
}
