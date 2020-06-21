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
    public class TransakcijaOpremaController : Controller
    {
        private DbModels db = new DbModels();

        // GET: TransakcijaOprema
        public ActionResult Index()
        {
            var transakcija_oprema = db.transakcija_oprema.Include(t => t.oprema);
            return View(transakcija_oprema.ToList());
        }

        // GET: TransakcijaOprema/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transakcija_oprema transakcija_oprema = db.transakcija_oprema.Find(id);
            if (transakcija_oprema == null)
            {
                return HttpNotFound();
            }
            return View(transakcija_oprema);
        }

        // GET: TransakcijaOprema/Create
        public ActionResult Create()
        {
            ViewBag.oprema_id = new SelectList(db.opremas, "id", "naziv");
            return View();
        }

        // POST: TransakcijaOprema/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,datum,prihod,trosak,oprema_id")] transakcija_oprema transakcija_oprema)
        {
            if (ModelState.IsValid)
            {
                oprema oprema = db.opremas.Find(transakcija_oprema.oprema_id);
                transakcija_oprema.oprema_id = (int) oprema.referentni_tip;
                db.transakcija_oprema.Add(transakcija_oprema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.oprema_id = new SelectList(db.opremas, "id", "naziv", transakcija_oprema.oprema_id);
            return View(transakcija_oprema);
        }

        // GET: TransakcijaOprema/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transakcija_oprema transakcija_oprema = db.transakcija_oprema.Find(id);
            if (transakcija_oprema == null)
            {
                return HttpNotFound();
            }
            ViewBag.oprema_id = new SelectList(db.opremas, "id", "naziv", transakcija_oprema.oprema_id);
            return View(transakcija_oprema);
        }

        // POST: TransakcijaOprema/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,datum,prihod,trosak,oprema_id")] transakcija_oprema transakcija_oprema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transakcija_oprema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.oprema_id = new SelectList(db.opremas, "id", "naziv", transakcija_oprema.oprema_id);
            return View(transakcija_oprema);
        }

        // GET: TransakcijaOprema/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transakcija_oprema transakcija_oprema = db.transakcija_oprema.Find(id);
            if (transakcija_oprema == null)
            {
                return HttpNotFound();
            }
            return View(transakcija_oprema);
        }

        // POST: TransakcijaOprema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            transakcija_oprema transakcija_oprema = db.transakcija_oprema.Find(id);
            db.transakcija_oprema.Remove(transakcija_oprema);
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
