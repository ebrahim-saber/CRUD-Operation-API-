using Frist_API_Project.Data;
using Frist_API_Project.Models;
using Frist_API_Project.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Frist_API_Project.Repository
{
    public class Repository<T> :IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            this._db = db;
            dbSet =_db.Set<T>();
        }

        public async Task Add(T t)
        {
            await dbSet.AddAsync(t);
            await Save();
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter, bool tracking = false)
        {
            //AsQueryable() يعني بيحتفظ ب الموظفين  في الميموري ك جملة كويري او جملة select وف الاخر بيرجعها 

            IQueryable<T> query = dbSet;
            if (tracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task<List<T>> GetAll()
        {
            return await dbSet.ToListAsync(); ;
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter)
        {
            var list = await dbSet.Where(filter).ToListAsync();
            return list;
        }
        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
        public async void Delete(T t)
        {
            dbSet.Remove(t);
            await Save();
        }
    }
}
