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
    public class EmployeeAppService:AppServiceBase
    {
        public EmployeeAppService(IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }

        #region CURD

        public List<EmployeeDto> GetAllEmployees()
        {

            return Mapper.Map<List<EmployeeDto>>(TheUnitOfWork.Employee.GetAllEmployee());
        }
        public EmployeeDto GetEmployee(int id)
        {
            return Mapper.Map<EmployeeDto>(TheUnitOfWork.Employee.GetById(id));
        }



        public Employee SaveNewEmployee(EmployeeDto employeeDto)
        {
            if (employeeDto == null)

                throw new ArgumentNullException();

            bool result = false;
            var employee = Mapper.Map<Employee>(employeeDto);
            if (TheUnitOfWork.Employee.Insert(employee))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return employee;
        }


        public bool UpdateEmployee(EmployeeDto employeeDto)
        {
            var employee = Mapper.Map<Employee>(employeeDto);
            TheUnitOfWork.Employee.Update(employee);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteEmployee(int id)
        {
            bool result = false;

            TheUnitOfWork.Employee.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckEmployeeExists(EmployeeDto employeeDto)
        {
            Employee employee = Mapper.Map<Employee>(employeeDto);
            return TheUnitOfWork.Employee.CheckEmployeeExists(employee);
        }
        #endregion
    }
}
