using Neyiyelim.ViewModel;
using Neyiyelim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Neyiyelim.Context;

namespace Neyiyelim.Controllers
{
    public class HomeController : Controller
    {
        restorantSehir rc = new restorantSehir();
        RestorantContext context = new RestorantContext(); 
 
        
        public ActionResult Index()
         {
           // var items = context.Receipts.ToList();
         
            return View();
          
        }
        public PartialViewResult ShowMenu()
        {
            rc.restorants = context.Restorants.ToList();
            rc.cities = context.Cities.ToList();
            rc.receipts = context.Receipts.ToList();
            rc.receiptCategories = context.receiptCategories.ToList();
            return PartialView(rc);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}