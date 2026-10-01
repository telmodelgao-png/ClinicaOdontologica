
using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Consumer;
using Microsoft.AspNetCore.Authorization;

[Authorize]
public class DetalleCitasController : Controller
{


    // GET: CITAS
    public ActionResult Index()
    {
        var detallecita = CRUD<DetalleCita>.GetAll();
        return View(detallecita);
    }

    // GET: CITAS/Details/5
    public ActionResult Details(int id)
    {
        var detallecita = CRUD<DetalleCita>.GetById(id);
        if (detallecita == null)
        {
            return NotFound();
        }
        else
        {
            return View(detallecita);
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
    public ActionResult Create(DetalleCita detallecita)
    {
        try
        {
            CRUD<DetalleCita>.Create(detallecita);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(detallecita);
        }
    }

    // GET: CITAS/Edit/5
    public ActionResult Edit(int id)
    {
        var detallecita = CRUD<DetalleCita>.GetById(id);
        if (detallecita == null)
        {
            return NotFound();
        }
        return View(detallecita);
    }

    // POST: CITAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, DetalleCita detallecita)
    {
        try
        {
            CRUD<DetalleCita>.Update(id, detallecita);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(detallecita);
        }
    }

    // GET: CITAS/Delete/5
    public ActionResult Delete(int id)
    {
        var detallecita = CRUD<DetalleCita>.GetById(id);
        if (detallecita == null)
        {
            return NotFound();
        }
        return View(detallecita);
    }

    // POST: CITAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id, DetalleCita detallecita)
    {
        try
        {
            CRUD<DetalleCita>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(detallecita);
        }

    }
}
