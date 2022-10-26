namespace Unit.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();


    }
}
