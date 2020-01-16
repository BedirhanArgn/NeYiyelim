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

namespace Neyiyelim.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> usermanager;


        public AccountController()
        {
            var userstore = new UserStore<ApplicationUser>(new IdentityDataContext());
            usermanager = new UserManager<ApplicationUser>(userstore);
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
        [ValidateAntiForgeryToken]  //Sql açıklarından korunmak için
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
            return RedirectToAction("Login");
                
        }
    }
}
