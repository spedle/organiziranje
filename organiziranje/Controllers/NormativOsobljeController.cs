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
    public class NormativOsobljeController : Controller
    {
        private DbModels db = new DbModels();

        // GET: NormativOsoblje
        public ActionResult Index()
        {
            var normativ_osoblje = db.normativ_osoblje.Include(n => n.osoblje).Include(n => n.usluga);
            return View(normativ_osoblje.ToList());
        }

        // GET: NormativOsoblje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            normativ_osoblje normativ_osoblje = db.normativ_osoblje.Find(id);
            if (normativ_osoblje == null)
            {
                return HttpNotFound();
            }
            return View(normativ_osoblje);
        }

        // GET: NormativOsoblje/Create
        public ActionResult Create()
        {
            ViewBag.osoblje_id = new SelectList(db.osobljes, "id", "ime");
            ViewBag.usluga_id = new SelectList(db.uslugas, "id", "opis");
            return View();
        }

        // POST: NormativOsoblje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,osoblje_id,usluga_id")] normativ_osoblje normativ_osoblje)
        {
            if (ModelState.IsValid)
            {
                db.normativ_osoblje.Add(normativ_osoblje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.osoblje_id = new SelectList(db.osobljes, "id", "ime", normativ_osoblje.osoblje_id);
            ViewBag.usluga_id = new SelectList(db.uslugas, "id", "opis", normativ_osoblje.usluga_id);
            return View(normativ_osoblje);
        }

        // GET: NormativOsoblje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            normativ_osoblje normativ_osoblje = db.normativ_osoblje.Find(id);
            if (normativ_osoblje == null)
            {
                return HttpNotFound();
            }
            ViewBag.osoblje_id = new SelectList(db.osobljes, "id", "ime", normativ_osoblje.osoblje_id);
            ViewBag.usluga_id = new SelectList(db.uslugas, "id", "opis", normativ_osoblje.usluga_id);
            return View(normativ_osoblje);
        }

        // POST: NormativOsoblje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,osoblje_id,usluga_id")] normativ_osoblje normativ_osoblje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(normativ_osoblje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.osoblje_id = new SelectList(db.osobljes, "id", "ime", normativ_osoblje.osoblje_id);
            ViewBag.usluga_id = new SelectList(db.uslugas, "id", "opis", normativ_osoblje.usluga_id);
            return View(normativ_osoblje);
        }

        // GET: NormativOsoblje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            normativ_osoblje normativ_osoblje = db.normativ_osoblje.Find(id);
            if (normativ_osoblje == null)
            {
                return HttpNotFound();
            }
            return View(normativ_osoblje);
        }

        // POST: NormativOsoblje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            normativ_osoblje normativ_osoblje = db.normativ_osoblje.Find(id);
            db.normativ_osoblje.Remove(normativ_osoblje);
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
