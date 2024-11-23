using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDWHVentas.Data.Entities.DwVentas
{
    public class DimCustomer
    {
        [Key]
        public int CustomerKey { get; set; }
        public string CustomerName { get; set; }
        public string CustomerID { get; set; }
    }
}
