using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyEmployeeApplication.Model
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        public int EmployeeAge { get; set; }
        public Gender Gender { get; set; }
        [ForeignKey("Department")]
        public int Department_Id { get; set; }
        public virtual Department Department { get; set; }
    }
    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
