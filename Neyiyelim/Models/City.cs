using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Neyiyelim.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public String CityName { get; set; }

        List<Restorant> Restorants { get; set; }
    }
}