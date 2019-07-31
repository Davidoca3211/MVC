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
    public class MobiliarioController : Controller
    {
        private miprimeravesEntities db = new miprimeravesEntities();

        // GET: Mobiliario
        public ActionResult Index()
        {
            return View(db.Mobiliarioyequipo.ToList());
        }

        // GET: Mobiliario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mobiliarioyequipo mobiliarioyequipo = db.Mobiliarioyequipo.Find(id);
            if (mobiliarioyequipo == null)
            {
                return HttpNotFound();
            }
            return View(mobiliarioyequipo);
        }

        // GET: Mobiliario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mobiliario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Mueble,Descripcion")] Mobiliarioyequipo mobiliarioyequipo)
        {
            if (ModelState.IsValid)
            {
                db.Mobiliarioyequipo.Add(mobiliarioyequipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mobiliarioyequipo);
        }

        // GET: Mobiliario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mobiliarioyequipo mobiliarioyequipo = db.Mobiliarioyequipo.Find(id);
            if (mobiliarioyequipo == null)
            {
                return HttpNotFound();
            }
            return View(mobiliarioyequipo);
        }

        // POST: Mobiliario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Mueble,Descripcion")] Mobiliarioyequipo mobiliarioyequipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mobiliarioyequipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mobiliarioyequipo);
        }

        // GET: Mobiliario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mobiliarioyequipo mobiliarioyequipo = db.Mobiliarioyequipo.Find(id);
            if (mobiliarioyequipo == null)
            {
                return HttpNotFound();
            }
            return View(mobiliarioyequipo);
        }

        // POST: Mobiliario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mobiliarioyequipo mobiliarioyequipo = db.Mobiliarioyequipo.Find(id);
            db.Mobiliarioyequipo.Remove(mobiliarioyequipo);
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
