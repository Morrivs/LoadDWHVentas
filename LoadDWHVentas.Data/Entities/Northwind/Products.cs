using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDWHVentas.Data.Entities.Northwind
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public string? QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public string? UnitsInStock { get; set; }
        public string? ReorderLevel { get; set; }
        public bool? Discontinued { get; set; }
    }
}
