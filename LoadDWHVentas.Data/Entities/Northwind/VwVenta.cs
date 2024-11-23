using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDWHVentas.Data.Entities.Northwind
{
    public class VwVenta
    {
        public string? CustomerID { get; set; }
        public string? CustomerName { get; set; }
        public int EmployeeID { get; set; }
        public string? EmployeeName { get; set; }
        public int ShipperID { get; set; }
        public string? CompanyName { get; set; }
        public string? City { get; set; }
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public int? DateKey { get; set; }
        public int? Año { get; set; }
        public int? Mes { get; set; }
        public decimal? TotalVentas { get; set; }
        public int? Cantidad { get; set; }


    }
}
