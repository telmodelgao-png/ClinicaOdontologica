
using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Consumer;
public class ConsultoriosController : Controller
{


    // GET: CITAS
    public ActionResult Index()
    {
        var consultorios = CRUD<Consultorio>.GetAll();
        return View(consultorios);
    }

    // GET: CITAS/Details/5
    public ActionResult Details(int id)
    {
        var consultorios = CRUD<Consultorio>.GetById(id);
        if (consultorios == null)
        {
            return NotFound();
        }
        else
        {
            return View(consultorios);
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
    public ActionResult Create(Consultorio consultorio)
    {
        try
        {
            CRUD<Consultorio>.Create(consultorio);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(consultorio);
        }
    }

    // GET: CITAS/Edit/5
    public ActionResult Edit(int id)
    {
        var consultorio = CRUD<Consultorio>.GetById(id);
        if (consultorio == null)
        {
            return NotFound();
        }
        return View(consultorio);
    }

    // POST: CITAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Consultorio consultorio)
    {
        try
        {
            CRUD<Consultorio>.Update(id, consultorio);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(consultorio);
        }
    }

    // GET: CITAS/Delete/5
    public ActionResult Delete(int id)
    {
        var consultorio = CRUD<Consultorio>.GetById(id);
        if (consultorio == null)
        {
            return NotFound();
        }
        return View(consultorio);
    }

    // POST: CITAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id, Consultorio consultorio)
    {
        try
        {
            CRUD<Consultorio>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(consultorio);
        }

    }
}
