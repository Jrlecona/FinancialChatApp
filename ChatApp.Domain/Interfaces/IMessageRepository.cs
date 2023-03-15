using ChatApp.Domain.Entities;

namespace ChatApp.Domain.Interfaces;

public interface IMessageRepository
{
    //Task<Message> GetByIdAsync(Guid id);
    Task<List<Message>> GetLast50Async(Guid id);
    Task<List<Message>> GetBySenderIdAsync(Guid senderId, Guid chatRoomId);
    Task AddAsync(Message message);
}