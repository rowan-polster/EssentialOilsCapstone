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
        public DbSet<Property> Treatment { get; set; }
        public DbSet<OilProperty> OilTreatment { get; set; }
        public OilDbContext(DbContextOptions<OilDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OilProperty>().HasKey(ot => new { ot.OilId, ot.TreatmentId });

            base.OnModelCreating(modelBuilder);
        }

    }
}