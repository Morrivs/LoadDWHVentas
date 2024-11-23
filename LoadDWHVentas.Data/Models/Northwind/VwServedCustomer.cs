using System;
using System.Collections.Generic;

namespace LoadDWHVentas.Data.Models.Northwind;

public partial class VwServedCustomer
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; }

    public int? TotalCustomersServed { get; set; }
}
