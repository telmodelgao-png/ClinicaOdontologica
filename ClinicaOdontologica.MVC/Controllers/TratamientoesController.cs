
using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Consumer;
public class TratamientoesController : Controller
{


    // GET: CITAS
    public ActionResult Index()
    {
        var tratamientos = CRUD<Tratamiento>.GetAll();
        return View(tratamientos);
    }

    // GET: CITAS/Details/5
    public ActionResult Details(int idtratamiento)
    {
        var tratamiento = CRUD<Tratamiento>.GetById(idtratamiento);
        if (tratamiento == null)
        {
            return NotFound();
        }
        else
        {
            return View(tratamiento);
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
    public ActionResult Create(Tratamiento tratamiento)
    {
        try
        {
            CRUD<Tratamiento>.Create(tratamiento);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(tratamiento);
        }
    }

    // GET: CITAS/Edit/5
    public ActionResult Edit(int idtratamiento)
    {
        var tratamiento = CRUD<Tratamiento>.GetById(idtratamiento);
        if (tratamiento == null)
        {
            return NotFound();
        }
        return View(tratamiento);
    }

    // POST: CITAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int idtratamiento, Tratamiento tratamiento)
    {
        try
        {
            CRUD<Tratamiento>.Update(idtratamiento, tratamiento);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(tratamiento);
        }
    }

    // GET: CITAS/Delete/5
    public ActionResult Delete(int idtratamiento)
    {
        var tratamiento = CRUD<Tratamiento>.GetById(idtratamiento);
        if (tratamiento == null)
        {
            return NotFound();
        }
        return View(tratamiento);
    }

    // POST: CITAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int idtratamiento, Tratamiento tratamiento)
    {
        try
        {
            CRUD<Tratamiento>.Delete(idtratamiento);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(tratamiento);
        }

    }
}
