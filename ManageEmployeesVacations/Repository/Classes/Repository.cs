using DataCon;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;

namespace Repository.Classes
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DataContext _context { get; set; }
        public Repository(DataContext Context)
        {
            _context = Context;
        }



        public void Create(T entity) => _context.Set<T>().Add(entity);
        public void Update(T entity) => _context.Set<T>().Update(entity);
        //public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public IEnumerable<T> FindAll()
        {
            return _context.Set<T>()
            .AsNoTracking();
        }



        public IEnumerable<T> FindByCondition(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
