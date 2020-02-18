using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STGchannelMVC.Controllers
{
    [Authorize(Roles = "Admin, SuperAdmin, Näytevalikoima-asiakas")]
    public class NVController : Controller
    {
        // GET: NV
        public ActionResult Index()
        {
            return View();
        }
    }
}