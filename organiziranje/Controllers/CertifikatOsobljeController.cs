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
    public class CertifikatOsobljeController : Controller
    {
        private DbModels db = new DbModels();

        // GET: CertifikatOsoblje
        public ActionResult Index()
        {
            var certifikat_osoblje = db.certifikat_osoblje.Include(c => c.certifikat).Include(c => c.osoblje);
            return View(certifikat_osoblje.ToList());
        }

        // GET: CertifikatOsoblje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            certifikat_osoblje certifikat_osoblje = db.certifikat_osoblje.Find(id);
            if (certifikat_osoblje == null)
            {
                return HttpNotFound();
            }
            return View(certifikat_osoblje);
        }

        // GET: CertifikatOsoblje/Create
        public ActionResult Create()
        {
            ViewBag.certifikat_id = new SelectList(db.certifikats, "id", "naziv");
            ViewBag.osoblje_id = new SelectList(db.osobljes, "id", "ime");
            return View();
        }

        // POST: CertifikatOsoblje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,certifikat_id,osoblje_id")] certifikat_osoblje certifikat_osoblje)
        {
            if (ModelState.IsValid)
            {
                db.certifikat_osoblje.Add(certifikat_osoblje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.certifikat_id = new SelectList(db.certifikats, "id", "naziv", certifikat_osoblje.certifikat_id);
            ViewBag.osoblje_id = new SelectList(db.osobljes, "id", "ime", certifikat_osoblje.osoblje_id);
            return View(certifikat_osoblje);
        }

        // GET: CertifikatOsoblje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            certifikat_osoblje certifikat_osoblje = db.certifikat_osoblje.Find(id);
            if (certifikat_osoblje == null)
            {
                return HttpNotFound();
            }
            ViewBag.certifikat_id = new SelectList(db.certifikats, "id", "naziv", certifikat_osoblje.certifikat_id);
            ViewBag.osoblje_id = new SelectList(db.osobljes, "id", "ime", certifikat_osoblje.osoblje_id);
            return View(certifikat_osoblje);
        }

        // POST: CertifikatOsoblje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,certifikat_id,osoblje_id")] certifikat_osoblje certifikat_osoblje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(certifikat_osoblje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.certifikat_id = new SelectList(db.certifikats, "id", "naziv", certifikat_osoblje.certifikat_id);
            ViewBag.osoblje_id = new SelectList(db.osobljes, "id", "ime", certifikat_osoblje.osoblje_id);
            return View(certifikat_osoblje);
        }

        // GET: CertifikatOsoblje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            certifikat_osoblje certifikat_osoblje = db.certifikat_osoblje.Find(id);
            if (certifikat_osoblje == null)
            {
                return HttpNotFound();
            }
            return View(certifikat_osoblje);
        }

        // POST: CertifikatOsoblje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            certifikat_osoblje certifikat_osoblje = db.certifikat_osoblje.Find(id);
            db.certifikat_osoblje.Remove(certifikat_osoblje);
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
