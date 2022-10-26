using Models;

namespace Services.Contracts
{
    public interface IUserService
    {
        UserDTO GetById(int id);
    }
}
