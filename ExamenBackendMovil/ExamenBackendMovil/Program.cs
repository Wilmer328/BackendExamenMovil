
using ExamenBackendMovil.Data;
using ExamenBackendMovil.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar conexi�n a DB 
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SupabaseDB")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
options.SwaggerDoc("v1", new OpenApiInfo
{
    Title = "Mi API de prueba",
    Version = "v1.0",
    Description = "Documentaci�n de API para proyecto de clase de Programaci�n M�vil"
});
});

// Registrar servicios
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<TareaService>();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAll");
app.Run();

