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
        // GET: Logistiikka
        public ActionResult Index()
        {
            return View();
        }
    }
}