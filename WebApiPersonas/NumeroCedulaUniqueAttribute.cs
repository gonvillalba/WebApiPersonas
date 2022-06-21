using System.ComponentModel.DataAnnotations;
using WebApiPersonas.Models;

namespace WebApiPersonas
{
    public class NumeroCedulaUniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            var persona = (Persona)validationContext.GetService(typeof(Persona));
            var entity = PersonasDataStore.Current.Personas.FirstOrDefault(c => c.NumeroDocumento == (int)value);

            if (entity != null)
            {
                return new ValidationResult(GetErrorMessage(value.ToString()));
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage(string cedula)
        {
            return $"Cedula {cedula} ya existe en el sistema.";
        }
    }
}
