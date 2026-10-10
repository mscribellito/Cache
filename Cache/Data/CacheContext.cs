using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cache.Models;

namespace Cache.Data
{
    public class CacheContext : DbContext
    {
        public CacheContext(DbContextOptions<CacheContext> options)
            : base(options)
        {
        }

        public DbSet<Cache.Models.Firearm> Firearm { get; set; } = default!;
        public DbSet<Cache.Models.CaliberGauge> CaliberGauge { get; set; } = default!;
    }
}
