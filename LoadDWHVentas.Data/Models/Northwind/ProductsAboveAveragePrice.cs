using System;
using System.Collections.Generic;

namespace LoadDWHVentas.Data.Models.Northwind;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; }

    public decimal? UnitPrice { get; set; }
}
