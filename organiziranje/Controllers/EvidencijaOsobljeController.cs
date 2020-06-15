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
    public class EvidencijaOsobljeController : Controller
    {
        private DbModels db = new DbModels();

        // GET: EvidencijaOsoblje
        public ActionResult Index()
        {
            var evidencija_osoblje = db.evidencija_osoblje.Include(e => e.osoblje).Include(e => e.posao);
            return View(evidencija_osoblje.ToList());
        }

        // GET: EvidencijaOsoblje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evidencija_osoblje evidencija_osoblje = db.evidencija_osoblje.Find(id);
            if (evidencija_osoblje == null)
            {
                return HttpNotFound();
            }
            return View(evidencija_osoblje);
        }

        // GET: EvidencijaOsoblje/Create
        public ActionResult Create()
        {
            ViewBag.osoblje_id = new SelectList(db.osobljes, "id", "ime");
            ViewBag.posao_id = new SelectList(db.posaos, "id", "grad");
            return View();
        }

        // POST: EvidencijaOsoblje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,osoblje_id,posao_id,dan,broj_sati")] evidencija_osoblje evidencija_osoblje)
        {
            if (ModelState.IsValid)
            {
                db.evidencija_osoblje.Add(evidencija_osoblje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.osoblje_id = new SelectList(db.osobljes, "id", "ime", evidencija_osoblje.osoblje_id);
            ViewBag.posao_id = new SelectList(db.posaos, "id", "grad", evidencija_osoblje.posao_id);
            return View(evidencija_osoblje);
        }

        // GET: EvidencijaOsoblje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evidencija_osoblje evidencija_osoblje = db.evidencija_osoblje.Find(id);
            if (evidencija_osoblje == null)
            {
                return HttpNotFound();
            }
            ViewBag.osoblje_id = new SelectList(db.osobljes, "id", "ime", evidencija_osoblje.osoblje_id);
            ViewBag.posao_id = new SelectList(db.posaos, "id", "grad", evidencija_osoblje.posao_id);
            return View(evidencija_osoblje);
        }

        // POST: EvidencijaOsoblje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,osoblje_id,posao_id,dan,broj_sati")] evidencija_osoblje evidencija_osoblje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evidencija_osoblje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.osoblje_id = new SelectList(db.osobljes, "id", "ime", evidencija_osoblje.osoblje_id);
            ViewBag.posao_id = new SelectList(db.posaos, "id", "grad", evidencija_osoblje.posao_id);
            return View(evidencija_osoblje);
        }

        // GET: EvidencijaOsoblje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evidencija_osoblje evidencija_osoblje = db.evidencija_osoblje.Find(id);
            if (evidencija_osoblje == null)
            {
                return HttpNotFound();
            }
            return View(evidencija_osoblje);
        }

        // POST: EvidencijaOsoblje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            evidencija_osoblje evidencija_osoblje = db.evidencija_osoblje.Find(id);
            db.evidencija_osoblje.Remove(evidencija_osoblje);
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
