using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using organiziranje.Models;
using Rotativa;

namespace organiziranje.Controllers
{
    public class NatjecajTransakcijaOsobljeController : Controller
    {
        private DbModels db = new DbModels();

        // GET: NatjecajTransakcijaOsoblje
        public ActionResult Index()
        {
            var natjecaj_transakcija_osoblje = db.natjecaj_transakcija_osoblje.Include(n => n.natjecaj).Include(n => n.transakcija_osoblje);
            return View(natjecaj_transakcija_osoblje.ToList());
        }

        public ActionResult printAll()
        {
            var report = new ActionAsPdf("Index");
            return report;
        }

        // GET: NatjecajTransakcijaOsoblje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            natjecaj_transakcija_osoblje natjecaj_transakcija_osoblje = db.natjecaj_transakcija_osoblje.Find(id);
            if (natjecaj_transakcija_osoblje == null)
            {
                return HttpNotFound();
            }
            return View(natjecaj_transakcija_osoblje);
        }

        // GET: NatjecajTransakcijaOsoblje/Create
        public ActionResult Create()
        {
            ViewBag.natjecaj_id = new SelectList(db.natjecajs, "id", "raspisala_osoba");
            ViewBag.transakcija_osoblje_id = new SelectList(db.transakcija_osoblje, "id", "id");
            return View();
        }

        // POST: NatjecajTransakcijaOsoblje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,natjecaj_id,transakcija_osoblje_id")] natjecaj_transakcija_osoblje natjecaj_transakcija_osoblje)
        {
            if (ModelState.IsValid)
            {
                db.natjecaj_transakcija_osoblje.Add(natjecaj_transakcija_osoblje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.natjecaj_id = new SelectList(db.natjecajs, "id", "raspisala_osoba", natjecaj_transakcija_osoblje.natjecaj_id);
            ViewBag.transakcija_osoblje_id = new SelectList(db.transakcija_osoblje, "id", "id", natjecaj_transakcija_osoblje.transakcija_osoblje_id);
            return View(natjecaj_transakcija_osoblje);
        }

        // GET: NatjecajTransakcijaOsoblje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            natjecaj_transakcija_osoblje natjecaj_transakcija_osoblje = db.natjecaj_transakcija_osoblje.Find(id);
            if (natjecaj_transakcija_osoblje == null)
            {
                return HttpNotFound();
            }
            ViewBag.natjecaj_id = new SelectList(db.natjecajs, "id", "raspisala_osoba", natjecaj_transakcija_osoblje.natjecaj_id);
            ViewBag.transakcija_osoblje_id = new SelectList(db.transakcija_osoblje, "id", "id", natjecaj_transakcija_osoblje.transakcija_osoblje_id);
            return View(natjecaj_transakcija_osoblje);
        }

        // POST: NatjecajTransakcijaOsoblje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,natjecaj_id,transakcija_osoblje_id")] natjecaj_transakcija_osoblje natjecaj_transakcija_osoblje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(natjecaj_transakcija_osoblje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.natjecaj_id = new SelectList(db.natjecajs, "id", "raspisala_osoba", natjecaj_transakcija_osoblje.natjecaj_id);
            ViewBag.transakcija_osoblje_id = new SelectList(db.transakcija_osoblje, "id", "id", natjecaj_transakcija_osoblje.transakcija_osoblje_id);
            return View(natjecaj_transakcija_osoblje);
        }

        // GET: NatjecajTransakcijaOsoblje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            natjecaj_transakcija_osoblje natjecaj_transakcija_osoblje = db.natjecaj_transakcija_osoblje.Find(id);
            if (natjecaj_transakcija_osoblje == null)
            {
                return HttpNotFound();
            }
            return View(natjecaj_transakcija_osoblje);
        }

        // POST: NatjecajTransakcijaOsoblje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            natjecaj_transakcija_osoblje natjecaj_transakcija_osoblje = db.natjecaj_transakcija_osoblje.Find(id);
            db.natjecaj_transakcija_osoblje.Remove(natjecaj_transakcija_osoblje);
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
