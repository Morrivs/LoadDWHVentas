using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDWHVentas.Models.Models
{
    public class VwServedCustomer
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public int? TotalCustomersServed { get; set; }
    }
}
