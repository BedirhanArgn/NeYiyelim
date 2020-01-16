using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Neyiyelim.Models
{
    public class Receipts
    {
        [Key]
        public int ReceiptId { get; set; }
        public string  ReceiptName { get; set; }
        public string ReceiptInfo { get; set; }
         public string ReceiptIntegredients { get; set; }
        public DateTime ReceiptTarih { get; set; }
        public string ReceiptUrl { get; set; }
        public int ReceiptCategoryId { get; set; }




    }
}