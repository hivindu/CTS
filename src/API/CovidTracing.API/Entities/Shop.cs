using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracing.API.Entities
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        public string ShopName { get; set; }
        public int Contact { get; set; }
        public string Latitude { get; set; }
        public string Longtitude { get; set; }
        [DefaultValue(0)]
        public int Status { get; set; }
        public string BrNumber { get; set; }
    }
}
