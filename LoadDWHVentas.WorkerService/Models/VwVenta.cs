using System;
using System.Collections.Generic;

namespace LoadDWHVentas.WorkerService.Models;

public partial class VwVenta
{
    public string CustomerId { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public int ShipperId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? City { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int? DateKey { get; set; }

    public int? Año { get; set; }

    public int? Mes { get; set; }

    public decimal? TotalVentas { get; set; }

    public int? Cantidad { get; set; }
}
