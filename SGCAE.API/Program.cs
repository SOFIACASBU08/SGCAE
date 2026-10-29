

using Microsoft.EntityFrameworkCore;
using SGCAE.Application.Interfaces;
using SGCAE.Application.Empleados.Queries;
using SGCAE.Infrastructure.Data;
using SGCAE.Infrastructure.Repositories;
using SGCAE.Application.Empleados.Commands;
using SGCAE.Application.Credenciales.Commands;
using SGCAE.Application.Credenciales.Queries;
using SGCAE.Application.PuntosAcceso.Commands;
using SGCAE.Application.PuntosAcceso.Queries;
using SGCAE.Application.RegistrosAcceso.Commands;
using SGCAE.Application.RegistrosAcceso.Queries;




var builder = WebApplication.CreateBuilder(args);

// Registrar controladores
builder.Services.AddControllers();

// Configurar la conexión con SQL Server
builder.Services.AddDbContext<SGCAEDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar repositorio y manejador de empleados
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddScoped<ObtenerEmpleadosHandler>();
builder.Services.AddScoped<RegistrarEmpleadoHandler>();
builder.Services.AddScoped<ActualizarEmpleadoHandler>();
builder.Services.AddScoped<DesactivarEmpleadoHandler>();
//Credenciales
builder.Services.AddScoped<ICredencialRepository, CredencialRepository>();
builder.Services.AddScoped<RegistrarCredencialHandler>();
builder.Services.AddScoped<ObtenerCredencialesHandler>();
builder.Services.AddScoped<BloquearCredencialHandler>();
builder.Services.AddScoped<RevocarCredencialHandler>();
//punto acceso
builder.Services.AddScoped<IPuntoAccesoRepository, PuntoAccesoRepository>();
builder.Services.AddScoped<RegistrarPuntoAccesoHandler>();
builder.Services.AddScoped<ObtenerPuntosAccesoHandler>();
builder.Services.AddScoped<DesactivarPuntoAccesoHandler>();
//Registro de acceso
builder.Services.AddScoped<IRegistroAccesoRepository, RegistroAccesoRepository>();
builder.Services.AddScoped<RegistrarAccesoHandler>();
builder.Services.AddScoped<ObtenerRegistrosAccesoHandler>();
//Filtrar registros de acceso
builder.Services.AddScoped<FiltrarRegistrosAccesoHandler>();


// Configurar OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();

// Habilitar OpenAPI en entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Configurar el pipeline HTTP
app.UseHttpsRedirection();

app.UseAuthorization();

// Mapear controladores
app.MapControllers();

app.Run();
