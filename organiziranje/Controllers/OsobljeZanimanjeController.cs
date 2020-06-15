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
    public class OsobljeZanimanjeController : Controller
    {
        private DbModels db = new DbModels();

        // GET: OsobljeZanimanje
        public ActionResult Index()
        {
            var osoblje_zanimanje = db.osoblje_zanimanje.Include(o => o.osoblje).Include(o => o.zanimanje);
            return View(osoblje_zanimanje.ToList());
        }

        // GET: OsobljeZanimanje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            osoblje_zanimanje osoblje_zanimanje = db.osoblje_zanimanje.Find(id);
            if (osoblje_zanimanje == null)
            {
                return HttpNotFound();
            }
            return View(osoblje_zanimanje);
        }

        // GET: OsobljeZanimanje/Create
        public ActionResult Create()
        {
            ViewBag.osoblje_id = new SelectList(db.osobljes, "id", "ime");
            ViewBag.zanimanje_id = new SelectList(db.zanimanjes, "id", "naziv");
            return View();
        }

        // POST: OsobljeZanimanje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,osoblje_id,zanimanje_id")] osoblje_zanimanje osoblje_zanimanje)
        {
            if (ModelState.IsValid)
            {
                db.osoblje_zanimanje.Add(osoblje_zanimanje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.osoblje_id = new SelectList(db.osobljes, "id", "ime", osoblje_zanimanje.osoblje_id);
            ViewBag.zanimanje_id = new SelectList(db.zanimanjes, "id", "naziv", osoblje_zanimanje.zanimanje_id);
            return View(osoblje_zanimanje);
        }

        // GET: OsobljeZanimanje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            osoblje_zanimanje osoblje_zanimanje = db.osoblje_zanimanje.Find(id);
            if (osoblje_zanimanje == null)
            {
                return HttpNotFound();
            }
            ViewBag.osoblje_id = new SelectList(db.osobljes, "id", "ime", osoblje_zanimanje.osoblje_id);
            ViewBag.zanimanje_id = new SelectList(db.zanimanjes, "id", "naziv", osoblje_zanimanje.zanimanje_id);
            return View(osoblje_zanimanje);
        }

        // POST: OsobljeZanimanje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,osoblje_id,zanimanje_id")] osoblje_zanimanje osoblje_zanimanje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(osoblje_zanimanje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.osoblje_id = new SelectList(db.osobljes, "id", "ime", osoblje_zanimanje.osoblje_id);
            ViewBag.zanimanje_id = new SelectList(db.zanimanjes, "id", "naziv", osoblje_zanimanje.zanimanje_id);
            return View(osoblje_zanimanje);
        }

        // GET: OsobljeZanimanje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            osoblje_zanimanje osoblje_zanimanje = db.osoblje_zanimanje.Find(id);
            if (osoblje_zanimanje == null)
            {
                return HttpNotFound();
            }
            return View(osoblje_zanimanje);
        }

        // POST: OsobljeZanimanje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            osoblje_zanimanje osoblje_zanimanje = db.osoblje_zanimanje.Find(id);
            db.osoblje_zanimanje.Remove(osoblje_zanimanje);
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
