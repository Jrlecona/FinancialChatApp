using AutoMapper;
using ChatApp.Application.DTOs;
using ChatApp.Application.Interfaces;
using ChatApp.Domain.Entities;
using ChatApp.Domain.Interfaces;

namespace ChatApp.Application.Services;

public class ChatService : IChatService
{
    private readonly IChatRoomRepository _chatRoomRepository;
    private readonly IMapper _mapper;
    private readonly IMessageRepository _messageRepository;
    private readonly IUserRepository _userRepository;

    public ChatService(IUserRepository userRepository, IChatRoomRepository chatRoomRepository,
        IMessageRepository messageRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _chatRoomRepository = chatRoomRepository;
        _messageRepository = messageRepository;
        _mapper = mapper;
    }
    
    public async Task<List<ChatRoomDTO>> GetChatRoomsAsync()
    {
        var chatRooms = await _chatRoomRepository.GetAllAsync();
        return _mapper.Map<List<ChatRoomDTO>>(chatRooms);
    }

    public async Task<List<MessageDTO>> GetLast50MessagesAsync(Guid chatRoomId)
    {
        var messages = await _messageRepository.GetLast50Async(chatRoomId);
        return _mapper.Map<List<MessageDTO>>(messages);
    }

    public async Task<List<MessageDTO>> GetMessagesBySenderIdAsync(Guid senderId, Guid chatRoomId)
    {
        var messages = await _messageRepository.GetBySenderIdAsync(senderId, chatRoomId);
        return _mapper.Map<List<MessageDTO>>(messages);
    }

    public async Task AddMessageAsync(Guid senderId, Guid chatRoomId, string text)
    {
        //var sender = await _userRepository.GetByIdAsync(senderId);
        //var chatRoom = await _chatRoomRepository.GetByIdAsync(chatRoomId);

        var message = new Message
        {
            SenderId = senderId,
            ChatRoomId = chatRoomId,
            Text = text,
            SentAt = DateTime.UtcNow
        };

        await _messageRepository.AddAsync(message);
    }
}
