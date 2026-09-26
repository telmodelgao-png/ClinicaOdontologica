
using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Consumer;
public class OdontologoesController : Controller
{


    // GET: CITAS
    public ActionResult Index()
    {
        var odontologos = CRUD<Odontologo>.GetAll();
        return View(odontologos);
    }

    // GET: CITAS/Details/5
    public ActionResult Details(int idodontologo)
    {
        var odontologo = CRUD<Odontologo>.GetById(idodontologo);
        if (odontologo == null)
        {
            return NotFound();
        }
        else
        {
            return View(odontologo);
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
    public ActionResult Create(Odontologo odontologo)
    {
        try
        {
            CRUD<Odontologo>.Create(odontologo);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(odontologo);
        }
    }

    // GET: CITAS/Edit/5
    public ActionResult Edit(int idodontologo)
    {
        var odontologo = CRUD<Odontologo>.GetById(idodontologo);
        if (odontologo == null)
        {
            return NotFound();
        }
        return View(odontologo);
    }

    // POST: CITAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int idodontologo, Odontologo odontologo)
    {
        try
        {
            CRUD<Odontologo>.Update(idodontologo, odontologo);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(odontologo);
        }
    }

    // GET: CITAS/Delete/5
    public ActionResult Delete(int idontologo)
    {
        var odontologo = CRUD<Odontologo>.GetById(idontologo);
        if (odontologo == null)
        {
            return NotFound();
        }
        return View(odontologo);
    }

    // POST: CITAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int idodontologo, Odontologo odontologo)
    {
        try
        {
            CRUD<Odontologo>.Delete(idodontologo);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(odontologo);
        }

    }
}
