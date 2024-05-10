using Frist_API_Project.Data;
using Frist_API_Project.Models;
using Frist_API_Project.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Frist_API_Project.Repository
{
    public class EmployeeRepository :Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db) :base(db)
        {
            this._db = db;
        }
        public void Update(Employee employee)
        {
            employee.UpdateDate = DateTime.Now;
            _db.Employees.Update(employee);
            _db.SaveChanges();
        }
    }
}
