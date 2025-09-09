using System.ComponentModel.DataAnnotations;

namespace TestSoftwareDeveloper.Entities
{
    public class PersonaForCreationDto
    {

        [Required(ErrorMessage = "El nombre es requerido")]
        public string? nombre { get; set; }

        [Required(ErrorMessage = "El apellido paterno es requerido")]
        public string? apellidoPaterno { get; set; }

        public string apellidoMaterno { get; set; } = string.Empty;

        [Required(ErrorMessage = "la identificacion es requerida")]
        public string? identificacion { get; set; }
    }
}
