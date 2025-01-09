using Microsoft.AspNetCore.Mvc;
using Northwind_API.Entities;
using Northwind_API.Models;
using Northwind_API.Repository;
using Northwind_API.UnitOfWork;

namespace Northwind_API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly NorthwindContext _context;
        private readonly IUnitOfWorkNorthwind _unitOfWorkNorthwind;
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeController()
        {
            _context = new NorthwindContext();
            _unitOfWorkNorthwind = new UnitOfWorkSQLServerNorthwind(_context);
            _employeeRepository = _unitOfWorkNorthwind.EmployeesRepository;
        }

        [HttpGet("/allEmployees")]
        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync()
        {
            IList<Employee> lst = await _employeeRepository.GetAllAsync();
            return lst.Select(e => EmployeeToDTO(e)).ToList();
        }

        [HttpGet("/employee/{id}")]
        public async Task<IActionResult> GetEmployeeAsync(int id)
        {
            Employee emp = await _employeeRepository.GetByIdAsync(id);
            if(emp == null) return NotFound();
            return Ok(EmployeeToDTO(emp));
        }

        [HttpPost("/addEmployee")]
        public async Task AddEmployeeAsync(EmployeeDTO employeeDTO)
        {
            // assure that id is not set to avoid error with autoincrement in database
            employeeDTO.EmployeeID = 0;
            Employee e = DTOToEmployee(employeeDTO);
            await _unitOfWorkNorthwind.EmployeesRepository.InsertAsync(e);

        }

        [HttpPut("/updateEmployee")]
        public async Task UpdateEmployeeAsync(EmployeeDTO employee)
        {
            Employee e = DTOToEmployee(employee);
            await _unitOfWorkNorthwind.EmployeesRepository.SaveAsync(e, e => e.EmployeeId == e.EmployeeId);
        }

        [HttpDelete("/deleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync(int id)
        {
            Employee emp = await _employeeRepository.GetByIdAsync(id);
            if(emp == null) return NotFound();
            await _employeeRepository.DeleteAsync(emp);
            return Ok(emp);
        }

        private static EmployeeDTO EmployeeToDTO(Employee emp) =>
           new EmployeeDTO
           {
               EmployeeID = emp.EmployeeId,
               LastName = emp.LastName,
               FirstName = emp.FirstName,    
               Title = emp.Title,
               TitleOfCourtesy = emp.TitleOfCourtesy

           };

        private static Employee DTOToEmployee(EmployeeDTO emp) =>
            new Employee
            {
                EmployeeId = emp.EmployeeID,
                LastName = emp.LastName,
                FirstName = emp.FirstName,
                Title = emp.Title,
                TitleOfCourtesy = emp.TitleOfCourtesy
            };

    }
}


