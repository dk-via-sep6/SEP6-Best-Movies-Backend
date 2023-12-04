using DomainLayer.Entities;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUser(UserDomain user);
        Task<UserDomain> GetUserById(string id);
        Task UpdateUser(UserDomain user);
        Task DeleteUser(string id);
    }
}
