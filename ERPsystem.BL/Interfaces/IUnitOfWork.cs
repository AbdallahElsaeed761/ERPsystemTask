using ERPsystem.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem.BL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        #region Method
        int Commit();
        #endregion

        EmployeeRepository Employee { get; }
        DepartmentRepository Department { get; }
        

    }
}
