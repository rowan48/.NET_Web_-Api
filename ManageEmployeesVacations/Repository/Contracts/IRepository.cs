namespace Repository.Contracts
{
    public interface IRepository<T>
    {
        IEnumerable<T> FindAll();

        IEnumerable<T> FindByCondition(int id);

        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
