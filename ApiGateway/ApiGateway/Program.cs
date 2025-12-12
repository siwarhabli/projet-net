using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Configuration: Load ocelot.json
builder.Configuration.AddJsonFile("ocelot.json", false, true);

// ----------------------------------------------------
// Step 1: Add CORS services
// We allow the React development server (port 3000)
// ----------------------------------------------------
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials();
                      });
});
// ----------------------------------------------------

builder.Services.AddControllers();
builder.Services.AddOcelot();

var app = builder.Build();

// ----------------------------------------------------
// Step 2: Use CORS policy - MUST BE BEFORE UseOcelot()
// ----------------------------------------------------
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

// Ocelot middleware to handle the routing
await app.UseOcelot();

app.Run();