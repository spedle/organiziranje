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
    public class NatjecajTransakcijaOpremaController : Controller
    {
        private DbModels db = new DbModels();

        // GET: NatjecajTransakcijaOprema
        public ActionResult Index()
        {
            var natjecaj_transakcija_oprema = db.natjecaj_transakcija_oprema.Include(n => n.natjecaj).Include(n => n.transakcija_oprema);
            return View(natjecaj_transakcija_oprema.ToList());
        }

        // GET: NatjecajTransakcijaOprema/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            natjecaj_transakcija_oprema natjecaj_transakcija_oprema = db.natjecaj_transakcija_oprema.Find(id);
            if (natjecaj_transakcija_oprema == null)
            {
                return HttpNotFound();
            }
            return View(natjecaj_transakcija_oprema);
        }

        // GET: NatjecajTransakcijaOprema/Create
        public ActionResult Create()
        {
            ViewBag.natjecaj_id = new SelectList(db.natjecajs, "id", "raspisala_osoba");
            ViewBag.transakcija_oprema_id = new SelectList(db.transakcija_oprema, "id", "id");
            return View();
        }

        // POST: NatjecajTransakcijaOprema/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,natjecaj_id,transakcija_oprema_id")] natjecaj_transakcija_oprema natjecaj_transakcija_oprema)
        {
            if (ModelState.IsValid)
            {
                db.natjecaj_transakcija_oprema.Add(natjecaj_transakcija_oprema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.natjecaj_id = new SelectList(db.natjecajs, "id", "raspisala_osoba", natjecaj_transakcija_oprema.natjecaj_id);
            ViewBag.transakcija_oprema_id = new SelectList(db.transakcija_oprema, "id", "id", natjecaj_transakcija_oprema.transakcija_oprema_id);
            return View(natjecaj_transakcija_oprema);
        }

        // GET: NatjecajTransakcijaOprema/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            natjecaj_transakcija_oprema natjecaj_transakcija_oprema = db.natjecaj_transakcija_oprema.Find(id);
            if (natjecaj_transakcija_oprema == null)
            {
                return HttpNotFound();
            }
            ViewBag.natjecaj_id = new SelectList(db.natjecajs, "id", "raspisala_osoba", natjecaj_transakcija_oprema.natjecaj_id);
            ViewBag.transakcija_oprema_id = new SelectList(db.transakcija_oprema, "id", "id", natjecaj_transakcija_oprema.transakcija_oprema_id);
            return View(natjecaj_transakcija_oprema);
        }

        // POST: NatjecajTransakcijaOprema/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,natjecaj_id,transakcija_oprema_id")] natjecaj_transakcija_oprema natjecaj_transakcija_oprema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(natjecaj_transakcija_oprema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.natjecaj_id = new SelectList(db.natjecajs, "id", "raspisala_osoba", natjecaj_transakcija_oprema.natjecaj_id);
            ViewBag.transakcija_oprema_id = new SelectList(db.transakcija_oprema, "id", "id", natjecaj_transakcija_oprema.transakcija_oprema_id);
            return View(natjecaj_transakcija_oprema);
        }

        // GET: NatjecajTransakcijaOprema/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            natjecaj_transakcija_oprema natjecaj_transakcija_oprema = db.natjecaj_transakcija_oprema.Find(id);
            if (natjecaj_transakcija_oprema == null)
            {
                return HttpNotFound();
            }
            return View(natjecaj_transakcija_oprema);
        }

        // POST: NatjecajTransakcijaOprema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            natjecaj_transakcija_oprema natjecaj_transakcija_oprema = db.natjecaj_transakcija_oprema.Find(id);
            db.natjecaj_transakcija_oprema.Remove(natjecaj_transakcija_oprema);
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
