using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDWHVentas.Data.Entities.DwVentas
{
    public class DimEmployees
    {
        [Key]
        public int EmployeeKey { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
    }
}
