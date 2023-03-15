using ChatApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Interfaces
{
    public interface IChatService
    {
        Task<List<ChatRoomDTO>> GetChatRoomsAsync();
        Task<List<MessageDTO>> GetLast50MessagesAsync(Guid chatRoomId);
        Task AddMessageAsync(Guid senderId, Guid chatRoomId, string text);
    }
}
