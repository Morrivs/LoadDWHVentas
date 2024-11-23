using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDWHVentas.Data.Entities.DwVentas
{
    public class DimDate
    {
        [Key]
        public int DateKey { get; set; }
        public int DateOrder { get; set; }
        public DateTime Date { get; set; }
        public string? DateName{ get; set; }
        public int Month{ get; set; }
        public string? MonthName{ get; set; }
        public int Year{ get; set; }
        public string? YearName { get; set; }
    }
}
