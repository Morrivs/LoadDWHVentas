using System;
using System.Collections.Generic;

namespace LoadDWHVentas.Data.Models.sales;

public partial class DimDate
{
    public int DateKey { get; set; }

    public int DateOrder { get; set; }

    public DateOnly? Date { get; set; }

    public int? Month { get; set; }

    public int? Year { get; set; }
}
