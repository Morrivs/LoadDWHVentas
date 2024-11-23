using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LoadDWHVentas.Data.Models.sales;

public partial class DbSalesContext : DbContext
{
    public DbSalesContext()
    {
    }

    public DbSalesContext(DbContextOptions<DbSalesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DimCustomer> DimCustomers { get; set; }

    public virtual DbSet<DimDate> DimDates { get; set; }

    public virtual DbSet<DimEmployee> DimEmployees { get; set; }

    public virtual DbSet<DimProductoCategory> DimProductoCategories { get; set; }

    public virtual DbSet<DimTransportistum> DimTransportista { get; set; }

    public virtual DbSet<FactClientAtendido> FactClientAtendidos { get; set; }

    public virtual DbSet<FactOrder> FactOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-VT50INI\\SQLEXPRESS;Database=DWVENTAS;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DimCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerKey);

            entity.ToTable("DimCustomer");

            entity.Property(e => e.CustomerId)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("CustomerID");
            entity.Property(e => e.CustomerName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<DimDate>(entity =>
        {
            entity.HasKey(e => e.DateKey);

            entity.ToTable("DimDate");

            entity.HasIndex(e => new { e.DateKey, e.Month, e.Year }, "NonClusteredIndex_Date");
        });

        modelBuilder.Entity<DimEmployee>(entity =>
        {
            entity.HasKey(e => e.EmployeeKey);

            entity.HasIndex(e => e.EmployeeName, "NonClusteredIndex_Employees");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.EmployeeName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<DimProductoCategory>(entity =>
        {
            entity.HasKey(e => e.ProductKey);

            entity.ToTable("DimProductoCategory");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<DimTransportistum>(entity =>
        {
            entity.HasKey(e => e.ShipperKey);

            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.ShipperId).HasColumnName("ShipperID");
        });

        modelBuilder.Entity<FactClientAtendido>(entity =>
        {
            entity.HasKey(e => e.ClienteAtendidoId);

            entity.ToTable("FactClientAtendido");

            entity.HasIndex(e => new { e.ClienteAtendidoId, e.EmployeeKey }, "NonClusteredIndex_ClientAtendido");
        });

        modelBuilder.Entity<FactOrder>(entity =>
        {
            entity.HasKey(e => e.OrderNumber);

            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TotalVentas).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
