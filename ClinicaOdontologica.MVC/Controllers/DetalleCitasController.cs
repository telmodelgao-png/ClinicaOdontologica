
using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Consumer;
public class DetalleCitasController : Controller
{


    // GET: CITAS
    public ActionResult Index()
    {
        var detallecita = CRUD<DetalleCita>.GetAll();
        return View(detallecita);
    }

    // GET: CITAS/Details/5
    public ActionResult Details(int iddetallecita)
    {
        var detallecita = CRUD<DetalleCita>.GetById(iddetallecita);
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
    public ActionResult Edit(int iddetallecita)
    {
        var detallecita = CRUD<DetalleCita>.GetById(iddetallecita);
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
    public ActionResult Edit(int iddetallecita, DetalleCita detallecita)
    {
        try
        {
            CRUD<DetalleCita>.Update(iddetallecita, detallecita);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(detallecita);
        }
    }

    // GET: CITAS/Delete/5
    public ActionResult Delete(int iddetallecita)
    {
        var detallecita = CRUD<DetalleCita>.GetById(iddetallecita);
        if (detallecita == null)
        {
            return NotFound();
        }
        return View(detallecita);
    }

    // POST: CITAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int iddetallecita, DetalleCita detallecita)
    {
        try
        {
            CRUD<DetalleCita>.Delete(iddetallecita);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(detallecita);
        }

    }
}
