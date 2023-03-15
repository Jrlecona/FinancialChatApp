using ChatApp.Domain.Entities;

namespace ChatApp.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);

    Task<User?> GetByUserNameAndPassword(string username, string password);
    Task<List<User?>> GetAllAsync();
    Task AddAsync(User? user);
    Task UpdateAsync(User? user);
    Task DeleteAsync(Guid userId);
}