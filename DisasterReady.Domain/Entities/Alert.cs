using DisasterReady.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterReady.Domain.Entities
{
    public class Alert
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Message { get; set; } = null!;
        public SeverityLevelEnum SeverityLevel { get; set; }
        public RegionEnum Region { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiresAt { get; set; }
        public string Source { get; set; } = "System";

        // Foreign Keys
        public int DisasterTypeId { get; set; }
        
        // Navigation Properties
        public DisasterType DisasterType { get; set; } = null!;
    }
}
