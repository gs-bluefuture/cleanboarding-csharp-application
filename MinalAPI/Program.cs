using Microsoft.EntityFrameworkCore;
using MinhaApiCrud.Models;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicionar serviços de controladores
builder.Services.AddControllers();

var configuration = builder.Configuration;
var stringConexao = configuration.GetConnectionString("OracleConnection");

builder.Services.AddDbContext<ShipContext>(options =>
{
    options.UseOracle(stringConexao);
});

var app = builder.Build();

// Configurar o Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MinhaApiCrud v1");
    c.RoutePrefix = string.Empty;
});

// Usar controladores
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
