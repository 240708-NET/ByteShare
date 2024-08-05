using ByteShare.Application.Common.Interface;
using ByteShare.Domain.Entities;

namespace ByteShare.Application.Repository;

public interface IUserRepository
{
    Task<User?> GetUser(int id);
    Task<int> CreateUser(User user);
    Task<ICollection<User>> GetAllUsers();
}
