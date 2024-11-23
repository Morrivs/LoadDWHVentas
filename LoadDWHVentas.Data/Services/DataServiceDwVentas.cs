using LoadDWHVentas.Data.Context;
using LoadDWHVentas.Data.Entities.DwVentas;
using LoadDWHVentas.Data.Interfaces;
using LoadDWHVentas.Data.Result;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LoadDWHVentas.Data.Services
{
    public class DataServiceDwVentas: IDataServiceDwVentas
    {
        private readonly NorthwindContext _northwindContext;
        private readonly DbSalesContext _salesContext;

        public DataServiceDwVentas(NorthwindContext northwindContext, DbSalesContext salesContext)
        {
            _northwindContext = northwindContext;
            _salesContext = salesContext;
        }

        public async Task<OperationResult> LoadDWH()
        {
            OperationResult result = new OperationResult();
            try
            {

                // Limpia las tablas antes de cargar los datos
                await ClearDimEmployees();
                await ClearDimProductCategory();
                await ClearDimCustomers();
                await ClearDimTransportista();

                await LoadDimEmployees();
                await LoadDimProductCategory();
                await LoadDimCustomers();
                //await LoadDimDate();
                await LoadDimTransportista();
                await LoadFactSales();
                await LoadFactCustomerServed(); 
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error cargando el DWH Ventas{ex.Message}";
            }
            return result;
        }
        private async Task<OperationResult> LoadDimEmployees() { 
            OperationResult result = new OperationResult();
            try
            {
                var employees = await _northwindContext.Employees.AsNoTracking().Select(emp => new DimEmployees()
                {
                    EmployeeID = emp.EmployeeID,
                    EmployeeName = string.Concat(emp.FirstName, " ", emp.LastName)
                }).ToListAsync();

                await _salesContext.DimEmployees.AddRangeAsync(employees);
                await _salesContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error cargando la dimension de empleado{ex.Message}";
            }
            return result;
        }
        private async Task<OperationResult> LoadDimProductCategory() {
            OperationResult result = new OperationResult();
            try
            {
                var productCategories = await (from product in _northwindContext.Products
                                         join category in _northwindContext.Categories on product.CategoryID equals category.CategoryID
                                         select new DimProductoCategory()
                                         {
                                             CategoryID = category.CategoryID,
                                             ProductName = product.ProductName,
                                             CategoryName = category.CategoryName,
                                             ProductID = product.ProductID,
                                         }).AsNoTracking().ToListAsync();

                await _salesContext.DimProductoCategory.AddRangeAsync(productCategories);
                await _salesContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error cargando la dimension de productoy categoria. {ex.Message}";
            }
            return result;
        }
        private async Task<OperationResult> LoadDimCustomers() {
            OperationResult result = new OperationResult() { Success=false};
            try
            {
                var customers = await _northwindContext.Customers.AsNoTracking().Select(cust => new DimCustomer()
                {
                    CustomerID = cust.CustomerID,
                    CustomerName = cust.CompanyName,
                }).AsNoTracking().ToListAsync();

                await _salesContext.DimCustomer.AddRangeAsync(customers);
                await _salesContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error cargando la dimension de empleado{ex.Message}";
            }
            return result;
        }
        //private async Task<OperationResult> LoadDimDate() { }
        private async Task<OperationResult> LoadDimTransportista() {
            OperationResult result = new OperationResult();
            try
            {
                var shippers = await _northwindContext.Shippers.Select(ship => new DimTransportista()
                {
                    ShipperID = ship.ShipperID,
                    CompanyName = ship.CompanyName,
                }).ToListAsync();

                await _salesContext.DimTransportista.AddRangeAsync(shippers);
                await _salesContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success=false;
                result.Message = $"Error cargando la dimension de transportistas {ex.Message}";
            }
            return result;
        }

        //private async Task<OperationResult> LoadFactSales()
        //{
        //    OperationResult result = new OperationResult();

        //    try
        //    {
        //        var ventas = await _northwindContext.VwVentas.AsNoTracking().ToListAsync();
        //    }
        //    catch(Exception ex)
        //    {
        //        result.Success = false;
        //        result.Message = $"Error cargando el fact de ventas {ex.Message}";
        //    }
        //    return result;
        //}

        //private async Task<OperationResult> LoadFactCustomerServed()
        //{
        //    OperationResult result = new OperationResult();

        //    try
        //    {
        //        var customerServed = await _northwindContext.VwServedCustomer.AsNoTracking().ToListAsync();
        //    }catch(Exception ex)
        //    {
        //        result.Success = false;
        //        result.Message = $"Error cargando el fact de clientes atendidos {ex.Message}";
        //    }
        //    return result;
        //}

        private async Task<OperationResult> LoadFactSales()
        {
            OperationResult result = new OperationResult();

            try
            {
                var ventas = await _northwindContext.VwVentas.AsNoTracking().ToListAsync();


                int[] ordersId = await _salesContext.FactOrders.Select(cd => cd.OrderNumber).ToArrayAsync();

                if (ordersId.Any())
                {
                    await _salesContext.FactOrders.Where(cd => ordersId.Contains(cd.OrderNumber))
                                                  .AsNoTracking()
                                                  .ExecuteDeleteAsync();
                }

                foreach (var venta in ventas)
                {
                    var customer = await _salesContext.DimCustomer.SingleOrDefaultAsync(cust => cust.CustomerID == venta.CustomerID);
                    var employee = await _salesContext.DimEmployees.SingleOrDefaultAsync(emp => emp.EmployeeID == venta.EmployeeID);
                    var shipper = await _salesContext.DimTransportista.SingleOrDefaultAsync(ship => ship.ShipperID == venta.ShipperID);
                    var product = await _salesContext.DimProductoCategory.SingleOrDefaultAsync(pro => pro.ProductID == venta.ProductID);

                    FactOrder factOrder = new FactOrder()
                    {
                        CantidadVentas = venta.Cantidad.Value,
                        City = venta.City,
                        CustomerKey = customer.CustomerKey,
                        EmployeeKey = employee.EmployeeKey,
                        DateKey = venta.DateKey.Value,
                        ProductKey = product.ProductKey,
                        ShipperKey = shipper.ShipperKey,
                        TotalVentas = Convert.ToDecimal(venta.TotalVentas)
                    };

                    await _salesContext.FactOrders.AddAsync(factOrder);

                    await _salesContext.SaveChangesAsync();
                }



                result.Success = true;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error cargando el fact de ventas {ex.Message} ";
            }

            return result;
        }

        private async Task<OperationResult> LoadFactCustomerServed()
        {
            OperationResult result = new OperationResult() { Success = true };

            try
            {
                // Cargar los clientes atendidos desde la vista
                var customerServeds = await _northwindContext.VwServedCustomer
                                                             .AsNoTracking()
                                                             .ToListAsync();

                // Obtener los IDs de clientes atendidos actuales
                var customerIds = await _salesContext.FactClientAtendido
                                                     .Select(cli => cli.ClienteAtendidoId)
                                                     .ToListAsync();

                // Limpiar la tabla si hay datos
                if (customerIds.Any())
                {
                    _salesContext.FactClientAtendido.RemoveRange(
                        _salesContext.FactClientAtendido.Where(cli => customerIds.Contains(cli.ClienteAtendidoId))
                    );
                    await _salesContext.SaveChangesAsync(); // Guardar eliminación
                }

                // Pre-cargar empleados en memoria para evitar múltiples consultas
                var employeeIds = customerServeds.Select(c => c.EmployeeID).Distinct().ToList();
                var employees = await _salesContext.DimEmployees
                                                   .Where(emp => employeeIds.Contains(emp.EmployeeID))
                                                   .ToDictionaryAsync(emp => emp.EmployeeID, emp => emp);

                // Crear las entidades de FactClientAtendido
                var factsToAdd = new List<FactClienteAtendido>();
                foreach (var customer in customerServeds)
                {
                    if (employees.TryGetValue(customer.EmployeeID, out var employee))
                    {
                        factsToAdd.Add(new FactClienteAtendido
                        {
                            EmployeeKey = employee.EmployeeKey,
                            TotalCustomersServed = customer.TotalCustomersServed
                        });
                    }
                }

                // Agregar todos los registros en una sola operación
                if (factsToAdd.Any())
                {
                    await _salesContext.FactClientAtendido.AddRangeAsync(factsToAdd);
                    await _salesContext.SaveChangesAsync(); // Guardar inserciones
                }

                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error cargando el fact de clientes atendidos: {ex.Message}";
            }

            return result;
        }




        private async Task ClearDimEmployees()
        {
            _salesContext.DimEmployees.RemoveRange(_salesContext.DimEmployees);
            await _salesContext.SaveChangesAsync();
        }

        private async Task ClearDimProductCategory()
        {
            _salesContext.DimProductoCategory.RemoveRange(_salesContext.DimProductoCategory);
            await _salesContext.SaveChangesAsync();
        }

        private async Task ClearDimCustomers()
        {
            _salesContext.DimCustomer.RemoveRange(_salesContext.DimCustomer);
            await _salesContext.SaveChangesAsync();
        }

        private async Task ClearDimTransportista()
        {
            _salesContext.DimTransportista.RemoveRange(_salesContext.DimTransportista);
            await _salesContext.SaveChangesAsync();
        }

    }
}
