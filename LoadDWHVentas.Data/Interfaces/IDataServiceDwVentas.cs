using LoadDWHVentas.Data.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDWHVentas.Data.Interfaces
{
    public interface IDataServiceDwVentas
    {
        Task<OperationResult> LoadDWH();
    }
}
