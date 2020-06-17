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
    public class EvidencijaOpremaController : Controller
    {
        private DbModels db = new DbModels();

        // GET: EvidencijaOprema
        public ActionResult Index()
        {
            var evidencija_oprema = db.evidencija_oprema.Include(e => e.oprema).Include(e => e.posao);
            return View(evidencija_oprema.ToList());
        }

        public ActionResult printAll()
        {
            var report = new ActionAsPdf("Index");
            return report;
        }

        // GET: EvidencijaOprema/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evidencija_oprema evidencija_oprema = db.evidencija_oprema.Find(id);
            if (evidencija_oprema == null)
            {
                return HttpNotFound();
            }
            return View(evidencija_oprema);
        }

        // GET: EvidencijaOprema/Create
        public ActionResult Create()
        {
            ViewBag.oprema_id = new SelectList(db.opremas, "id", "naziv");
            ViewBag.posao_id = new SelectList(db.posaos, "id", "grad");
            return View();
        }

        // POST: EvidencijaOprema/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,oprema_id,posao_id,dan,broj_sati")] evidencija_oprema evidencija_oprema)
        {
            if (ModelState.IsValid)
            {
                db.evidencija_oprema.Add(evidencija_oprema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.oprema_id = new SelectList(db.opremas, "id", "naziv", evidencija_oprema.oprema_id);
            ViewBag.posao_id = new SelectList(db.posaos, "id", "grad", evidencija_oprema.posao_id);
            return View(evidencija_oprema);
        }

        // GET: EvidencijaOprema/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evidencija_oprema evidencija_oprema = db.evidencija_oprema.Find(id);
            if (evidencija_oprema == null)
            {
                return HttpNotFound();
            }
            ViewBag.oprema_id = new SelectList(db.opremas, "id", "naziv", evidencija_oprema.oprema_id);
            ViewBag.posao_id = new SelectList(db.posaos, "id", "grad", evidencija_oprema.posao_id);
            return View(evidencija_oprema);
        }

        // POST: EvidencijaOprema/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,oprema_id,posao_id,dan,broj_sati")] evidencija_oprema evidencija_oprema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evidencija_oprema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.oprema_id = new SelectList(db.opremas, "id", "naziv", evidencija_oprema.oprema_id);
            ViewBag.posao_id = new SelectList(db.posaos, "id", "grad", evidencija_oprema.posao_id);
            return View(evidencija_oprema);
        }

        // GET: EvidencijaOprema/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evidencija_oprema evidencija_oprema = db.evidencija_oprema.Find(id);
            if (evidencija_oprema == null)
            {
                return HttpNotFound();
            }
            return View(evidencija_oprema);
        }

        // POST: EvidencijaOprema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            evidencija_oprema evidencija_oprema = db.evidencija_oprema.Find(id);
            db.evidencija_oprema.Remove(evidencija_oprema);
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
