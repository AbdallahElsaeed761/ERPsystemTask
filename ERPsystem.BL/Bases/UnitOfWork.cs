using ERPsystem.BL.Interfaces;
using ERPsystem.BL.Repositories;
using ERPsystem.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem.BL.Bases
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Common Properties
        private DbContext EC_DbContext { get; set; }
        


        #endregion

        #region Constructors
        public UnitOfWork(ApplicationDbContext EC_DbContext)
        {
            
            this.EC_DbContext = EC_DbContext;//


            // Avoid load navigation properties
            //EC_DbContext.Configuration.LazyLoadingEnabled = false;
        }
        #endregion
        public EmployeeRepository employee;// => throw new NotImplementedException();
        public EmployeeRepository Employee
        {
            get
            {
                if (employee == null)
                    employee = new EmployeeRepository(EC_DbContext);
                return employee;
            }
        }

        public DepartmentRepository department;// => throw new NotImplementedException();
        public DepartmentRepository Department
        {
            get
            {
                if (department==null)
                
                    department = new DepartmentRepository(EC_DbContext);

                return department;
            }
        }

       
        #region Methods
        public int Commit()
        {
            return EC_DbContext.SaveChanges();
        }

        public void Dispose()
        {
            EC_DbContext.Dispose();
        }
        #endregion
    }
}
