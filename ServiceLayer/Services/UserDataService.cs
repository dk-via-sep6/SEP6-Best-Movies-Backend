using AutoMapper;
using DataAccessLayer.Interfaces;
using DomainLayer.Entities;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserDataService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task CreateUser(UserDTO user)
        {
            var userDomain = _mapper.Map<UserDomain>(user);
            await _userRepository.CreateUser(userDomain);
        }

        public async Task<UserDTO> GetUserById(string id)
        {
            var userDomain = await _userRepository.GetUserById(id);
            if(userDomain == null)
            {
                return null;
            }
            var userDTO = _mapper.Map<UserDTO>(userDomain);
            return userDTO;
        }

        public async Task UpdateUser(UserDTO user)
        {
            var userDomain = _mapper.Map<UserDomain>(user);
            await _userRepository.UpdateUser(userDomain);
        }

        public async Task DeleteUser(string id)
        {
            await _userRepository.DeleteUser(id);
        }
    }
}
