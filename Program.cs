using Simulacro1.Data;
using Microsoft.EntityFrameworkCore;
using Simulacro1.Models;
using Simulacro1.Services;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* ----------------- Añadir interfaces ------------ */
builder.Services.AddScoped< IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped< IEditorialRepository, EditorialRepository>();
builder.Services.AddScoped< IBookRepository, BookRepository>();

builder.Services.AddDbContext<SimulacroBaseContext> (options => options.UseMySql(
    builder.Configuration.GetConnectionString("MySqlConnection"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")
));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
