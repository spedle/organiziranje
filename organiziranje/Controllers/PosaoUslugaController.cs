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
    public class PosaoUslugaController : Controller
    {
        private DbModels db = new DbModels();

        // GET: PosaoUsluga
        public ActionResult Index()
        {
            var posao_usluga = db.posao_usluga.Include(p => p.posao).Include(p => p.usluga);
            return View(posao_usluga.ToList());
        }

        // GET: PosaoUsluga/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            posao_usluga posao_usluga = db.posao_usluga.Find(id);
            if (posao_usluga == null)
            {
                return HttpNotFound();
            }
            return View(posao_usluga);
        }

        // GET: PosaoUsluga/Create
        public ActionResult Create()
        {
            ViewBag.posao_id = new SelectList(db.posaos, "id", "grad");
            ViewBag.usluga_id = new SelectList(db.uslugas, "id", "opis");
            return View();
        }

        // POST: PosaoUsluga/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,posao_id,usluga_id")] posao_usluga posao_usluga)
        {   
            if (ModelState.IsValid)
            {
                posao posao = db.posaos.Where(p => p.id == posao_usluga.posao_id).First();

                if(posao.sklopljen == "D" && posao.zavrsen == "N")
                {
                    this.occupy(posao_usluga.usluga_id);
                }
                db.posao_usluga.Add(posao_usluga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.posao_id = new SelectList(db.posaos, "id", "grad", posao_usluga.posao_id);
            ViewBag.usluga_id = new SelectList(db.uslugas, "id", "opis", posao_usluga.usluga_id);
            return View(posao_usluga);
        }

        // GET: PosaoUsluga/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            posao_usluga posao_usluga = db.posao_usluga.Find(id);
            if (posao_usluga == null)
            {
                return HttpNotFound();
            }
            ViewBag.posao_id = new SelectList(db.posaos, "id", "grad", posao_usluga.posao_id);
            ViewBag.usluga_id = new SelectList(db.uslugas, "id", "opis", posao_usluga.usluga_id);
            return View(posao_usluga);
        }

        // POST: PosaoUsluga/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,posao_id,usluga_id")] posao_usluga posao_usluga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posao_usluga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.posao_id = new SelectList(db.posaos, "id", "grad", posao_usluga.posao_id);
            ViewBag.usluga_id = new SelectList(db.uslugas, "id", "opis", posao_usluga.usluga_id);
            return View(posao_usluga);
        }

        // GET: PosaoUsluga/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            posao_usluga posao_usluga = db.posao_usluga.Find(id);
            if (posao_usluga == null)
            {
                return HttpNotFound();
            }
            return View(posao_usluga);
        }

        // POST: PosaoUsluga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            posao_usluga posao_usluga = db.posao_usluga.Find(id);
            db.posao_usluga.Remove(posao_usluga);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public void occupy(int usluga_id)
        {
            IList<normativ_oprema> normativOpremas = db.normativ_oprema.Where(no => no.usluga_id == usluga_id).ToList();
            IList<normativ_osoblje> normativOsobljes = db.normativ_osoblje.Where(no => no.usluga_id == usluga_id).ToList();

            foreach (normativ_oprema normativOprema in normativOpremas)
            {
                IList<oprema> opremas = db.opremas.Where(o => o.tip == normativOprema.oprema.tip).Where(o => o.dostupna == "D").ToList();
                oprema oprema = opremas.First();
                oprema.dostupna = "N";

                db.Entry(oprema).State = EntityState.Modified;
                db.SaveChanges();
            }

            foreach (normativ_osoblje normativOsoblje in normativOsobljes)
            {
                osoblje osoblje = normativOsoblje.osoblje;
                osoblje.zauzet = "D";

                db.Entry(osoblje).State = EntityState.Modified;
                db.SaveChanges();
            }
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
