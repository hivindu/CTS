using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracing.API.Entities
{
    public class CDC
    {
        [Required]
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string NIC { get; set; }

        public string Password { get; set; }
    }
}
