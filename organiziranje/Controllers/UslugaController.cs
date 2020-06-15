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
    public class UslugaController : Controller
    {
        private DbModels db = new DbModels();

        // GET: Usluga
        public ActionResult Index()
        {
            var uslugas = db.uslugas.Include(u => u.usluga_kategorija);
            return View(uslugas.ToList());
        }

        // GET: Usluga/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usluga usluga = db.uslugas.Find(id);
            if (usluga == null)
            {
                return HttpNotFound();
            }
            return View(usluga);
        }

        // GET: Usluga/Create
        public ActionResult Create()
        {
            ViewBag.tip = new SelectList(db.usluga_kategorija, "id", "naziv");
            return View();
        }

        // POST: Usluga/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tip,cijena,opis")] usluga usluga)
        {
            if (ModelState.IsValid)
            {
                db.uslugas.Add(usluga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tip = new SelectList(db.usluga_kategorija, "id", "naziv", usluga.tip);
            return View(usluga);
        }

        // GET: Usluga/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usluga usluga = db.uslugas.Find(id);
            if (usluga == null)
            {
                return HttpNotFound();
            }
            ViewBag.tip = new SelectList(db.usluga_kategorija, "id", "naziv", usluga.tip);
            return View(usluga);
        }

        // POST: Usluga/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tip,cijena,opis")] usluga usluga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usluga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tip = new SelectList(db.usluga_kategorija, "id", "naziv", usluga.tip);
            return View(usluga);
        }

        // GET: Usluga/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usluga usluga = db.uslugas.Find(id);
            if (usluga == null)
            {
                return HttpNotFound();
            }
            return View(usluga);
        }

        // POST: Usluga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usluga usluga = db.uslugas.Find(id);
            db.uslugas.Remove(usluga);
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
