using DisasterReady.Shared.Enums;

namespace DisasterReady.Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public UserRoleEnum Role { get; set; }
        public bool IsSubscribedToAlerts { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateUserDto
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public UserRoleEnum Role { get; set; } = UserRoleEnum.User;
        public bool IsSubscribedToAlerts { get; set; } = true;
    }

    public class UpdateUserDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public UserRoleEnum Role { get; set; }
        public bool IsSubscribedToAlerts { get; set; }
    }
} 