using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracing.API.Entities
{
    public class Citizen
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string NIC { get; set; }

        public string Address { get; set; }

        public string Proffession { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

        public string Affiliation { get; set; }

        public string Password { get; set; }

        public int HealthStatus { get; set; }

        public double Latitude { get; set; }

        public double Longtitude { get; set; }
    }
}
