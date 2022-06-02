using aula.App_Start.Models;
using aula.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aula.Controllers
{
    public class FabricantesController : Controller
    {
        private EFContext context = new EFContext();

        private static IList<Fabricante> fabricantes = new List<Fabricante>()
        {
        new Fabricante() { FabricanteId = 1, Nome = "LG"},
        new Fabricante() { FabricanteId = 1, Nome = "Microsoft"}
        };

        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(
                fabricantes
                //context.Fabricantes.OrderBy(c => c.Nome)
                );
        }

        // GET: Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            fabricantes.Add(fabricante);
            fabricante.FabricanteId = fabricantes.Select(m => m.FabricanteId).Max() + 1;
            //context.Fabricantes.Add(fabricante);
            //context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}