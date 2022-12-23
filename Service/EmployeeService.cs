using Microsoft.EntityFrameworkCore;
using MyEmployeeApplication.Data;
using MyEmployeeApplication.IService;
using MyEmployeeApplication.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEmployeeApplication.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDBContext _context;

        public EmployeeService(ApplicationDBContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            if (employee.Department != null)
            {
                _context.Entry(employee.Department).State = EntityState.Unchanged;
            }

            var result = await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees.Include(e => e.Department).FirstOrDefaultAsync(e => e.EmployeeId == id);

        }


        public async Task RemoveEmployee(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Employee>> SearchEmployee(string Name, Gender? gender)
        {
            IQueryable<Employee> query = _context.Employees;

            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(e => e.FirstName.Contains(Name) || e.LastName.Contains(Name));
            }
            if (gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }
            return await query.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);
            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.DateOfBirth = employee.DateOfBirth;
                result.Department_Id = employee.Department_Id;
                result.EmployeeAge = employee.EmployeeAge;
                result.Gender = employee.Gender;
                result.Email = employee.Email;

                _context.Employees.Update(result);
                await _context.SaveChangesAsync();
                return result;
            }
            else
                return null;
        }
    }
}

