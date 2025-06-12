using DisasterReady.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterReady.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string FullName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public UserRoleEnum Role { get; set; } 
        public bool IsSubscribedToAlerts { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public Household? Household { get; set; }
        public ICollection<Checklist> Checklists { get; set; } = new List<Checklist>();
    }

}
