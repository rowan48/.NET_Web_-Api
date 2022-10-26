using Models;

namespace Repository.Contracts
{
    public interface IUserRepository
    {
        UserDTO getMyinfo(int id);
    }
}
