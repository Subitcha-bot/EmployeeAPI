using MyEmployeeApplication.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyEmployeeApplication.IService
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<IEnumerable<Employee>> SearchEmployee(string name, Gender? gender);
        Task RemoveEmployee(int id);
    }
}
