
using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Consumer;
public class RecetasController : Controller
{


    // GET: CITAS
    public ActionResult Index()
    {
        var recetas = CRUD<Receta>.GetAll();
        return View(recetas);
    }

    // GET: CITAS/Details/5
    public ActionResult Details(int idreceta)
    {
        var receta = CRUD<Receta>.GetById(idreceta);
        if (receta == null)
        {
            return NotFound();
        }
        else
        {
            return View(receta);
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
    public ActionResult Create(Receta receta)
    {
        try
        {
            CRUD<Receta>.Create(receta);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(receta);
        }
    }

    // GET: CITAS/Edit/5
    public ActionResult Edit(int idreceta)
    {
        var receta = CRUD<Receta>.GetById(idreceta);
        if (receta == null)
        {
            return NotFound();
        }
        return View(receta);
    }

    // POST: CITAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int idreceta, Receta receta)
    {
        try
        {
            CRUD<Receta>.Update(idreceta, receta);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(receta);
        }
    }

    // GET: CITAS/Delete/5
    public ActionResult Delete(int idreceta)
    {
        var receta = CRUD<Receta>.GetById(idreceta);
        if (receta == null)
        {
            return NotFound();
        }
        return View(receta);
    }

    // POST: CITAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int idreceta, Receta receta)
    {
        try
        {
            CRUD<Receta>.Delete(idreceta);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(receta);
        }

    }
}
