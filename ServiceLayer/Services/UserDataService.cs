using DomainLayer.Entities;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;
using DataAccessLayer.Interfaces;
using AutoMapper;

namespace ServiceLayer.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        public UserDataService(IMapper mapper, IUserRepository userRepository) {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task CreateUser(UserDTO user)
        {
            var userData = _mapper.Map<UserDomain>(user);
           await _userRepository.CreateUser(userData);
        }

  
    }
}
