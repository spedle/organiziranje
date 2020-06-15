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
    public class SkladisteController : Controller
    {
        private DbModels db = new DbModels();

        // GET: Skladiste
        public ActionResult Index()
        {
            return View(db.skladistes.ToList());
        }

        // GET: Skladiste/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skladiste skladiste = db.skladistes.Find(id);
            if (skladiste == null)
            {
                return HttpNotFound();
            }
            return View(skladiste);
        }

        // GET: Skladiste/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skladiste/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,naziv,adresa")] skladiste skladiste)
        {
            if (ModelState.IsValid)
            {
                db.skladistes.Add(skladiste);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skladiste);
        }

        // GET: Skladiste/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skladiste skladiste = db.skladistes.Find(id);
            if (skladiste == null)
            {
                return HttpNotFound();
            }
            return View(skladiste);
        }

        // POST: Skladiste/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,naziv,adresa")] skladiste skladiste)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skladiste).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skladiste);
        }

        // GET: Skladiste/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skladiste skladiste = db.skladistes.Find(id);
            if (skladiste == null)
            {
                return HttpNotFound();
            }
            return View(skladiste);
        }

        // POST: Skladiste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            skladiste skladiste = db.skladistes.Find(id);
            db.skladistes.Remove(skladiste);
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
