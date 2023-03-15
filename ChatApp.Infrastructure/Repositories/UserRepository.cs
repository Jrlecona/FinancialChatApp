using ChatApp.Domain.Entities;
using ChatApp.Domain.Interfaces;
using ChatApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IChatDbContext _context;

    public UserRepository(IChatDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByUserNameAndPassword(string username, string password)
    {
        return await Task.FromResult(_context.Users.FirstOrDefault(u => u.Username == username && u.Password == password));
    }
    
    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u!.Id == id);
    }

    public async Task<List<User?>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task AddAsync(User? user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task UpdateAsync(User? user)
    {
        _context.Users.Update(user);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await GetByIdAsync(id);
        if (user != null) _context.Users.Remove(user);
    }
}