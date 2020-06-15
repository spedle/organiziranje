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
    public class NatjecajController : Controller
    {
        private DbModels db = new DbModels();

        // GET: Natjecaj
        public ActionResult Index()
        {
            return View(db.natjecajs.ToList());
        }

        // GET: Natjecaj/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            natjecaj natjecaj = db.natjecajs.Find(id);
            if (natjecaj == null)
            {
                return HttpNotFound();
            }
            return View(natjecaj);
        }

        // GET: Natjecaj/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Natjecaj/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,raspisala_osoba,opis,iznos,datum_od,datum_do,pobjednik,prihvacen_iznos")] natjecaj natjecaj)
        {
            if (ModelState.IsValid)
            {
                db.natjecajs.Add(natjecaj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(natjecaj);
        }

        // GET: Natjecaj/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            natjecaj natjecaj = db.natjecajs.Find(id);
            if (natjecaj == null)
            {
                return HttpNotFound();
            }
            return View(natjecaj);
        }

        // POST: Natjecaj/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,raspisala_osoba,opis,iznos,datum_od,datum_do,pobjednik,prihvacen_iznos")] natjecaj natjecaj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(natjecaj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(natjecaj);
        }

        // GET: Natjecaj/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            natjecaj natjecaj = db.natjecajs.Find(id);
            if (natjecaj == null)
            {
                return HttpNotFound();
            }
            return View(natjecaj);
        }

        // POST: Natjecaj/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            natjecaj natjecaj = db.natjecajs.Find(id);
            db.natjecajs.Remove(natjecaj);
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
