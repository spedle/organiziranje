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
    public class TransakcijaOsobljeController : Controller
    {
        private DbModels db = new DbModels();

        // GET: TransakcijaOsoblje
        public ActionResult Index()
        {
            var transakcija_osoblje = db.transakcija_osoblje.Include(t => t.osoblje);
            return View(transakcija_osoblje.ToList());
        }

        // GET: TransakcijaOsoblje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transakcija_osoblje transakcija_osoblje = db.transakcija_osoblje.Find(id);
            if (transakcija_osoblje == null)
            {
                return HttpNotFound();
            }
            return View(transakcija_osoblje);
        }

        // GET: TransakcijaOsoblje/Create
        public ActionResult Create()
        {
            ViewBag.osoblje_id = new SelectList(db.osobljes, "id", "ime");
            return View();
        }

        // POST: TransakcijaOsoblje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,datum,prihod,trosak,osoblje_id")] transakcija_osoblje transakcija_osoblje)
        {
            if (ModelState.IsValid)
            {
                db.transakcija_osoblje.Add(transakcija_osoblje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.osoblje_id = new SelectList(db.osobljes, "id", "ime", transakcija_osoblje.osoblje_id);
            return View(transakcija_osoblje);
        }

        // GET: TransakcijaOsoblje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transakcija_osoblje transakcija_osoblje = db.transakcija_osoblje.Find(id);
            if (transakcija_osoblje == null)
            {
                return HttpNotFound();
            }
            ViewBag.osoblje_id = new SelectList(db.osobljes, "id", "ime", transakcija_osoblje.osoblje_id);
            return View(transakcija_osoblje);
        }

        // POST: TransakcijaOsoblje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,datum,prihod,trosak,osoblje_id")] transakcija_osoblje transakcija_osoblje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transakcija_osoblje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.osoblje_id = new SelectList(db.osobljes, "id", "ime", transakcija_osoblje.osoblje_id);
            return View(transakcija_osoblje);
        }

        // GET: TransakcijaOsoblje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transakcija_osoblje transakcija_osoblje = db.transakcija_osoblje.Find(id);
            if (transakcija_osoblje == null)
            {
                return HttpNotFound();
            }
            return View(transakcija_osoblje);
        }

        // POST: TransakcijaOsoblje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            transakcija_osoblje transakcija_osoblje = db.transakcija_osoblje.Find(id);
            db.transakcija_osoblje.Remove(transakcija_osoblje);
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
