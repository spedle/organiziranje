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
    public class NatjecajPonudaController : Controller
    {
        private DbModels db = new DbModels();

        // GET: NatjecajPonuda
        public ActionResult Index()
        {
            var natjecaj_ponuda = db.natjecaj_ponuda.Include(n => n.natjecaj);
            return View(natjecaj_ponuda.ToList());
        }

        // GET: NatjecajPonuda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            natjecaj_ponuda natjecaj_ponuda = db.natjecaj_ponuda.Find(id);
            if (natjecaj_ponuda == null)
            {
                return HttpNotFound();
            }
            return View(natjecaj_ponuda);
        }

        // GET: NatjecajPonuda/Create
        public ActionResult Create()
        {
            ViewBag.natjecaj_id = new SelectList(db.natjecajs, "id", "raspisala_osoba");
            return View();
        }

        // POST: NatjecajPonuda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,broj_osoblja,iznos,natjecaj_id,dobitna_ponuda")] natjecaj_ponuda natjecaj_ponuda)
        {
            if (ModelState.IsValid)
            {
                db.natjecaj_ponuda.Add(natjecaj_ponuda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.natjecaj_id = new SelectList(db.natjecajs, "id", "raspisala_osoba", natjecaj_ponuda.natjecaj_id);
            return View(natjecaj_ponuda);
        }

        // GET: NatjecajPonuda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            natjecaj_ponuda natjecaj_ponuda = db.natjecaj_ponuda.Find(id);
            if (natjecaj_ponuda == null)
            {
                return HttpNotFound();
            }
            ViewBag.natjecaj_id = new SelectList(db.natjecajs, "id", "raspisala_osoba", natjecaj_ponuda.natjecaj_id);
            return View(natjecaj_ponuda);
        }

        // POST: NatjecajPonuda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,broj_osoblja,iznos,natjecaj_id,dobitna_ponuda")] natjecaj_ponuda natjecaj_ponuda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(natjecaj_ponuda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.natjecaj_id = new SelectList(db.natjecajs, "id", "raspisala_osoba", natjecaj_ponuda.natjecaj_id);
            return View(natjecaj_ponuda);
        }

        // GET: NatjecajPonuda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            natjecaj_ponuda natjecaj_ponuda = db.natjecaj_ponuda.Find(id);
            if (natjecaj_ponuda == null)
            {
                return HttpNotFound();
            }
            return View(natjecaj_ponuda);
        }

        // POST: NatjecajPonuda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            natjecaj_ponuda natjecaj_ponuda = db.natjecaj_ponuda.Find(id);
            db.natjecaj_ponuda.Remove(natjecaj_ponuda);
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
