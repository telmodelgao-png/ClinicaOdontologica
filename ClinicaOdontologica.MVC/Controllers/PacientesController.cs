
using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Consumer;
using Microsoft.AspNetCore.Authorization;

[Authorize]
public class PacientesController : Controller
{


    // GET: CITAS
    public ActionResult Index()
    {
        var pacientes = CRUD<Paciente>.GetAll();
        return View(pacientes);
    }

    // GET: CITAS/Details/5
    public ActionResult Details(int id)
    {
        var paciente = CRUD<Paciente>.GetById(id);
        if (paciente == null)
        {
            return NotFound();
        }
        else
        {
            return View(paciente);
        }
    }

    // GET: CITAS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: CITAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Paciente paciente)
    {
        try
        {
            CRUD<Paciente>.Create(paciente);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(paciente);
        }
    }

    // GET: CITAS/Edit/5
    public ActionResult Edit(int id)
    {
        var paciente = CRUD<Paciente>.GetById(id);
        if (paciente == null)
        {
            return NotFound();
        }
        return View(paciente);
    }

    // POST: CITAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Paciente paciente)
    {
        try
        {
            CRUD<Paciente>.Update(id, paciente);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(paciente);
        }
    }

    // GET: CITAS/Delete/5
    public ActionResult Delete(int id)
    {
        var paciente = CRUD<Paciente>.GetById(id);
        if (paciente == null)
        {
            return NotFound();
        }
        return View(paciente);
    }

    // POST: CITAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id, Paciente paciente)
    {
        try
        {
            CRUD<Paciente>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(paciente);
        }

    }
}
