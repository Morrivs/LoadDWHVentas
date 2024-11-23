using System;
using System.Collections.Generic;

namespace LoadDWHVentas.Data.Models.sales;

public partial class FactOrder
{
    public int OrderNumber { get; set; }

    public int DateKey { get; set; }

    public int ProductKey { get; set; }

    public int CustomerKey { get; set; }

    public int ShipperKey { get; set; }

    public int EmployeeKey { get; set; }

    public string City { get; set; }

    public decimal TotalVentas { get; set; }

    public int CantidadVentas { get; set; }
}
