﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDWHVentas.Data.Entities.Northwind
{
    public class VwServedCustomer
    {
        public int EmployeeID { get; set; }
        public string? EmployeeName { get; set; }
        public int TotalCustomersServed { get; set; }
    }
}
