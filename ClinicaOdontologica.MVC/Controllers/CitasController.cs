
using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Consumer;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

[Authorize]
public class CitasController : Controller
{


    // GET: CITAS
    public ActionResult Index()    
    {
        var citas = CRUD<Cita>.GetAll();
        return View(citas);
    }

    // GET: CITAS/Details/5
    public ActionResult Details(int id)
    {
        var citas=CRUD<Cita>.GetById(id);
        if (citas == null)
        {
            return NotFound();
        }
        else
        {
            return View(citas);
        }
    }
    //Metodo interno para obtener pacientes
    private List<SelectListItem> GetPacientes() {
        var pacientes = CRUD<Paciente>.GetAll();
        return pacientes.Select(p=> new SelectListItem
        { 
        
        Value=p.idPaciente.ToString(),
            Text =p.nombres+""+p.apellidos
        }).ToList();
    }
    private List<SelectListItem> GetOdontologos()
    {
        var odontologos = CRUD<Odontologo>.GetAll();
        return odontologos.Select(o => new SelectListItem
        {

            Value = o.IdOdontologo.ToString(),
            Text = o.nombres + " " + o.apellidos
        }).ToList();
    }
    private List<SelectListItem> GetPiso()
    {
        var consultorios = CRUD<Consultorio>.GetAll();
        return consultorios.Select(c => new SelectListItem
        {

            Value = c.idConsultorio.ToString(),
            Text = c.piso+" "+c.numeroSala
        }).ToList();
    }

    // GET: CITAS/Create
    public ActionResult Create()
    {
        ViewBag.Pacientes = GetPacientes();
        ViewBag.Odontologos = GetOdontologos();
        ViewBag.Consultorio = GetPiso();
        return View();
    }

    // POST: CITAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create( Cita cita)
    {
        try
        {
            CRUD<Cita>.Create(cita);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex) {
            ModelState.AddModelError("",ex.Message);
            return View(cita);
        }
    }

    // GET: CITAS/Edit/5
    public ActionResult Edit(int id)
    {
        var cita = CRUD<Cita>.GetById(id);
        ViewBag.Pacientes = GetPacientes();
        ViewBag.Odontologos = GetOdontologos();
        ViewBag.Consultorio = GetPiso();
        if (cita == null) {
            return NotFound();
        }
        return View(cita);
    }

    // POST: CITAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Cita cita)
    {
        try
        {
            CRUD<Cita>.Update(id,cita);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(cita);
        }
    }

    // GET: CITAS/Delete/5
    public ActionResult Delete(int id)
    {
        var cita = CRUD<Cita>.GetById(id);
        
        if (cita == null) {
            return NotFound();
        }
        return View(cita);
    }

    // POST: CITAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id,Cita cita)
    {
        try
        {
            CRUD<Cita>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex) {
            ModelState.AddModelError("", ex.Message);
            return View(cita);
        }

    }
}
