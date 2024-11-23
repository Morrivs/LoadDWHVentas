using System;
using System.Collections.Generic;

namespace LoadDWHVentas.Data.Models.sales;

public partial class DimCustomer
{
    public int CustomerKey { get; set; }

    public string CustomerId { get; set; }

    public string CustomerName { get; set; }
}
