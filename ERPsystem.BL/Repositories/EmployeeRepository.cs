using ERPsystem.BL.Bases;
using ERPsystem.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem.BL.Repositories
{
    public class EmployeeRepository:BaseRepository<Employee>
    {
        private  DbContext dbContext;

        public EmployeeRepository(DbContext dbContext ):base(dbContext)
        {
            this.dbContext = dbContext;
        }
        #region CRUB

        public List<Employee> GetAllEmployee()
        {
            return GetAll().ToList();
        }

        public bool InsertEmployee(Employee employee)
        {
            return Insert(employee);
        }
        public void UpdateEmployee(Employee employee)
        {
            Update(employee);
        }
        public void DeleteEmployee(int id)
        {
            Delete(id);
        }

        public bool CheckEmployeeExists(Employee employee)
        {
            return GetAny(l => l.EmployeeId == employee.EmployeeId);
        }
        public Employee GetEmployeeById(int id)
        {
            return GetFirstOrDefault(l => l.EmployeeId == id);
        }
        #endregion
    }
}
