using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Neyiyelim.Models
{
    public class Register
    {
        [Required]
        [Key]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Adsoyad { get; set; }
        public string Password { get; set; }
        public string Telefon { get; set; }
    }
}