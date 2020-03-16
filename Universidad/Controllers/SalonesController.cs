using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Universidad.Models;

namespace Universidad.Controllers
{
    public class SalonesController : Controller
    {
        UniversidadEntities db = new UniversidadEntities();
        // GET: Salones
        public ActionResult Index()
        {
            var salones = db.Salones;
            return View(salones);
        }

        // GET: Salones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salones/Create
        [HttpPost]
        public ActionResult Create(Salones collection)
        {
            try
            {
                db.Salones.Add(collection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Salones/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.Salones.Find(id));
        }

        // POST: Salones/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Salones collection)
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

        // GET: Salones/Delete/5
        public ActionResult Delete(int id)
        {
            var salon = db.Salones.Find(id);
            return View(salon);
        }

        // POST: Salones/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Salones salon = db.Salones.Find(id);

                db.Salones.Remove(salon);

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
