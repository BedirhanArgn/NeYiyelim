using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Neyiyelim.Identity;
using Neyiyelim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Neyiyelim.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> usermanager;
        private RoleManager<IdentityRole> roleManager;

        public AccountController()
        {
            var userstore = new UserStore<ApplicationUser>(new IdentityDataContext());
            usermanager = new UserManager<ApplicationUser>(userstore);
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new IdentityDataContext()));

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]  
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.Email = model.Email;
                user.UserName = model.Username;
                user.PhoneNumber = model.Telefon;

                var result = usermanager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    if (roleManager.RoleExists("User"))
                    {

                        usermanager.AddToRole(user.Id, "User");
                    }
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var user = usermanager.Find(model.Username, model.Password);

                if (user == null)
                {

                    ModelState.AddModelError("", "Yanlış Kullanici adi");
                }
                else
                {

                    if (usermanager.IsInRole(user.Id, "Admin"))
                    {
                        var authmanager = HttpContext.GetOwinContext().Authentication; //Çerez bırakma işlemi için gereklidir.
                        var identity = usermanager.CreateIdentity(user, "ApplicationCookie");

                        var authproperties = new AuthenticationProperties()  //Burada beni hatırla gibi cooki'nin kalıcı olmasını sağlayabilirsiniz.
                        {
                            IsPersistent = false  //beni hatırla kapalı

                        };

                        authmanager.SignOut();
                        authmanager.SignIn(authproperties, identity);
                        return RedirectToAction("Index", "Home");


                    }
                    else
                    {
                        var authmanager = HttpContext.GetOwinContext().Authentication; //Çerez bırakma işlemi için gereklidir.
                        var identity = usermanager.CreateIdentity(user, "ApplicationCookie");

                        var authproperties = new AuthenticationProperties()  //Burada beni hatırla gibi cooki'nin kalıcı olmasını sağlayabilirsiniz.
                        {
                            IsPersistent = false  //beni hatırla kapalı

                        };

                        authmanager.SignOut();
                        authmanager.SignIn(authproperties, identity);

                        return Redirect("/");
                    }
                }
            }
            return RedirectToAction("Login");

        }


        public ActionResult Logout()
        {

            var authmanager = HttpContext.GetOwinContext().Authentication;
            authmanager.SignOut();

            return RedirectToAction("Index", "Home");

        }
    }
}
