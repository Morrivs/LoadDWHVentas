using LoadDWHVentas.Data.Entities.Northwind;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDWHVentas.Data.Context
{
    public class NorthwindContext:DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options) { 
            
        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Shippers> Shippers { get; set; }
        public DbSet<VwVenta> VwVentas { get; set; }
        public DbSet<VwServedCustomer> VwServedCustomer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VwServedCustomer>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("VW_ServedCustomers", "DWH");
            }
            );
            modelBuilder.Entity<VwVenta>(entity=>
            {
                entity
                    .HasNoKey()
                    .ToView("VWVentas", "DWH");
            }
            );
        }
    }
}


