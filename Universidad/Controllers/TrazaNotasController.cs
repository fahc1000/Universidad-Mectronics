using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Universidad.Models;

namespace Universidad.Controllers
{
    public class TrazaNotasController : Controller
    {
        UniversidadEntities db = new UniversidadEntities();
        // GET: TrazaNotas
        public ActionResult Index()
        {
            var trazaNotas = db.TrazaNota;
            return View(trazaNotas);
        }
    }
}