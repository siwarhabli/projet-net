using DoctorsService.Controllers;
using DoctorsService.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// -----------------------------------------------------
// Services
// -----------------------------------------------------

// Controllers API
builder.Services.AddControllers();

// Swagger (documentation)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext (avec MySQL)
builder.Services.AddDbContext<PatientsDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 33))
    )
);

// ⚠️ IMPORTANT :
// Pas de AddScoped<HomeController>() car les controllers API
// sont automatiquement gérés par ASP.NET Core.

var app = builder.Build();

// -----------------------------------------------------
// Middleware
// -----------------------------------------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// API Routing
app.MapControllers();

// Start app
app.Run();
