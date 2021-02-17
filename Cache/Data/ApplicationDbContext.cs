using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Cache.Models;

namespace Cache.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cache.Models.Firearm> Firearm { get; set; }
        
        public DbSet<Cache.Models.CaliberGauge> CaliberGauge { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Firearm>().ToTable("Firearm");
            modelBuilder.Entity<CaliberGauge>().ToTable("CaliberGauge");

            modelBuilder.Entity<Firearm>()
                .HasOne(d => d.CaliberGauge)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
