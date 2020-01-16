using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Neyiyelim.Models
{
    public class Restorant
    {

        [Key]
        public int Id { get; set; }
        public String RestoranName { get; set; }
        
        public int CityId { get; set; }
        public City city { get; set; }
    }
}