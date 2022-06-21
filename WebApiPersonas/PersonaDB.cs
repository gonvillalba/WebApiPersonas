using Microsoft.EntityFrameworkCore;
using WebApiPersonas.Models;

class PersonaDb : DbContext
{
    public PersonaDb(DbContextOptions<PersonaDb> options)
        : base(options) { }

    public DbSet<Persona> Personas => Set<Persona>();
}