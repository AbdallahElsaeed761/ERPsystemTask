using AutoMapper;
using ERPsystem.BL.Bases;
using ERPsystem.BL.Dtos;
using ERPsystem.BL.Interfaces;
using ERPsystem.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem.BL.AppServices
{
   public class DepartmentAppService:AppServiceBase
    {
        public DepartmentAppService(IUnitOfWork theunitOfWork,IMapper mapper):base(theunitOfWork,mapper)
        {

        }

        #region CURD
           
        public List<DepartmentDto> GetAllDepartments()
        {
            return Mapper.Map<List<DepartmentDto>>(TheUnitOfWork.Department.GetAllDepartment());
        }

        public DepartmentDto GetDepartment(int id)
        {
            return Mapper.Map<DepartmentDto>(TheUnitOfWork.Department.GetById(id));
        }
        public bool SaveNewDepartment(DepartmentDto departmentDto)
        {
            if (departmentDto==null)
            {
                throw new ArgumentNullException();
            }
            bool result = false;
            var department = Mapper.Map<Department>(departmentDto);
            if (TheUnitOfWork.Department.InsertDepartment(department))
            {
                result = TheUnitOfWork.Commit()> new int();
            }
            return result;
        }

        public bool UpdateDepartment(DepartmentDto departmentDto)
        {
            var department = Mapper.Map<Department>(departmentDto);
            TheUnitOfWork.Department.Update(department);
            TheUnitOfWork.Commit();

            return true;
        }

        public bool DeleteDepartment(int id)
        {
            bool result = false;

            TheUnitOfWork.Department.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckDepartmentExists(DepartmentDto departmentDto)
        {
            Department department = Mapper.Map<Department>(departmentDto);
            return TheUnitOfWork.Department.CheckDepartmentExists(department);
        }

        #endregion
    }
}
