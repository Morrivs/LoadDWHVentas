using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadDWHVentas.Data.Entities.DwVentas;
using Microsoft.EntityFrameworkCore;

namespace LoadDWHVentas.Data.Context
{
    public class DbSalesContext : DbContext
    {
        public DbSalesContext(DbContextOptions<DbSalesContext> options) : base(options)
        {

        }

        public DbSet<DimCustomer> DimCustomer { get; set; }
        public DbSet<DimDate> DimDate { get; set; }
        public DbSet<DimEmployees> DimEmployees { get; set; }
        public DbSet<DimProductoCategory> DimProductoCategory { get; set; }
        public DbSet<DimTransportista> DimTransportista { get; set; }
        public DbSet<FactOrder> FactOrders { get; set; }
        public DbSet<FactClienteAtendido> FactClientAtendido { get; set; }
    }
}
