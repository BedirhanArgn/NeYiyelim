using Neyiyelim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Neyiyelim.ViewModel
{
    public class restorantSehir
    {
        public IEnumerable<Restorant> restorants { get; set; }
        public IEnumerable<City> cities { get; set; }
        public IEnumerable<Receipts> receipts { get; set; }

        public IEnumerable<ReceiptCategory> receiptCategories { get; set; }
    }
}