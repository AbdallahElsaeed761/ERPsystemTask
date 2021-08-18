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
   public class DepartmentRepository:BaseRepository<Department>
    {
        private  DbContext dbContext;

        public DepartmentRepository(DbContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }
        #region CRUB

        public List<Department> GetAllDepartment()
        {
            return GetAll().ToList();
        }

        public bool InsertDepartment(Department department)
        {
            return Insert(department);
        }
        public void UpdateDepartment(Department department)
        {
            Update(department);
        }
        public void DeleteDepartment(int id)
        {
            Delete(id);
        }

        public bool CheckDepartmentExists(Department department)
        {
            return GetAny(l => l.DepartmentId == department.DepartmentId);
        }
        public Department GetODepartmentById(int id)
        {
            return GetFirstOrDefault(l => l.DepartmentId == id);
        }
        #endregion
        public override int CountEntity()
        {
            return DbSet.Count();
        }
    }
}
