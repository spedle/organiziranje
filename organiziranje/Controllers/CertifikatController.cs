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
    public class CertifikatController : Controller
    {
        private DbModels db = new DbModels();

        // GET: Certifikat
        public ActionResult Index()
        {
            return View(db.certifikats.ToList());
        }

        // GET: Certifikat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            certifikat certifikat = db.certifikats.Find(id);
            if (certifikat == null)
            {
                return HttpNotFound();
            }
            return View(certifikat);
        }

        // GET: Certifikat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Certifikat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,naziv")] certifikat certifikat)
        {
            if (ModelState.IsValid)
            {
                db.certifikats.Add(certifikat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(certifikat);
        }

        // GET: Certifikat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            certifikat certifikat = db.certifikats.Find(id);
            if (certifikat == null)
            {
                return HttpNotFound();
            }
            return View(certifikat);
        }

        // POST: Certifikat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,naziv")] certifikat certifikat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(certifikat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(certifikat);
        }

        // GET: Certifikat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            certifikat certifikat = db.certifikats.Find(id);
            if (certifikat == null)
            {
                return HttpNotFound();
            }
            return View(certifikat);
        }

        // POST: Certifikat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            certifikat certifikat = db.certifikats.Find(id);
            db.certifikats.Remove(certifikat);
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
