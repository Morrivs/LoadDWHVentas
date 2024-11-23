using System;
using System.Collections.Generic;

namespace LoadDWHVentas.Data.Models.sales;

public partial class DimTransportistum
{
    public int ShipperKey { get; set; }

    public int ShipperId { get; set; }

    public string CompanyName { get; set; }
}
