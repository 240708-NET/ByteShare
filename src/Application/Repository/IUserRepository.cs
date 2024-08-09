using ByteShare.Domain.Entities;

namespace ByteShare.Application.Repository;

public interface IUserRepository : IRepository<User, int?>
{
    Task<User?> GetUserByUsernamePassword(string username, string password);
}
