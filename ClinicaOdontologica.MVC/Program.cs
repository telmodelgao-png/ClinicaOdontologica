using ClinicaOdontologica.Consumer;
using ClinicaOdontologica.Modelos;
using Microsoft.EntityFrameworkCore;

CRUD<Cita>.Endpoint = "https://localhost:7142/api/Citas";
CRUD<Consultorio>.Endpoint = "https://localhost:7142/api/Consultorios";
CRUD<DetalleCita>.Endpoint = "https://localhost:7142/api/DetalleCitas";
CRUD<Especialidad>.Endpoint = "https://localhost:7142/api/Especialidads";
CRUD<Factura>.Endpoint = "https://localhost:7142/api/Facturas";
CRUD<HistorialMedico>.Endpoint = "https://localhost:7142/api/HistorialMedicoes";
CRUD<Odontologo>.Endpoint = "https://localhost:7142/api/Odontologoes";
CRUD<Paciente>.Endpoint = "https://localhost:7142/api/Pacientes";
CRUD<Receta>.Endpoint = "https://localhost:7142/api/Recetas";
CRUD<Tratamiento>.Endpoint = "https://localhost:7142/api/Tratamientoes";


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ClinicaOdontologicaAPIContext") ?? throw new InvalidOperationException("Connection string 'ClinicaOdontologicaAPIContext' not found.");

builder.Services.AddDbContext<ClinicaOdontologicaAPIContext>(options => options.UseNpgsql(connectionString));



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
