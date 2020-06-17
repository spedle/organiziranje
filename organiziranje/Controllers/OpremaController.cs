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
    public class OpremaController : Controller
    {
        private DbModels db = new DbModels();

        // GET: Oprema
        public ActionResult Index()
        {
            var opremas = db.opremas.Include(o => o.oprema2);
            return View(opremas.ToList());
        }

        // GET: Oprema/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oprema oprema = db.opremas.Find(id);
            if (oprema == null)
            {
                return HttpNotFound();
            }
            return View(oprema);
        }

        // GET: Oprema/Create
        public ActionResult Create()
        {
            ViewBag.referentni_tip = new SelectList(db.opremas, "id", "naziv");
            return View();
        }

        // POST: Oprema/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,naziv,inventarni_broj,kupljena_vrijednost,knjigovodstvena_vrijednost,tip,dostupna,broj_radnih_sati,referentni_tip")] oprema oprema)
        {
            if (ModelState.IsValid)
            {
                db.opremas.Add(oprema);
                db.SaveChanges();
                if (oprema.referentni_tip == null)
                {
                    oprema.referentni_tip = oprema.id;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.referentni_tip = new SelectList(db.opremas, "id", "naziv", oprema.referentni_tip);
            return View(oprema);
        }

        // GET: Oprema/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oprema oprema = db.opremas.Find(id);
            if (oprema == null)
            {
                return HttpNotFound();
            }
            ViewBag.referentni_tip = new SelectList(db.opremas, "id", "naziv", oprema.referentni_tip);
            return View(oprema);
        }

        // POST: Oprema/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,naziv,inventarni_broj,kupljena_vrijednost,knjigovodstvena_vrijednost,tip,dostupna,broj_radnih_sati,referentni_tip")] oprema oprema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oprema).State = EntityState.Modified;
                db.SaveChanges();
                if (oprema.referentni_tip == null)
                {
                    oprema.referentni_tip = oprema.id;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.referentni_tip = new SelectList(db.opremas, "id", "naziv", oprema.referentni_tip);
            return View(oprema);
        }

        // GET: Oprema/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oprema oprema = db.opremas.Find(id);
            if (oprema == null)
            {
                return HttpNotFound();
            }
            return View(oprema);
        }

        // POST: Oprema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            oprema oprema = db.opremas.Find(id);
            db.opremas.Remove(oprema);
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
