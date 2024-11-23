using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDWHVentas.Data.Entities.DwVentas
{
    public class FactClienteAtendido
    {
        [Key]
        public int ClienteAtendidoId { get; set; }
        public int EmployeeKey { get; set; }
        public int? TotalCustomersServed { get; set; }
    }
}
