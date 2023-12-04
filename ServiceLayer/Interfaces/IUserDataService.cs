using ServiceLayer.DTOs;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IUserDataService
    {
        Task CreateUser(UserDTO user);
        Task<UserDTO> GetUserById(string id);
        Task UpdateUser(UserDTO user);
        Task DeleteUser(string id);
    }
}
