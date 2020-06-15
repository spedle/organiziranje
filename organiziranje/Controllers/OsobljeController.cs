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
    public class OsobljeController : Controller
    {
        private DbModels db = new DbModels();

        // GET: Osoblje
        public ActionResult Index()
        {
            return View(db.osobljes.ToList());
        }

        // GET: Osoblje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            osoblje osoblje = db.osobljes.Find(id);
            if (osoblje == null)
            {
                return HttpNotFound();
            }
            return View(osoblje);
        }

        // GET: Osoblje/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Osoblje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ime,prezime,datum_rodjenja,zauzet")] osoblje osoblje)
        {
            if (ModelState.IsValid)
            {
                db.osobljes.Add(osoblje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(osoblje);
        }

        // GET: Osoblje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            osoblje osoblje = db.osobljes.Find(id);
            if (osoblje == null)
            {
                return HttpNotFound();
            }
            return View(osoblje);
        }

        // POST: Osoblje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ime,prezime,datum_rodjenja,zauzet")] osoblje osoblje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(osoblje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(osoblje);
        }

        // GET: Osoblje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            osoblje osoblje = db.osobljes.Find(id);
            if (osoblje == null)
            {
                return HttpNotFound();
            }
            return View(osoblje);
        }

        // POST: Osoblje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            osoblje osoblje = db.osobljes.Find(id);
            db.osobljes.Remove(osoblje);
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
