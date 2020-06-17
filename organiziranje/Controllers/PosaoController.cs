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
    public class PosaoController : Controller
    {
        private DbModels db = new DbModels();

        // GET: Posao
        public ActionResult Index()
        {
            return View(db.posaos.ToList());
        }

        // GET: Posao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            posao posao = db.posaos.Find(id);
            if (posao == null)
            {
                return HttpNotFound();
            }
            return View(posao);
        }

        // GET: Posao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,grad,lokacija,sklopljen,zavrsen,trajanje_od,trajanje_do")] posao posao)
        {
            if (ModelState.IsValid)
            {
                if (posao.zavrsen.Length != 1)
                {
                    throw new Exception("Duljina polja završen mora biti točno 1");
                }
                if (posao.sklopljen.Length != 1)
                {
                    throw new Exception("Duljina polja sklopljen mora biti točno 1");
                }
                db.posaos.Add(posao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(posao);
        }

        // GET: Posao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            posao posao = db.posaos.Find(id);
            if (posao == null)
            {
                return HttpNotFound();
            }
            return View(posao);
        }

        // POST: Posao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,grad,lokacija,sklopljen,zavrsen,trajanje_od,trajanje_do")] posao posao)
        {
            if (ModelState.IsValid)
            {
                if (posao.zavrsen.Length != 1)
                {
                    throw new Exception("Duljina polja završen mora biti točno 1");
                }
                if (posao.sklopljen.Length != 1)
                {
                    throw new Exception("Duljina polja sklopljen mora biti točno 1");
                }
                db.Entry(posao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(posao);
        }

        // GET: Posao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            posao posao = db.posaos.Find(id);
            if (posao == null)
            {
                return HttpNotFound();
            }
            return View(posao);
        }

        // POST: Posao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            posao posao = db.posaos.Find(id);
            db.posaos.Remove(posao);
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
