using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Neyiyelim.Context;
using Neyiyelim.Identity;
using Neyiyelim.Models;
using Neyiyelim.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Neyiyelim.Controllers {
    
    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> usermanager;
        private RestorantContext context = new RestorantContext();
        public AdminController()
        {
            var userstore = new UserStore<ApplicationUser>(new IdentityDataContext());
            usermanager = new UserManager<ApplicationUser>(userstore);
            
        }
       
            public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TarifEkle()
        {
            ViewBag.model = context.receiptCategories.ToList();
            return View(new Receipts());
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult TarifEkle(Receipts rc)
        {
            ViewBag.model = context.receiptCategories.ToList();
            Receipts receipts = new Receipts();
            receipts.ReceiptInfo = rc.ReceiptInfo;
            receipts.ReceiptIntegredients = rc.ReceiptIntegredients;
            receipts.ReceiptName = rc.ReceiptName;
            receipts.ReceiptTarih = DateTime.Now;
            receipts.ReceiptUrl = rc.ReceiptUrl;
            receipts.ReceiptCategoryId = rc.ReceiptCategoryId;
            context.Receipts.Add(receipts);
            context.SaveChanges();
            return View();
        }
    }
}