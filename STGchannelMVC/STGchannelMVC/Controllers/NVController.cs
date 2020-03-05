using STGchannelMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace STGchannelMVC.Controllers
{
    [Authorize(Roles = "Admin, SuperAdmin, Näytevalikoima-asiakas")]
    public class NVController : Controller
    {
        private STGchannelEntities db = new STGchannelEntities();

        // GET: NV
        public ActionResult Index()
        {
           
            return View(db.Selection.ToList());
        }
        public ActionResult IndexSVE()
        {

            return View();
        }
        public ActionResult Info()
        {

            return View();
        }

        public ActionResult Shoppingcart()
        {
            return View();
        }

        public ActionResult History()
        {
            return View();
        }


        // GET: Carts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Cart.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cart cart = db.Cart.Find(id);
            db.Cart.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}