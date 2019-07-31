using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ManteniminetoASP.Models;

namespace ManteniminetoASP.Controllers
{
    public class AcreedoresController : Controller
    {
        private miprimeravesEntities db = new miprimeravesEntities();

        // GET: Acreedores
        public ActionResult Index()
        {
            return View(db.Acreedores.ToList());
        }

        // GET: Acreedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acreedores acreedores = db.Acreedores.Find(id);
            if (acreedores == null)
            {
                return HttpNotFound();
            }
            return View(acreedores);
        }

        // GET: Acreedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Acreedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nombre,Apellido,Telefono")] Acreedores acreedores)
        {
            if (ModelState.IsValid)
            {
                db.Acreedores.Add(acreedores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(acreedores);
        }

        // GET: Acreedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acreedores acreedores = db.Acreedores.Find(id);
            if (acreedores == null)
            {
                return HttpNotFound();
            }
            return View(acreedores);
        }

        // POST: Acreedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nombre,Apellido,Telefono")] Acreedores acreedores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acreedores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(acreedores);
        }

        // GET: Acreedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acreedores acreedores = db.Acreedores.Find(id);
            if (acreedores == null)
            {
                return HttpNotFound();
            }
            return View(acreedores);
        }

        // POST: Acreedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Acreedores acreedores = db.Acreedores.Find(id);
            db.Acreedores.Remove(acreedores);
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
