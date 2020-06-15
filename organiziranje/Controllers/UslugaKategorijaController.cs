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
    public class UslugaKategorijaController : Controller
    {
        private DbModels db = new DbModels();

        // GET: UslugaKategorija
        public ActionResult Index()
        {
            return View(db.usluga_kategorija.ToList());
        }

        // GET: UslugaKategorija/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usluga_kategorija usluga_kategorija = db.usluga_kategorija.Find(id);
            if (usluga_kategorija == null)
            {
                return HttpNotFound();
            }
            return View(usluga_kategorija);
        }

        // GET: UslugaKategorija/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UslugaKategorija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,naziv")] usluga_kategorija usluga_kategorija)
        {
            if (ModelState.IsValid)
            {
                db.usluga_kategorija.Add(usluga_kategorija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usluga_kategorija);
        }

        // GET: UslugaKategorija/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usluga_kategorija usluga_kategorija = db.usluga_kategorija.Find(id);
            if (usluga_kategorija == null)
            {
                return HttpNotFound();
            }
            return View(usluga_kategorija);
        }

        // POST: UslugaKategorija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,naziv")] usluga_kategorija usluga_kategorija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usluga_kategorija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usluga_kategorija);
        }

        // GET: UslugaKategorija/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usluga_kategorija usluga_kategorija = db.usluga_kategorija.Find(id);
            if (usluga_kategorija == null)
            {
                return HttpNotFound();
            }
            return View(usluga_kategorija);
        }

        // POST: UslugaKategorija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usluga_kategorija usluga_kategorija = db.usluga_kategorija.Find(id);
            db.usluga_kategorija.Remove(usluga_kategorija);
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
