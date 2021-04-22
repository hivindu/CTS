using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracing.API.Entities
{
    public class Shop
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public int Contact { get; set; }
        public string Latitude { get; set; }
        public string Longtitude { get; set; }
        public int Status { get; set; }
        public string BrNumber { get; set; }
    }
}
