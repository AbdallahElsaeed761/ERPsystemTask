using AutoMapper;
using ERPsystem.BL.Dtos;
using ERPsystem.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem.BL.Configration
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>()
               //.ForMember(vm => vm.DepartmentId, m => m.MapFrom(u => u.Department.DepartmentId))
               .ForMember(vm => vm.DeptName, m => m.MapFrom(u => u.Department.DeptName)).ReverseMap()
               .ForMember(m => m.Department, m => m.Ignore());

            CreateMap<Department, DepartmentDto>().ReverseMap();


        }
    }
}
