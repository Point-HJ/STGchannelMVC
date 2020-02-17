using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using STGchannelMVC.Models;


namespace STGchannelMVC.Controllers
{
    [Authorize(Roles ="SuperAdmin, Admin")]
    public class AdminController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AdminController()
        {
        }

        public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateUser()
        {
            ViewBag.Roles = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
            return View("CreateUser");
        }
        [HttpPost]
        public ActionResult CreateUser(FormCollection form)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            string CompanyID = form["CompanyID"];
            string CompanyName = form["CompanyName"];
            string Email = form["Email"];
            string password = form["Password"];
            string rolname = form["RoleName"];
            var user = new ApplicationUser();
            user.UserName = CompanyID;
            user.Email = Email;
            user.Password = password;
            user.CompanyName = CompanyName;

            var newuser = userManager.Create(user, password);

            if (newuser.Succeeded)
            {
                UserManager.AddToRole(user.Id, rolname);
            }
            return RedirectToAction("CreateUser");
        }
       
        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewRole(FormCollection form)
        {
            string rolename = form["RoleName"];
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists(rolename))
            {
                var role = new IdentityRole(rolename);
                roleManager.Create(role);

            }
            return View("Index");
        }

        public ActionResult AssignRole()
        {
            ViewBag.Roles = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AssignRole(FormCollection form)
        {
            string usrname = form["txtUserName"];
            string rolname = form["RoleName"];
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(usrname, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            UserManager.AddToRole(user.Id, rolname);
            return View("Index");
        }



        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

    }
}