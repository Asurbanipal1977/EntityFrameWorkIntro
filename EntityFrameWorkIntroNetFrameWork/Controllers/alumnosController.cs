using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityFrameWorkIntroNetFrameWork;

namespace EntityFrameWorkIntroNetFrameWork.Controllers
{
    public class alumnosController : Controller
    {
        private pruebasEntities db = new pruebasEntities();

        // GET: alumnos
        public ActionResult Index()
        {
            var alumnos = db.alumnos.Include(a => a.paises);
            return View(alumnos.ToList());
        }

        // GET: alumnos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alumnos alumnos = db.alumnos.Find(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            return View(alumnos);
        }

        // GET: alumnos/Create
        public ActionResult Create()
        {
            ViewBag.Pais = new SelectList(db.paises, "Id", "Nombre");
            return View();
        }

        // POST: alumnos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellidos,Dni,FechaNacimiento,Pais,EstadoCivil")] alumnos alumnos)
        {
            if (ModelState.IsValid)
            {
                db.alumnos.Add(alumnos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Pais = new SelectList(db.paises, "Id", "Nombre", alumnos.Pais);
            return View(alumnos);
        }

        // GET: alumnos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alumnos alumnos = db.alumnos.Find(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pais = new SelectList(db.paises, "Id", "Nombre", alumnos.Pais);
            return View(alumnos);
        }

        // POST: alumnos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellidos,Dni,FechaNacimiento,Pais,EstadoCivil")] alumnos alumnos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumnos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pais = new SelectList(db.paises, "Id", "Nombre", alumnos.Pais);
            return View(alumnos);
        }

        // GET: alumnos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alumnos alumnos = db.alumnos.Find(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            return View(alumnos);
        }

        // POST: alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            alumnos alumnos = db.alumnos.Find(id);
            db.alumnos.Remove(alumnos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
