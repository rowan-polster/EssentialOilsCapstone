using EssentialOilCapstone.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EssentialOilCapstone.Data
{
    public class OilDbContext : DbContext
    {
        public DbSet<Oil> EssentialOils { get; set; }
        public DbSet<Treatment> Treatment { get; set; }
        public DbSet<OilTreatment> OilTreatment { get; set; }
        public OilDbContext(DbContextOptions<OilDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OilTreatment>().HasKey(ot => new { ot.OilId, ot.TreatmentId });

            base.OnModelCreating(modelBuilder);
        }

    }
}