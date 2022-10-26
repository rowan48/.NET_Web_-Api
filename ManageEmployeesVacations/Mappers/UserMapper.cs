using Models;

namespace Mappers
{
    public class UserMapper : IUserMapper
    {
        public User ConvertUserDTOToUser(UserDTO userDTO)
        {
            User user = new User();
            user.UserId = userDTO.UserId;
            user.Password = userDTO.Password;
            user.CreatedDate = userDTO.CreatedDate;
            user.Email = userDTO.Email;
            return user;
        }

        public UserDTO ConvertUserToUserDTO(User user)
        {

            UserDTO userdto = new UserDTO();
            userdto.UserId = user.UserId;
            userdto.Email = user.Email;
            userdto.CreatedDate = user.CreatedDate;
            userdto.Password = user.Password;

            return userdto;
        }
    }

}



