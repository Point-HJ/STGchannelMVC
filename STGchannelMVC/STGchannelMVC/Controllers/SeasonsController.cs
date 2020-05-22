using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using STGchannelMVC.Models;

namespace STGchannelMVC.Controllers
{
    [Authorize(Roles = "Admin, SuperAdmin")]

    public class SeasonsController : Controller
    {
        private STGchannelEntities db = new STGchannelEntities();

        // GET: Seasons
        public ActionResult Index()
        {
            return View(db.Seasons.ToList());
        }

        // GET: Seasons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seasons seasons = db.Seasons.Find(id);
            if (seasons == null)
            {
                return HttpNotFound();
            }
            return View(seasons);
        }

        // GET: Seasons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seasons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SeasonID,Season,StartDate,StopDate,Reference")] Seasons seasons)
        {
            if (ModelState.IsValid)
            {
                db.Seasons.Add(seasons);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seasons);
        }

        // GET: Seasons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seasons seasons = db.Seasons.Find(id);
            if (seasons == null)
            {
                return HttpNotFound();
            }
            return View(seasons);
        }

        // POST: Seasons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SeasonID,Season,StartDate,StopDate,Reference")] Seasons seasons)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seasons).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seasons);
        }

        // GET: Seasons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seasons seasons = db.Seasons.Find(id);
            if (seasons == null)
            {
                return HttpNotFound();
            }
            return View(seasons);
        }

        // POST: Seasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seasons seasons = db.Seasons.Find(id);
            db.Seasons.Remove(seasons);
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
