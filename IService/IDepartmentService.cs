using MyEmployeeApplication.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEmployeeApplication.IService
{
    
        public interface IDepartmentService
        {
        Task<IEnumerable<Department>> GetDepartments();
        //Task<IQueryable<Department>> GetDepartments();
        //IEnumerable<Department> GetDepartments();
        Task<Department> GetDepartmentById(int departmentId);
            Task<Department> CreateDepartment(Department department);
            Task<Department> UpdateDepartment(Department department);
            Task DeleteDepartment(int departmentId);
        }
    
}
