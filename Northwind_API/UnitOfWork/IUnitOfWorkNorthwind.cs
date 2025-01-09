using Northwind_API.Entities;
using Northwind_API.Repository;


namespace Northwind_API.UnitOfWork
{
    public interface IUnitOfWorkNorthwind
    {
        IRepository<Employee> EmployeesRepository { get; }
        IRepository<Order> OrderRepository { get; }


    }
}


