using ChatApp.Application.DTOs;

namespace ChatApp.Application.Interfaces;

public interface IMessageService
{

    //Task<MessageDTO> GetByIdAsync(Guid id);
    Task<List<MessageDTO>> GetLast50Async(Guid chatRoomId);
    Task<List<MessageDTO>> GetBySenderIdAsync(Guid senderId, Guid chatRoomId);
    Task AddAsync(MessageDTO message);

    //Task<List<MessageDTO>> GetLast50MessagesAsync(Guid chatRoomId);
    //Task<List<MessageDTO>> GetMessagesBySenderIdAsync(Guid senderId, Guid chatRoomId);
    //Task AddMessageAsync(MessageDTO message, Guid chatRoomId);
    //Task<List<UserDTO>> GetUsersByChatRoomIdAsync(Guid chatRoomId);
    //Task JoinChatRoomAsync(Guid userId, Guid chatRoomId);
    //Task LeaveChatRoomAsync(Guid userId, Guid chatRoomId);
    //Task<List<ChatRoomDTO>> GetAllChatRoomsAsync();
    //Task<ChatRoomDTO> GetChatRoomByIdAsync(Guid id);
    //Task AddChatRoomAsync(ChatRoomDTO chatRoom);
    //Task UpdateChatRoomAsync(ChatRoomDTO chatRoom);
    //Task DeleteChatRoomAsync(Guid id);
}