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
    public class PosaoTransakcijaOpremaController : Controller
    {
        private DbModels db = new DbModels();

        // GET: PosaoTransakcijaOprema
        public ActionResult Index()
        {
            var posao_transakcija_oprema = db.posao_transakcija_oprema.Include(p => p.posao).Include(p => p.transakcija_oprema);
            return View(posao_transakcija_oprema.ToList());
        }

        public ActionResult printAll()
        {
            var report = new ActionAsPdf("Index");
            return report;
        }

        // GET: PosaoTransakcijaOprema/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            posao_transakcija_oprema posao_transakcija_oprema = db.posao_transakcija_oprema.Find(id);
            if (posao_transakcija_oprema == null)
            {
                return HttpNotFound();
            }
            return View(posao_transakcija_oprema);
        }

        // GET: PosaoTransakcijaOprema/Create
        public ActionResult Create()
        {
            ViewBag.posao_id = new SelectList(db.posaos, "id", "grad");
            ViewBag.transakcija_oprema_id = new SelectList(db.transakcija_oprema, "id", "id");
            return View();
        }

        // POST: PosaoTransakcijaOprema/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,posao_id,transakcija_oprema_id")] posao_transakcija_oprema posao_transakcija_oprema)
        {
            if (ModelState.IsValid)
            {
                db.posao_transakcija_oprema.Add(posao_transakcija_oprema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.posao_id = new SelectList(db.posaos, "id", "grad", posao_transakcija_oprema.posao_id);
            ViewBag.transakcija_oprema_id = new SelectList(db.transakcija_oprema, "id", "id", posao_transakcija_oprema.transakcija_oprema_id);
            return View(posao_transakcija_oprema);
        }

        // GET: PosaoTransakcijaOprema/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            posao_transakcija_oprema posao_transakcija_oprema = db.posao_transakcija_oprema.Find(id);
            if (posao_transakcija_oprema == null)
            {
                return HttpNotFound();
            }
            ViewBag.posao_id = new SelectList(db.posaos, "id", "grad", posao_transakcija_oprema.posao_id);
            ViewBag.transakcija_oprema_id = new SelectList(db.transakcija_oprema, "id", "id", posao_transakcija_oprema.transakcija_oprema_id);
            return View(posao_transakcija_oprema);
        }

        // POST: PosaoTransakcijaOprema/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,posao_id,transakcija_oprema_id")] posao_transakcija_oprema posao_transakcija_oprema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posao_transakcija_oprema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.posao_id = new SelectList(db.posaos, "id", "grad", posao_transakcija_oprema.posao_id);
            ViewBag.transakcija_oprema_id = new SelectList(db.transakcija_oprema, "id", "id", posao_transakcija_oprema.transakcija_oprema_id);
            return View(posao_transakcija_oprema);
        }

        // GET: PosaoTransakcijaOprema/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            posao_transakcija_oprema posao_transakcija_oprema = db.posao_transakcija_oprema.Find(id);
            if (posao_transakcija_oprema == null)
            {
                return HttpNotFound();
            }
            return View(posao_transakcija_oprema);
        }

        // POST: PosaoTransakcijaOprema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            posao_transakcija_oprema posao_transakcija_oprema = db.posao_transakcija_oprema.Find(id);
            db.posao_transakcija_oprema.Remove(posao_transakcija_oprema);
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
