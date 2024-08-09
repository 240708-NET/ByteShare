using ByteShare.Application.Repository;
using ByteShare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ByteShare.Infrastructure.Persistence.Repository;

public class UserRepository : GenericRepository<User, int?>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context) {}

    public async Task<User?> GetUserByUsernamePassword(string username, string password)
    {
        return await dbSet
                .Where(u => u.Username.Equals(username) && u.Password.Equals(password))
                .SingleOrDefaultAsync();
    }
}
