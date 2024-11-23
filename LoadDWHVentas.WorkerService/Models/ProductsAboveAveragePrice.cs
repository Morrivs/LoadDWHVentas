using System;
using System.Collections.Generic;

namespace LoadDWHVentas.WorkerService.Models;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
