using System;
using System.Collections.Generic;

namespace LoadDWHVentas.WorkerService.Models;

public partial class VwServedCustomer
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public int? TotalCustomersServed { get; set; }
}
