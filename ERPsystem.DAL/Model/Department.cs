using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem.DAL.Model
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Please enter Valid name min 2 Letters and max 50 letters")]

        public string DeptName { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}
