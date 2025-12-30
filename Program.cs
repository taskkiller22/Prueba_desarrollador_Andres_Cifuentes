using Microsoft.EntityFrameworkCore;
using Prueba_desarrollador_Andres_Cifuentes.Components;
using Prueba_desarrollador_Andres_Cifuentes.Data;
using Prueba_desarrollador_Andres_Cifuentes.Interfaces;
using Prueba_desarrollador_Andres_Cifuentes.Provider;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Intentamos conectar a la base de datos real usando SQL Server
// Si la cadena de conexión no está disponible, usamos InMemory
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (!string.IsNullOrEmpty(connectionString))
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));
}
else
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseInMemoryDatabase("FallbackDb"));
}

// Registramos los providers con sus interfaces
builder.Services.AddScoped<IEmpleadosDb, EmpleadosDbProvider>();
builder.Services.AddScoped<IEmpleadosMemory, EmpleadosMemoryProvider>();
builder.Services.AddScoped<IEmpleados, EmpleadosFallbackProvider>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("FallbackDb"));


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
else
{
    app.UseSwagger();
 }

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapControllers();
app.MapRazorPages();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
