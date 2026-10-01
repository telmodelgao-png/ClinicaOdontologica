using ClinicaOdontologica.Consumer;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Services.Interfaces;
using ClinicaOdontologica.Servicios;

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
CRUD<Usuario>.Endpoint = "https://localhost:7142/api/Usuarios";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAuthServices, AuthService>();
builder.Services.AddHttpContextAccessor();


builder.Services.AddAuthentication("Cookies").AddCookie("Cookies", options =>
{
    options.LoginPath = "/Account/Index";
});

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}");

app.Run();
