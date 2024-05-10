using Frist_API_Project.Models;
using System.Linq.Expressions;

namespace Frist_API_Project.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAll();
        Task<T> Get(Expression<Func<T, bool>> filter, bool tracking = false);

        Task Add(T entity);
        void Delete(T entity);

        Task Save();
    }
}
