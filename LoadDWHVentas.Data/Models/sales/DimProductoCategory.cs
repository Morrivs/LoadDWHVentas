using System;
using System.Collections.Generic;

namespace LoadDWHVentas.Data.Models.sales;

public partial class DimProductoCategory
{
    public int ProductKey { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public int CategoryId { get; set; }

    public string CategoryName { get; set; }
}
