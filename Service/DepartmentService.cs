using Microsoft.EntityFrameworkCore;
using MyEmployeeApplication.Data;
using MyEmployeeApplication.IService;
using MyEmployeeApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyEmployeeApplication.Service
{
    
        public class DepartmentService : IDepartmentService
    {
            private readonly ApplicationDBContext _context;
            public DepartmentService(ApplicationDBContext context)
            {
                _context = context;

            }
            public async Task<Department> CreateDepartment(Department department)
            {
                var result = await _context.Departments.AddAsync(department);
                await _context.SaveChangesAsync();
                return result.Entity;
            }

            public async Task DeleteDepartment(int departmentId)
            {
                var result = await _context.Departments.FirstOrDefaultAsync(e => e.DepartmentId == departmentId);
            if (result != null)
            {
                _context.Departments.Remove(result);
                await _context.SaveChangesAsync();
            }
          
            
            }

            public async Task<Department> GetDepartmentById(int departmentId)
            {
                return await _context.Departments.
                    FirstOrDefaultAsync(e => e.DepartmentId == departmentId);
            }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();            
        }        

        public async Task<Department> UpdateDepartment(Department department)
            {
                var depart = await _context.Departments.FirstOrDefaultAsync(e => e.DepartmentId == department.DepartmentId);
                if (depart != null)
                {                    
                    depart.DepartmentName = department.DepartmentName;
                    _context.Departments.Update(depart);
                    _context.SaveChanges();
                    return depart;
                }
                return null;
            }
        }
    }

