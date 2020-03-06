using STGchannelMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STGchannelMVC.Controllers
{
    [Authorize(Roles = "Admin, SuperAdmin, Logistiikka-asiakas")]
    public class LogistiikkaController : Controller
    { 
       private Test_jvspkkEntities db = new Test_jvspkkEntities();
    
        // GET: Logistiikka
        public ActionResult Index()
        {
            return View(db.q_import_bp);
        }
        public ActionResult AddPO()
        {
            return View(db.q_import_bp);
        }
        public JsonResult InsertPB(List<q_import_bp> insertbps)
        {
            {
                //Loop and insert records.
                foreach (q_import_bp importbp in insertbps)
                {
                    db.q_import_bp.Add(importbp);
                }
                int insertedRecords = db.SaveChanges();
                return Json(insertedRecords);
            }
        }

    }

}