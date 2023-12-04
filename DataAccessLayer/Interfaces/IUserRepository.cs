using DomainLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IUserRepository
    {

        public Task CreateUser(UserDomain user);
    }
}
