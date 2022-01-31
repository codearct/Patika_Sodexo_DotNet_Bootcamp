using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ExchangeRateDbContext:DbContext
    {
        public ExchangeRateDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().Property(c => c.Purchase).HasColumnType("decimal(8, 6)");
            modelBuilder.Entity<Currency>().Property(c => c.Sale).HasColumnType("decimal(8, 6)");
            base.OnModelCreating(modelBuilder);
        }
    }
}
