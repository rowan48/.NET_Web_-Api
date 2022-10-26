using DataCon;
using Unit.Contracts;

namespace Unit.Classes
{
    public class AUnitOfWork : IUnitOfWork
    {

        private readonly DataContext _Conext;

        public AUnitOfWork(DataContext dataContext)
        {
            _Conext = dataContext;

        }

        public int Complete()
        {
            return _Conext.SaveChanges();
        }

        public void Dispose()
        {
            _Conext.Dispose();
        }
    }
}
