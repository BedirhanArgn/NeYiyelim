using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Neyiyelim.Models
{
    public class IndexPage
    {
        [Key]
        public int Id { get; set; }
        public string anasayfabaslik  { get; set; }
        public string anasayfaicerik { get; set; }
        public string anasayfaresimUrl { get; set; }
        
        public string receiptbaslik { get; set; }
        public string receipicerik { get; set; }
        public string receiptfoto { get; set; }
        public string ReceiptIntegredients { get; set; }
    }
}