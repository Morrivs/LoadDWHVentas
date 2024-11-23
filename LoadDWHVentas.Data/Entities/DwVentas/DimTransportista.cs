using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDWHVentas.Data.Entities.DwVentas
{
    public class DimTransportista
    {
        [Key]
        public int ShipperKey { get; set; }
        public int ShipperID { get; set; }
        public string? CompanyName { get; set; }
    }
}
