using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem.DAL.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        
        [StringLength(50,MinimumLength =2,ErrorMessage ="Please enter valid name min 2 Letters and max 50 letters")]
        public string FName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Please enter valid name min 2 Letters and max 50 letters")]

        public string LName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Please enter valid Address min 2 Letters and max 50 letters")]

        public string Address { get; set; }
        [Range(2000,10000,ErrorMessage = "Please enter valid Salary between 2000 and 10000")]
        
        public double  Salary { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
