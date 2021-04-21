using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CovidTracing.API.Entities
{
    public class TravelLog
    {
        [Key]
        public int Id { get; set; }
        public int CID { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}
