using WebApiPersonas.Models;

namespace WebApiPersonas
{
    public class PersonasDataStore
    {
        public List<Persona> Personas { get; set; }
        public static PersonasDataStore Current { get; } = new PersonasDataStore();

        public PersonasDataStore()
        {

            Personas = new List<Persona>()
            {
                new Persona()
                {
                    Id = 1,
                    Nombre = "Jose",
                    Apellido = "Ramirez",
                    NumeroDocumento = 5555555,
                    Email = "jose.ramirez@gmail.com",
                    Telefono = "0988111222",
                    FechaNacimiento = "05111993"

                },
                new Persona()
                {
                    Id = 2,
                    Nombre = "Ana",
                    Apellido = "Gonzalez",
                    NumeroDocumento = 4444444,
                    Email = "ana.gonzalez@gmail.com",
                    Telefono = "0988333444",
                    FechaNacimiento = "11052000"

                }

            };
        }

        //private DateOnly Date(int year, int month, int day)
        //{
        //    var date = new DateOnly(year, month, day);
        //    return date;
        //}
    }
}
