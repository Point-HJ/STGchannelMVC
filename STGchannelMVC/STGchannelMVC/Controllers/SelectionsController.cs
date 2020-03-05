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
    public class SelectionsController : Controller
    {
        private STGchannelEntities db = new STGchannelEntities();

        // GET: Selections
        public ActionResult Index()
        {
            
            return View(db.Selection.ToList());
        }
       
        // GET: Selections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Selection selection = db.Selection.Find(id);
            if (selection == null)
            {
                return HttpNotFound();
            }
            return View(selection);
        }

        // GET: Selections/Create
        public ActionResult Create()
        {
            ViewBag.Language = db.Language.Select(l => new SelectListItem { Value = l.Language1, Text = l.Language1 }).ToList();
            ViewBag.Season = db.Seasons.Select(s => new SelectListItem { Value = s.Season, Text = s.Season }).ToList();
            
            return View("Create");
        }

        // POST: Selections/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin, SuperAdmin")]
        public ActionResult Create([Bind(Include = "BookID,ISBN,Author,BookName,Publisher,Price,Season,Language")] Selection selection)
        {
            if (ModelState.IsValid)
            {
                db.Selection.Add(selection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(selection);
        }


        // GET: Selections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Selection selection = db.Selection.Find(id);
            if (selection == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageList = new SelectList(db.Language.ToList(), "Language1", "Language1");
            ViewBag.SeasonList = new SelectList(db.Seasons.ToList(), "Season", "Season");


            return View(selection);
        }

        // POST: Selections/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult Edit([Bind(Include = "BookID,ISBN,Author,BookName,Publisher,Price,Season,Language")] Selection selection)
        {
                     
            if (ModelState.IsValid)
            {
                db.Entry(selection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(selection);
        }

        // GET: Selections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Selection selection = db.Selection.Find(id);
            if (selection == null)
            {
                return HttpNotFound();
            }
            return View(selection);
        }

        // POST: Selections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Selection selection = db.Selection.Find(id);
            db.Selection.Remove(selection);
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
