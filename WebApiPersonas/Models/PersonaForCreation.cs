using System.ComponentModel.DataAnnotations;

namespace WebApiPersonas.Models
{
    public class PersonaForCreation

    {
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(50)]
        public string Apellido { get; set; }
        [Required]
        [Range(400000, 8000000)]
        [NumeroCedulaUnique]
        public int NumeroDocumento { get; set; }
        [Required]
        [EmailAddress]
        [EmailUserUnique]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Telefono { get; set; }
        [Required]
        [MaxLength(8)]
        public string FechaNacimiento { get; set; }

       
    }
}
