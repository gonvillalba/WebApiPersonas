using System.ComponentModel.DataAnnotations;

namespace WebApiPersonas.Models
{
    public class PersonaForUpdate

    {
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(50)]
        public string Apellido { get; set; }
        [Required]
        [Range(400000, 8000000)]        
        public int NumeroDocumento { get; set; }
        [Required]
        [EmailAddress]        
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Telefono { get; set; }
        [Required]
        [MaxLength(8)]
        public string FechaNacimiento { get; set; }


    }
}
