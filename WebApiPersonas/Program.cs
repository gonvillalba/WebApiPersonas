using Microsoft.EntityFrameworkCore;
using WebApiPersonas.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{ options.ReturnHttpNotAcceptable = true;}
).AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen().AddSwaggerGenNewtonsoftSupport();

builder.Services.AddDbContext<PersonaDb>(opt => opt.UseInMemoryDatabase("PersonaList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


var app = builder.Build();

app.MapGet("/personas", async (PersonaDb db) =>
    await db.Personas.ToListAsync());

app.MapGet("/personas/{id}", async (int id, PersonaDb db) =>
    await db.Personas.FindAsync(id)
        is Persona persona
            ? Results.Ok(persona)
            : Results.NotFound());

app.MapPost("/personas", async (PersonaForCreation inputPersona, PersonaDb db) =>
{
    var persona = new Persona();

    persona.Nombre = inputPersona.Nombre;
    persona.Apellido = inputPersona.Apellido;
    persona.NumeroDocumento = inputPersona.NumeroDocumento;
    persona.Email = inputPersona.Email;
    persona.Telefono = inputPersona.Telefono;
    persona.FechaNacimiento = inputPersona.FechaNacimiento;

    db.Personas.Add(persona);
    await db.SaveChangesAsync();

    return Results.Created($"/personas/{persona.Id}", persona);
});

app.MapPut("/personas/{id}", async (int id, PersonaForUpdate inputPersona, PersonaDb db) =>
{
    var persona = await db.Personas.FindAsync(id);

    if (persona is null) return Results.NotFound();

    persona.Nombre = inputPersona.Nombre;
    persona.Apellido = inputPersona.Apellido;
    persona.NumeroDocumento = inputPersona.NumeroDocumento;
    persona.Email = inputPersona.Email;
    persona.Telefono = inputPersona.Telefono;
    persona.FechaNacimiento = inputPersona.FechaNacimiento;   

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/personas/{id}", async (int id, PersonaDb db) =>
{
    if (await db.Personas.FindAsync(id) is Persona todo)
    {
        db.Personas.Remove(todo);
        await db.SaveChangesAsync();
        return Results.Ok(todo);
    }

    return Results.NotFound();
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
