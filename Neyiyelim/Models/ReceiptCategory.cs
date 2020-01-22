using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Neyiyelim.Models
{
    public class ReceiptCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public List<Receipts> receipts { get; set; }


    }
}