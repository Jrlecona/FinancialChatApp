using ChatApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infrastructure.Interfaces;

public interface IChatDbContext
{
    DbSet<User?> Users { get; set; }
    DbSet<ChatRoom> ChatRooms { get; set; }
    DbSet<Message> Messages { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    Task<int> SaveChangesAsync();
}