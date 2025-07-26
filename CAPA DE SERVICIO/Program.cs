using MICRUDGABRIEL.Data;
using MICRUDGABRIEL.Contract;         // <-- Asegúrate de tener este using
using MICRUDGABRIEL.Service;          // <-- Y este también
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios de controlador para API
builder.Services.AddControllers();

// Swagger para documentación y pruebas
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura la cadena de conexión a SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 👉 REGISTRO DE LOS SERVICIOS PERSONALIZADOS
builder.Services.AddScoped<IMemberService, MemberService>();

builder.Services.AddScoped<ITrainerService, TrainerService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

