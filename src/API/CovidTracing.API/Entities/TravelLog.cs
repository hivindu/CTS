using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CovidTracing.API.Entities
{
    public class TravelLog
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Citizen")]
        public int CID { get; set; }
        [ForeignKey("Shop")]
        public int SID { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}
