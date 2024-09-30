using AutoMapper;
using LaboratorioApi.Data;
using LaboratorioApi.Services;
using LaboratorioWeb.Services;
using LaboratorioWeb.Services.Interfase;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Registrar AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IComandaService, ComandaService>(); 
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<IEstadoMesaService, EstadoMesaService>();
builder.Services.AddScoped<IEstadoPedidoService, EstadoPedidoService>();
builder.Services.AddScoped<IMesaService, MesaService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<ISectorService, SectorService>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<IProductoService, ProductoService>();

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar la conexión a la base de datos
builder.Services.AddDbContext<RestauranteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Construir la aplicación
var app = builder.Build();

// Configuración del pipeline de manejo de solicitudes
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
