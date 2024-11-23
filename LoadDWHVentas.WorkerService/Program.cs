using LoadDWHVentas.Data.Context;
using LoadDWHVentas.Data.Interfaces;
using LoadDWHVentas.Data.Services;
using LoadDWHVentas.WorkerService;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                // Configuraci�n de DbContext para NorthwindContext
                services.AddDbContext<NorthwindContext>(options =>
                    options.UseSqlServer(hostContext.Configuration.GetConnectionString("DbNorthwind")));

                // Configuraci�n de DbContext para DbSalesContext
                services.AddDbContext<DbSalesContext>(options =>
                    options.UseSqlServer(hostContext.Configuration.GetConnectionString("DbSales")));

                // Registrar el servicio IDataServiceDwVentas
                services.AddScoped<IDataServiceDwVentas, DataServiceDwVentas>();

                // Registrar el Worker Service
                services.AddHostedService<Worker>();
            });
}
