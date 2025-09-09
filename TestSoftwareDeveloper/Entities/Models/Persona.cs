using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace TestSoftwareDeveloper.Entities.Models
{

    [Table("Persona")]
    public class Persona
    {
        [Column("idPersona")]
        [Key]
        public Guid idPersona { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El apellido paterno es requerido")]
        public string apellidoPaterno { get; set; }

        public string apellidoMaterno { get; set; }

        [Required(ErrorMessage = "la identificacion es requerida")]
        public string identificacion { get; set; }

        public ICollection<Factura>? Facturas { get; set; }

    }
}
