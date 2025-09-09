using System.ComponentModel.DataAnnotations;

namespace TestSoftwareDeveloper.Entities
{
    public class PersonaDto
    {
        public Guid idPersona { get; set; }
        public string? nombre { get; set; }

        public string? apellidoPaterno { get; set; }

        public string apellidoMaterno { get; set; } = null;
        public string? identificacion { get; set; }

        public IEnumerable<FacturaDto>? Facturas { get; set; }
    }
}
