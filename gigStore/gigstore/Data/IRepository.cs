using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace gigstore.Data
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(string key);
        bool Delete(T entity);
        void Add(T entity);
        void Update(T entity);

    }

    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void Add(T entity)
        {
            _dbContext.Add<T>(entity);
        }

        public bool Delete(T entity)
        {

            return true;
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();

        }

        public T GetById(string key)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
