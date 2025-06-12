using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterReady.Domain.Entities
{
    public class Checklist
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DisasterTypeId { get; set; }
        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public User User { get; set; } = null!;
        public DisasterType DisasterType { get; set; } = null!;
        public ICollection<ChecklistItem> Items { get; set; } = new List<ChecklistItem>();
    }

}
