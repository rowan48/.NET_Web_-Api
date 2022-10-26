using DataCon;
using Models;
using Repository.Contracts;
using Unit.Classes;

namespace Repository.Classes
{
    public class UserRepository : GenericRepository, IUserRepository
    {
        protected DataContext _context { get; set; }

        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        UserDTO IUserRepository.getMyinfo(int id)
        {
            UserDTO userDTO =
(from user in _context.User

 where user.UserId == id
 select new UserDTO
 {

     UserId = user.UserId,
     Email = user.Email,
     Name = user.Name,


 }).FirstOrDefault();
            return userDTO;
        }
    }
}
