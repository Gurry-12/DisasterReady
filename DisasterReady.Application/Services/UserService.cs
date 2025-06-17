using DisasterReady.Application.Interfaces;
using DisasterReady.Domain.Entities;
using DisasterReady.Persistence.Interfaces;
using DisasterReady.Shared.Enums;

namespace DisasterReady.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _unitOfWork.Users.GetByEmailAsync(email);
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(UserRoleEnum role)
        {
            return await _unitOfWork.Users.GetByRoleAsync(role);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var createdUser = await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return createdUser;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null) return false;
            _unitOfWork.Users.Delete(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<User?> UpdateUserAsync(User user)
        {
            var existing = await _unitOfWork.Users.GetByIdAsync(user.Id);
            if (existing == null) return null;
            existing.FullName = user.FullName;
            existing.Location = user.Location;
            existing.Role = user.Role;
            existing.IsSubscribedToAlerts = user.IsSubscribedToAlerts;
            // Add more fields as needed
            _unitOfWork.Users.Update(existing);
            await _unitOfWork.SaveChangesAsync();
            return existing;
        }
    }
} 