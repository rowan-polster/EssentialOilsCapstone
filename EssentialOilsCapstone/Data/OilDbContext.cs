using EssentialOilsCapstone.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EssentialOilsCapstone.Data
{
    public class OilDbContext : DbContext
    {
        public DbSet<Oil> EssentialOils { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<OilProperty> OilProperty { get; set; }
        public OilDbContext(DbContextOptions<OilDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OilProperty>().HasKey(ot => new { ot.OilId, ot.PropertyId });

            base.OnModelCreating(modelBuilder);
        }

    }
}