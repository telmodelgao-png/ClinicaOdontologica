
using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Consumer;
public class HistorialMedicoesController : Controller
{


    // GET: CITAS
    public ActionResult Index()
    {
        var historialmedico = CRUD<HistorialMedico>.GetAll();
        return View(historialmedico);
    }

    // GET: CITAS/Details/5
    public ActionResult Details(int idhistorialmedico)
    {
        var historialmedico = CRUD<HistorialMedico>.GetById(idhistorialmedico);
        if (historialmedico == null)
        {
            return NotFound();
        }
        else
        {
            return View(historialmedico);
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
    public ActionResult Create(HistorialMedico historialmedico)
    {
        try
        {
            CRUD<HistorialMedico>.Create(historialmedico);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(historialmedico);
        }
    }

    // GET: CITAS/Edit/5
    public ActionResult Edit(int idhistorialmedico)
    {
        var historialmedico = CRUD<HistorialMedico>.GetById(idhistorialmedico);
        if (historialmedico == null)
        {
            return NotFound();
        }
        return View(historialmedico);
    }

    // POST: CITAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int idhistorialmedico, HistorialMedico historialmedico)
    {
        try
        {
            CRUD<HistorialMedico>.Update(idhistorialmedico, historialmedico);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(historialmedico);
        }
    }

    // GET: CITAS/Delete/5
    public ActionResult Delete(int idhistorialmedico)
    {
        var historialmedico = CRUD<HistorialMedico>.GetById(idhistorialmedico);
        if (historialmedico == null)
        {
            return NotFound();
        }
        return View(historialmedico);
    }

    // POST: CITAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int idhitorialmedico, HistorialMedico historialmedico)
    {
        try
        {
            CRUD<HistorialMedico>.Delete(idhitorialmedico);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(historialmedico);
        }

    }
}
