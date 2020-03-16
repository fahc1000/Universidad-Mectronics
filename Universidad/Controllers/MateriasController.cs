using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Universidad.Models;

namespace Universidad.Controllers
{
    public class MateriasController : Controller
    {
        UniversidadEntities db = new UniversidadEntities();
        // GET: Materias
        public ActionResult Index(string campo)
        {
            IEnumerable<Materias> materias;
            if (!string.IsNullOrEmpty(campo))
            {
                materias = db.Materias.Where(x => x.Nombre.ToLower().Trim().Contains(campo));
            }
            else
            {
                materias = db.Materias;
            }
            return View(materias);
        }

        // GET: Materias/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Materias/Create
        public ActionResult Create()
        {
            List<Profesores> profesoresList = db.Profesores.ToList();
            var profesorList = profesoresList.Select(
                x => new
                {
                    ProfesorId = x.Id,
                    x.Nombre
                }
                );
            ViewBag.Profesores = new SelectList(profesorList, "ProfesorId", "Nombre");
            return View();
        }

        // POST: Materias/Create
        [HttpPost]
        public ActionResult Create(Materias collection)
        {
            try
            {
                db.Materias.Add(collection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Materias/Edit/5
        public ActionResult Edit(int id)
        {
            List<Profesores> profesoresList = db.Profesores.ToList();
            var profesorList = profesoresList.Select(
                x => new
                {
                    ProfesorId = x.Id,
                    x.Nombre
                }
                );
            ViewBag.Profesores = new SelectList(profesorList, "ProfesorId", "Nombre");
            return View();
        }

        // POST: Materias/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Materias collection)
        {
            try
            {
                db.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Materias/Delete/5
        public ActionResult Delete(int id)
        {
            Materias materia = db.Materias.Find(id);
            return View(materia);
        }

        // POST: Materias/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Materias collection)
        {
            try
            {
                Materias materia = db.Materias.Find(id);

                db.Materias.Remove(materia);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
