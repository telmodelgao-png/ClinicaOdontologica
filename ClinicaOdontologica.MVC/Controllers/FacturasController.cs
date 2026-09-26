
using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologica.Modelos;
using ClinicaOdontologica.Consumer;
public class FacturasController : Controller
{


    // GET: CITAS
    public ActionResult Index()
    {
        var factura = CRUD<Factura>.GetAll();
        return View(factura);
    }

    // GET: CITAS/Details/5
    public ActionResult Details(int idfactura)
    {
        var factura = CRUD<Factura>.GetById(idfactura);
        if (factura == null)
        {
            return NotFound();
        }
        else
        {
            return View(factura);
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
    public ActionResult Create(Factura factura)
    {
        try
        {
            CRUD<Factura>.Create(factura);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(factura);
        }
    }

    // GET: CITAS/Edit/5
    public ActionResult Edit(int idfactura)
    {
        var factura = CRUD<Factura>.GetById(idfactura);
        if (factura == null)
        {
            return NotFound();
        }
        return View(factura);
    }

    // POST: CITAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int idfactura, Factura factura)
    {
        try
        {
            CRUD<Factura>.Update(idfactura, factura);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(factura);
        }
    }

    // GET: CITAS/Delete/5
    public ActionResult Delete(int idfactura)
    {
        var factura = CRUD<Factura>.GetById(idfactura);
        if (factura == null)
        {
            return NotFound();
        }
        return View(factura);
    }

    // POST: CITAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int idfactura, Factura factura)
    {
        try
        {
            CRUD<Factura>.Delete(idfactura);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(factura);
        }

    }
}
