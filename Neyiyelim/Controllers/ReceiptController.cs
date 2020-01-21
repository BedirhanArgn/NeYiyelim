using Neyiyelim.Context;
using Neyiyelim.Models;
using Neyiyelim.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Neyiyelim.Controllers
{

    public class ReceiptController : Controller
    {
        // GET: Receipt
        //restorantSehir rc = new restorantSehir();
        RestorantContext context = new RestorantContext();[HttpGet]
        public ActionResult Index(string ad)
        {
            var deger = context.Receipts.Where(i => i.ReceiptName == ad).FirstOrDefault();

            return View(deger);
        }

        //[HttpPost]
        //public ActionResult Index(string ad)
        //{
        //    var deger = context.Receipts.Where(i => i.ReceiptName == ad).FirstOrDefault();

        //    return View(deger);
        //}

    }
}