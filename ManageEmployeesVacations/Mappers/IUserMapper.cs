using Models;

namespace Mappers
{
    public interface IUserMapper
    {
        public UserDTO ConvertUserToUserDTO(User user);
        public User ConvertUserDTOToUser(UserDTO userDTO);
    }
}
