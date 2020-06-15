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
    public class UnajmljenaOpremaController : Controller
    {
        private DbModels db = new DbModels();

        // GET: UnajmljenaOprema
        public ActionResult Index()
        {
            var unajmljena_oprema = db.unajmljena_oprema.Include(u => u.oprema);
            return View(unajmljena_oprema.ToList());
        }

        // GET: UnajmljenaOprema/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            unajmljena_oprema unajmljena_oprema = db.unajmljena_oprema.Find(id);
            if (unajmljena_oprema == null)
            {
                return HttpNotFound();
            }
            return View(unajmljena_oprema);
        }

        // GET: UnajmljenaOprema/Create
        public ActionResult Create()
        {
            ViewBag.oprema_id = new SelectList(db.opremas, "id", "naziv");
            return View();
        }

        // POST: UnajmljenaOprema/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,koristenje_od,koristenje_do,tip,osoba,oprema_id")] unajmljena_oprema unajmljena_oprema)
        {
            if (ModelState.IsValid)
            {
                db.unajmljena_oprema.Add(unajmljena_oprema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.oprema_id = new SelectList(db.opremas, "id", "naziv", unajmljena_oprema.oprema_id);
            return View(unajmljena_oprema);
        }

        // GET: UnajmljenaOprema/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            unajmljena_oprema unajmljena_oprema = db.unajmljena_oprema.Find(id);
            if (unajmljena_oprema == null)
            {
                return HttpNotFound();
            }
            ViewBag.oprema_id = new SelectList(db.opremas, "id", "naziv", unajmljena_oprema.oprema_id);
            return View(unajmljena_oprema);
        }

        // POST: UnajmljenaOprema/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,koristenje_od,koristenje_do,tip,osoba,oprema_id")] unajmljena_oprema unajmljena_oprema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unajmljena_oprema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.oprema_id = new SelectList(db.opremas, "id", "naziv", unajmljena_oprema.oprema_id);
            return View(unajmljena_oprema);
        }

        // GET: UnajmljenaOprema/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            unajmljena_oprema unajmljena_oprema = db.unajmljena_oprema.Find(id);
            if (unajmljena_oprema == null)
            {
                return HttpNotFound();
            }
            return View(unajmljena_oprema);
        }

        // POST: UnajmljenaOprema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            unajmljena_oprema unajmljena_oprema = db.unajmljena_oprema.Find(id);
            db.unajmljena_oprema.Remove(unajmljena_oprema);
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
