using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Neyiyelim.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Neyiyelim.Controllers
{

    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> usermanager;

      
        public AdminController()
        {
            var userstore = new UserStore<ApplicationUser>(new IdentityDataContext());
            usermanager = new UserManager<ApplicationUser>(userstore);
        }

         [Authorize]  // GET: Admin
        public ActionResult Index()
        {

            return View(usermanager.Users);
        }
    }
}