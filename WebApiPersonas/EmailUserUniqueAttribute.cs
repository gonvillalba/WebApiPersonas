using System.ComponentModel.DataAnnotations;
using WebApiPersonas.Models;

namespace WebApiPersonas
{
    public class EmailUserUniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            var persona = (Persona)validationContext.GetService(typeof(Persona));
            var entity = PersonasDataStore.Current.Personas.FirstOrDefault(c => c.Email==value.ToString());

            if (entity!=null)
            {
                return new ValidationResult(GetErrorMessage(value.ToString()));
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage(string email)
        {
            return $"Email {email} ya esta siendo utilizado.";
        }
    }
}
