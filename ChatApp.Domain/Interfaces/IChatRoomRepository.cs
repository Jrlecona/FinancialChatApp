using ChatApp.Domain.Entities;

namespace ChatApp.Domain.Interfaces;

public interface IChatRoomRepository
{
    Task<ChatRoom> GetByIdAsync(Guid id);
    Task<IEnumerable<ChatRoom>> GetAllAsync();
    Task AddAsync(ChatRoom chatRoom);
    Task UpdateAsync(ChatRoom chatRoom);
    Task DeleteAsync(Guid id);
}