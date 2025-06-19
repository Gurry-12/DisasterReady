using DisasterReady.Domain.Entities;
using DisasterReady.Shared.Enums;

namespace DisasterReady.Application.Services.AbstractServices
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> GetUsersByRoleAsync(UserRoleEnum role);
        Task<User> CreateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
        Task<User?> UpdateUserAsync(User user);
    }
} 