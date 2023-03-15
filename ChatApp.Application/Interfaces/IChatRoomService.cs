using ChatApp.Application.DTOs;

namespace ChatApp.Application.Interfaces;

public interface IChatRoomService
{
    Task<ChatRoomDTO> GetByIdAsync(Guid id);
    Task<List<ChatRoomDTO>> GetAllAsync();
    Task AddAsync(ChatRoomDTO chatRoomDto);
    Task UpdateAsync(ChatRoomDTO chatRoomDto);
    Task DeleteAsync(Guid id);
}