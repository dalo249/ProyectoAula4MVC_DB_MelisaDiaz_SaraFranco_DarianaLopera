using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoAula4MVC.Models.DB;

namespace ProyectoAula4MVC.Controllers
{
    public class Ideas_De_NegocioController : Controller
    {
        private ProyectoAula4MVC_DBEntities db = new ProyectoAula4MVC_DBEntities();

        // GET: Ideas_De_Negocio
        public ActionResult Index()
        {
            var ideas_De_Negocio = db.Ideas_De_Negocio.Include(i => i.Herramientas4RI).Include(i => i.Impactos);
            return View(ideas_De_Negocio.ToList());
        }

        // GET: Ideas_De_Negocio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ideas_De_Negocio ideas_De_Negocio = db.Ideas_De_Negocio.Find(id);
            if (ideas_De_Negocio == null)
            {
                return HttpNotFound();
            }
            return View(ideas_De_Negocio);
        }

        // GET: Ideas_De_Negocio/Create
        public ActionResult Create()
        {
            ViewBag.ID_Herramienta = new SelectList(db.Herramientas4RI, "ID_Herramienta", "Nombre");
            ViewBag.ID_Impacto = new SelectList(db.Impactos, "ID_Impacto", "Nombre");
            return View();
        }

        // POST: Ideas_De_Negocio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Idea,Nombre,ID_Impacto,Valor_Inversion,Valor_Inversion_Infraestructura,Total_Ingresos,ID_Herramienta")] Ideas_De_Negocio ideas_De_Negocio)
        {
            if (ModelState.IsValid)
            {
                db.Ideas_De_Negocio.Add(ideas_De_Negocio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Herramienta = new SelectList(db.Herramientas4RI, "ID_Herramienta", "Nombre", ideas_De_Negocio.ID_Herramienta);
            ViewBag.ID_Impacto = new SelectList(db.Impactos, "ID_Impacto", "Nombre", ideas_De_Negocio.ID_Impacto);
            return View(ideas_De_Negocio);
        }

        // GET: Ideas_De_Negocio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ideas_De_Negocio ideas_De_Negocio = db.Ideas_De_Negocio.Find(id);
            if (ideas_De_Negocio == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Herramienta = new SelectList(db.Herramientas4RI, "ID_Herramienta", "Nombre", ideas_De_Negocio.ID_Herramienta);
            ViewBag.ID_Impacto = new SelectList(db.Impactos, "ID_Impacto", "Nombre", ideas_De_Negocio.ID_Impacto);
            return View(ideas_De_Negocio);
        }

        // POST: Ideas_De_Negocio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Idea,Nombre,ID_Impacto,Valor_Inversion,Valor_Inversion_Infraestructura,Total_Ingresos,ID_Herramienta")] Ideas_De_Negocio ideas_De_Negocio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ideas_De_Negocio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Herramienta = new SelectList(db.Herramientas4RI, "ID_Herramienta", "Nombre", ideas_De_Negocio.ID_Herramienta);
            ViewBag.ID_Impacto = new SelectList(db.Impactos, "ID_Impacto", "Nombre", ideas_De_Negocio.ID_Impacto);
            return View(ideas_De_Negocio);
        }

        // GET: Ideas_De_Negocio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ideas_De_Negocio ideas_De_Negocio = db.Ideas_De_Negocio.Find(id);
            if (ideas_De_Negocio == null)
            {
                return HttpNotFound();
            }
            return View(ideas_De_Negocio);
        }

        // POST: Ideas_De_Negocio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ideas_De_Negocio ideas_De_Negocio = db.Ideas_De_Negocio.Find(id);
            db.Ideas_De_Negocio.Remove(ideas_De_Negocio);
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
