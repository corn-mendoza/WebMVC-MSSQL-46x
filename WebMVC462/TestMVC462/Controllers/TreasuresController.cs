using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestMVC462.Models;
using Workshop.Models;

namespace TestMVC462.Views
{
    public class TreasuresController : Controller
    {
        private TreasureContext db = new TreasureContext();

        // GET: Treasures
        public ActionResult Index()
        {
            return View(db.Treasures.ToList());
        }

        // GET: Treasures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treasure treasure = db.Treasures.Find(id);
            if (treasure == null)
            {
                return HttpNotFound();
            }
            return View(treasure);
        }

        // GET: Treasures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Treasures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Location,PhotoLink,Value,AcquiredDate,PurchaseFrom,PurchasePrice,Longitude,Latitude")] Treasure treasure)
        {
            if (ModelState.IsValid)
            {
                db.Treasures.Add(treasure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(treasure);
        }

        // GET: Treasures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treasure treasure = db.Treasures.Find(id);
            if (treasure == null)
            {
                return HttpNotFound();
            }
            return View(treasure);
        }

        // POST: Treasures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Location,PhotoLink,Value,AcquiredDate,PurchaseFrom,PurchasePrice,Longitude,Latitude")] Treasure treasure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treasure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(treasure);
        }

        // GET: Treasures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treasure treasure = db.Treasures.Find(id);
            if (treasure == null)
            {
                return HttpNotFound();
            }
            return View(treasure);
        }

        // POST: Treasures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Treasure treasure = db.Treasures.Find(id);
            db.Treasures.Remove(treasure);
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
