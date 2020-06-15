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
    public class SkladisteOpremaController : Controller
    {
        private DbModels db = new DbModels();

        // GET: SkladisteOprema
        public ActionResult Index()
        {
            var skladiste_opreme = db.skladiste_opreme.Include(s => s.oprema).Include(s => s.skladiste);
            return View(skladiste_opreme.ToList());
        }

        // GET: SkladisteOprema/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skladiste_opreme skladiste_opreme = db.skladiste_opreme.Find(id);
            if (skladiste_opreme == null)
            {
                return HttpNotFound();
            }
            return View(skladiste_opreme);
        }

        // GET: SkladisteOprema/Create
        public ActionResult Create()
        {
            ViewBag.oprema_id = new SelectList(db.opremas, "id", "naziv");
            ViewBag.skladiste_id = new SelectList(db.skladistes, "id", "naziv");
            return View();
        }

        // POST: SkladisteOprema/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,skladiste_id,oprema_id,broj_na_polici,polica,stalak")] skladiste_opreme skladiste_opreme)
        {
            if (ModelState.IsValid)
            {
                db.skladiste_opreme.Add(skladiste_opreme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.oprema_id = new SelectList(db.opremas, "id", "naziv", skladiste_opreme.oprema_id);
            ViewBag.skladiste_id = new SelectList(db.skladistes, "id", "naziv", skladiste_opreme.skladiste_id);
            return View(skladiste_opreme);
        }

        // GET: SkladisteOprema/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skladiste_opreme skladiste_opreme = db.skladiste_opreme.Find(id);
            if (skladiste_opreme == null)
            {
                return HttpNotFound();
            }
            ViewBag.oprema_id = new SelectList(db.opremas, "id", "naziv", skladiste_opreme.oprema_id);
            ViewBag.skladiste_id = new SelectList(db.skladistes, "id", "naziv", skladiste_opreme.skladiste_id);
            return View(skladiste_opreme);
        }

        // POST: SkladisteOprema/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,skladiste_id,oprema_id,broj_na_polici,polica,stalak")] skladiste_opreme skladiste_opreme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skladiste_opreme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.oprema_id = new SelectList(db.opremas, "id", "naziv", skladiste_opreme.oprema_id);
            ViewBag.skladiste_id = new SelectList(db.skladistes, "id", "naziv", skladiste_opreme.skladiste_id);
            return View(skladiste_opreme);
        }

        // GET: SkladisteOprema/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skladiste_opreme skladiste_opreme = db.skladiste_opreme.Find(id);
            if (skladiste_opreme == null)
            {
                return HttpNotFound();
            }
            return View(skladiste_opreme);
        }

        // POST: SkladisteOprema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            skladiste_opreme skladiste_opreme = db.skladiste_opreme.Find(id);
            db.skladiste_opreme.Remove(skladiste_opreme);
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
