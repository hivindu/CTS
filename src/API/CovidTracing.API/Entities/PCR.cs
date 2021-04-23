﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracing.API.Entities
{
    public class PCR
    {
        [Key]
        public int Id { get; set; }
        public int CID { get; set; }
        public DateTime dateTime { get; set; }
        [DefaultValue(0)]
        public int Status { get; set; }
    }
}
