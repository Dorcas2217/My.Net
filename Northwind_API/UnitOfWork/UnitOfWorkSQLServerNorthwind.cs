using Northwind_API.Entities;
using Northwind_API.Repository;

namespace Northwind_API.UnitOfWork
{
    public class UnitOfWorkSQLServerNorthwind  : IUnitOfWorkNorthwind
    {
        private readonly NorthwindContext _context;
        private BaseRepositorySQL<Employee> _employeeRepository;
        private BaseRepositorySQL<Order> _orderRepository;

        public UnitOfWorkSQLServerNorthwind(NorthwindContext context)
        {
            this._context = context;
            this._employeeRepository = new BaseRepositorySQL<Employee>(context);
            this._orderRepository = new BaseRepositorySQL<Order>(context);
        }

        public IRepository<Employee> EmployeesRepository
        {
            get { return this._employeeRepository; }
        }

        public IRepository<Order> OrderRepository
        {
            get { return this._orderRepository; }
        }
    }
}


