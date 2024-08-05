using ByteShare.Application.Common.Interface;
using ByteShare.Application.Repository;
using ByteShare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ByteShare.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly IApplicationDbContext _context;

    public UserRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateUser(User user)
    {
        _context.Users.Add(user);
        int id = await _context.SaveChangesAsync();
        return id;
    }

    public async Task<ICollection<User>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetUser(int id)
    {
        return await _context.Users.FindAsync(id);
    }
}
