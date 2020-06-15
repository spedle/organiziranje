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
    public class ZanimanjeController : Controller
    {
        private DbModels db = new DbModels();

        // GET: Zanimanje
        public ActionResult Index()
        {
            return View(db.zanimanjes.ToList());
        }

        // GET: Zanimanje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zanimanje zanimanje = db.zanimanjes.Find(id);
            if (zanimanje == null)
            {
                return HttpNotFound();
            }
            return View(zanimanje);
        }

        // GET: Zanimanje/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zanimanje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,naziv,opis")] zanimanje zanimanje)
        {
            if (ModelState.IsValid)
            {
                db.zanimanjes.Add(zanimanje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zanimanje);
        }

        // GET: Zanimanje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zanimanje zanimanje = db.zanimanjes.Find(id);
            if (zanimanje == null)
            {
                return HttpNotFound();
            }
            return View(zanimanje);
        }

        // POST: Zanimanje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,naziv,opis")] zanimanje zanimanje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zanimanje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zanimanje);
        }

        // GET: Zanimanje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zanimanje zanimanje = db.zanimanjes.Find(id);
            if (zanimanje == null)
            {
                return HttpNotFound();
            }
            return View(zanimanje);
        }

        // POST: Zanimanje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            zanimanje zanimanje = db.zanimanjes.Find(id);
            db.zanimanjes.Remove(zanimanje);
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
