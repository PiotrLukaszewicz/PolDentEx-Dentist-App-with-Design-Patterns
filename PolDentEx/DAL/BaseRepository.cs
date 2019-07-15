using System.Data.Entity;
using System.Linq;

namespace PolDentEx.DAL
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
        void Save();
    }

    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IDbSet<T> _dbSet;

        protected BaseRepository()
        {
            _dbSet = DbContext.Instance.ApplicationDbContext.Set<T>();
        }

        public abstract IQueryable<T> GetAll();

        public void Insert(T obj)
        {

            _dbSet.Add(obj);
        }

        public void Update(T obj)
        {
            DbContext.Instance.ApplicationDbContext.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(T obj)
        {
            _dbSet.Remove(obj);
        }

        public void Save()
        {
            DbContext.Instance.ApplicationDbContext.SaveChanges();
        }
    }
}