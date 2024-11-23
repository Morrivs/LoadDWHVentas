using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDWHVentas.Data.Entities.Northwind
{
    public class Shippers
    {
        [Key]
        public int ShipperID { get; set; }
        public string? CompanyName { get; set; }
        public string? Phone { get; set; }
    }
}
