using DomainLayer.Entities;
using ServiceLayer.DTOs;

namespace ServiceLayer.Interfaces
{
    public interface IUserDataService
    {
        Task CreateUser(UserDTO user);
   
    }
}
