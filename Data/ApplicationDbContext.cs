using Microsoft.EntityFrameworkCore;
using MyEmployeeApplication.Model;
using MyEmployeeApplication.Service;
using System;

namespace MyEmployeeApplication.Data
{
    public class ApplicationDBContext : DbContext

    {
        public ApplicationDBContext()
        {

        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 1, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 2, DepartmentName = "Sales" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 3, DepartmentName = "Production" });

            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 101, FirstName = "Nick", LastName = "Jones", EmployeeAge = 27, Gender = Gender.Male, Department_Id = 1, DateOfBirth = new DateTime(1995, 10, 21),Email= "NickJones@gmail.com" });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 102, FirstName = "Daniel", LastName = "Thomphson", EmployeeAge = 36, Gender = Gender.Male, Department_Id = 3, DateOfBirth = new DateTime(1986, 11, 09),Email = "DanielThompson@gmail.com" });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 103, FirstName = "Susan", LastName = "Bradford", EmployeeAge = 31, Gender = Gender.Female, Department_Id = 3, DateOfBirth = new DateTime(1991, 08, 14),Email = "SusanBradford@gmail.com" });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 104, FirstName = "Roseline ", LastName = "Esther", EmployeeAge = 28, Gender = Gender.Female, Department_Id = 2, DateOfBirth = new DateTime(1994, 05, 04),Email = "RoselineEsther@gmail.com" });


        }

    }


}

