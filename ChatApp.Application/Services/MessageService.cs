using AutoMapper;
using ChatApp.Application.DTOs;
using ChatApp.Application.Interfaces;
using ChatApp.Domain.Entities;
using ChatApp.Domain.Interfaces;

namespace ChatApp.Application.Services;

public class MessageService : IMessageService
{
    private readonly IMapper _mapper;
    private readonly IMessageRepository _messageRepository;

    public MessageService(IMessageRepository messageRepository, IMapper mapper)
    {
        _messageRepository = messageRepository;
        _mapper = mapper;
    }

    //public async Task<MessageDTO> GetByIdAsync(Guid id)
    //{
    //    var message = await _messageRepository.GetByIdAsync(id);
    //    return _mapper.Map<MessageDTO>(message);
    //}

    public async Task<List<MessageDTO>> GetLast50Async(Guid chatRoomId)
    {
        var messages = await _messageRepository.GetLast50Async(chatRoomId);
        return _mapper.Map<List<MessageDTO>>(messages);
    }

    public async Task<List<MessageDTO>> GetBySenderIdAsync(Guid senderId, Guid chatRoomId)
    {
        var messages = await _messageRepository.GetBySenderIdAsync(senderId, chatRoomId);
        return _mapper.Map<List<MessageDTO>>(messages);
    }

    public async Task AddAsync(MessageDTO message)
    {
        var messageEntity = _mapper.Map<Message>(message);
        await _messageRepository.AddAsync(messageEntity);
    }
}