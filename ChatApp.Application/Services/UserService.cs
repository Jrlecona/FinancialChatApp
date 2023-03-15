using AutoMapper;
using ChatApp.Application.DTOs;
using ChatApp.Application.Interfaces;
using ChatApp.Domain.Entities;
using ChatApp.Domain.Interfaces;

namespace ChatApp.Application.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDTO> Authenticate(string username, string password)
    {
        var user = await _userRepository.GetByUserNameAndPassword(username, password);

        if (user == null)
        {
            return null;
        }

        return new UserDTO
        {
            Id = user.Id,
            UserName = user.Username,
            Email = user.Email
        };
    }

    public async Task<UserDTO> GetByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return _mapper.Map<UserDTO>(user);
    }

    public async Task<List<UserDTO>> GetUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<List<UserDTO>>(users);
    }

    //public async Task<UserDTO> GetByUsernameAsync(string username)
    //{
    //    var user = await _userRepository.GetByUsernameAsync(username);
    //    return _mapper.Map<UserDTO>(user);
    //}

    public async Task<List<UserDTO>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<List<UserDTO>>(users);
    }

    public async Task AddAsync(UserDTO user)
    {
        var newUser = _mapper.Map<User>(user);
        await _userRepository.AddAsync(newUser);
    }

    public async Task UpdateAsync(UserDTO user)
    {
        var updatedUser = _mapper.Map<User>(user);
        await _userRepository.UpdateAsync(updatedUser);
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
        {
            throw new Exception($"User with id {id} not found.");
        }

        await _userRepository.DeleteAsync(id);
    }
}