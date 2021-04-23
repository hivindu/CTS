using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CovidTracing.API.Entities;

namespace CovidTracing.API.Data
{
    public class CovidTracingAPIDBContext : DbContext
    {
        public CovidTracingAPIDBContext (DbContextOptions<CovidTracingAPIDBContext> options)
            : base(options)
        {
        }

        public DbSet<CovidTracing.API.Entities.Citizen> Citizen { get; set; }

        public DbSet<CovidTracing.API.Entities.CDC> CDC { get; set; }

        public DbSet<CovidTracing.API.Entities.PHI> PHI { get; set; }

        public DbSet<CovidTracing.API.Entities.TravelLog> TravelLog { get; set; }

        public DbSet<CovidTracing.API.Entities.Shop> Shop { get; set; }

        public DbSet<CovidTracing.API.Entities.PCR> PCR { get; set; }
    }
}
