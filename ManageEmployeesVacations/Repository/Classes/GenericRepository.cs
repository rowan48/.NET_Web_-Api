using DataCon;
using Repository.Contracts;

namespace Unit.Classes
{
    public class GenericRepository : IGenericRepository
    {
        protected DataContext _Context;


        public GenericRepository(
            DataContext context)
        {
            _Context = context;

        }

    }
}
