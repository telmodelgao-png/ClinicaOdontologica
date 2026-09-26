
using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Consumer;
public class EspecialidadsController : Controller
{


    // GET: CITAS
    public ActionResult Index()
    {
        var especialidades = CRUD<Especialidad>.GetAll();
        return View(especialidades);
    }

    // GET: CITAS/Details/5
    public ActionResult Details(int idespecialidad)
    {
        var especialidad = CRUD<Especialidad>.GetById(idespecialidad);
        if (especialidad == null)
        {
            return NotFound();
        }
        else
        {
            return View(especialidad);
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
    public ActionResult Create(Especialidad especialidad)
    {
        try
        {
            CRUD<Especialidad>.Create(especialidad);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(especialidad);
        }
    }

    // GET: CITAS/Edit/5
    public ActionResult Edit(int idespecialidad)
    {
        var especialidad = CRUD<Especialidad>.GetById(idespecialidad);
        if (especialidad == null)
        {
            return NotFound();
        }
        return View(especialidad);
    }

    // POST: CITAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int idespecialidad, Especialidad especialidad)
    {
        try
        {
            CRUD<Especialidad>.Update(idespecialidad, especialidad);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(especialidad);
        }
    }

    // GET: CITAS/Delete/5
    public ActionResult Delete(int idespecialidad)
    {
        var especialidad = CRUD<Especialidad>.GetById(idespecialidad);
        if (especialidad == null)
        {
            return NotFound();
        }
        return View(especialidad);
    }

    // POST: CITAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int idespecialidad, Especialidad especialidad)
    {
        try
        {
            CRUD<Especialidad>.Delete(idespecialidad);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(especialidad);
        }

    }
}
