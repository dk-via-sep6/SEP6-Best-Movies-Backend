using DataAccessLayer.DbContextFolder;
using DataAccessLayer.Interfaces;
using DomainLayer.Entities;


namespace DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context; // Add this line

        // Inject AppDbContext into the repository
        public UserRepository(AppDbContext context)
        {
            _context = context; // Initialize the _context field
        }

        public async Task CreateUser(UserDomain user)
        {
            _context.Users.Add(user); // Add the user to the DbSet
            await _context.SaveChangesAsync(); // Save changes to the database

            // You can remove the console write lines if they were just for testing
        }
    }
}
