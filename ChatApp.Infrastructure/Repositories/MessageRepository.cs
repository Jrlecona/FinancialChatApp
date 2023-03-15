using ChatApp.Domain.Entities;
using ChatApp.Domain.Interfaces;
using ChatApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infrastructure.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly IChatDbContext _context;

    public MessageRepository(IChatDbContext context)
    {
        _context = context;
    }

    public async Task<List<Message>> GetBySenderIdAsync(Guid senderId, Guid chatRoomId)
    {
        return await _context.Messages
            .Where(m => m.SenderId == senderId && m.ChatRoomId == chatRoomId)
            .ToListAsync();
    }

    public async Task<List<Message>> GetLast50Async(Guid chatRoomId)
    {
        return await _context.Messages
            .Where(m => m.ChatRoomId == chatRoomId)
            .OrderByDescending(m => m.SentAt)
            .Take(50)
            .ToListAsync();
    }

    public async Task AddAsync(Message message)
    {
        await _context.Messages.AddAsync(message);
    }
}