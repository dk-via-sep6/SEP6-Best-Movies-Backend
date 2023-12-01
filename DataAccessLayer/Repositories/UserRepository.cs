using DataAccessLayer.Interfaces;
using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task CreateUser(UserDomain user)
        {
            throw new NotImplementedException();
        }
    }
}
