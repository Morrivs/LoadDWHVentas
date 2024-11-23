using System;
using System.Collections.Generic;

namespace LoadDWHVentas.Data.Models.sales;

public partial class DimEmployee
{
    public int EmployeeKey { get; set; }

    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; }
}
