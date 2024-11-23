using System;
using System.Collections.Generic;

namespace LoadDWHVentas.Data.Models.sales;

public partial class FactClientAtendido
{
    public int ClienteAtendidoId { get; set; }

    public int EmployeeKey { get; set; }

    public int TotalCliente { get; set; }
}
