using ChatApp.Application.DTOs;
using ChatApp.Domain.Interfaces;

namespace ChatApp.Application.Interfaces;

public interface IUserService
{
    Task<UserDTO> Authenticate(string username, string password);
    Task<List<UserDTO>> GetUsersAsync();
    Task<UserDTO> GetByIdAsync(Guid id);
    //Task<UserDTO> GetByUsernameAsync(string username);
    Task<List<UserDTO>> GetAllAsync();
    Task AddAsync(UserDTO user);
    Task UpdateAsync(UserDTO user);
    Task DeleteAsync(Guid id);
}