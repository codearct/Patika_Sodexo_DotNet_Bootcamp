using GCS.Domain.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Repository.Concrete.EntityFramework
{
    public class GarbageCollectionSystemDbContext:DbContext
    {
        public GarbageCollectionSystemDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Container> Containers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Container>().Property(c => c.Latitude).HasColumnType("decimal(10, 6)");
            modelBuilder.Entity<Container>().Property(c => c.Longitude).HasColumnType("decimal(10, 6)");
            base.OnModelCreating(modelBuilder);
        }
    }
}

