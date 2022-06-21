using System.ComponentModel.DataAnnotations;

namespace WebApiPersonas.Models
{
    public class Persona

    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Apellido { get; set; } = String.Empty;
        [Required]
        [Range(400000,8000000)]        
        public int NumeroDocumento { get; set; } = 400001;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "test.dummy@gmail.com";
        [Required]
        [Phone]
        public string Telefono { get; set; } = "111111111";
        [Required]
        [MaxLength(8)]
        public string FechaNacimiento { get; set; } = "12121999";


    }
}
