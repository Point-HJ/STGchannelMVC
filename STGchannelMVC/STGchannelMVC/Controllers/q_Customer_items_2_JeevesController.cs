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
    public class q_Customer_items_2_JeevesController : Controller
    {
        private ProductEntities db = new ProductEntities();

        // GET: q_Customer_items_2_Jeeves
        public ActionResult Index()
        {
            return View(db.q_Customer_items_2_Jeeves.ToList());
        }

        // GET: q_Customer_items_2_Jeeves/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            q_Customer_items_2_Jeeves q_Customer_items_2_Jeeves = db.q_Customer_items_2_Jeeves.Find(id);
            if (q_Customer_items_2_Jeeves == null)
            {
                return HttpNotFound();
            }
            return View(q_Customer_items_2_Jeeves);
        }

        // GET: q_Customer_items_2_Jeeves/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: q_Customer_items_2_Jeeves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "foretagkod,lagstalle,q_profit_center,q_material_group,q_isbn_no,artnr,artbeskr,q_itemtypecd1,q_artkat,artlistpris,momskod,itemstatuscode,q_sap_item_no,artstatnr,UpdateStatusDescr,itemtypecd2,q_wsoy_libraryclass,varugruppkod,q_fetched_by_inobiz,ar_q_edition_counter,artkalkber,artkalkpris,q_publisher_itemid,artvikt,q_publ_date,q_artbeskr_kiva,q_planned_arrival_date,q_pl_garr_date,ArtBeskrSpec,q_author,q_edt,q_aof,q_au,q_des,q_eic,q_ill,q_ot,q_pho,q_pre,q_rea,q_tra,itemtypecd3,q_print_year,q_size,q_original_title,q_series,q_series_id,q_series_partno,q_total_no_part_series,itemtypecd4,q_language,webpublish")] q_Customer_items_2_Jeeves q_Customer_items_2_Jeeves)
        {
            if (ModelState.IsValid)
            {
                db.q_Customer_items_2_Jeeves.Add(q_Customer_items_2_Jeeves);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(q_Customer_items_2_Jeeves);
        }

        // GET: q_Customer_items_2_Jeeves/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            q_Customer_items_2_Jeeves q_Customer_items_2_Jeeves = db.q_Customer_items_2_Jeeves.Find(id);
            if (q_Customer_items_2_Jeeves == null)
            {
                return HttpNotFound();
            }
            return View(q_Customer_items_2_Jeeves);
        }

        // POST: q_Customer_items_2_Jeeves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "foretagkod,lagstalle,q_profit_center,q_material_group,q_isbn_no,artnr,artbeskr,q_itemtypecd1,q_artkat,artlistpris,momskod,itemstatuscode,q_sap_item_no,artstatnr,UpdateStatusDescr,itemtypecd2,q_wsoy_libraryclass,varugruppkod,q_fetched_by_inobiz,ar_q_edition_counter,artkalkber,artkalkpris,q_publisher_itemid,artvikt,q_publ_date,q_artbeskr_kiva,q_planned_arrival_date,q_pl_garr_date,ArtBeskrSpec,q_author,q_edt,q_aof,q_au,q_des,q_eic,q_ill,q_ot,q_pho,q_pre,q_rea,q_tra,itemtypecd3,q_print_year,q_size,q_original_title,q_series,q_series_id,q_series_partno,q_total_no_part_series,itemtypecd4,q_language,webpublish")] q_Customer_items_2_Jeeves q_Customer_items_2_Jeeves)
        {
            if (ModelState.IsValid)
            {
                db.Entry(q_Customer_items_2_Jeeves).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(q_Customer_items_2_Jeeves);
        }

        // GET: q_Customer_items_2_Jeeves/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            q_Customer_items_2_Jeeves q_Customer_items_2_Jeeves = db.q_Customer_items_2_Jeeves.Find(id);
            if (q_Customer_items_2_Jeeves == null)
            {
                return HttpNotFound();
            }
            return View(q_Customer_items_2_Jeeves);
        }

        // POST: q_Customer_items_2_Jeeves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            q_Customer_items_2_Jeeves q_Customer_items_2_Jeeves = db.q_Customer_items_2_Jeeves.Find(id);
            db.q_Customer_items_2_Jeeves.Remove(q_Customer_items_2_Jeeves);
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
