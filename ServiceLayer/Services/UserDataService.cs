using DomainLayer.Entities;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;
using DataAccessLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly IUserRepository _userRepository;
        public UserDataService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public Task<UserDomain> CreateUser(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
