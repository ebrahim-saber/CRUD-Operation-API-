using Frist_API_Project.Models;
using System.Linq.Expressions;

namespace Frist_API_Project.Repository.IRepository
{
    public interface IEmployeeRepository :IRepository<Employee>
    {
        void Update(Employee employee);

    }
}
