using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STGchannelMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            if (User.IsInRole("Näytevalikoima-asiakas"))
            {
                return View("NV/Index.cshtml");
            }
            if (User.IsInRole("Logistiikka-asiakas"))
            {
                return View("Logistiikka/Index");
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Yhteystiedot";

            return View();
        }
    }
}