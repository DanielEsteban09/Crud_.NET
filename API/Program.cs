using API.Controllers;
using Core.Entities;
using Core.Interfaces;
using Core.Services;
using Infraestructure.Data;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddAutoMapper(Assembly.Load("Application"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<Core.Interfaces.IEmpresaRepository, EmpresaRepository>();
builder.Services.AddTransient<IEmpresaServices, EmpresaServices>();

builder.Services.AddTransient<IDependenciaRepository, DependenciaRepository>();
builder.Services.AddTransient<IDependenciaServices, DependenciaServices>();

builder.Services.AddTransient<IPersonaRepository, PersonasRepository>();
builder.Services.AddTransient<IPersonaService, PersonaService>();



builder.Services.AddDbContext<EjercicioContext>(option =>

           option.UseSqlServer(configuration.GetConnectionString("myDb1"))

        );

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Prueba Daniel"

    });

});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

// Configuracion Swagger
app.UseSwagger();
app.UseSwaggerUI(option =>
{
    option.SwaggerEndpoint("/swagger/v1/swagger.json", "Proyecto daniel");
    option.RoutePrefix = String.Empty;
    // option.RoutePrefix = builder.Configuration["Swagger:RutaSwagger"];
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
