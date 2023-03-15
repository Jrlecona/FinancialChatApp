using AutoMapper;
using ChatApp.Application.DTOs;
using ChatApp.Application.Interfaces;
using ChatApp.Domain.Entities;
using ChatApp.Domain.Interfaces;

namespace ChatApp.Application.Services;

public class ChatRoomService : IChatRoomService
{
    private readonly IChatRoomRepository _chatRoomRepository;
    private readonly IMapper _mapper;

    public ChatRoomService(IChatRoomRepository chatRoomRepository, IMapper mapper)
    {
        _chatRoomRepository = chatRoomRepository;
        _mapper = mapper;
    }

    public async Task<ChatRoomDTO> GetByIdAsync(Guid id)
    {
        var chatRoom = await _chatRoomRepository.GetByIdAsync(id);
        return _mapper.Map<ChatRoomDTO>(chatRoom);
    }

    public async Task<List<ChatRoomDTO>> GetAllAsync()
    {
        var chatRooms = await _chatRoomRepository.GetAllAsync();
        return _mapper.Map<List<ChatRoomDTO>>(chatRooms);
    }

    public async Task AddAsync(ChatRoomDTO chatRoom)
    {
        var chatRoomEntity = _mapper.Map<ChatRoom>(chatRoom);
        await _chatRoomRepository.AddAsync(chatRoomEntity);
    }

    public async Task UpdateAsync(ChatRoomDTO chatRoom)
    {
        var chatRoomEntity = _mapper.Map<ChatRoom>(chatRoom);
        await _chatRoomRepository.UpdateAsync(chatRoomEntity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _chatRoomRepository.DeleteAsync(id);
    }

    //public async Task<List<UserDTO>> GetUsersAsync(Guid chatRoomId)
    //{
    //    var users = await _chatRoomRepository.GetUsersAsync(chatRoomId);
    //    return _mapper.Map<List<UserDTO>>(users);
    //}

    //public async Task AddUserAsync(Guid chatRoomId, Guid userId)
    //{
    //    await _chatRoomRepository.AddUserAsync(chatRoomId, userId);
    //}

    //public async Task RemoveUserAsync(Guid chatRoomId, Guid userId)
    //{
    //    await _chatRoomRepository.RemoveUserAsync(chatRoomId, userId);
    //}
}