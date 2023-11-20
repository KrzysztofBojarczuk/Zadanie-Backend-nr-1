using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web.Http.ModelBinding;
using Zadanie_Backend_nr_1;
using Zadanie_Backend_nr_1.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var persons = new List<Person>
{
   new Person { ID = 1, FirstName = "Jan", LastName = "Kowalski", DateBirth = new DateTime(1990, 5, 15), Adresss = "ul. Kwiatowa 1" },
   new Person { ID = 2, FirstName = "Anna", LastName = "Nowak", DateBirth = new DateTime(1985, 10, 25), Adresss = "ul. Leśna 5" }
};

app.MapGet("/Get", () => Results.Ok(persons));


app.MapGet("/GetById/{id}", (int id) =>
{
    var person = persons.FirstOrDefault(o => o.ID == id);

    if (person == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(person);
});

var personService = new PersonService(new DataValidationService(), persons);

app.MapPost("/Post", (Person newPerson) =>
{
    try
    {
        personService.Create(newPerson, persons);
        return Results.Ok("Person has been created");
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message); 
    }
});

app.Run();
