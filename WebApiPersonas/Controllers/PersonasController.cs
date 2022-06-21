using Microsoft.AspNetCore.Mvc;
using WebApiPersonas.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiPersonas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        // GET: api/<PersonasController>
        [HttpGet(Name ="Get")]
        public ActionResult<IEnumerable<Persona>> Get()
        {   

            return Ok(PersonasDataStore.Current.Personas);
        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}",Name ="GetPersona")]
        public ActionResult<Persona> GetPersona(int id)
        {
            var personaReturn = PersonasDataStore.Current.Personas.FirstOrDefault(p=> p.Id == id);

            if (personaReturn == null)
            {
                return NotFound();
            }
            return Ok(personaReturn);
        }

        // POST api/<PersonasController>
        [HttpPost]
        public ActionResult<Persona> CreatePersona(PersonaForCreation personaCreation)
        {
            //var persona = PersonasDataStore.Current.Personas.FirstOrDefault(p=> p.Id == id);
            //if(persona == null)
            //{
            //    return NotFound();
            //}

            var maxPersonaId = PersonasDataStore.Current.Personas.Max(p => p.Id);

            var finalPersona = new Persona()
            {
                Id = ++maxPersonaId,
                Nombre = personaCreation.Nombre,
                Apellido = personaCreation.Apellido,
                NumeroDocumento = personaCreation.NumeroDocumento,
                Email = personaCreation.Email,
                Telefono = personaCreation.Telefono,
                FechaNacimiento = personaCreation.FechaNacimiento

            };

            PersonasDataStore.Current.Personas.Add(finalPersona);
            
            return CreatedAtRoute("Get", finalPersona);

        }
        


        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
       public ActionResult<Persona>UpdatePersona(int id, PersonaForUpdate personaUpdate)
        {
            var persona = PersonasDataStore.Current.Personas.FirstOrDefault(p => p.Id == id);
            if(persona == null)
            {
                return NotFound();
            }
            persona.Nombre = personaUpdate.Nombre;
            persona.Apellido = personaUpdate.Apellido;
            persona.NumeroDocumento = personaUpdate.NumeroDocumento;
            persona.Email = personaUpdate.Email;
            persona.Telefono = personaUpdate.Telefono;
            persona.FechaNacimiento = personaUpdate.FechaNacimiento;

            return NoContent();

        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public ActionResult DeletePersona(int id)
        {
            var persona = PersonasDataStore.Current.Personas.FirstOrDefault(p => p.Id == id);
            if(persona == null)
            {
                return NotFound();
            }

            PersonasDataStore.Current.Personas.Remove(persona);
            return NoContent();
        }
    }
}
