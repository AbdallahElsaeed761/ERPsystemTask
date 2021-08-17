using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem.BL.Dtos
{
    public class DepartmentDto
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Please enter Valid name min 2 Letters and max 50 letters")]

        public string DeptName { get; set; }
    }
}
