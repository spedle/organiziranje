using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using organiziranje.Models;

namespace organiziranje.Controllers
{
    public class NormativOpremaController : Controller
    {
        private DbModels db = new DbModels();

        // GET: NormativOprema
        public ActionResult Index()
        {
            var normativ_oprema = db.normativ_oprema.Include(n => n.oprema).Include(n => n.usluga);
            return View(normativ_oprema.ToList());
        }

        // GET: NormativOprema/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            normativ_oprema normativ_oprema = db.normativ_oprema.Find(id);
            if (normativ_oprema == null)
            {
                return HttpNotFound();
            }
            return View(normativ_oprema);
        }

        // GET: NormativOprema/Create
        public ActionResult Create()
        {
            ViewBag.oprema_id = new SelectList(db.opremas, "id", "naziv");
            ViewBag.usluga_id = new SelectList(db.uslugas, "id", "opis");
            return View();
        }

        // POST: NormativOprema/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,oprema_id,usluga_id")] normativ_oprema normativ_oprema)
        {
            if (ModelState.IsValid)
            {
                db.normativ_oprema.Add(normativ_oprema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.oprema_id = new SelectList(db.opremas, "id", "naziv", normativ_oprema.oprema_id);
            ViewBag.usluga_id = new SelectList(db.uslugas, "id", "opis", normativ_oprema.usluga_id);
            return View(normativ_oprema);
        }

        // GET: NormativOprema/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            normativ_oprema normativ_oprema = db.normativ_oprema.Find(id);
            if (normativ_oprema == null)
            {
                return HttpNotFound();
            }
            ViewBag.oprema_id = new SelectList(db.opremas, "id", "naziv", normativ_oprema.oprema_id);
            ViewBag.usluga_id = new SelectList(db.uslugas, "id", "opis", normativ_oprema.usluga_id);
            return View(normativ_oprema);
        }

        // POST: NormativOprema/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,oprema_id,usluga_id")] normativ_oprema normativ_oprema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(normativ_oprema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.oprema_id = new SelectList(db.opremas, "id", "naziv", normativ_oprema.oprema_id);
            ViewBag.usluga_id = new SelectList(db.uslugas, "id", "opis", normativ_oprema.usluga_id);
            return View(normativ_oprema);
        }

        // GET: NormativOprema/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            normativ_oprema normativ_oprema = db.normativ_oprema.Find(id);
            if (normativ_oprema == null)
            {
                return HttpNotFound();
            }
            return View(normativ_oprema);
        }

        // POST: NormativOprema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            normativ_oprema normativ_oprema = db.normativ_oprema.Find(id);
            db.normativ_oprema.Remove(normativ_oprema);
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
