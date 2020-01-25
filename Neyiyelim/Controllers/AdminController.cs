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
        [Authorize(Roles = "Admin")]
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
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View(new ReceiptCategory());
        }
        [HttpPost] 
        public ActionResult KategoriEkle(ReceiptCategory rc)
        {
            if (ModelState.IsValid)
            {
                ViewBag.control = "control";
                ReceiptCategory rccat = new ReceiptCategory();
                rccat.CategoryName = rc.CategoryName;
                context.receiptCategories.Add(rccat);
                context.SaveChanges();

                return View();

            }
            return View();
       }
        [HttpGet]
        public ActionResult IndexPage()
        {

            return View(new IndexPage());

        }
        [HttpPost]
       public ActionResult IndexPage(IndexPage ip)
       {
            IndexPage indexpage = new IndexPage();
            indexpage.anasayfabaslik = ip.anasayfabaslik;
            indexpage.anasayfaicerik = ip.anasayfaicerik;
            indexpage.anasayfaresimUrl = ip.anasayfaresimUrl;
            indexpage.receipicerik = ip.receipicerik;
            indexpage.receiptbaslik = ip.receiptbaslik;
            indexpage.receiptfoto = ip.receiptfoto;
            indexpage.ReceiptIntegredients = ip.ReceiptIntegredients;
            context.IndexPages.Where(i => i.Id == ip.Id-1);
            context.SaveChanges();
            
            return View();
       }
    }
}