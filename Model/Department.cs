using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyEmployeeApplication.Model
{
    public class Department
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]

        public int DepartmentId { get; set; }
        [StringLength(20)]
        public string DepartmentName { get; set; }

       
    }
}
