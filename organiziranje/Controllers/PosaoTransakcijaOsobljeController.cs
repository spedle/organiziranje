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
    public class PosaoTransakcijaOsobljeController : Controller
    {
        private DbModels db = new DbModels();

        // GET: PosaoTransakcijaOsoblje
        public ActionResult Index()
        {
            var posao_transakcija_osoblje = db.posao_transakcija_osoblje.Include(p => p.posao).Include(p => p.transakcija_osoblje);
            return View(posao_transakcija_osoblje.ToList());
        }

        public ActionResult printAll()
        {
            var report = new ActionAsPdf("Index");
            return report;
        }
        // GET: PosaoTransakcijaOsoblje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            posao_transakcija_osoblje posao_transakcija_osoblje = db.posao_transakcija_osoblje.Find(id);
            if (posao_transakcija_osoblje == null)
            {
                return HttpNotFound();
            }
            return View(posao_transakcija_osoblje);
        }

        // GET: PosaoTransakcijaOsoblje/Create
        public ActionResult Create()
        {
            ViewBag.posao_id = new SelectList(db.posaos, "id", "grad");
            ViewBag.transakcija_osoblje_id = new SelectList(db.transakcija_osoblje, "id", "id");
            return View();
        }

        // POST: PosaoTransakcijaOsoblje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,posao_id,transakcija_osoblje_id")] posao_transakcija_osoblje posao_transakcija_osoblje)
        {
            if (ModelState.IsValid)
            {
                db.posao_transakcija_osoblje.Add(posao_transakcija_osoblje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.posao_id = new SelectList(db.posaos, "id", "grad", posao_transakcija_osoblje.posao_id);
            ViewBag.transakcija_osoblje_id = new SelectList(db.transakcija_osoblje, "id", "id", posao_transakcija_osoblje.transakcija_osoblje_id);
            return View(posao_transakcija_osoblje);
        }

        // GET: PosaoTransakcijaOsoblje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            posao_transakcija_osoblje posao_transakcija_osoblje = db.posao_transakcija_osoblje.Find(id);
            if (posao_transakcija_osoblje == null)
            {
                return HttpNotFound();
            }
            ViewBag.posao_id = new SelectList(db.posaos, "id", "grad", posao_transakcija_osoblje.posao_id);
            ViewBag.transakcija_osoblje_id = new SelectList(db.transakcija_osoblje, "id", "id", posao_transakcija_osoblje.transakcija_osoblje_id);
            return View(posao_transakcija_osoblje);
        }

        // POST: PosaoTransakcijaOsoblje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,posao_id,transakcija_osoblje_id")] posao_transakcija_osoblje posao_transakcija_osoblje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posao_transakcija_osoblje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.posao_id = new SelectList(db.posaos, "id", "grad", posao_transakcija_osoblje.posao_id);
            ViewBag.transakcija_osoblje_id = new SelectList(db.transakcija_osoblje, "id", "id", posao_transakcija_osoblje.transakcija_osoblje_id);
            return View(posao_transakcija_osoblje);
        }

        // GET: PosaoTransakcijaOsoblje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            posao_transakcija_osoblje posao_transakcija_osoblje = db.posao_transakcija_osoblje.Find(id);
            if (posao_transakcija_osoblje == null)
            {
                return HttpNotFound();
            }
            return View(posao_transakcija_osoblje);
        }

        // POST: PosaoTransakcijaOsoblje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            posao_transakcija_osoblje posao_transakcija_osoblje = db.posao_transakcija_osoblje.Find(id);
            db.posao_transakcija_osoblje.Remove(posao_transakcija_osoblje);
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
