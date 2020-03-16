using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Universidad.Models;

namespace Universidad.Controllers
{
    public class AlumnosController : Controller
    {
        UniversidadEntities db = new UniversidadEntities();
        // GET: Alumnos
        public ActionResult Index(string cedula,string orden)
        {
            IEnumerable<Alumnos> alumnos;
            if (!string.IsNullOrEmpty(cedula))
            {
                alumnos = db.Alumnos.Where(x => x.Cedula.ToString().ToLower().Trim().Contains(cedula));
            }
            else
            {
                alumnos = db.Alumnos;
            }
            if(!string.IsNullOrEmpty(orden))
            {
                switch (orden)
                {
                    case "Cedula":
                        alumnos = db.Alumnos.OrderBy(x => x.Cedula);
                        break;
                    case "FechaRegistro":
                        alumnos = db.Alumnos.OrderBy(x => x.FechaRegistro);
                        break;
                    default:
                        alumnos = db.Alumnos;
                        break;
                }
            }
            return View(alumnos);
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(int id)
        {
            
            var alumnosmaterias = db.Alumnos.Find(id).Alunmos_Materias;
            ViewBag.Cedula = id;
            return View(alumnosmaterias);
        }

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alumnos/Create
        [HttpPost]
        public ActionResult Create(Alumnos alumno)
        {
            try
            {
                alumno.FechaRegistro = DateTime.Now;
                db.Alumnos.Add(alumno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alumnos/Create
        public ActionResult CreateAlumnoMateria(int cedula)
        {
            List<Salones> SalonesList = db.Salones.ToList();
            var SalonPisoList = SalonesList.Select(
                x => new
                {
                    SalonId = x.Id,
                    Nombre = x.NumeroSalon + " - " + x.Piso
                }
                );
            ViewBag.Salones = new SelectList(SalonPisoList, "SalonId", "Nombre");

            List<Materias> MateriasList = db.Materias.ToList();
            var MateList = MateriasList.Select(
                x => new
                {
                    MateriaId = x.Id,
                    x.Nombre
                }
                );
            ViewBag.Materias = new SelectList(MateList, "MateriaId", "Nombre");

            Alunmos_Materias alumnoMateria = new Alunmos_Materias();
            alumnoMateria.Cedula = cedula;
            Alumnos alumno = db.Alumnos.Find(cedula);
            ViewBag.nombreEstudiante = alumno.Nombre;
            
            return View(alumnoMateria);
        }

        // POST: Alumnos/Create
        [HttpPost]
        public ActionResult CreateAlumnoMateria(Alunmos_Materias alumnomateria)
        {
            try
            {
                db.Alunmos_Materias.Add(alumnomateria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alumnos/Edit/5
        public ActionResult Edit(int id)
        {
            var alumno = db.Alumnos.Find(id);
            return View(alumno);
        }

        // POST: Alumnos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Alumnos collection)
        {
            try
            {
                db.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Alumnos/Edit/5
        public ActionResult EditAlumnoMateria(int id)
        {
            List<Salones> SalonesList = db.Salones.ToList();
            var SalonPisoList = SalonesList.Select(
                x => new
                {
                    SalonId = x.Id,
                    Nombre = x.NumeroSalon + " - " + x.Piso
                }
                );
            ViewBag.Salones = new SelectList(SalonPisoList, "SalonId", "Nombre");

            List<Materias> MateriasList = db.Materias.ToList();
            var MateList = MateriasList.Select(
                x => new
                {
                    MateriaId = x.Id,
                    x.Nombre
                }
                );
            ViewBag.Materias = new SelectList(MateList, "MateriaId", "Nombre");
            var alumnoMateria = db.Alunmos_Materias.Find(id);
            return View(alumnoMateria);
        }

        // POST: Alumnos/Edit/5
        [HttpPost]
        public ActionResult EditAlumnoMateria(int id, Alunmos_Materias collection)
        {
            try
            {
                db.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int id)
        {
            var alumno = db.Alumnos.Find(id);
            return View(alumno);
        }

        // POST: Alumnos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Alumnos collection)
        {
            try
            {
                Alumnos alumno = db.Alumnos.Find(id);
                List<Alunmos_Materias> alunmos_Materias = db.Alunmos_Materias.Where(x => x.Cedula == id).ToList();

                if(alunmos_Materias != null)
                {
                    List<int> lstAlumnosMaterias = alunmos_Materias.Select(x => x.Id).ToList();
                    List<TrazaNota> trazaNotas = db.TrazaNota.Where(x => lstAlumnosMaterias.Contains(x.Alumnos_Materias_Id)).ToList();
                    if(trazaNotas != null)
                    {
                        db.TrazaNota.RemoveRange(trazaNotas);
                    }
                    db.Alunmos_Materias.RemoveRange(alunmos_Materias);
                }

                db.Alumnos.Remove(alumno);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Alumnos/Delete/5
        public ActionResult DeleteAlumnoMateria(int id)
        {
            var alumnoMateria = db.Alunmos_Materias.Find(id);
            return View(alumnoMateria);
        }

        // POST: Alumnos/Delete/5
        [HttpPost]
        public ActionResult DeleteAlumnoMateria(int id, Alunmos_Materias collection)
        {
            try
            {
                Alunmos_Materias alumnoMateria = db.Alunmos_Materias.Find(id);

                List<TrazaNota> trazaNotas = db.TrazaNota.Where(x => x.Alumnos_Materias_Id == id).ToList();
                if (trazaNotas != null)
                {
                    db.TrazaNota.RemoveRange(trazaNotas);
                }
                db.Alunmos_Materias.Remove(alumnoMateria);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Alumnos/EditNota/5
        public ActionResult EditNota(int id)
        {
            Alunmos_Materias alunmos_Materria = db.Alunmos_Materias.Find(id);
            return View(alunmos_Materria);
        }

        // POST: Alumnos/Delete/5
        [HttpPost]
        public ActionResult EditNota(int id, Alunmos_Materias collection)
        {
            try
            {
                int NotaOld = 0;
                int NotaNew = 0;
                Alunmos_Materias oldValue = db.Alunmos_Materias.AsNoTracking().FirstOrDefault(x => x.Id == id);

                int.TryParse(oldValue.Nota.ToString(), out NotaOld);
                int.TryParse(collection.Nota.ToString(), out NotaNew);

                TrazaNota trazaNota = new TrazaNota();
                trazaNota.ProfesorId = oldValue.Materias.ProfesorId;
                trazaNota.ValorAnterior = NotaOld;
                trazaNota.ValorNuevo = NotaNew;
                trazaNota.Alumnos_Materias_Id = collection.Id;

                db.TrazaNota.Add(trazaNota);
                db.Entry(collection).State = System.Data.Entity.EntityState.Modified;
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
