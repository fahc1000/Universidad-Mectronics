using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Universidad.Models;

namespace Universidad.Controllers
{
    public class ProfesoresController : Controller
    {
        UniversidadEntities db = new UniversidadEntities();
        // GET: Profesores
        public ActionResult Index()
        {
            var Profesores = db.Profesores;
            return View(Profesores);
        }

        // GET: Profesores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profesores/Create
        [HttpPost]
        public ActionResult Create(Profesores collection)
        {
            try
            {
                db.Profesores.Add(collection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profesores/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profesores/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Profesores collection)
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

        // GET: Profesores/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profesores/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Profesores profesor = db.Profesores.Find(id);

                db.Profesores.Remove(profesor);

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
