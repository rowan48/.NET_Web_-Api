using Mappers;
using Models;
using Repository.Contracts;
using Services.Contracts;
using Unit.Contracts;

namespace Services.Classes
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUserMapper _userMapper;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IUserMapper userMapper)
        {
            _repository = userRepository;
            _unitOfWork = unitOfWork;
            _userMapper = userMapper;
        }
        UserDTO IUserService.GetById(int id)
        {
            return _repository.getMyinfo(id);
        }
    }
}
